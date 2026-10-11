using static System.Net.Mime.MediaTypeNames;

namespace FitZoneGym
{
    partial class FormHoiVien
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
            lblHoTen = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblSDT = new System.Windows.Forms.Label();
            txtSDT = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblNgaySinh = new System.Windows.Forms.Label();
            dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            lblHang = new System.Windows.Forms.Label();
            cboHangThanhVien = new System.Windows.Forms.ComboBox();
            chkTrangThai = new System.Windows.Forms.CheckBox();
            grpGioiTinh = new System.Windows.Forms.GroupBox();
            rdoNu = new System.Windows.Forms.RadioButton();
            rdoNam = new System.Windows.Forms.RadioButton();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            txtTimKiemTen = new System.Windows.Forms.TextBox();
            lblLocHang = new System.Windows.Forms.Label();
            cboLocHang = new System.Windows.Forms.ComboBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvHoiVien = new System.Windows.Forms.DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new System.Drawing.Point(30, 25);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(46, 15);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new System.Drawing.Point(130, 22);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(200, 23);
            txtHoTen.TabIndex = 1;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new System.Drawing.Point(30, 60);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new System.Drawing.Size(79, 15);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new System.Drawing.Point(130, 57);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new System.Drawing.Size(200, 23);
            txtSDT.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(30, 95);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(130, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(200, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new System.Drawing.Point(30, 130);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new System.Drawing.Size(63, 15);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new System.Drawing.Point(130, 127);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new System.Drawing.Size(200, 23);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblHang
            // 
            lblHang.AutoSize = true;
            lblHang.Location = new System.Drawing.Point(30, 165);
            lblHang.Name = "lblHang";
            lblHang.Size = new System.Drawing.Size(95, 15);
            lblHang.TabIndex = 8;
            lblHang.Text = "Hạng thành viên:";
            // 
            // cboHangThanhVien
            // 
            cboHangThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboHangThanhVien.FormattingEnabled = true;
            cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.Location = new System.Drawing.Point(130, 162);
            cboHangThanhVien.Name = "cboHangThanhVien";
            cboHangThanhVien.Size = new System.Drawing.Size(200, 23);
            cboHangThanhVien.TabIndex = 9;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTrangThai.Location = new System.Drawing.Point(30, 200);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new System.Drawing.Size(110, 19);
            chkTrangThai.TabIndex = 10;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Location = new System.Drawing.Point(370, 20);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new System.Drawing.Size(180, 70);
            grpGioiTinh.TabIndex = 11;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new System.Drawing.Point(95, 30);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new System.Drawing.Size(41, 19);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new System.Drawing.Point(20, 30);
            rdoNam.Name = "Nam";
            rdoNam.Size = new System.Drawing.Size(51, 19);
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(620, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(100, 32);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(620, 60);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(100, 32);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(620, 100);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(100, 32);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(620, 140);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(100, 32);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiemTen
            // 
            txtTimKiemTen.Location = new System.Drawing.Point(30, 235);
            txtTimKiemTen.Name = "txtTimKiemTen";
            txtTimKiemTen.PlaceholderText = "Nhập họ tên cần tìm...";
            txtTimKiemTen.Size = new System.Drawing.Size(220, 23);
            txtTimKiemTen.TabIndex = 16;
            // 
            // lblLocHang
            // 
            lblLocHang.AutoSize = true;
            lblLocHang.Location = new System.Drawing.Point(270, 238);
            lblLocHang.Name = "lblLocHang";
            lblLocHang.Size = new System.Drawing.Size(95, 15);
            lblLocHang.TabIndex = 17;
            lblLocHang.Text = "Hạng thành viên:";
            // 
            // cboLocHang
            // 
            cboLocHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocHang.FormattingEnabled = true;
            cboLocHang.Location = new System.Drawing.Point(370, 235);
            cboLocHang.Name = "cboLocHang";
            cboLocHang.Size = new System.Drawing.Size(150, 23);
            cboLocHang.TabIndex = 18;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(620, 230);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(100, 32);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new System.Drawing.Point(30, 275);
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.Size = new System.Drawing.Size(730, 250);
            dgvHoiVien.TabIndex = 20;
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
            // 
            // FormHoiVien
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 545);
            Controls.Add(dgvHoiVien);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocHang);
            Controls.Add(lblLocHang);
            Controls.Add(txtTimKiemTen);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpGioiTinh);
            Controls.Add(chkTrangThai);
            Controls.Add(cboHangThanhVien);
            Controls.Add(lblHang);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormHoiVien";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Hội Viên Phòng Gym FitZone";
            Load += FormHoiVien_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.ComboBox cboHangThanhVien;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiemTen;
        private System.Windows.Forms.Label lblLocHang;
        private System.Windows.Forms.ComboBox cboLocHang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHoiVien;
    }
}