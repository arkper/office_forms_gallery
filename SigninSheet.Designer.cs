namespace OfficeForms
{
    partial class SigninSheet
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
            this.sigPlusNET1 = new Topaz.SigPlusNET();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgAppoints = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnAppoint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnShowSheet = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppoints)).BeginInit();
            this.SuspendLayout();
            // 
            // sigPlusNET1
            // 
            this.sigPlusNET1.Location = new System.Drawing.Point(189, 364);
            this.sigPlusNET1.Name = "sigPlusNET1";
            this.sigPlusNET1.Size = new System.Drawing.Size(226, 119);
            this.sigPlusNET1.TabIndex = 0;
            this.sigPlusNET1.TabStop = false;
            this.sigPlusNET1.Text = "sigPlusNET1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(78, 42);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(131, 20);
            this.txtLastName.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(313, 42);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(131, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First Name";
            // 
            // dgAppoints
            // 
            this.dgAppoints.AllowUserToAddRows = false;
            this.dgAppoints.AllowUserToDeleteRows = false;
            this.dgAppoints.AllowUserToOrderColumns = true;
            this.dgAppoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppoints.Location = new System.Drawing.Point(15, 154);
            this.dgAppoints.Name = "dgAppoints";
            this.dgAppoints.ReadOnly = true;
            this.dgAppoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAppoints.Size = new System.Drawing.Size(581, 204);
            this.dgAppoints.TabIndex = 6;
            this.dgAppoints.SelectionChanged += new System.EventHandler(this.dgAppoints_RowClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Appointments:";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(340, 108);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 7;
            this.btnSignIn.Text = "S&ign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // cmbProvider
            // 
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Items.AddRange(new object[] {
            "Givner, Steven",
            "Nejatheim, Allon",
            "Optika, Inc, Modern"});
            this.cmbProvider.Location = new System.Drawing.Point(78, 77);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(131, 21);
            this.cmbProvider.TabIndex = 11;
            this.cmbProvider.Tag = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "To See";
            // 
            // btnPatient
            // 
            this.btnPatient.Location = new System.Drawing.Point(94, 108);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(99, 23);
            this.btnPatient.TabIndex = 3;
            this.btnPatient.Text = "Lookup &Patient";
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnAppoint
            // 
            this.btnAppoint.Location = new System.Drawing.Point(204, 108);
            this.btnAppoint.Name = "btnAppoint";
            this.btnAppoint.Size = new System.Drawing.Size(130, 23);
            this.btnAppoint.TabIndex = 4;
            this.btnAppoint.Text = "Lookup &Appointments";
            this.btnAppoint.UseVisualStyleBackColor = true;
            this.btnAppoint.Click += new System.EventHandler(this.btnAppoint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 108);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(313, 77);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Date";
            // 
            // btnShowSheet
            // 
            this.btnShowSheet.Location = new System.Drawing.Point(422, 107);
            this.btnShowSheet.Name = "btnShowSheet";
            this.btnShowSheet.Size = new System.Drawing.Size(80, 23);
            this.btnShowSheet.TabIndex = 15;
            this.btnShowSheet.Text = "&Show Sheet";
            this.btnShowSheet.UseVisualStyleBackColor = true;
            this.btnShowSheet.Click += new System.EventHandler(this.btnShowSheet_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SigninSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 495);
            this.Controls.Add(this.btnShowSheet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAppoint);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProvider);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgAppoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sigPlusNET1);
            this.Name = "SigninSheet";
            this.Text = "Sign-in Sheet";
            this.Load += new System.EventHandler(this.SigninSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Topaz.SigPlusNET sigPlusNET1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgAppoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnAppoint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnShowSheet;
        private System.Windows.Forms.Timer timer1;
    }
}