using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NhaSachTriThuc.Models;

namespace NhaSachTriThuc
{
    public partial class FormTheLoaiSach : Form
    {
        private NhaSachDbContext _context;

        public FormTheLoaiSach()
        {
            InitializeComponent();
            _context = new NhaSachDbContext();
        }

        private async void FormTheLoaiSach_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Tải dữ liệu lên DataGridView
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.TheLoaiSaches
                    .AsNoTracking()
                    .Select(tl => new
                    {
                        MaTL = tl.MaTl,
                        TenTheLoai = tl.TenTheLoai,
                        MoTa = tl.MoTa,
                        SoLuongSach = tl.SoLuongSach,
                        NgayTao = tl.NgayTao
                    })
                    .ToListAsync();

                dgvTheLoai.DataSource = list;

                if (dgvTheLoai.Columns["MaTL"] != null) dgvTheLoai.Columns["MaTL"].HeaderText = "Mã TL";
                if (dgvTheLoai.Columns["TenTheLoai"] != null) dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
                if (dgvTheLoai.Columns["MoTa"] != null) dgvTheLoai.Columns["MoTa"].HeaderText = "Mô tả";
                if (dgvTheLoai.Columns["SoLuongSach"] != null) dgvTheLoai.Columns["SoLuongSach"].HeaderText = "Số lượng sách";
                if (dgvTheLoai.Columns["NgayTao"] != null) dgvTheLoai.Columns["NgayTao"].HeaderText = "Ngày tạo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đổ dữ liệu dòng đang chọn lên TextBox
        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow != null && dgvTheLoai.CurrentRow.Index >= 0)
            {
                var row = dgvTheLoai.CurrentRow;
                txtMaTL.Text = row.Cells["MaTL"].Value?.ToString() ?? "";
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                var ngayTao = row.Cells["NgayTao"].Value;
                lblNgayTao.Text = ngayTao != null
                    ? Convert.ToDateTime(ngayTao).ToString("dd/MM/yyyy HH:mm:ss")
                    : "...";
            }
        }

        // Nút Làm mới
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            await LoadDataAsync();
        }

        private void ClearInput()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            lblNgayTao.Text = "...";
            dgvTheLoai.ClearSelection();
        }

        // Nút Thêm mới
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenTL = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            bool daTonTai = await _context.TheLoaiSaches.AnyAsync(x => x.TenTheLoai.ToLower() == tenTL.ToLower());
            if (daTonTai)
            {
                MessageBox.Show("Tên thể loại này đã tồn tại trong hệ thống!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                var newTL = new TheLoaiSach
                {
                    TenTheLoai = tenTL,
                    MoTa = moTa,
                    SoLuongSach = 0,
                    NgayTao = DateTime.Now
                };

                _context.TheLoaiSaches.Add(newTL);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm mới thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text) || !int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa trên danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTL = txtTenTheLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Tên thể loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trungTen = await _context.TheLoaiSaches
                .AnyAsync(x => x.MaTl != maTL && x.TenTheLoai.ToLower() == tenTL.ToLower());
            if (trungTen)
            {
                MessageBox.Show("Tên thể loại đã được sử dụng bởi thể loại khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var tlToUpdate = await _context.TheLoaiSaches.FindAsync(maTL);
                if (tlToUpdate != null)
                {
                    tlToUpdate.TenTheLoai = tenTL;
                    tlToUpdate.MoTa = txtMoTa.Text.Trim();

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text) || !int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại muốn xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại '{txtTenTheLoai.Text}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var tlToDelete = await _context.TheLoaiSaches.FindAsync(maTL);
                    if (tlToDelete != null)
                    {
                        _context.TheLoaiSaches.Remove(tlToDelete);
                        await _context.SaveChangesAsync();

                        MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInput();
                        await LoadDataAsync();
                    }
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show(
                        "Không thể xóa thể loại này vì đang có sách thuộc thể loại này tham chiếu tới!",
                        "Lỗi ràng buộc dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Tìm kiếm
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            try
            {
                var query = _context.TheLoaiSaches.AsNoTracking().AsQueryable();

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(x => x.TenTheLoai.Contains(tuKhoa));
                }

                var ketQua = await query.Select(tl => new
                {
                    MaTL = tl.MaTl,
                    TenTheLoai = tl.TenTheLoai,
                    MoTa = tl.MoTa,
                    SoLuongSach = tl.SoLuongSach,
                    NgayTao = tl.NgayTao
                }).ToListAsync();

                dgvTheLoai.DataSource = ketQua;

                if (!ketQua.Any())
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}