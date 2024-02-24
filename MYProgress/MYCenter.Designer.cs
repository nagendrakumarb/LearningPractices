using System.Windows.Forms;

namespace MYProgressAdmin
{
    partial class MYCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            treeViewMYActions = new TreeView();
            btnAddTitle = new Button();
            label2 = new Label();
            cboConnectSource = new ComboBox();
            label1 = new Label();
            cboDbMaps = new ComboBox();
            btnSync = new Button();
            lblProgressLabel = new Label();
            cboStatus = new ComboBox();
            btnAddAction = new Button();
            btnDownloadData = new Button();
            grpCleansingOptions = new GroupBox();
            grpUploadFileType = new GroupBox();
            rbImage = new RadioButton();
            rbCSV = new RadioButton();
            btnDownloadTemplate = new Button();
            btnUploadData = new Button();
            grpComputationChoice = new GroupBox();
            rbPowerBI = new RadioButton();
            rbSQLPython = new RadioButton();
            rbAzure = new RadioButton();
            rbPYTHONML = new RadioButton();
            rbMLNET = new RadioButton();
            btnTrainThisModel = new Button();
            lblSelectedALGORITHM = new Label();
            lblSelectedCorrectionLabel = new Label();
            cboTargetCorrectionLabel = new ComboBox();
            lblSolutionAlgorthems = new Label();
            lblSelectedFeatures = new Label();
            lstSelectedModelFeatures = new ListBox();
            tvSolutionAlgorithms = new TreeView();
            cboTrainingAlgorithms = new ComboBox();
            lstViewRoleModels = new ListView();
            contextMenuStrip = new ContextMenuStrip(components);
            tbPages = new TabControl();
            tbActionCenterGateWay = new TabPage();
            btnDelete = new Button();
            actionsProgressBar = new ProgressBar();
            tabRoleModelAnalytics = new TabPage();
            grpCleansingOptions.SuspendLayout();
            grpUploadFileType.SuspendLayout();
            grpComputationChoice.SuspendLayout();
            tbPages.SuspendLayout();
            tbActionCenterGateWay.SuspendLayout();
            tabRoleModelAnalytics.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewMYActions
            // 
            treeViewMYActions.BackColor = SystemColors.Info;
            treeViewMYActions.Location = new Point(6, 67);
            treeViewMYActions.Name = "treeViewMYActions";
            treeViewMYActions.Size = new Size(1389, 775);
            treeViewMYActions.TabIndex = 12;
            treeViewMYActions.AfterSelect += treeViewMYActions_AfterSelect;
            treeViewMYActions.NodeMouseClick += TreeViewMYActions_NodeMouseClick;
            treeViewMYActions.NodeMouseDoubleClick += TreeViewMYActions_NodeMouseDoubleClick;
            // 
            // btnAddTitle
            // 
            btnAddTitle.BackColor = Color.Coral;
            btnAddTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTitle.ForeColor = Color.White;
            btnAddTitle.Location = new Point(875, 842);
            btnAddTitle.Name = "btnAddTitle";
            btnAddTitle.Size = new Size(175, 92);
            btnAddTitle.TabIndex = 39;
            btnAddTitle.Text = "ADD TITLE";
            btnAddTitle.UseVisualStyleBackColor = false;
            btnAddTitle.Click += btnAddTitle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(6, 856);
            label2.Name = "label2";
            label2.Size = new Size(98, 32);
            label2.TabIndex = 38;
            label2.Text = "STATUS";
            // 
            // cboConnectSource
            // 
            cboConnectSource.BackColor = SystemColors.GradientActiveCaption;
            cboConnectSource.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConnectSource.FormattingEnabled = true;
            cboConnectSource.Location = new Point(1034, 13);
            cboConnectSource.Name = "cboConnectSource";
            cboConnectSource.Size = new Size(361, 40);
            cboConnectSource.TabIndex = 24;
            cboConnectSource.SelectedIndexChanged += CboConnectSource_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(889, 16);
            label1.Name = "label1";
            label1.Size = new Size(108, 32);
            label1.TabIndex = 23;
            label1.Text = "Connect";
            // 
            // cboDbMaps
            // 
            cboDbMaps.BackColor = SystemColors.GradientActiveCaption;
            cboDbMaps.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDbMaps.FormattingEnabled = true;
            cboDbMaps.Location = new Point(26, 12);
            cboDbMaps.Name = "cboDbMaps";
            cboDbMaps.Size = new Size(335, 40);
            cboDbMaps.TabIndex = 20;
            // 
            // btnSync
            // 
            btnSync.BackColor = Color.YellowGreen;
            btnSync.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSync.ForeColor = Color.Snow;
            btnSync.Location = new Point(376, 3);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(140, 58);
            btnSync.TabIndex = 19;
            btnSync.Text = "SYNC DB";
            btnSync.UseVisualStyleBackColor = false;
            // 
            // lblProgressLabel
            // 
            lblProgressLabel.AutoSize = true;
            lblProgressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgressLabel.ForeColor = Color.IndianRed;
            lblProgressLabel.Location = new Point(6, 934);
            lblProgressLabel.Name = "lblProgressLabel";
            lblProgressLabel.Size = new Size(252, 32);
            lblProgressLabel.TabIndex = 18;
            lblProgressLabel.Text = "Progress: 0% (0/0/0)";
            // 
            // cboStatus
            // 
            cboStatus.BackColor = SystemColors.GradientActiveCaption;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(6, 891);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(672, 40);
            cboStatus.TabIndex = 13;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            cboStatus.LostFocus += CboStatus_LostFocus;
            // 
            // btnAddAction
            // 
            btnAddAction.BackColor = SystemColors.MenuHighlight;
            btnAddAction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddAction.ForeColor = Color.White;
            btnAddAction.Location = new Point(1056, 842);
            btnAddAction.Name = "btnAddAction";
            btnAddAction.Size = new Size(183, 92);
            btnAddAction.TabIndex = 15;
            btnAddAction.Text = "ADD ACTION";
            btnAddAction.UseVisualStyleBackColor = false;
            btnAddAction.Click += btnAddAction_Click;
            // 
            // btnDownloadData
            // 
            btnDownloadData.BackColor = Color.YellowGreen;
            btnDownloadData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDownloadData.ForeColor = Color.Snow;
            btnDownloadData.Location = new Point(286, 31);
            btnDownloadData.Name = "btnDownloadData";
            btnDownloadData.Size = new Size(275, 90);
            btnDownloadData.TabIndex = 24;
            btnDownloadData.Text = "Download Data";
            btnDownloadData.UseVisualStyleBackColor = false;
            // 
            // grpCleansingOptions
            // 
            grpCleansingOptions.Controls.Add(grpUploadFileType);
            grpCleansingOptions.Controls.Add(btnDownloadData);
            grpCleansingOptions.Controls.Add(btnDownloadTemplate);
            grpCleansingOptions.Controls.Add(btnUploadData);
            grpCleansingOptions.Font = new Font("Segoe UI", 7F, FontStyle.Bold | FontStyle.Italic);
            grpCleansingOptions.Location = new Point(6, 15);
            grpCleansingOptions.Name = "grpCleansingOptions";
            grpCleansingOptions.Size = new Size(1394, 119);
            grpCleansingOptions.TabIndex = 42;
            grpCleansingOptions.TabStop = false;
            grpCleansingOptions.Text = "DATA CLEANSING OPTIONS";
            // 
            // grpUploadFileType
            // 
            grpUploadFileType.BackColor = Color.IndianRed;
            grpUploadFileType.Controls.Add(rbImage);
            grpUploadFileType.Controls.Add(rbCSV);
            grpUploadFileType.ForeColor = Color.White;
            grpUploadFileType.Location = new Point(745, 23);
            grpUploadFileType.Name = "grpUploadFileType";
            grpUploadFileType.Size = new Size(387, 88);
            grpUploadFileType.TabIndex = 43;
            grpUploadFileType.TabStop = false;
            grpUploadFileType.Text = "Upload File Type Source";
            // 
            // rbImage
            // 
            rbImage.AutoSize = true;
            rbImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbImage.Location = new Point(160, 37);
            rbImage.Name = "rbImage";
            rbImage.Size = new Size(201, 36);
            rbImage.TabIndex = 41;
            rbImage.Text = "Image Source";
            rbImage.UseVisualStyleBackColor = true;
            // 
            // rbCSV
            // 
            rbCSV.AutoSize = true;
            rbCSV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbCSV.Location = new Point(34, 37);
            rbCSV.Name = "rbCSV";
            rbCSV.Size = new Size(89, 36);
            rbCSV.TabIndex = 42;
            rbCSV.Text = "CSV";
            rbCSV.UseVisualStyleBackColor = true;
            // 
            // btnDownloadTemplate
            // 
            btnDownloadTemplate.BackColor = Color.FromArgb(255, 128, 0);
            btnDownloadTemplate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDownloadTemplate.ForeColor = Color.Snow;
            btnDownloadTemplate.Location = new Point(6, 31);
            btnDownloadTemplate.Name = "btnDownloadTemplate";
            btnDownloadTemplate.Size = new Size(278, 90);
            btnDownloadTemplate.TabIndex = 26;
            btnDownloadTemplate.Text = "Download Template";
            btnDownloadTemplate.UseVisualStyleBackColor = false;
            // 
            // btnUploadData
            // 
            btnUploadData.BackColor = Color.White;
            btnUploadData.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUploadData.ForeColor = Color.Black;
            btnUploadData.Location = new Point(1150, 21);
            btnUploadData.Name = "btnUploadData";
            btnUploadData.Size = new Size(238, 90);
            btnUploadData.TabIndex = 23;
            btnUploadData.Text = "Upload Data";
            btnUploadData.UseVisualStyleBackColor = false;
            btnUploadData.Click += btnUploadData_Click;
            // 
            // grpComputationChoice
            // 
            grpComputationChoice.Controls.Add(rbPowerBI);
            grpComputationChoice.Controls.Add(rbSQLPython);
            grpComputationChoice.Controls.Add(rbAzure);
            grpComputationChoice.Controls.Add(rbPYTHONML);
            grpComputationChoice.Controls.Add(rbMLNET);
            grpComputationChoice.Controls.Add(btnTrainThisModel);
            grpComputationChoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpComputationChoice.Location = new Point(205, 849);
            grpComputationChoice.Name = "grpComputationChoice";
            grpComputationChoice.Size = new Size(922, 168);
            grpComputationChoice.TabIndex = 41;
            grpComputationChoice.TabStop = false;
            grpComputationChoice.Text = "Compute and Cluster Options";
            // 
            // rbPowerBI
            // 
            rbPowerBI.AutoSize = true;
            rbPowerBI.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbPowerBI.Location = new Point(675, 35);
            rbPowerBI.Name = "rbPowerBI";
            rbPowerBI.Size = new Size(161, 36);
            rbPowerBI.TabIndex = 41;
            rbPowerBI.TabStop = true;
            rbPowerBI.Text = "POWER BI";
            rbPowerBI.UseVisualStyleBackColor = true;
            // 
            // rbSQLPython
            // 
            rbSQLPython.AutoSize = true;
            rbSQLPython.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbSQLPython.Location = new Point(87, 35);
            rbSQLPython.Name = "rbSQLPython";
            rbSQLPython.Size = new Size(169, 36);
            rbSQLPython.TabIndex = 40;
            rbSQLPython.TabStop = true;
            rbSQLPython.Text = "SQLPython";
            rbSQLPython.UseVisualStyleBackColor = true;
            // 
            // rbAzure
            // 
            rbAzure.AutoSize = true;
            rbAzure.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbAzure.Location = new Point(546, 35);
            rbAzure.Name = "rbAzure";
            rbAzure.Size = new Size(123, 36);
            rbAzure.TabIndex = 39;
            rbAzure.TabStop = true;
            rbAzure.Text = "AZURE";
            rbAzure.UseVisualStyleBackColor = true;
            // 
            // rbPYTHONML
            // 
            rbPYTHONML.AutoSize = true;
            rbPYTHONML.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbPYTHONML.Location = new Point(262, 35);
            rbPYTHONML.Name = "rbPYTHONML";
            rbPYTHONML.Size = new Size(126, 36);
            rbPYTHONML.TabIndex = 38;
            rbPYTHONML.TabStop = true;
            rbPYTHONML.Text = "Python";
            rbPYTHONML.UseVisualStyleBackColor = true;
            // 
            // rbMLNET
            // 
            rbMLNET.AutoSize = true;
            rbMLNET.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbMLNET.Location = new Point(394, 35);
            rbMLNET.Name = "rbMLNET";
            rbMLNET.Size = new Size(133, 36);
            rbMLNET.TabIndex = 37;
            rbMLNET.TabStop = true;
            rbMLNET.Text = "ML.NET";
            rbMLNET.UseVisualStyleBackColor = true;
            // 
            // btnTrainThisModel
            // 
            btnTrainThisModel.AutoSize = true;
            btnTrainThisModel.BackColor = SystemColors.ActiveCaption;
            btnTrainThisModel.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrainThisModel.Location = new Point(87, 77);
            btnTrainThisModel.Name = "btnTrainThisModel";
            btnTrainThisModel.Size = new Size(749, 88);
            btnTrainThisModel.TabIndex = 36;
            btnTrainThisModel.Text = "TRAIN THIS Model";
            btnTrainThisModel.UseVisualStyleBackColor = false;
            // 
            // lblSelectedALGORITHM
            // 
            lblSelectedALGORITHM.AutoSize = true;
            lblSelectedALGORITHM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedALGORITHM.Location = new Point(34, 734);
            lblSelectedALGORITHM.Name = "lblSelectedALGORITHM";
            lblSelectedALGORITHM.Size = new Size(364, 32);
            lblSelectedALGORITHM.TabIndex = 40;
            lblSelectedALGORITHM.Text = "(AUTO) SELECTED ALGORITHM";
            // 
            // lblSelectedCorrectionLabel
            // 
            lblSelectedCorrectionLabel.AutoSize = true;
            lblSelectedCorrectionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedCorrectionLabel.Location = new Point(1218, 720);
            lblSelectedCorrectionLabel.Name = "lblSelectedCorrectionLabel";
            lblSelectedCorrectionLabel.Size = new Size(176, 32);
            lblSelectedCorrectionLabel.TabIndex = 39;
            lblSelectedCorrectionLabel.Text = "Selected Label";
            // 
            // cboTargetCorrectionLabel
            // 
            cboTargetCorrectionLabel.FormattingEnabled = true;
            cboTargetCorrectionLabel.Items.AddRange(new object[] { "Supervised Learning", "Unsupervised Learning", "Semi-Supervised Learning", "Reinforcement Learning", "Transfer Learning", "Online Learning", "Ensemble Learning", "Self-Supervised Learning", "Multi-instance Learning", "Meta-Learning" });
            cboTargetCorrectionLabel.Location = new Point(789, 769);
            cboTargetCorrectionLabel.Name = "cboTargetCorrectionLabel";
            cboTargetCorrectionLabel.Size = new Size(605, 40);
            cboTargetCorrectionLabel.TabIndex = 38;
            // 
            // lblSolutionAlgorthems
            // 
            lblSolutionAlgorthems.AutoSize = true;
            lblSolutionAlgorthems.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSolutionAlgorthems.Location = new Point(89, 518);
            lblSolutionAlgorthems.Name = "lblSolutionAlgorthems";
            lblSolutionAlgorthems.Size = new Size(300, 32);
            lblSolutionAlgorthems.TabIndex = 37;
            lblSolutionAlgorthems.Text = "SOLUTION ALGORTHEMS";
            // 
            // lblSelectedFeatures
            // 
            lblSelectedFeatures.AutoSize = true;
            lblSelectedFeatures.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedFeatures.Location = new Point(1045, 507);
            lblSelectedFeatures.Name = "lblSelectedFeatures";
            lblSelectedFeatures.Size = new Size(349, 32);
            lblSelectedFeatures.TabIndex = 36;
            lblSelectedFeatures.Text = "Selected Role Model Features";
            // 
            // lstSelectedModelFeatures
            // 
            lstSelectedModelFeatures.FormattingEnabled = true;
            lstSelectedModelFeatures.Location = new Point(723, 560);
            lstSelectedModelFeatures.Name = "lstSelectedModelFeatures";
            lstSelectedModelFeatures.Size = new Size(671, 132);
            lstSelectedModelFeatures.TabIndex = 32;
            // 
            // tvSolutionAlgorithms
            // 
            tvSolutionAlgorithms.Location = new Point(17, 560);
            tvSolutionAlgorithms.Name = "tvSolutionAlgorithms";
            tvSolutionAlgorithms.Size = new Size(577, 136);
            tvSolutionAlgorithms.TabIndex = 29;
            // 
            // cboTrainingAlgorithms
            // 
            cboTrainingAlgorithms.FormattingEnabled = true;
            cboTrainingAlgorithms.Items.AddRange(new object[] { "Supervised Learning", "Unsupervised Learning", "Semi-Supervised Learning", "Reinforcement Learning", "Transfer Learning", "Online Learning", "Ensemble Learning", "Self-Supervised Learning", "Multi-instance Learning", "Meta-Learning" });
            cboTrainingAlgorithms.Location = new Point(17, 782);
            cboTrainingAlgorithms.Name = "cboTrainingAlgorithms";
            cboTrainingAlgorithms.Size = new Size(577, 40);
            cboTrainingAlgorithms.TabIndex = 28;
            // 
            // lstViewRoleModels
            // 
            lstViewRoleModels.Location = new Point(12, 142);
            lstViewRoleModels.Name = "lstViewRoleModels";
            lstViewRoleModels.Size = new Size(1388, 351);
            lstViewRoleModels.TabIndex = 25;
            lstViewRoleModels.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(32, 32);
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(61, 4);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // tbPages
            // 
            tbPages.Alignment = TabAlignment.Bottom;
            tbPages.Controls.Add(tbActionCenterGateWay);
            tbPages.Controls.Add(tabRoleModelAnalytics);
            tbPages.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            tbPages.Location = new Point(12, 12);
            tbPages.Name = "tbPages";
            tbPages.SelectedIndex = 0;
            tbPages.Size = new Size(1418, 1100);
            tbPages.TabIndex = 1;
            // 
            // tbActionCenterGateWay
            // 
            tbActionCenterGateWay.Controls.Add(btnDelete);
            tbActionCenterGateWay.Controls.Add(cboConnectSource);
            tbActionCenterGateWay.Controls.Add(treeViewMYActions);
            tbActionCenterGateWay.Controls.Add(label1);
            tbActionCenterGateWay.Controls.Add(actionsProgressBar);
            tbActionCenterGateWay.Controls.Add(cboDbMaps);
            tbActionCenterGateWay.Controls.Add(label2);
            tbActionCenterGateWay.Controls.Add(btnSync);
            tbActionCenterGateWay.Controls.Add(btnAddAction);
            tbActionCenterGateWay.Controls.Add(btnAddTitle);
            tbActionCenterGateWay.Controls.Add(cboStatus);
            tbActionCenterGateWay.Controls.Add(lblProgressLabel);
            tbActionCenterGateWay.Location = new Point(8, 8);
            tbActionCenterGateWay.Name = "tbActionCenterGateWay";
            tbActionCenterGateWay.Padding = new Padding(3);
            tbActionCenterGateWay.Size = new Size(1402, 1046);
            tbActionCenterGateWay.TabIndex = 3;
            tbActionCenterGateWay.Text = "Action Center Gateway";
            tbActionCenterGateWay.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1245, 842);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(151, 92);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDeleteAction_Click;
            // 
            // actionsProgressBar
            // 
            actionsProgressBar.Dock = DockStyle.Bottom;
            actionsProgressBar.Location = new Point(3, 983);
            actionsProgressBar.Name = "actionsProgressBar";
            actionsProgressBar.Size = new Size(1396, 60);
            actionsProgressBar.TabIndex = 41;
            // 
            // tabRoleModelAnalytics
            // 
            tabRoleModelAnalytics.Controls.Add(grpComputationChoice);
            tabRoleModelAnalytics.Controls.Add(grpCleansingOptions);
            tabRoleModelAnalytics.Controls.Add(lblSelectedALGORITHM);
            tabRoleModelAnalytics.Controls.Add(lblSelectedCorrectionLabel);
            tabRoleModelAnalytics.Controls.Add(lstViewRoleModels);
            tabRoleModelAnalytics.Controls.Add(cboTargetCorrectionLabel);
            tabRoleModelAnalytics.Controls.Add(lstSelectedModelFeatures);
            tabRoleModelAnalytics.Controls.Add(cboTrainingAlgorithms);
            tabRoleModelAnalytics.Controls.Add(tvSolutionAlgorithms);
            tabRoleModelAnalytics.Controls.Add(lblSolutionAlgorthems);
            tabRoleModelAnalytics.Controls.Add(lblSelectedFeatures);
            tabRoleModelAnalytics.Location = new Point(8, 8);
            tabRoleModelAnalytics.Name = "tabRoleModelAnalytics";
            tabRoleModelAnalytics.Padding = new Padding(3);
            tabRoleModelAnalytics.Size = new Size(1402, 1046);
            tabRoleModelAnalytics.TabIndex = 0;
            tabRoleModelAnalytics.Text = "PAAS- MY Role Model Analytics";
            tabRoleModelAnalytics.UseVisualStyleBackColor = true;
            // 
            // MYCenter
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1428, 1131);
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(tbPages);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.On;
            MaximizeBox = false;
            Name = "MYCenter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TRACKER ADMIN";
            Load += frmAdmin_Load;
            grpCleansingOptions.ResumeLayout(false);
            grpUploadFileType.ResumeLayout(false);
            grpUploadFileType.PerformLayout();
            grpComputationChoice.ResumeLayout(false);
            grpComputationChoice.PerformLayout();
            tbPages.ResumeLayout(false);
            tbActionCenterGateWay.ResumeLayout(false);
            tbActionCenterGateWay.PerformLayout();
            tabRoleModelAnalytics.ResumeLayout(false);
            tabRoleModelAnalytics.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cboConnectSource;
        private Label label1;
        private ComboBox cboDbMaps;
        private Button btnSync;
        private Label lblProgressLabel;
        private ComboBox cboStatus;
        private TreeView treeViewMYActions;
        private Button btnAddAction;
        private ContextMenuStrip contextMenuStrip;
        private ListView lstViewRoleModels;
        private Button btnDownloadData;
        private Button btnUploadData;
        private Button btnDownloadTemplate;
        private ComboBox cboTrainingAlgorithms;
        private TreeView tvSolutionAlgorithms;
        private ListBox lstSelectedModelFeatures;
        private Panel pnlActions;
        private Label lblSolutionAlgorthems;
        private Label lblSelectedFeatures;
        private Label lblSelectedCorrectionLabel;
        private ComboBox cboTargetCorrectionLabel;
        private Label lblSelectedALGORITHM;
        private GroupBox grpComputationChoice;
        private RadioButton rbPowerBI;
        private RadioButton rbSQLPython;
        private RadioButton rbAzure;
        private RadioButton rbPYTHONML;
        private RadioButton rbMLNET;
        private GroupBox grpCleansingOptions;
        private Button btnAddTitle;
        private Label label2;
        private TabControl tbPages;
        private TabPage tabRoleModelAnalytics;
        private TabPage tbActionCenterGateWay;
        private Button btnTrainThisModel;
        private ProgressBar actionsProgressBar;
        private Button btnDelete;
        // Instance variables for controls
 

        private Label labelTaskModelName;
        private Label labelExistingTaskModels;
        private RadioButton rbCSV;
        private RadioButton rbImage;
        private GroupBox grpUploadFileType;
    }


}
