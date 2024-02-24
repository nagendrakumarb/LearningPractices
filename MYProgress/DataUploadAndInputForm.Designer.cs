#region Assembly System.Windows.Forms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Windows.Forms.dll
#endregion

#nullable enable

namespace MYProgressAdmin
{
    partial class DataUploadAndInputForm
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
            pnlImageActions = new Panel();
            lblActionName = new Label();
            txtActionName = new TextBox();
            lblSource = new Label();
            txtActionSource = new TextBox();
            saveFile = new Button();
            snipButton = new Button();
            btnUploadData = new Button();
            lblStatus = new Label();
            txtStatus = new TextBox();
            pnlDataActions = new Panel();
            btnSaveCommand = new Button();
            btnCancel = new Button();
            pnlCommandRequest = new Panel();
            gbCsvAttributes = new GroupBox();
            lblCsvFields = new Label();
            lbCsvFields = new ListBox();
            gbImageAttributes = new GroupBox();
            lblImageWidth = new Label();
            txtImageWidth = new TextBox();
            lblImageHeight = new Label();
            txtImageHeight = new TextBox();
            lblDesiredFileName = new Label();
            txtDesiredFileName = new TextBox();
            lblFileName = new Label();
            txtFileName = new TextBox();
            lblFiletype = new Label();
            txtFiletype = new TextBox();
            lblFileSize = new Label();
            txtFileSize = new TextBox();
            lblFormat = new Label();
            txtFileFormat = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            tabCntrlUploadedData = new TabControl();
            tbPageImage = new TabPage();
            pnlImages = new Panel();
            pbImage = new PictureBox();
            tbPageText = new TabPage();
            dgViewCsv = new DataGridView();
            pnlImageActions.SuspendLayout();
            pnlDataActions.SuspendLayout();
            pnlCommandRequest.SuspendLayout();
            gbCsvAttributes.SuspendLayout();
            gbImageAttributes.SuspendLayout();
            tabCntrlUploadedData.SuspendLayout();
            tbPageImage.SuspendLayout();
            pnlImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            tbPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgViewCsv).BeginInit();
            SuspendLayout();
            // 
            // pnlImageActions
            // 
            pnlImageActions.AutoScroll = true;
            pnlImageActions.BorderStyle = BorderStyle.Fixed3D;
            pnlImageActions.Controls.Add(lblActionName);
            pnlImageActions.Controls.Add(txtActionName);
            pnlImageActions.Controls.Add(lblSource);
            pnlImageActions.Controls.Add(txtActionSource);
            pnlImageActions.Controls.Add(saveFile);
            pnlImageActions.Controls.Add(snipButton);
            pnlImageActions.Controls.Add(btnUploadData);
            pnlImageActions.Controls.Add(lblStatus);
            pnlImageActions.Controls.Add(txtStatus);
            pnlImageActions.Dock = DockStyle.Top;
            pnlImageActions.Location = new Point(0, 0);
            pnlImageActions.Name = "pnlImageActions";
            pnlImageActions.Size = new Size(2331, 120);
            pnlImageActions.TabIndex = 44;
            // 
            // lblActionName
            // 
            lblActionName.AutoSize = true;
            lblActionName.BorderStyle = BorderStyle.FixedSingle;
            lblActionName.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            lblActionName.ForeColor = Color.IndianRed;
            lblActionName.Location = new Point(561, 54);
            lblActionName.Name = "lblActionName";
            lblActionName.Size = new Size(191, 33);
            lblActionName.TabIndex = 19;
            lblActionName.Text = "Action Name:";
            // 
            // txtActionName
            // 
            txtActionName.BorderStyle = BorderStyle.FixedSingle;
            txtActionName.CausesValidation = false;
            txtActionName.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            txtActionName.ForeColor = Color.IndianRed;
            txtActionName.Location = new Point(805, 54);
            txtActionName.Name = "txtActionName";
            txtActionName.ReadOnly = true;
            txtActionName.Size = new Size(260, 38);
            txtActionName.TabIndex = 20;
            txtActionName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.BorderStyle = BorderStyle.FixedSingle;
            lblSource.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            lblSource.ForeColor = Color.IndianRed;
            lblSource.Location = new Point(10, 54);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(207, 33);
            lblSource.TabIndex = 17;
            lblSource.Text = "Action Source:";
            // 
            // txtActionSource
            // 
            txtActionSource.BorderStyle = BorderStyle.FixedSingle;
            txtActionSource.CausesValidation = false;
            txtActionSource.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            txtActionSource.ForeColor = Color.IndianRed;
            txtActionSource.Location = new Point(249, 54);
            txtActionSource.Name = "txtActionSource";
            txtActionSource.ReadOnly = true;
            txtActionSource.Size = new Size(260, 38);
            txtActionSource.TabIndex = 18;
            txtActionSource.TextAlign = HorizontalAlignment.Center;
            // 
            // saveFile
            // 
            saveFile.BackColor = Color.Snow;
            saveFile.Dock = DockStyle.Right;
            saveFile.FlatStyle = FlatStyle.Flat;
            saveFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            saveFile.Location = new Point(1626, 0);
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(287, 116);
            saveFile.TabIndex = 14;
            saveFile.Text = "Save As File";
            saveFile.UseVisualStyleBackColor = false;
            saveFile.Click += saveAsFile_Button_Click;
            // 
            // snipButton
            // 
            snipButton.BackColor = Color.Snow;
            snipButton.Dock = DockStyle.Right;
            snipButton.FlatStyle = FlatStyle.Flat;
            snipButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            snipButton.Location = new Point(1913, 0);
            snipButton.Name = "snipButton";
            snipButton.Size = new Size(196, 116);
            snipButton.TabIndex = 15;
            snipButton.Text = "Snip Image";
            snipButton.UseVisualStyleBackColor = false;
            snipButton.Click += snipButton_Click;
            // 
            // btnUploadData
            // 
            btnUploadData.BackColor = Color.Snow;
            btnUploadData.Dock = DockStyle.Right;
            btnUploadData.FlatStyle = FlatStyle.Flat;
            btnUploadData.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            btnUploadData.Location = new Point(2109, 0);
            btnUploadData.Name = "btnUploadData";
            btnUploadData.Size = new Size(218, 116);
            btnUploadData.TabIndex = 16;
            btnUploadData.Text = "Upload";
            btnUploadData.UseVisualStyleBackColor = false;
            btnUploadData.Click += btnUploadData_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(1129, 54);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(109, 33);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.BorderStyle = BorderStyle.FixedSingle;
            txtStatus.CausesValidation = false;
            txtStatus.Font = new Font("Microsoft Sans Serif", 10.125F, FontStyle.Bold);
            txtStatus.ForeColor = Color.IndianRed;
            txtStatus.Location = new Point(1261, 54);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(260, 38);
            txtStatus.TabIndex = 19;
            txtStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlDataActions
            // 
            pnlDataActions.AutoScroll = true;
            pnlDataActions.BorderStyle = BorderStyle.Fixed3D;
            pnlDataActions.Controls.Add(btnSaveCommand);
            pnlDataActions.Controls.Add(btnCancel);
            pnlDataActions.Dock = DockStyle.Bottom;
            pnlDataActions.Location = new Point(0, 1390);
            pnlDataActions.Name = "pnlDataActions";
            pnlDataActions.Size = new Size(2331, 123);
            pnlDataActions.TabIndex = 51;
            // 
            // btnSaveCommand
            // 
            btnSaveCommand.BackColor = Color.LightCoral;
            btnSaveCommand.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveCommand.ForeColor = Color.White;
            btnSaveCommand.Location = new Point(649, 12);
            btnSaveCommand.Name = "btnSaveCommand";
            btnSaveCommand.Size = new Size(250, 101);
            btnSaveCommand.TabIndex = 43;
            btnSaveCommand.Text = "SAVE COMMAND";
            btnSaveCommand.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DeepSkyBlue;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(905, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 101);
            btnCancel.TabIndex = 42;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlCommandRequest
            // 
            pnlCommandRequest.AutoScroll = true;
            pnlCommandRequest.BorderStyle = BorderStyle.Fixed3D;
            pnlCommandRequest.Controls.Add(gbCsvAttributes);
            pnlCommandRequest.Controls.Add(gbImageAttributes);
            pnlCommandRequest.Controls.Add(lblDesiredFileName);
            pnlCommandRequest.Controls.Add(txtDesiredFileName);
            pnlCommandRequest.Controls.Add(lblFileName);
            pnlCommandRequest.Controls.Add(txtFileName);
            pnlCommandRequest.Controls.Add(lblFiletype);
            pnlCommandRequest.Controls.Add(txtFiletype);
            pnlCommandRequest.Controls.Add(lblFileSize);
            pnlCommandRequest.Controls.Add(txtFileSize);
            pnlCommandRequest.Controls.Add(lblFormat);
            pnlCommandRequest.Controls.Add(txtFileFormat);
            pnlCommandRequest.Controls.Add(lblDescription);
            pnlCommandRequest.Controls.Add(txtDescription);
            pnlCommandRequest.Dock = DockStyle.Bottom;
            pnlCommandRequest.Location = new Point(0, 902);
            pnlCommandRequest.Name = "pnlCommandRequest";
            pnlCommandRequest.Size = new Size(2331, 488);
            pnlCommandRequest.TabIndex = 53;
            // 
            // gbCsvAttributes
            // 
            gbCsvAttributes.Controls.Add(lblCsvFields);
            gbCsvAttributes.Controls.Add(lbCsvFields);
            gbCsvAttributes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbCsvAttributes.Location = new Point(732, 207);
            gbCsvAttributes.Name = "gbCsvAttributes";
            gbCsvAttributes.Size = new Size(698, 201);
            gbCsvAttributes.TabIndex = 23;
            gbCsvAttributes.TabStop = false;
            gbCsvAttributes.Text = "Attributes";
            // 
            // lblCsvFields
            // 
            lblCsvFields.AutoSize = true;
            lblCsvFields.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCsvFields.ForeColor = Color.DeepSkyBlue;
            lblCsvFields.Location = new Point(13, 93);
            lblCsvFields.Name = "lblCsvFields";
            lblCsvFields.Size = new Size(137, 32);
            lblCsvFields.TabIndex = 2;
            lblCsvFields.Text = "CSV Fields:";
            // 
            // lbCsvFields
            // 
            lbCsvFields.Location = new Point(193, 37);
            lbCsvFields.Name = "lbCsvFields";
            lbCsvFields.Size = new Size(492, 164);
            lbCsvFields.TabIndex = 3;
            // 
            // gbImageAttributes
            // 
            gbImageAttributes.Controls.Add(lblImageWidth);
            gbImageAttributes.Controls.Add(txtImageWidth);
            gbImageAttributes.Controls.Add(lblImageHeight);
            gbImageAttributes.Controls.Add(txtImageHeight);
            gbImageAttributes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbImageAttributes.Location = new Point(1448, 194);
            gbImageAttributes.Name = "gbImageAttributes";
            gbImageAttributes.Size = new Size(818, 214);
            gbImageAttributes.TabIndex = 22;
            gbImageAttributes.TabStop = false;
            gbImageAttributes.Text = "Attributes";
            // 
            // lblImageWidth
            // 
            lblImageWidth.AutoSize = true;
            lblImageWidth.BorderStyle = BorderStyle.FixedSingle;
            lblImageWidth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImageWidth.ForeColor = Color.DeepSkyBlue;
            lblImageWidth.Location = new Point(21, 137);
            lblImageWidth.Name = "lblImageWidth";
            lblImageWidth.Size = new Size(177, 34);
            lblImageWidth.TabIndex = 14;
            lblImageWidth.Text = "Image  Width:";
            // 
            // txtImageWidth
            // 
            txtImageWidth.BorderStyle = BorderStyle.FixedSingle;
            txtImageWidth.CausesValidation = false;
            txtImageWidth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtImageWidth.ForeColor = Color.DeepSkyBlue;
            txtImageWidth.Location = new Point(197, 132);
            txtImageWidth.Name = "txtImageWidth";
            txtImageWidth.ReadOnly = true;
            txtImageWidth.Size = new Size(615, 39);
            txtImageWidth.TabIndex = 15;
            // 
            // lblImageHeight
            // 
            lblImageHeight.AutoSize = true;
            lblImageHeight.BorderStyle = BorderStyle.FixedSingle;
            lblImageHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImageHeight.ForeColor = Color.DeepSkyBlue;
            lblImageHeight.Location = new Point(21, 69);
            lblImageHeight.Name = "lblImageHeight";
            lblImageHeight.Size = new Size(177, 34);
            lblImageHeight.TabIndex = 16;
            lblImageHeight.Text = "Image Height:";
            // 
            // txtImageHeight
            // 
            txtImageHeight.BorderStyle = BorderStyle.FixedSingle;
            txtImageHeight.CausesValidation = false;
            txtImageHeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtImageHeight.ForeColor = Color.DeepSkyBlue;
            txtImageHeight.Location = new Point(197, 67);
            txtImageHeight.Name = "txtImageHeight";
            txtImageHeight.ReadOnly = true;
            txtImageHeight.Size = new Size(615, 39);
            txtImageHeight.TabIndex = 17;
            // 
            // lblDesiredFileName
            // 
            lblDesiredFileName.Location = new Point(3, 185);
            lblDesiredFileName.Name = "lblDesiredFileName";
            lblDesiredFileName.Size = new Size(137, 73);
            lblDesiredFileName.TabIndex = 2;
            lblDesiredFileName.Text = "Desired File Name:";
            // 
            // txtDesiredFileName
            // 
            txtDesiredFileName.BorderStyle = BorderStyle.FixedSingle;
            txtDesiredFileName.Location = new Point(168, 185);
            txtDesiredFileName.MinimumSize = new Size(0, 60);
            txtDesiredFileName.Name = "txtDesiredFileName";
            txtDesiredFileName.Size = new Size(535, 60);
            txtDesiredFileName.TabIndex = 3;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.BorderStyle = BorderStyle.FixedSingle;
            lblFileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileName.ForeColor = Color.DeepSkyBlue;
            lblFileName.Location = new Point(12, 106);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(136, 34);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            txtFileName.BorderStyle = BorderStyle.FixedSingle;
            txtFileName.CausesValidation = false;
            txtFileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtFileName.ForeColor = Color.DeepSkyBlue;
            txtFileName.Location = new Point(168, 104);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(535, 39);
            txtFileName.TabIndex = 5;
            // 
            // lblFiletype
            // 
            lblFiletype.AutoSize = true;
            lblFiletype.BorderStyle = BorderStyle.FixedSingle;
            lblFiletype.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiletype.ForeColor = Color.DeepSkyBlue;
            lblFiletype.Location = new Point(12, 31);
            lblFiletype.Name = "lblFiletype";
            lblFiletype.Size = new Size(123, 34);
            lblFiletype.TabIndex = 6;
            lblFiletype.Text = "File Type:";
            // 
            // txtFiletype
            // 
            txtFiletype.BorderStyle = BorderStyle.FixedSingle;
            txtFiletype.CausesValidation = false;
            txtFiletype.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtFiletype.ForeColor = Color.DeepSkyBlue;
            txtFiletype.Location = new Point(168, 29);
            txtFiletype.Name = "txtFiletype";
            txtFiletype.ReadOnly = true;
            txtFiletype.Size = new Size(535, 39);
            txtFiletype.TabIndex = 7;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.BorderStyle = BorderStyle.FixedSingle;
            lblFileSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileSize.ForeColor = Color.DeepSkyBlue;
            lblFileSize.Location = new Point(732, 31);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(114, 34);
            lblFileSize.TabIndex = 14;
            lblFileSize.Text = "File Size:";
            // 
            // txtFileSize
            // 
            txtFileSize.BorderStyle = BorderStyle.FixedSingle;
            txtFileSize.CausesValidation = false;
            txtFileSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtFileSize.ForeColor = Color.DeepSkyBlue;
            txtFileSize.Location = new Point(884, 26);
            txtFileSize.Name = "txtFileSize";
            txtFileSize.ReadOnly = true;
            txtFileSize.Size = new Size(533, 39);
            txtFileSize.TabIndex = 15;
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.BorderStyle = BorderStyle.FixedSingle;
            lblFormat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFormat.ForeColor = Color.DeepSkyBlue;
            lblFormat.Location = new Point(732, 117);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(104, 34);
            lblFormat.TabIndex = 16;
            lblFormat.Text = "Format:";
            // 
            // txtFileFormat
            // 
            txtFileFormat.BorderStyle = BorderStyle.FixedSingle;
            txtFileFormat.CausesValidation = false;
            txtFileFormat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtFileFormat.ForeColor = Color.DeepSkyBlue;
            txtFileFormat.Location = new Point(884, 117);
            txtFileFormat.Name = "txtFileFormat";
            txtFileFormat.ReadOnly = true;
            txtFileFormat.Size = new Size(533, 39);
            txtFileFormat.TabIndex = 17;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(1448, 18);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(140, 32);
            lblDescription.TabIndex = 20;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(1445, 68);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(821, 101);
            txtDescription.TabIndex = 21;
            // 
            // tabCntrlUploadedData
            // 
            tabCntrlUploadedData.Controls.Add(tbPageImage);
            tabCntrlUploadedData.Controls.Add(tbPageText);
            tabCntrlUploadedData.Dock = DockStyle.Fill;
            tabCntrlUploadedData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabCntrlUploadedData.Location = new Point(0, 120);
            tabCntrlUploadedData.Name = "tabCntrlUploadedData";
            tabCntrlUploadedData.SelectedIndex = 0;
            tabCntrlUploadedData.Size = new Size(2331, 782);
            tabCntrlUploadedData.TabIndex = 23;
            // 
            // tbPageImage
            // 
            tbPageImage.Controls.Add(pnlImages);
            tbPageImage.Location = new Point(8, 46);
            tbPageImage.Name = "tbPageImage";
            tbPageImage.Padding = new Padding(3);
            tbPageImage.Size = new Size(2315, 728);
            tbPageImage.TabIndex = 0;
            tbPageImage.Text = "Images";
            tbPageImage.UseVisualStyleBackColor = true;
            // 
            // pnlImages
            // 
            pnlImages.AutoScroll = true;
            pnlImages.Controls.Add(pbImage);
            pnlImages.Dock = DockStyle.Top;
            pnlImages.Location = new Point(3, 3);
            pnlImages.Name = "pnlImages";
            pnlImages.Size = new Size(2309, 776);
            pnlImages.TabIndex = 9;
            // 
            // pbImage
            // 
            pbImage.BackColor = Color.White;
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.Location = new Point(0, 0);
            pbImage.MinimumSize = new Size(1120, 302);
            pbImage.Name = "pbImage";
            pbImage.Padding = new Padding(50, 5, 5, 5);
            pbImage.Size = new Size(2331, 776);
            pbImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pbImage.TabIndex = 9;
            pbImage.TabStop = false;
            // 
            // tbPageText
            // 
            tbPageText.Controls.Add(dgViewCsv);
            tbPageText.Location = new Point(8, 46);
            tbPageText.Name = "tbPageText";
            tbPageText.Padding = new Padding(3);
            tbPageText.Size = new Size(2315, 728);
            tbPageText.TabIndex = 1;
            tbPageText.Text = "Text";
            tbPageText.UseVisualStyleBackColor = true;
            // 
            // dgViewCsv
            // 
            dgViewCsv.AllowUserToOrderColumns = true;
            dgViewCsv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgViewCsv.Dock = DockStyle.Fill;
            dgViewCsv.Location = new Point(3, 3);
            dgViewCsv.Name = "dgViewCsv";
            dgViewCsv.RowHeadersWidth = 82;
            dgViewCsv.Size = new Size(2309, 722);
            dgViewCsv.TabIndex = 0;
            // 
            // DataUploadAndInputForm
            // 
            AllowDrop = true;
            ClientSize = new Size(2331, 1513);
            Controls.Add(tabCntrlUploadedData);
            Controls.Add(pnlCommandRequest);
            Controls.Add(pnlDataActions);
            Controls.Add(pnlImageActions);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataUploadAndInputForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Loader and Snip Tool";
            pnlImageActions.ResumeLayout(false);
            pnlImageActions.PerformLayout();
            pnlDataActions.ResumeLayout(false);
            pnlCommandRequest.ResumeLayout(false);
            pnlCommandRequest.PerformLayout();
            gbCsvAttributes.ResumeLayout(false);
            gbCsvAttributes.PerformLayout();
            gbImageAttributes.ResumeLayout(false);
            gbImageAttributes.PerformLayout();
            tabCntrlUploadedData.ResumeLayout(false);
            tbPageImage.ResumeLayout(false);
            pnlImages.ResumeLayout(false);
            pnlImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            tbPageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgViewCsv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlImageActions;
        private Button saveFile;
        private Button snipButton;
        private Button btnUploadData;
        private Panel pnlDataActions;
        private Button btnSaveCommand;
        private Button btnCancel;
        private Panel pnlCommandRequest;
        private Label lblDesiredFileName;
        private TextBox txtDesiredFileName;
        private Label lblFileName;
        private TextBox txtFileName;
        private Label lblFiletype;
        private TextBox txtFiletype;
        private Label lblFileSize;
        private TextBox txtFileSize;
        private Label lblFormat;
        private TextBox txtFileFormat;
        private Label lblStatus;
        private TextBox txtStatus;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblSource;
        private TextBox txtActionSource;
        private Label lblActionName;
        private TextBox txtActionName;
        private TabControl tabCntrlUploadedData;
        private TabPage tbPageImage;
        private Panel pnlImages;
        private PictureBox pbImage;
        private TabPage tbPageText;
        private DataGridView dgViewCsv;
        private GroupBox gbCsvAttributes;
        private Label lblCsvFields;
        private ListBox lbCsvFields;
        private GroupBox gbImageAttributes;
        private Label lblImageWidth;
        private TextBox txtImageWidth;
        private Label lblImageHeight;
        private TextBox txtImageHeight;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

    }
}
