using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SunriseHomestay
{
    partial class FormPhong
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
            lblSoPhong = new System.Windows.Forms.Label();
            txtSoPhong = new System.Windows.Forms.TextBox();
            lblTang = new System.Windows.Forms.Label();
            nudTangSo = new System.Windows.Forms.NumericUpDown();
            lblLoaiPhong = new System.Windows.Forms.Label();
            cboLoaiPhong = new System.Windows.Forms.ComboBox();
            lblTinhTrang = new System.Windows.Forms.Label();
            cboTinhTrang = new System.Windows.Forms.ComboBox();
            picHinhAnh = new System.Windows.Forms.PictureBox();
            btnChonAnh = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            cboLocLoai = new System.Windows.Forms.ComboBox();
            cboLocTinhTrang = new System.Windows.Forms.ComboBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvPhong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTangSo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // lblSoPhong
            // 
            lblSoPhong.AutoSize = true;
            lblSoPhong.Location = new System.Drawing.Point(20, 20);
            lblSoPhong.Name = "lblSoPhong";
            lblSoPhong.Size = new System.Drawing.Size(61, 15);
            lblSoPhong.TabIndex = 0;
            lblSoPhong.Text = "Số phòng:";
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new System.Drawing.Point(20, 40);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new System.Drawing.Size(120, 23);
            txtSoPhong.TabIndex = 1;
            // 
            // lblTang
            // 
            lblTang.AutoSize = true;
            lblTang.Location = new System.Drawing.Point(160, 20);
            lblTang.Name = "lblTang";
            lblTang.Size = new System.Drawing.Size(48, 15);
            lblTang.TabIndex = 2;
            lblTang.Text = "Tầng số:";
            // 
            // nudTangSo
            // 
            nudTangSo.Location = new System.Drawing.Point(160, 40);
            nudTangSo.Name = "nudTangSo";
            nudTangSo.Size = new System.Drawing.Size(80, 23);
            nudTangSo.TabIndex = 3;
            nudTangSo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Location = new System.Drawing.Point(260, 20);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new System.Drawing.Size(70, 15);
            lblLoaiPhong.TabIndex = 4;
            lblLoaiPhong.Text = "Loại phòng:";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new System.Drawing.Point(260, 40);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new System.Drawing.Size(120, 23);
            cboLoaiPhong.TabIndex = 5;
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new System.Drawing.Point(400, 20);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new System.Drawing.Size(64, 15);
            lblTinhTrang.TabIndex = 6;
            lblTinhTrang.Text = "Tình trạng:";
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
            cboTinhTrang.Location = new System.Drawing.Point(400, 40);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new System.Drawing.Size(120, 23);
            cboTinhTrang.TabIndex = 7;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picHinhAnh.Location = new System.Drawing.Point(540, 15);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new System.Drawing.Size(100, 65);
            picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 8;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new System.Drawing.Point(540, 85);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new System.Drawing.Size(100, 25);
            btnChonAnh.TabIndex = 9;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(670, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(75, 30);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(755, 20);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(75, 30);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(840, 20);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(75, 30);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(925, 20);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(75, 30);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cboLocLoai
            // 
            cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocLoai.FormattingEnabled = true;
            cboLocLoai.Location = new System.Drawing.Point(20, 130);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new System.Drawing.Size(180, 23);
            cboLocLoai.TabIndex = 14;
            // 
            // cboLocTinhTrang
            // 
            cboLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocTinhTrang.FormattingEnabled = true;
            cboLocTinhTrang.Items.AddRange(new object[] { "-- Tất cả tình trạng --", "Trống", "Đang ở", "Đang dọn" });
            cboLocTinhTrang.Location = new System.Drawing.Point(220, 130);
            cboLocTinhTrang.Name = "cboLocTinhTrang";
            cboLocTinhTrang.Size = new System.Drawing.Size(180, 23);
            cboLocTinhTrang.TabIndex = 15;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(420, 127);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(90, 28);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvPhong
            // 
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new System.Drawing.Point(20, 170);
            dgvPhong.MultiSelect = false;
            dgvPhong.Name = "dgvPhong";
            dgvPhong.ReadOnly = true;
            dgvPhong.RowTemplate.Height = 60;
            dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new System.Drawing.Size(980, 340);
            dgvPhong.TabIndex = 17;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
            // 
            // FormPhong
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1020, 530);
            Controls.Add(dgvPhong);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocTinhTrang);
            Controls.Add(cboLocLoai);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnChonAnh);
            Controls.Add(picHinhAnh);
            Controls.Add(cboTinhTrang);
            Controls.Add(lblTinhTrang);
            Controls.Add(cboLoaiPhong);
            Controls.Add(lblLoaiPhong);
            Controls.Add(nudTangSo);
            Controls.Add(lblTang);
            Controls.Add(txtSoPhong);
            Controls.Add(lblSoPhong);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPhong";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Phòng - Sunrise Homestay";
            Load += FormPhong_Load;
            ((System.ComponentModel.ISupportInitialize)nudTangSo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label lblTang;
        private System.Windows.Forms.NumericUpDown nudTangSo;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.ComboBox cboLoaiPhong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.ComboBox cboLocTinhTrang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvPhong;
    }
}