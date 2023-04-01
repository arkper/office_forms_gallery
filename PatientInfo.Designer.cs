namespace OfficeForms
{
    partial class PatientInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgPatients = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.address2 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewEditHipaa = new System.Windows.Forms.Button();
            this.btnViewEditEDoc = new System.Windows.Forms.Button();
            this.cmbHipaa = new System.Windows.Forms.ComboBox();
            this.btnNewHipaa = new System.Windows.Forms.Button();
            this.dgHipaa = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEDocs = new System.Windows.Forms.ComboBox();
            this.bntNewEdoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgEDocs = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastN = new System.Windows.Forms.NumericUpDown();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBithdate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPatientNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHipaa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last";
            // 
            // dgPatients
            // 
            this.dgPatients.AllowUserToAddRows = false;
            this.dgPatients.AllowUserToDeleteRows = false;
            this.dgPatients.AllowUserToOrderColumns = true;
            this.dgPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPatients.Location = new System.Drawing.Point(49, 40);
            this.dgPatients.MultiSelect = false;
            this.dgPatients.Name = "dgPatients";
            this.dgPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatients.Size = new System.Drawing.Size(684, 150);
            this.dgPatients.TabIndex = 1;
            this.dgPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatients_CellContentClick);
            this.dgPatients.SelectionChanged += new System.EventHandler(this.dgPatients_CellContentClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(658, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPhone2);
            this.groupBox1.Controls.Add(this.txtPhone1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtZip);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAddress2);
            this.groupBox1.Controls.Add(this.address2);
            this.groupBox1.Controls.Add(this.txtAddress1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(49, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 325);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Phone 2";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(68, 173);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(212, 20);
            this.txtPhone2.TabIndex = 12;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(68, 143);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(212, 20);
            this.txtPhone1.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Phone 1";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(200, 102);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(80, 20);
            this.txtZip.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Zip";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(68, 102);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(98, 20);
            this.txtState.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(68, 73);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(212, 20);
            this.txtCity.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "City";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(68, 46);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(212, 20);
            this.txtAddress2.TabIndex = 3;
            // 
            // address2
            // 
            this.address2.AutoSize = true;
            this.address2.Location = new System.Drawing.Point(8, 49);
            this.address2.Name = "address2";
            this.address2.Size = new System.Drawing.Size(54, 13);
            this.address2.TabIndex = 2;
            this.address2.Text = "Address 2";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(68, 19);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(212, 20);
            this.txtAddress1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewEditHipaa);
            this.groupBox2.Controls.Add(this.btnViewEditEDoc);
            this.groupBox2.Controls.Add(this.cmbHipaa);
            this.groupBox2.Controls.Add(this.btnNewHipaa);
            this.groupBox2.Controls.Add(this.dgHipaa);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbEDocs);
            this.groupBox2.Controls.Add(this.bntNewEdoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dgEDocs);
            this.groupBox2.Location = new System.Drawing.Point(351, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 325);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documents";
            // 
            // btnViewEditHipaa
            // 
            this.btnViewEditHipaa.Location = new System.Drawing.Point(6, 298);
            this.btnViewEditHipaa.Name = "btnViewEditHipaa";
            this.btnViewEditHipaa.Size = new System.Drawing.Size(75, 23);
            this.btnViewEditHipaa.TabIndex = 9;
            this.btnViewEditHipaa.Text = "View/Edit";
            this.btnViewEditHipaa.UseVisualStyleBackColor = true;
            this.btnViewEditHipaa.Click += new System.EventHandler(this.btnViewEditHipaa_Click);
            // 
            // btnViewEditEDoc
            // 
            this.btnViewEditEDoc.Location = new System.Drawing.Point(7, 143);
            this.btnViewEditEDoc.Name = "btnViewEditEDoc";
            this.btnViewEditEDoc.Size = new System.Drawing.Size(75, 23);
            this.btnViewEditEDoc.TabIndex = 8;
            this.btnViewEditEDoc.Text = "View/Edit";
            this.btnViewEditEDoc.UseVisualStyleBackColor = true;
            this.btnViewEditEDoc.Click += new System.EventHandler(this.btnViewEditEDoc_Click);
            // 
            // cmbHipaa
            // 
            this.cmbHipaa.FormattingEnabled = true;
            this.cmbHipaa.Items.AddRange(new object[] {
            "Consent"});
            this.cmbHipaa.Location = new System.Drawing.Point(162, 298);
            this.cmbHipaa.Name = "cmbHipaa";
            this.cmbHipaa.Size = new System.Drawing.Size(220, 21);
            this.cmbHipaa.TabIndex = 7;
            this.cmbHipaa.SelectedIndexChanged += new System.EventHandler(this.cmbHipaa_SelectedIndexChanged);
            // 
            // btnNewHipaa
            // 
            this.btnNewHipaa.Location = new System.Drawing.Point(81, 298);
            this.btnNewHipaa.Name = "btnNewHipaa";
            this.btnNewHipaa.Size = new System.Drawing.Size(75, 23);
            this.btnNewHipaa.TabIndex = 6;
            this.btnNewHipaa.Text = "Add New";
            this.btnNewHipaa.UseVisualStyleBackColor = true;
            this.btnNewHipaa.Click += new System.EventHandler(this.btnNewHipaa_Click);
            // 
            // dgHipaa
            // 
            this.dgHipaa.AllowUserToAddRows = false;
            this.dgHipaa.AllowUserToDeleteRows = false;
            this.dgHipaa.AllowUserToOrderColumns = true;
            this.dgHipaa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHipaa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgHipaa.Location = new System.Drawing.Point(6, 189);
            this.dgHipaa.Name = "dgHipaa";
            this.dgHipaa.ReadOnly = true;
            this.dgHipaa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHipaa.Size = new System.Drawing.Size(376, 106);
            this.dgHipaa.TabIndex = 5;
            this.dgHipaa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHipaa_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Expiration";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Path";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "HIPAA";
            // 
            // cmbEDocs
            // 
            this.cmbEDocs.FormattingEnabled = true;
            this.cmbEDocs.Items.AddRange(new object[] {
            "Release Of Medical Info",
            "Transportation Approval",
            "Medicaid Eyeglasses"});
            this.cmbEDocs.Location = new System.Drawing.Point(162, 143);
            this.cmbEDocs.Name = "cmbEDocs";
            this.cmbEDocs.Size = new System.Drawing.Size(220, 21);
            this.cmbEDocs.TabIndex = 3;
            // 
            // bntNewEdoc
            // 
            this.bntNewEdoc.Location = new System.Drawing.Point(81, 143);
            this.bntNewEdoc.Name = "bntNewEdoc";
            this.bntNewEdoc.Size = new System.Drawing.Size(75, 23);
            this.bntNewEdoc.TabIndex = 2;
            this.bntNewEdoc.Text = "Add New";
            this.bntNewEdoc.UseVisualStyleBackColor = true;
            this.bntNewEdoc.Click += new System.EventHandler(this.bntNewEdoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "eDocuments";
            // 
            // dgEDocs
            // 
            this.dgEDocs.AllowUserToAddRows = false;
            this.dgEDocs.AllowUserToDeleteRows = false;
            this.dgEDocs.AllowUserToOrderColumns = true;
            this.dgEDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DocType,
            this.ExpirationDate,
            this.Path});
            this.dgEDocs.Location = new System.Drawing.Point(6, 36);
            this.dgEDocs.Name = "dgEDocs";
            this.dgEDocs.ReadOnly = true;
            this.dgEDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEDocs.Size = new System.Drawing.Size(376, 100);
            this.dgEDocs.TabIndex = 0;
            this.dgEDocs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEDocs_CellContentClick);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // DocType
            // 
            this.DocType.HeaderText = "Type";
            this.DocType.Name = "DocType";
            this.DocType.ReadOnly = true;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.HeaderText = "Exipration";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Visible = false;
            // 
            // lastN
            // 
            this.lastN.Location = new System.Drawing.Point(80, 9);
            this.lastN.Name = "lastN";
            this.lastN.Size = new System.Drawing.Size(45, 20);
            this.lastN.TabIndex = 5;
            this.lastN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(210, 9);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(121, 20);
            this.lastName.TabIndex = 6;
            this.lastName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Last Name";
            // 
            // txtBithdate
            // 
            this.txtBithdate.Location = new System.Drawing.Point(392, 6);
            this.txtBithdate.Name = "txtBithdate";
            this.txtBithdate.Size = new System.Drawing.Size(100, 20);
            this.txtBithdate.TabIndex = 8;
            this.txtBithdate.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(337, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Birthdate";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.Location = new System.Drawing.Point(565, 8);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.Size = new System.Drawing.Size(79, 20);
            this.txtPatientNo.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(510, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Patient No";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // PatientInfo
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 533);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPatientNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBithdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.lastN);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgPatients);
            this.Controls.Add(this.label1);
            this.Name = "PatientInfo";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHipaa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone2DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource patientBindingSource1;
        private System.Windows.Forms.Label address2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgHipaa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEDocs;
        private System.Windows.Forms.Button bntNewEdoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgEDocs;
        private System.Windows.Forms.ComboBox cmbHipaa;
        private System.Windows.Forms.Button btnNewHipaa;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.Button btnViewEditEDoc;
        private System.Windows.Forms.Button btnViewEditHipaa;
        private System.Windows.Forms.NumericUpDown lastN;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBithdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPatientNo;
        private System.Windows.Forms.Label label12;
    }
}

