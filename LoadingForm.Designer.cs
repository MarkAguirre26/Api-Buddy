namespace Api_Buddy
{
    partial class LoadingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            cmdClose = new Button();
            labelMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Spinner;
            pictureBox1.Location = new Point(110, -1);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cmdClose
            // 
            cmdClose.Cursor = Cursors.Hand;
            cmdClose.FlatAppearance.BorderSize = 0;
            cmdClose.FlatStyle = FlatStyle.Flat;
            cmdClose.Location = new Point(315, 2);
            cmdClose.Margin = new Padding(4, 3, 4, 3);
            cmdClose.Name = "cmdClose";
            cmdClose.Size = new Size(21, 27);
            cmdClose.TabIndex = 1;
            cmdClose.Text = "X";
            cmdClose.UseVisualStyleBackColor = true;
            cmdClose.Click += button1_Click;
            // 
            // labelMessage
            // 
            labelMessage.Dock = DockStyle.Bottom;
            labelMessage.Location = new Point(0, 97);
            labelMessage.Margin = new Padding(4, 0, 4, 0);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(341, 17);
            labelMessage.TabIndex = 2;
            labelMessage.Text = "-";
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 114);
            Controls.Add(cmdClose);
            Controls.Add(labelMessage);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoadingForm";
            Text = "LoadingForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button cmdClose;
        private Label labelMessage;
    }
}