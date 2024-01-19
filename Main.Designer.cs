namespace Api_Buddy
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            treeView = new TreeView();
            imageList1 = new ImageList(components);
            txtSearchNode = new TextBox();
            panel2 = new Panel();
            panel4 = new Panel();
            splitContainer2 = new SplitContainer();
            tabControl1 = new TabControl();
            BodyTab = new TabPage();
            txtBody = new RichTextBox();
            CurlTab = new TabPage();
            txtCurl = new RichTextBox();
            HeaderTab = new TabPage();
            txtHeader = new RichTextBox();
            panel6 = new Panel();
            panel7 = new Panel();
            txtResponse = new RichTextBox();
            txtSearchFromResponse = new TextBox();
            panel3 = new Panel();
            cmdSend = new Button();
            txtUrl = new TextBox();
            cboMethod = new ComboBox();
            panel5 = new Panel();
            cmdSave = new Button();
            HostPanel = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            lblErrors = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabControl1.SuspendLayout();
            BodyTab.SuspendLayout();
            CurlTab.SuspendLayout();
            HeaderTab.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(989, 554);
            splitContainer1.SplitterDistance = 302;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(treeView);
            panel1.Controls.Add(txtSearchNode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 554);
            panel1.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            treeView.ImageIndex = 0;
            treeView.ImageList = imageList1;
            treeView.LabelEdit = true;
            treeView.Location = new Point(0, 23);
            treeView.Name = "treeView";
            treeView.SelectedImageIndex = 0;
            treeView.ShowLines = false;
            treeView.ShowPlusMinus = false;
            treeView.Size = new Size(302, 531);
            treeView.TabIndex = 1;
            treeView.BeforeLabelEdit += treeView_BeforeLabelEdit;
            treeView.AfterLabelEdit += treeView_AfterLabelEdit;
            treeView.AfterCollapse += treeView_AfterCollapse;
            treeView.AfterExpand += treeView_AfterExpand;
            treeView.NodeMouseHover += treeView_NodeMouseHover;
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.KeyDown += treeView_KeyDown;
            treeView.MouseLeave += treeView_MouseLeave;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "get_icon.png");
            imageList1.Images.SetKeyName(1, "post_icon.png");
            imageList1.Images.SetKeyName(2, "down_icon.png");
            imageList1.Images.SetKeyName(3, "next_icon.png");
            imageList1.Images.SetKeyName(4, "folder_icons.png");
            imageList1.Images.SetKeyName(5, "folder_open.png");
            imageList1.Images.SetKeyName(6, "get_.jpg");
            imageList1.Images.SetKeyName(7, "post_.jpg");
            imageList1.Images.SetKeyName(8, "put.png");
            // 
            // txtSearchNode
            // 
            txtSearchNode.Dock = DockStyle.Top;
            txtSearchNode.Location = new Point(0, 0);
            txtSearchNode.Name = "txtSearchNode";
            txtSearchNode.Size = new Size(302, 23);
            txtSearchNode.TabIndex = 0;
            txtSearchNode.TextChanged += textBox1_TextChanged;
            txtSearchNode.KeyDown += txtSearchNode_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(683, 554);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.AutoSize = true;
            panel4.Controls.Add(splitContainer2);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(683, 554);
            panel4.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 59);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.White;
            splitContainer2.Panel1.Controls.Add(tabControl1);
            splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel6);
            splitContainer2.Panel2MinSize = 0;
            splitContainer2.Size = new Size(683, 495);
            splitContainer2.SplitterDistance = 350;
            splitContainer2.TabIndex = 8;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(BodyTab);
            tabControl1.Controls.Add(CurlTab);
            tabControl1.Controls.Add(HeaderTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(350, 495);
            tabControl1.TabIndex = 4;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // BodyTab
            // 
            BodyTab.Controls.Add(txtBody);
            BodyTab.Location = new Point(4, 24);
            BodyTab.Name = "BodyTab";
            BodyTab.Padding = new Padding(3);
            BodyTab.Size = new Size(342, 467);
            BodyTab.TabIndex = 1;
            BodyTab.Text = "Body";
            BodyTab.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            txtBody.BorderStyle = BorderStyle.None;
            txtBody.Dock = DockStyle.Fill;
            txtBody.Location = new Point(3, 3);
            txtBody.Name = "txtBody";
            txtBody.ShowSelectionMargin = true;
            txtBody.Size = new Size(336, 461);
            txtBody.TabIndex = 0;
            txtBody.Text = "";
            // 
            // CurlTab
            // 
            CurlTab.Controls.Add(txtCurl);
            CurlTab.Location = new Point(4, 24);
            CurlTab.Name = "CurlTab";
            CurlTab.Size = new Size(342, 467);
            CurlTab.TabIndex = 2;
            CurlTab.Text = "Curl";
            CurlTab.UseVisualStyleBackColor = true;
            // 
            // txtCurl
            // 
            txtCurl.BackColor = Color.White;
            txtCurl.BorderStyle = BorderStyle.None;
            txtCurl.Dock = DockStyle.Fill;
            txtCurl.Location = new Point(0, 0);
            txtCurl.Name = "txtCurl";
            txtCurl.ReadOnly = true;
            txtCurl.ShowSelectionMargin = true;
            txtCurl.Size = new Size(342, 467);
            txtCurl.TabIndex = 1;
            txtCurl.Text = "";
            // 
            // HeaderTab
            // 
            HeaderTab.Controls.Add(txtHeader);
            HeaderTab.Location = new Point(4, 24);
            HeaderTab.Name = "HeaderTab";
            HeaderTab.Padding = new Padding(3);
            HeaderTab.Size = new Size(342, 467);
            HeaderTab.TabIndex = 0;
            HeaderTab.Text = "Header";
            HeaderTab.UseVisualStyleBackColor = true;
            // 
            // txtHeader
            // 
            txtHeader.BackColor = Color.White;
            txtHeader.BorderStyle = BorderStyle.None;
            txtHeader.Dock = DockStyle.Fill;
            txtHeader.Location = new Point(3, 3);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(336, 461);
            txtHeader.TabIndex = 3;
            txtHeader.Text = "";
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(txtSearchFromResponse);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(329, 495);
            panel6.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.AppWorkspace;
            panel7.Controls.Add(txtResponse);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 23);
            panel7.Name = "panel7";
            panel7.Size = new Size(329, 472);
            panel7.TabIndex = 1;
            // 
            // txtResponse
            // 
            txtResponse.Dock = DockStyle.Fill;
            txtResponse.Location = new Point(0, 0);
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.ShowSelectionMargin = true;
            txtResponse.Size = new Size(329, 472);
            txtResponse.TabIndex = 5;
            txtResponse.Text = "";
            // 
            // txtSearchFromResponse
            // 
            txtSearchFromResponse.Dock = DockStyle.Top;
            txtSearchFromResponse.Location = new Point(0, 0);
            txtSearchFromResponse.Name = "txtSearchFromResponse";
            txtSearchFromResponse.Size = new Size(329, 23);
            txtSearchFromResponse.TabIndex = 0;
            txtSearchFromResponse.TextChanged += textBox1_TextChanged_1;
            txtSearchFromResponse.KeyDown += textBox1_KeyDown;
            // 
            // panel3
            // 
            panel3.Controls.Add(cmdSend);
            panel3.Controls.Add(txtUrl);
            panel3.Controls.Add(cboMethod);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 27);
            panel3.Name = "panel3";
            panel3.Size = new Size(683, 32);
            panel3.TabIndex = 1;
            // 
            // cmdSend
            // 
            cmdSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdSend.Cursor = Cursors.Hand;
            cmdSend.Location = new Point(606, 4);
            cmdSend.Name = "cmdSend";
            cmdSend.Size = new Size(74, 25);
            cmdSend.TabIndex = 2;
            cmdSend.Text = "Send";
            cmdSend.UseVisualStyleBackColor = true;
            cmdSend.Click += cmdSend_Click;
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(86, 5);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(514, 23);
            txtUrl.TabIndex = 1;
            txtUrl.Enter += txtUrl_Enter;
            // 
            // cboMethod
            // 
            cboMethod.FormattingEnabled = true;
            cboMethod.Items.AddRange(new object[] { "GET", "POST", "PUT" });
            cboMethod.Location = new Point(3, 5);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(78, 23);
            cboMethod.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(cmdSave);
            panel5.Controls.Add(HostPanel);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(683, 27);
            panel5.TabIndex = 0;
            // 
            // cmdSave
            // 
            cmdSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdSave.Cursor = Cursors.Hand;
            cmdSave.Location = new Point(606, 2);
            cmdSave.Name = "cmdSave";
            cmdSave.Size = new Size(74, 25);
            cmdSave.TabIndex = 8;
            cmdSave.Text = "Save";
            cmdSave.UseVisualStyleBackColor = true;
            cmdSave.Click += button1_Click;
            // 
            // HostPanel
            // 
            HostPanel.Dock = DockStyle.Left;
            HostPanel.Location = new Point(0, 0);
            HostPanel.Name = "HostPanel";
            HostPanel.Padding = new Padding(0, 1, 0, 0);
            HostPanel.Size = new Size(608, 27);
            HostPanel.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblErrors, toolStripStatusLabel2, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(5, 562);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(989, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblErrors
            // 
            lblErrors.BackColor = SystemColors.Control;
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(12, 17);
            lblErrors.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.BackColor = SystemColors.Control;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(10, 17);
            toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = SystemColors.Control;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(166, 17);
            toolStripStatusLabel1.Text = "Api Buddy by Generali FedDev";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 589);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Main";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Api Buddy";
            Load += Main_Load;
            KeyDown += Main_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            BodyTab.ResumeLayout(false);
            CurlTab.ResumeLayout(false);
            HeaderTab.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private TreeView treeView;
        private TextBox txtSearchNode;
        private Panel panel3;
        private Button cmdSend;
        private TextBox txtUrl;
        private ComboBox cboMethod;
        private Panel panel4;
        private RichTextBox txtResponse;
        private RichTextBox txtHeader;
        private FlowLayoutPanel HostPanel;
        private SplitContainer splitContainer2;
        private ImageList imageList1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblErrors;
        private TabControl tabControl1;
        private TabPage HeaderTab;
        private TabPage BodyTab;
        private RichTextBox txtBody;
        private TabPage CurlTab;
        private RichTextBox txtCurl;
        private Panel panel5;
        private Button cmdSave;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private TextBox txtSearchFromResponse;
        private Panel panel6;
        private Panel panel7;
    }
}