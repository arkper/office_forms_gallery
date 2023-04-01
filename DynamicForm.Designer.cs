namespace OfficeForms
{
    partial class DynamicForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wbDocView = new System.Windows.Forms.WebBrowser();
            this.sigPlusNET1 = new Topaz.SigPlusNET();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picSig = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSig)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(335, 635);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(416, 635);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(498, 635);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = " Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wbDocView
            // 
            this.wbDocView.Dock = System.Windows.Forms.DockStyle.Top;
            this.wbDocView.Location = new System.Drawing.Point(0, 0);
            this.wbDocView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDocView.Name = "wbDocView";
            this.wbDocView.Size = new System.Drawing.Size(897, 629);
            this.wbDocView.TabIndex = 4;
            this.wbDocView.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbDocView_DocumentCompleted);
            // 
            // sigPlusNET1
            // 
            this.sigPlusNET1.BackColor = System.Drawing.Color.White;
            this.sigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.sigPlusNET1.Location = new System.Drawing.Point(304, 466);
            this.sigPlusNET1.Name = "sigPlusNET1";
            this.sigPlusNET1.Size = new System.Drawing.Size(332, 104);
            this.sigPlusNET1.TabIndex = 5;
            this.sigPlusNET1.Text = "sigPlusNET1";
            this.sigPlusNET1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picSig
            // 
            this.picSig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSig.Location = new System.Drawing.Point(304, 466);
            this.picSig.Name = "picSig";
            this.picSig.Size = new System.Drawing.Size(332, 103);
            this.picSig.TabIndex = 6;
            this.picSig.TabStop = false;
            this.picSig.Visible = false;
            this.picSig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSig_MouseDown);
            this.picSig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSig_MouseMove);
            this.picSig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSig_MouseUp);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(371, 576);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(464, 576);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DynamicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 670);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.picSig);
            this.Controls.Add(this.sigPlusNET1);
            this.Controls.Add(this.wbDocView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSign);
            this.Name = "DynamicForm";
            this.Text = "DynamicForm";
            this.Load += new System.EventHandler(this.DynamicForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.WebBrowser wbDocView;
        private Topaz.SigPlusNET sigPlusNET1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picSig;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOK;
    }
}