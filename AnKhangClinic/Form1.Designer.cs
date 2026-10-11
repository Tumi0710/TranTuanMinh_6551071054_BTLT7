using static System.Net.Mime.MediaTypeNames;

namespace AnKhangClinic
{
    partial class FormLichKham
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTenBN = new System.Windows.Forms.Label();
            txtTenBenhNhan = new System.Windows.Forms.TextBox();
            lblSDT = new System.Windows.Forms.Label();
            txtSDT = new System.Windows.Forms.TextBox();
            lblNgayKham = new System.Windows.Forms.Label();
            dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            lblGioKham = new System.Windows.Forms.Label();
            dtpGioKham = new System.Windows.Forms.DateTimePicker();
            lblBacSi = new System.Windows.Forms.Label();
            cboBacSi = new System.Windows.Forms.ComboBox();
            lblTrangThai = new System.Windows.Forms.Label();
            cboTrangThai = new System.Windows.Forms.ComboBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            lblTuNgay = new System.Windows.Forms.Label();
            dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            lblDenNgay = new System.Windows.Forms.Label();
            dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            lblLocBacSi = new System.Windows.Forms.Label();
            cboLocBacSi = new System.Windows.Forms.ComboBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvLichKham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // lblTenBN
            // 
            lblTenBN.AutoSize = true;
            lblTenBN.Location = new System.Drawing.Point(30, 20);
            lblTenBN.Name = "lblTenBN";
            lblTenBN.Size = new System.Drawing.Size(88, 15);
            lblTenBN.TabIndex = 0;
            lblTenBN.Text = "Tên bệnh nhân:";
            // 
            // txtTenBenhNhan
            // 
            txtTenBenhNhan.Location = new System.Drawing.Point(130, 17);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new System.Drawing.Size(200, 23);
            txtTenBenhNhan.TabIndex = 1;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new System.Drawing.Point(30, 55);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new System.Drawing.Size(79, 15);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new System.Drawing.Point(130, 52);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new System.Drawing.Size(200, 23);
            txtSDT.TabIndex = 3;
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new System.Drawing.Point(30, 90);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new System.Drawing.Size(71, 15);
            lblNgayKham.TabIndex = 4;
            lblNgayKham.Text = "Ngày khám:";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpNgayKham.Location = new System.Drawing.Point(130, 87);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new System.Drawing.Size(200, 23);
            dtpNgayKham.TabIndex = 5;
            // 
            // lblGioKham
            // 
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new System.Drawing.Point(30, 125);
            lblGioKham.Name = "lblGioKham";
            lblGioKham.Size = new System.Drawing.Size(61, 15);
            lblGioKham.TabIndex = 6;
            lblGioKham.Text = "Giờ khám:";
            // 
            // dtpGioKham
            // 
            dtpGioKham.CustomFormat = "HH:mm";
            dtpGioKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpGioKham.Location = new System.Drawing.Point(130, 122);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Size = new System.Drawing.Size(200, 23);
            dtpGioKham.TabIndex = 7;
            // 
            // lblBacSi
            // 
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new System.Drawing.Point(360, 20);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new System.Drawing.Size(41, 15);
            lblBacSi.TabIndex = 8;
            lblBacSi.Text = "Bác sĩ:";
            // 
            // cboBacSi
            // 
            cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new System.Drawing.Point(430, 17);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new System.Drawing.Size(250, 23);
            cboBacSi.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(360, 55);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(62, 15);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cboTrangThai.Location = new System.Drawing.Point(430, 52);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new System.Drawing.Size(250, 23);
            cboTrangThai.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(720, 15);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(90, 30);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(825, 15);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(90, 30);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(720, 55);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(90, 30);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(825, 55);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(90, 30);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new System.Drawing.Point(30, 175);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new System.Drawing.Size(52, 15);
            lblTuNgay.TabIndex = 16;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTuNgay.Location = new System.Drawing.Point(90, 171);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new System.Drawing.Size(120, 23);
            dtpTuNgay.TabIndex = 17;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new System.Drawing.Point(225, 175);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new System.Drawing.Size(60, 15);
            lblDenNgay.TabIndex = 18;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDenNgay.Location = new System.Drawing.Point(290, 171);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new System.Drawing.Size(120, 23);
            dtpDenNgay.TabIndex = 19;
            // 
            // lblLocBacSi
            // 
            lblLocBacSi.AutoSize = true;
            lblLocBacSi.Location = new System.Drawing.Point(430, 175);
            lblLocBacSi.Name = "lblLocBacSi";
            lblLocBacSi.Size = new System.Drawing.Size(41, 15);
            lblLocBacSi.TabIndex = 20;
            lblLocBacSi.Text = "Bác sĩ:";
            // 
            // cboLocBacSi
            // 
            cboLocBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocBacSi.FormattingEnabled = true;
            cboLocBacSi.Location = new System.Drawing.Point(480, 171);
            cboLocBacSi.Name = "cboLocBacSi";
            cboLocBacSi.Size = new System.Drawing.Size(200, 23);
            cboLocBacSi.TabIndex = 21;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(700, 167);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(100, 30);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvLichKham
            // 
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new System.Drawing.Point(30, 215);
            dgvLichKham.MultiSelect = false;
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLichKham.Size = new System.Drawing.Size(885, 300);
            dgvLichKham.TabIndex = 23;
            dgvLichKham.SelectionChanged += dgvLichKham_SelectionChanged;
            // 
            // FormLichKham
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(945, 535);
            Controls.Add(dgvLichKham);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocBacSi);
            Controls.Add(lblLocBacSi);
            Controls.Add(dtpDenNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblTuNgay);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(cboBacSi);
            Controls.Add(lblBacSi);
            Controls.Add(dtpGioKham);
            Controls.Add(lblGioKham);
            Controls.Add(dtpNgayKham);
            Controls.Add(lblNgayKham);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtTenBenhNhan);
            Controls.Add(lblTenBN);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLichKham";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Lịch Khám Bệnh - An Khang Clinic";
            Load += FormLichKham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTenBN;
        private System.Windows.Forms.TextBox txtTenBenhNhan;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNgayKham;
        private System.Windows.Forms.DateTimePicker dtpNgayKham;
        private System.Windows.Forms.Label lblGioKham;
        private System.Windows.Forms.DateTimePicker dtpGioKham;
        private System.Windows.Forms.Label lblBacSi;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocBacSi;
        private System.Windows.Forms.ComboBox cboLocBacSi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvLichKham;
    }
}