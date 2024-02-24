using Microsoft.VisualBasic.FileIO;
using MYProgressAdmin.Model;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace MYProgressAdmin
{
    public partial class DataUploadAndInputForm : Form
    {

        private bool isMouseDown = false;
        private Point startPoint;
        private Rectangle selectedRegion;
        private readonly CommandModelRequest _commandModelRequest;

        public DataUploadAndInputForm(string prompt, string title, CommandModelRequest commandModelRequest)
        {
            InitializeComponent();

            this.Text = title;
            _commandModelRequest ??= new CommandModelRequest();
            this._commandModelRequest = commandModelRequest;
             this.txtActionSource.Text = _commandModelRequest.ActionSource;
             this.txtActionSource.Tag = _commandModelRequest.ActionSourceId;
             this.txtActionName.Text = _commandModelRequest.ActionName;
             this.txtActionName.Tag = _commandModelRequest.ActionId;
             this.txtStatus.Text = commandModelRequest.Status.ToString();
             this.txtStatus.Tag = commandModelRequest.Status.ToString();

            if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Csv)
            {
                 this.tabCntrlUploadedData.TabPages.Remove(tabCntrlUploadedData.TabPages["tbPageImage"]); ;
                 this.tabCntrlUploadedData.TabPages["tbPageText"].Visible = true;
                 this.btnUploadData.Text = "Upload CSV Data";
                 this.snipButton.Hide();
                 this.gbCsvAttributes.Visible = true;
                this.gbImageAttributes.Visible = false;
            }
            else
            {
                this.tabCntrlUploadedData.TabPages["tbPageImage"].Visible = true;
                this.tabCntrlUploadedData.TabPages.Remove(tabCntrlUploadedData.TabPages["tbPageText"]); ;
                this.btnUploadData.Text = "Upload Image Data";
                this.snipButton.Show();
                this.gbCsvAttributes.Visible = false;
                this.gbImageAttributes.Visible = true;
            }

            //this.txtActionSource.Enabled = false;
            //this.txtActionName.Enabled = false;
            //this.txtStatus.Enabled = false;
            //this.txtFileName.Enabled = false;
            //this.txtFileSize.Enabled = false;
            //this.txtFiletype.Enabled = false;
            this.txtFileFormat.Enabled = false;
            this.txtImageHeight.Enabled = false;
            this.txtImageWidth.Enabled = false;
        }
        private void saveAsFile_Button_Click(object sender, EventArgs e)
        {
            // Define allowed file extensions based on the upload source type
            string filter = "";
            if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Image)
            {
                filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
            }
            else if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Csv)
            {
                filter = "CSV File|*.csv";
            }

            // Save the file with the specified filter
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Check if the selected file matches the allowed file types
                    if (!IsValidFile(saveFileDialog.FileName))
                    {
                        MessageBox.Show("Invalid file type selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Save the image or CSV file
                    if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Image)
                    {
                        pbImage.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully!");
                    }
                    else if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Csv)
                    {
                        // Save CSV file logic here
                        ExportToCsv(dgViewCsv, saveFileDialog.FileName);
                    }
                }
            }
        }

    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            long fileSizeInBytes = 0;
            List<string> headers= new List<string>();
            // Get the image width and height
            int imageWidth=0;
            int imageHeight=0 ;
            // Open a dialog to choose how to load the image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Image)
                {
                    openFileDialog.Title = "Load Image";
                    openFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";


                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!IsValidFile(openFileDialog.FileName))
                        {
                            MessageBox.Show("Invalid file type selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // Read the file into a MemoryStream to obtain the size
                        using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(openFileDialog.FileName)))
                        {
                            // Get the file size
                             fileSizeInBytes = ms.Length;

                            // Load the image from the MemoryStream
                            Image loadedImage = Image.FromStream(ms);
                            // Get the image width and height
                             imageWidth = loadedImage.Width;
                             imageHeight = loadedImage.Height;
                            // Set the loaded image to the pbImage PictureBox
                            pbImage.Image = loadedImage;

                            // Process the loaded image as needed
                            // (You can convert it to bytes or display it, etc.)

                            MessageBox.Show($"Image loaded successfully!\nFile size: {fileSizeInBytes} bytes");
                        }
                    }

                }
                else if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Csv)
                {
                    openFileDialog.Title = "Load Csv";
                    openFileDialog.Filter = "CSV File|*.csv";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!IsValidFile(openFileDialog.FileName))
                        {
                            MessageBox.Show("Invalid file type selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        lbCsvFields.Items.Clear();
                        headers = FillAndGetDataGridViewFromCSVHeaders(openFileDialog.FileName, ref fileSizeInBytes);
                        lbCsvFields.DataSource = headers;
                        
                    }
                }
                string[] splittedFileStrings = openFileDialog.SafeFileNames[0].Split(".", StringSplitOptions.None);
                txtFiletype.Text = _commandModelRequest.UploadSourceType.ToString();
                txtFileFormat.Text = splittedFileStrings[1];
                txtFileName .Text = splittedFileStrings[0];
                txtFileSize.Text = $"{fileSizeInBytes.ToString()} Bytes";
                txtFileSize.Tag = fileSizeInBytes.ToString();
                txtImageHeight.Text = $"{imageHeight.ToString()} px" ;
                txtImageHeight.Tag= imageHeight.ToString();
                txtImageWidth.Text = $"{imageWidth.ToString()} px";
                txtImageWidth.Tag = imageWidth.ToString();

            }
        }

        private List<string> FillAndGetDataGridViewFromCSVHeaders(string filePath, ref long fileSizeInBytes)
        {
            string[] headers = default;
            try
            {
                dgViewCsv.Rows?.Clear();
                // Create DataTable to hold CSV data
                DataTable dataTable = new DataTable();

                // Read CSV file and parse its contents
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // Read CSV header
                     headers = parser.ReadFields();
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    // Read CSV data and calculate file size
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        dataTable.Rows.Add(fields);

                        // Calculate the size of each field and sum them up
                        fileSizeInBytes += CalculateFieldSize(fields);
                    }
                }

                // Bind DataTable to DataGridView
                dgViewCsv.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return headers?.ToList()?? new List<string>();
        }

        private long CalculateFieldSize(string[] fields)
        {
            long totalSize = 0;
            foreach (string field in fields)
            {
                // Calculate the size of the string representation of the field and add it to the total size
                totalSize += Encoding.UTF8.GetByteCount(field);
            }
            return totalSize;
        }


        private void snipButton_Click(object sender, EventArgs e)
        {
            // Hide the current form temporarily
            this.Hide();

            // Allow the user to select a region on the screen
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                // Create a new form to display the snipping tool
                using (Form snipForm = new Form())
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = bitmap,
                        SizeMode = PictureBoxSizeMode.AutoSize
                    };

                    pictureBox.MouseDown += (snipSender, snipArgs) =>
                    {
                        isMouseDown = true;
                        startPoint = snipArgs.Location;
                    };

                    pictureBox.MouseMove += (snipSender, snipArgs) =>
                    {
                        if (isMouseDown)
                        {
                            // Draw a rectangle based on mouse movement
                            ControlPaint.DrawReversibleFrame(
                                new Rectangle(startPoint, new Size(snipArgs.X - startPoint.X, snipArgs.Y - startPoint.Y)),
                                Color.Black, FrameStyle.Dashed);

                            selectedRegion = new Rectangle(
                                Math.Min(startPoint.X, snipArgs.X),
                                Math.Min(startPoint.Y, snipArgs.Y),
                                Math.Abs(snipArgs.X - startPoint.X),
                                Math.Abs(snipArgs.Y - startPoint.Y));
                        }
                    };

                    pictureBox.MouseUp += (snipSender, snipArgs) =>
                    {
                        isMouseDown = false;
                        // Close the snip form after the mouse is released
                        snipForm.Close();

                        // Process the snipped image as needed
                        if (selectedRegion.Width > 0 && selectedRegion.Height > 0)
                        {
                            Bitmap snippedImage = new Bitmap(selectedRegion.Width, selectedRegion.Height);
                            using (Graphics g = Graphics.FromImage(snippedImage))
                            {
                                g.DrawImage(bitmap, 0, 0, selectedRegion, GraphicsUnit.Pixel);
                            }
                            // Set the snipped image to the pbImage PictureBox
                            pbImage.Image = snippedImage;
                            // Copy the snipped image to clipboard
                            Clipboard.SetImage(snippedImage);

                            // Notify user
                            MessageBox.Show("Image snipped and copied to clipboard!");
                        }

                        // Show the main form again
                        this.Show();
                    };

                    snipForm.Controls.Add(pictureBox);
                    snipForm.FormBorderStyle = FormBorderStyle.None;
                    snipForm.WindowState = FormWindowState.Maximized;
                    snipForm.Cursor = Cursors.Cross;

                    // Show the snip form
                    snipForm.ShowDialog();
                }
            }
        }

        // Method to validate the selected file type
        private bool IsValidFile(string fileName)
        {
            if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Image)
            {
                // Validate image file types
                string extension = Path.GetExtension(fileName).ToLower();
                return extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".bmp";
            }
            else if (_commandModelRequest.UploadSourceType == UploadFileSourceTypesEnum.Csv)
            {
                // Validate CSV file type
                string extension = Path.GetExtension(fileName).ToLower();
                return extension == ".csv";
            }
            return false;
        }

        private void ExportToCsv(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Create a StreamWriter to write to the CSV file
                using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Write column headers
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        streamWriter.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                        {
                            streamWriter.Write(",");
                        }
                    }
                    streamWriter.WriteLine();

                    // Write row data
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            if (row.Cells[i].Value != null)
                            {
                                streamWriter.Write(row.Cells[i].Value.ToString());
                            }
                            if (i < dataGridView.Columns.Count - 1)
                            {
                                streamWriter.Write(",");
                            }
                        }
                        streamWriter.WriteLine();
                    }
                }

                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
