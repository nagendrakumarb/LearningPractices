using System;
using System.Windows.Forms;

public class InputForm : Form
{
    private Label lblPrompt;
    private TextBox txtInput;
    private Button btnOK;
    private Button btnCancel;

    public string InputValue => txtInput.Text;

    public InputForm(string prompt, string title)
    {
        InitializeComponent();

        lblPrompt.Text = prompt;
        this.Text = title;
    }

    private void InitializeComponent()
    {
        lblPrompt = new Label();
        txtInput = new TextBox();
        btnOK = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblPrompt
        // 
        lblPrompt.AutoSize = true;
        lblPrompt.Location = new Point(24, 40);
        lblPrompt.Name = "lblPrompt";
        lblPrompt.Size = new Size(97, 32);
        lblPrompt.TabIndex = 0;
        lblPrompt.Text = "Prompt:";
        // 
        // txtInput
        // 
        txtInput.Location = new Point(24, 75);
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(568, 39);
        txtInput.TabIndex = 1;
        // 
        // btnOK
        // 
        btnOK.DialogResult = DialogResult.OK;
        btnOK.Location = new Point(126, 120);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(76, 45);
        btnOK.TabIndex = 2;
        btnOK.Text = "OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(222, 120);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(142, 45);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // InputForm
        // 
        ClientSize = new Size(789, 217);
        Controls.Add(lblPrompt);
        Controls.Add(txtInput);
        Controls.Add(btnOK);
        Controls.Add(btnCancel);
        Name = "InputForm";
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
 
 
}
