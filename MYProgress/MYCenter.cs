using MYProgressAdmin.Model;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace MYProgressAdmin
{
    public partial class MYCenter : Form
    {
        private bool manuallyChanged = false;
        private string ConnectionString = "";
        private DataTable taskModelTable;
        private int editedRowIndex = -1;
        private CommandModelRequest commandModelRequest;
        public MYCenter()
        {
            InitializeComponent();

            var s = SumSubarrayMins([3, 1, 2, 4]);
            foreach (ConnectionStringSettings connection in ConfigurationManager.ConnectionStrings)
            {
                // Check if the connection string is defined in the app.config
                if (!string.IsNullOrEmpty(connection.ConnectionString))
                {
                    cboConnectSource.Items.Add(connection.Name);
                }
            }
            cboConnectSource.SelectedIndex = cboConnectSource.FindStringExact("Admin");
            InitializeForm();
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Handle the click event

            MessageBox.Show("Menu item clicked!");
        }

        private void CboStatus_LostFocus(object sender, EventArgs e)
        {
            treeViewMYActions.Focus();
        }
        private void CboConnectSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectionString = cboConnectSource.SelectedItem.ToString();
            InitializeTreeViewFromDatabase();
        }

        private void treeViewMYActions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                ActionCenterData actionData = (ActionCenterData)e.Node.Tag;
                manuallyChanged = true;
                cboStatus.SelectedItem = GetActionStatusItem(actionData.Status);
                manuallyChanged = false;

                UpdateProgressBar();
            }
            treeViewMYActions.Focus();
        }
        private void TreeViewMYActions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeViewMYActions.SelectedNode?.Parent != null)
            {
                MessageBox.Show("Node clicked!");
            }
        }
        private ActionStateItem GetActionStatusItem(UserActionStatus status)
        {
            foreach (ActionStateItem item in cboStatus.Items)
            {
                if (item.Status == status)
                {
                    return item;
                }
            }
            return null;
        }

        private void treeViewMYActions_GotFocus(object sender, EventArgs e)
        {
            treeViewMYActions.SelectedNode = treeViewMYActions.SelectedNode;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!manuallyChanged)
            {
                if (treeViewMYActions.SelectedNode != null)
                {

                    if (cboStatus.SelectedItem != null && cboStatus.SelectedItem is ActionStateItem)
                    {
                        ActionStateItem selectedItem = (ActionStateItem)cboStatus.SelectedItem;
                        UpdateParentAndChildNodesStatus(treeViewMYActions.SelectedNode, selectedItem.Status);
                    }

                    UpdateProgressBar();
                }
            }
            manuallyChanged = false;
            treeViewMYActions.Focus();
        }

        private void UpdateParentAndChildNodesStatus(TreeNode node, UserActionStatus status)
        {
            ActionCenterData actionData = (ActionCenterData)node.Tag;
            UpdateActionStatusInDatabase(actionData.ActionId, status);
            node.Tag = new ActionCenterData { ActionId = actionData.ActionId, Status = status };

            if (node.Parent != null)
            {
                UpdateParentNodeStatus(node.Parent, status);
            }
            else if (node.Nodes.Count > 0)
            {
                UpdateChildNodesStatus(node.Nodes, status);
            }
        }

        private void UpdateParentNodeStatus(TreeNode parentNode, UserActionStatus status)
        {
            UserActionStatus parentStatus = CalculateParentStatus(parentNode, status);

            ActionCenterData parentActionData = (ActionCenterData)parentNode.Tag;
            parentActionData.Status = parentStatus;

            UpdateActionStatusInDatabase(parentActionData.ActionId, parentStatus);
            parentNode.Tag = new ActionCenterData { ActionId = parentActionData.ActionId, Status = parentActionData.Status };
        }

        private void UpdateChildNodesStatus(TreeNodeCollection nodes, UserActionStatus status)
        {
            foreach (TreeNode childNode in nodes)
            {
                ActionCenterData childActionData = (ActionCenterData)childNode.Tag;

                if (status == UserActionStatus.NotStarted)
                {
                    // Set all child nodes to Not Started
                    UpdateActionStatusInDatabase(childActionData.ActionId, UserActionStatus.NotStarted);
                    childNode.Tag = new ActionCenterData { ActionId = childActionData.ActionId, Status = UserActionStatus.NotStarted };
                }
                else if (status == UserActionStatus.Completed)
                {
                    // Set all child nodes to Completed
                    UpdateActionStatusInDatabase(childActionData.ActionId, UserActionStatus.Completed);
                    childNode.Tag = new ActionCenterData { ActionId = childActionData.ActionId, Status = UserActionStatus.Completed };
                }
                else if (status == UserActionStatus.InProgress)
                {
                    // Check if all child nodes have the specified status
                    bool allMatch = nodes.Cast<TreeNode>().All(n => ((ActionCenterData)n.Tag).Status == status);
                    if (allMatch)
                    {
                        // Set all child nodes to In Progress
                        UpdateActionStatusInDatabase(childActionData.ActionId, UserActionStatus.InProgress);
                        childNode.Tag = new ActionCenterData { ActionId = childActionData.ActionId, Status = UserActionStatus.InProgress };
                    }
                    else
                    {
                        // If no action is in progress and all are in not started, make the first child In Progress
                        bool anyInProgress = nodes.Cast<TreeNode>().Any(n => ((ActionCenterData)n.Tag).Status == UserActionStatus.InProgress);

                        if (!anyInProgress)
                        {
                            UpdateActionStatusInDatabase(childActionData.ActionId, UserActionStatus.InProgress);
                            childNode.Tag = new ActionCenterData { ActionId = childActionData.ActionId, Status = UserActionStatus.InProgress };
                        }
                    }
                }
            }
        }

        private UserActionStatus CalculateParentStatus(TreeNode parentNode, UserActionStatus status)
        {
            bool allMatch = parentNode.Nodes.Cast<TreeNode>().All(n => ((ActionCenterData)n.Tag).Status == status);
            bool anyNotStartedMatch = parentNode.Nodes.Cast<TreeNode>().Any(n => ((ActionCenterData)n.Tag).Status == UserActionStatus.NotStarted);
            bool anyInProgressMatch = parentNode.Nodes.Cast<TreeNode>().Any(n => ((ActionCenterData)n.Tag).Status == UserActionStatus.InProgress);
            bool anyIsCompletedMatch = parentNode.Nodes.Cast<TreeNode>().Any(n => ((ActionCenterData)n.Tag).Status == UserActionStatus.Completed);

            UserActionStatus parentStatus = UserActionStatus.NotStarted;
            if (allMatch)
            {
                parentStatus = status;
            }
            else if ((anyNotStartedMatch && anyInProgressMatch) || (anyNotStartedMatch && anyIsCompletedMatch) || (anyInProgressMatch && anyIsCompletedMatch))
            {
                parentStatus = UserActionStatus.InProgress;
            }

            return parentStatus;

        }

        private void InitializeTreeViewFromDatabase()
        {
            try
            {
                treeViewMYActions.Nodes.Clear();
                lblProgressLabel.Text = "Progress: 0% (0/0/0)";
                using (SqlConnection connection = new SqlConnection(
                   ConfigurationManager.ConnectionStrings[ConnectionString]?.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT ActionIdx, ActionName, ParentIdx, Status FROM ActionsCenter";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int actionIdx = reader.GetInt32(0);
                            string actionName = reader.GetString(1);
                            int? parentIdx = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                            string status = reader.GetString(3);

                            TreeNode actionNode = new TreeNode(actionName);
                            actionNode.Tag = new ActionCenterData { ActionId = actionIdx, Status = (UserActionStatus)Enum.Parse(typeof(UserActionStatus), status) };

                            if (parentIdx.HasValue)
                            {
                                TreeNode parentNode = FindNodeById(treeViewMYActions.Nodes, parentIdx.Value);
                                if (parentNode != null)
                                {
                                    parentNode.Nodes.Add(actionNode);
                                }
                            }
                            else
                            {
                                treeViewMYActions.Nodes.Add(actionNode);
                            }
                        }
                    }

                    if (treeViewMYActions.Nodes.Count > 0)
                    {
                        treeViewMYActions.SelectedNode = treeViewMYActions.Nodes[0];

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching actions from the database: {ex.Message}");
            }
        }

        private void UpdateActionStatusInDatabase(int actionId, UserActionStatus status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString]?.ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE ActionsCenter SET Status = @Status WHERE ActionIdx = @ActionId";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Status", status.ToString());
                    updateCommand.Parameters.AddWithValue("@ActionId", actionId);
                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating action status in the database: {ex.Message}");
            }
        }

        private TreeNode FindNodeById(TreeNodeCollection nodes, int actionId)
        {
            foreach (TreeNode node in nodes)
            {
                if (((ActionCenterData)node.Tag).ActionId == actionId)
                {
                    return node;
                }

                TreeNode foundNode = FindNodeById(node.Nodes, actionId);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }
        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            if (treeViewMYActions.SelectedNode?.Parent != null)
            {
                treeViewMYActions.SelectedNode = treeViewMYActions.Nodes[0];
            }

            AddTitleOrAction(false);

            treeViewMYActions.Focus();
        }
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if (treeViewMYActions.SelectedNode?.Parent != null)
            {
                MessageBox.Show("Select a Root Node!");
            }
            else
            {
                AddTitleOrAction(true);
            }
            treeViewMYActions.Focus();
        }

        private void AddTitleOrAction(bool blnINeedParent)
        {

            TreeNode parentNode = blnINeedParent ? treeViewMYActions.SelectedNode : null;
            string newActionName = GetInput("Enter the name of the new action:", "New Action");

            if (!string.IsNullOrEmpty(newActionName))
            {
                int? parentIdx = (blnINeedParent && parentNode != null) ? ((ActionCenterData)parentNode.Tag).ActionId : (int?)null;
                int? actionId = InsertActionIntoDatabase(newActionName, parentIdx, blnINeedParent);

                TreeNode newActionNode = new TreeNode(newActionName);
                newActionNode.Tag = new ActionCenterData { ActionId = actionId ?? -1, Status = UserActionStatus.NotStarted };

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(newActionNode);
                }
                else
                {
                    treeViewMYActions.Nodes.Add(newActionNode);
                }

                treeViewMYActions.SelectedNode = newActionNode;
                UpdateProgressBar();
            }
            else
            {
                treeViewMYActions.SelectedNode = treeViewMYActions.SelectedNode;
                treeViewMYActions.Focus();
            }
        }

        private int? InsertActionIntoDatabase(string actionName, int? parentIdx, bool isChild)
        {
            int? insertedActionIdx = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString]?.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO ActionsCenter (ActionName,  Status) VALUES (@ActionName,  @Status); SELECT SCOPE_IDENTITY()";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                            insertCommand.Parameters.AddWithValue("@ActionName", actionName);
                            //    insertCommand.Parameters.AddWithValue("@ParentIdx", parentIdx ?? (object)DBNull.Value);
                            insertCommand.Parameters.AddWithValue("@Status", UserActionStatus.NotStarted.ToString());

                            // ExecuteScalar to get the identity value immediately after the insert
                            insertedActionIdx = Convert.ToInt32(insertCommand.ExecuteScalar());

                            if (isChild && parentIdx != null && parentIdx > 0)
                            {
                                string updateQuery = "UPDATE ActionsCenter SET ParentIdx = @ParentIdx WHERE ActionIdx = @InsertedActionIdx";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                                updateCommand.Parameters.AddWithValue("@ParentIdx", parentIdx);
                                updateCommand.Parameters.AddWithValue("@InsertedActionIdx", insertedActionIdx);
                                updateCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error inserting action into the database: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
            }
            return insertedActionIdx;
        }

        private void UpdateProgressBar()
        {
            if (treeViewMYActions.SelectedNode != null)
            {
                actionsProgressBar.Visible = true;
                if (treeViewMYActions.SelectedNode.Parent == null)
                {
                    // Parent node selected
                    int totalActions = treeViewMYActions.SelectedNode.Nodes.Count;
                    int completedActions = treeViewMYActions.SelectedNode.Nodes.Cast<TreeNode>().Count(node =>
                        ((ActionCenterData)node.Tag).Status == UserActionStatus.Completed);

                    int inProgressActions = treeViewMYActions.SelectedNode.Nodes.Cast<TreeNode>().Count(node =>
                        ((ActionCenterData)node.Tag).Status == UserActionStatus.InProgress);

                    int notStartedActions = treeViewMYActions.SelectedNode.Nodes.Cast<TreeNode>().Count(node =>
                        ((ActionCenterData)node.Tag).Status == UserActionStatus.NotStarted);

                    // Calculate weighted progress
                    double weightedProgress = (completedActions * 1) + (inProgressActions * 0.5);

                    actionsProgressBar.Value = totalActions > 0 ? (int)((weightedProgress / totalActions) * 31) : 0;

                    // Update the label text
                    lblProgressLabel.Text = $"Progress: {actionsProgressBar.Value}% " +
                                            $"(Completed: {completedActions}, In Progress: {inProgressActions}, Not Started: {notStartedActions})";
                }
                else
                {
                    // Child node selected
                    actionsProgressBar.Visible = false;
                    lblProgressLabel.Text = string.Empty; // Clear the label text for child nodes
                }
            }
            else
            {
                actionsProgressBar.Visible = true;
                // No node selected, show overall completion status of parent nodes
                int totalParentNodes = treeViewMYActions.Nodes.Count;
                int completedParentNodes = treeViewMYActions.Nodes.Cast<TreeNode>().Count(node =>
                    ((ActionCenterData)node.Tag).Status == UserActionStatus.Completed);

                // Calculate weighted progress
                double weightedProgress = (completedParentNodes * 1) + ((totalParentNodes - completedParentNodes) * 0.5);

                actionsProgressBar.Value = totalParentNodes > 0 ? (int)((weightedProgress / totalParentNodes) * 31) : 0;

                // Update the label text
                lblProgressLabel.Text = $"Progress: {actionsProgressBar.Value}% " +
                                        $"(Completed: {completedParentNodes}, In Progress: {totalParentNodes - completedParentNodes}, Not Started: 0)";
            }
        }

        private string GetInput(string prompt, string title)
        {
            using (var form = new InputForm(prompt, title))
            {
                var result = form.ShowDialog();
                treeViewMYActions.SelectedNode = treeViewMYActions.SelectedNode;
                return result == DialogResult.OK ? form.InputValue : string.Empty;
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            ActionStateItem[] statusItems = {
                new ActionStateItem { Status = UserActionStatus.NotStarted, DisplayText = "Not Started" },
                new ActionStateItem { Status = UserActionStatus.InProgress, DisplayText = "In Progress" },
                new ActionStateItem { Status = UserActionStatus.Completed, DisplayText = "Completed" }
            };

            this.cboStatus.Items.AddRange(statusItems);
        }
        private void TreeViewMYActions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Node.Parent != null)
            {
                // Select the clicked node
                treeViewMYActions.SelectedNode = e.Node;

                // Show the context menu
                contextMenuStrip.Show(treeViewMYActions, e.Location);
            }
        }
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            TreeNode selectedNode = treeViewMYActions.SelectedNode;

            // Check your conditions here, and if not met, cancel the opening of the context menu
            if (selectedNode == null || selectedNode.Parent == null)
            {
                e.Cancel = true;
            }
        }


        private void DeleteActionFromDatabase(int actionId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString]?.ConnectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM ActionsCenter WHERE ActionIdx = @ActionId OR ParentIdx = @ActionId";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ActionId", actionId);
                    deleteCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting action from the database: {ex.Message}");
            }
        }

        private void DeleteSelectedNodeFromTreeView()
        {
            if (treeViewMYActions.SelectedNode != null)
            {
                ActionCenterData actionData = (ActionCenterData)treeViewMYActions.SelectedNode.Tag;

                if (treeViewMYActions.SelectedNode.Nodes.Count > 0)
                {
                    DeleteChildNodesFromDatabase(treeViewMYActions.SelectedNode);
                }

                DeleteActionFromDatabase(actionData.ActionId);

                treeViewMYActions.SelectedNode.Remove();
                UpdateProgressBar();
            }
        }

        private void DeleteChildNodesFromDatabase(TreeNode parentNode)
        {
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                ActionCenterData childActionData = (ActionCenterData)childNode.Tag;

                if (childNode.Nodes.Count > 0)
                {
                    DeleteChildNodesFromDatabase(childNode);
                }

                DeleteActionFromDatabase(childActionData.ActionId);
            }
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            DeleteSelectedNodeFromTreeView();
        }


        public int SumSubarrayMins(int[] arr)
        {
            const int MOD = 1000000007;
            int n = arr.Length;
            long result = 0;

            Stack<int> stack = new Stack<int>();
            int[] prevSmaller = new int[n];
            int[] nextSmaller = new int[n];

            // Populate prevSmaller
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[i] < arr[stack.Peek()])
                {
                    stack.Pop();
                }

                prevSmaller[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            // Clear the stack for the next traversal
            stack.Clear();

            // Populate nextSmaller
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[i] <= arr[stack.Peek()])
                {
                    stack.Pop();
                }

                nextSmaller[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            // Calculate the contribution of each element to the result
            for (int i = 0; i < n; i++)
            {
                result = (result + (long)arr[i] * (i - prevSmaller[i]) * (nextSmaller[i] - i) % MOD) % MOD;
            }

            return (int)result;
        }
        // Method to add a context menu item dynamically
        private void AddContextMenuItem(string text)
        {
            int index = contextMenuStrip.Items.Count; // Get the index based on the current count
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = $"toolStripMenuItem_{RemoveSpaces(text)}_{index}";
            toolStripMenuItem.Size = new Size(180, 38);
            toolStripMenuItem.Text = text;
            toolStripMenuItem.Click += ToolStripMenuItem_Click;

            contextMenuStrip.Items.Add(toolStripMenuItem);
        }

        // Method to remove a context menu item dynamically
        private void RemoveContextMenuItem(int index)
        {
            if (index >= 0 && index < contextMenuStrip.Items.Count)
            {
                contextMenuStrip.Items.RemoveAt(index);
            }
        }
        string RemoveSpaces(string input)
        {
            // Regular expression pattern to match one or more spaces
            string pattern = @"\s+";

            // Replace matched spaces with an empty string
            string result = Regex.Replace(input, pattern, "");

            return result;
        }


        private void InitializeForm()
        {
            // Initialize DataTable for TaskModel
            taskModelTable = new DataTable();
            taskModelTable.Columns.Add("TaskModelName", typeof(string));
            taskModelTable.Columns.Add("Description", typeof(string));
            taskModelTable.Columns.Add("TaskPageUrl", typeof(string));
            taskModelTable.Columns.Add("EpicId", typeof(int));
            taskModelTable.Columns.Add("FeatureId", typeof(int));
            taskModelTable.Columns.Add("UserStoryId", typeof(int));
            taskModelTable.Columns.Add("UseCaseProblemId", typeof(int));
            taskModelTable.Columns.Add("PhaseId", typeof(int));
            taskModelTable.Columns.Add("StageId", typeof(int));
            taskModelTable.Columns.Add("LineOfBusinessId", typeof(int));
            taskModelTable.Columns.Add("NeuralSchema", typeof(string));
            taskModelTable.Columns.Add("IsBAApprovedSchema", typeof(bool));
            taskModelTable.Columns.Add("ApprovedBy", typeof(string));
            taskModelTable.Columns.Add("ApprovedOn", typeof(DateTime));
            taskModelTable.Columns.Add("WorkflowStateId", typeof(int));
            taskModelTable.Columns.Add("MaxJobs", typeof(int));
            taskModelTable.Columns.Add("CurrentJobs", typeof(int));
            taskModelTable.Columns.Add("TimeOutThresHoldInMs", typeof(int));

            // Set DataGridView properties

            // Add columns to DataGridView
            DataGridViewTextBoxColumn taskModelNameColumn = new DataGridViewTextBoxColumn();
            taskModelNameColumn.DataPropertyName = "TaskModelName";
            taskModelNameColumn.HeaderText = "Task Model Name";

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";


            // Add other columns as needed...


        }


        // Event handler for Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Implement logic to reset controls or perform other cancel operations
            MessageBox.Show("Operation canceled.");
        }

        // Event handler for generating random data


        private void btnUploadData_Click(object sender, EventArgs e)
        {
            ActionCenterData actionSourceNode;
            ActionCenterData actionNode; ;

            if (treeViewMYActions.SelectedNode?.Parent != null)
            {
                actionSourceNode = (ActionCenterData)treeViewMYActions.SelectedNode.Parent.Tag;
                actionNode = (ActionCenterData)treeViewMYActions.SelectedNode.Tag;

                int inProgressActions = treeViewMYActions.SelectedNode.Nodes.Cast<TreeNode>().Count(node =>
                     ((ActionCenterData)node.Tag).Status == UserActionStatus.InProgress);

                switch (true)
                {
                    case true when rbCSV.Checked:
                        // Handle CSV checked condition
                        commandModelRequest = new CommandModelRequest()
                        {
                            ActionId = actionNode.ActionId,
                            ActionName = treeViewMYActions.SelectedNode.Text,
                            ActionSourceId = actionSourceNode.ActionId,
                            ActionSource = treeViewMYActions.SelectedNode.Parent.Text,
                            UserId = "dbo",
                            UploadSourceType = UploadFileSourceTypesEnum.Csv
                        };
                        break;

                    case true when rbImage.Checked:
                        // Handle Image checked condition
                        commandModelRequest = new CommandModelRequest()
                        {
                            ActionId = actionNode.ActionId,
                            ActionName = treeViewMYActions.SelectedNode.Text,
                            ActionSourceId = actionSourceNode.ActionId,
                            ActionSource = treeViewMYActions.SelectedNode.Parent.Text,
                            Status = actionNode.Status,
                            UserId = "dbo",
                            UploadSourceType = UploadFileSourceTypesEnum.Image
                        };
                        break;

                    default:
                        // Handle other cases
                        MessageBox.Show("Select Upload File Source Type.", "Csv or Any Image", MessageBoxButtons.OK, icon: MessageBoxIcon.Asterisk);
                        return;
                }
                // Create an instance of the form you want to show
                DataUploadAndInputForm imageForm = new DataUploadAndInputForm("Data Processor", "TreeMindRootSeed", commandModelRequest);

                // Show the form modelessly
                imageForm.Show();

            }
            else
            {
                tbPages.SelectedIndex = 0;
                MessageBox.Show("Select a Action  Node!");
            }
        }
    }

}



