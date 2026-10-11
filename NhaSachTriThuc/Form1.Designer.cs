using static System.Net.Mime.MediaTypeNames;

namespace NhaSachTriThuc
{
    partial class FormTheLoaiSach
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
            lblMaTL = new System.Windows.Forms.Label();
            lblTenTL = new System.Windows.Forms.Label();
            lblMoTa = new System.Windows.Forms.Label();
            txtMaTL = new System.Windows.Forms.TextBox();
            txtTenTheLoai = new System.Windows.Forms.TextBox();
            txtMoTa = new System.Windows.Forms.TextBox();
            lblTitleNgayTao = new System.Windows.Forms.Label();
            lblNgayTao = new System.Windows.Forms.Label();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvTheLoai = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new System.Drawing.Point(30, 25);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new System.Drawing.Size(73, 15);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại:";
            // 
            // lblTenTL
            // 
            lblTenTL.AutoSize = true;
            lblTenTL.Location = new System.Drawing.Point(30, 60);
            lblTenTL.Name = "lblTenTL";
            lblTenTL.Size = new System.Drawing.Size(74, 15);
            lblTenTL.TabIndex = 1;
            lblTenTL.Text = "Tên thể loại:";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new System.Drawing.Point(30, 95);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new System.Drawing.Size(41, 15);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new System.Drawing.Point(120, 22);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.PlaceholderText = "ReadOnly";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new System.Drawing.Size(320, 23);
            txtMaTL.TabIndex = 3;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new System.Drawing.Point(120, 57);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new System.Drawing.Size(320, 23);
            txtTenTheLoai.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new System.Drawing.Point(120, 92);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtMoTa.Size = new System.Drawing.Size(320, 75);
            txtMoTa.TabIndex = 5;
            // 
            // lblTitleNgayTao
            // 
            lblTitleNgayTao.AutoSize = true;
            lblTitleNgayTao.Location = new System.Drawing.Point(30, 180);
            lblTitleNgayTao.Name = "lblTitleNgayTao";
            lblTitleNgayTao.Size = new System.Drawing.Size(58, 15);
            lblTitleNgayTao.TabIndex = 6;
            lblTitleNgayTao.Text = "Ngày tạo:";
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblNgayTao.Location = new System.Drawing.Point(120, 180);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new System.Drawing.Size(19, 15);
            lblNgayTao.TabIndex = 7;
            lblNgayTao.Text = "...";
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(520, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(85, 30);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(620, 20);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(85, 30);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(720, 20);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(85, 30);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(820, 20);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(85, 30);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(230, 215);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
            txtTimKiem.Size = new System.Drawing.Size(260, 23);
            txtTimKiem.TabIndex = 12;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(500, 212);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(100, 28);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new System.Drawing.Point(30, 255);
            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowHeadersVisible = true;
            dgvTheLoai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.Size = new System.Drawing.Size(875, 270);
            dgvTheLoai.TabIndex = 14;
            dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
            // 
            // FormTheLoaiSach
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(934, 545);
            Controls.Add(dgvTheLoai);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblNgayTao);
            Controls.Add(lblTitleNgayTao);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenTheLoai);
            Controls.Add(txtMaTL);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenTL);
            Controls.Add(lblMaTL);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormTheLoaiSach";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            Load += FormTheLoaiSach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMaTL;
        private System.Windows.Forms.Label lblTenTL;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.TextBox txtTenTheLoai;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblTitleNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTheLoai;
    }
}