namespace MYProgressAdmin
{
    public partial class MYCenter
    {
        private class ActionCenterData
        {
            public int ActionId { get; set; }
            public UserActionStatus Status { get; set; }


        }

       
    }

}
//using System;
//using System.Drawing;
//using System.Windows.Forms;

namespace ImageLoaderSnipTool
{
    public partial class MainForm : Form
    {
        private bool isMouseDown = false;
        private Point startPoint;
        private Rectangle selectedRegion;

        public MainForm()
        {
            //InitializeComponent();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            // Open a dialog to choose how to load the image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load Image";
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the image from the selected file
                    Image loadedImage = Image.FromFile(openFileDialog.FileName);

                    // Process the loaded image as needed
                    // (You can convert it to bytes or display it, etc.)

                    MessageBox.Show("Image loaded successfully!");
                }
            }
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

                            // Process the snipped image as needed
                            // (You can convert it to bytes or display it, etc.)
                            MessageBox.Show("Image snipped successfully!");
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
    }
}




