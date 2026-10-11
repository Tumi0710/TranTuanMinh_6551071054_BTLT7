using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FitZoneGym.Models;

namespace FitZoneGym
{
    public partial class FormHoiVien : Form
    {
        private FitZoneDbContext _context;
        private int _selectedMaHV = 0;

        public FormHoiVien()
        {
            InitializeComponent();
            _context = new FitZoneDbContext();
        }

        private async void FormHoiVien_Load(object sender, EventArgs e)
        {
            cboHangThanhVien.SelectedIndex = 0;

            cboLocHang.Items.Clear();
            cboLocHang.Items.Add("-- Tất cả --");
            cboLocHang.Items.Add("Basic");
            cboLocHang.Items.Add("VIP");
            cboLocHang.Items.Add("Premium");
            cboLocHang.SelectedIndex = 0;

            await LoadDataAsync();
        }

        // Tải danh sách hội viên lên DataGridView
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.HoiViens
                    .AsNoTracking()
                    .Select(hv => new
                    {
                        MaHV = hv.MaHv,
                        HoTen = hv.HoTen,
                        GioiTinh = hv.GioiTinh == true ? "Nam" : "Nữ",
                        NgaySinh = hv.NgaySinh.HasValue ? hv.NgaySinh.Value.ToString("dd/MM/yyyy") : "",
                        SDT = hv.Sdt,
                        HangThanhVien = hv.HangThanhVien,
                        TrangThai = hv.TrangThai == true ? "Đang hoạt động" : "Tạm ngưng"
                    })
                    .ToListAsync();

                dgvHoiVien.DataSource = list;

                if (dgvHoiVien.Columns["MaHV"] != null) dgvHoiVien.Columns["MaHV"].HeaderText = "Mã HV";
                if (dgvHoiVien.Columns["HoTen"] != null) dgvHoiVien.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvHoiVien.Columns["GioiTinh"] != null) dgvHoiVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                if (dgvHoiVien.Columns["NgaySinh"] != null) dgvHoiVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                if (dgvHoiVien.Columns["SDT"] != null) dgvHoiVien.Columns["SDT"].HeaderText = "SĐT";
                if (dgvHoiVien.Columns["HangThanhVien"] != null) dgvHoiVien.Columns["HangThanhVien"].HeaderText = "Hạng thành viên";
                if (dgvHoiVien.Columns["TrangThai"] != null) dgvHoiVien.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SelectionChanged: Đọc dữ liệu từ DataGridView lên các điều khiển
        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow != null && dgvHoiVien.CurrentRow.Index >= 0)
            {
                var row = dgvHoiVien.CurrentRow;
                _selectedMaHV = Convert.ToInt32(row.Cells["MaHV"].Value);

                var hv = _context.HoiViens.AsNoTracking().FirstOrDefault(x => x.MaHv == _selectedMaHV);
                if (hv != null)
                {
                    txtHoTen.Text = hv.HoTen;
                    txtSDT.Text = hv.Sdt ?? "";
                    txtEmail.Text = hv.Email ?? "";

                    if (hv.GioiTinh == true)
                        rdoNam.Checked = true;
                    else
                        rdoNu.Checked = true;

                    if (hv.NgaySinh.HasValue)
                        dtpNgaySinh.Value = new DateTime(hv.NgaySinh.Value.Year, hv.NgaySinh.Value.Month, hv.NgaySinh.Value.Day);

                    cboHangThanhVien.SelectedItem = hv.HangThanhVien ?? "Basic";
                    chkTrangThai.Checked = hv.TrangThai ?? true;
                }
            }
        }

        // Kiểm tra hợp lệ dữ liệu theo yêu cầu bài toán
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            string sdt = txtSDT.Text.Trim();
            if (!Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số và có độ dài từ 9 đến 11 ký tự!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            string email = txtEmail.Text.Trim();
            if (!email.Contains('@'))
            {
                MessageBox.Show("Email không hợp lệ (phải chứa ký tự '@')!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            int tuoi = DateTime.Today.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show($"Hội viên chưa đủ tuổi đăng ký! Tuổi hiện tại là {tuoi} (Yêu cầu từ 15 tuổi trở lên).", "Lỗi độ tuổi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            return true;
        }

        // Thêm mới
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var newHv = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdoNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cboHangThanhVien.SelectedItem?.ToString(),
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                _context.HoiViens.Add(newHv);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm mới hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var hv = await _context.HoiViens.FindAsync(_selectedMaHV);
                if (hv != null)
                {
                    hv.HoTen = txtHoTen.Text.Trim();
                    hv.GioiTinh = rdoNam.Checked;
                    hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                    hv.Sdt = txtSDT.Text.Trim();
                    hv.Email = txtEmail.Text.Trim();
                    hv.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString();
                    hv.TrangThai = chkTrangThai.Checked;

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hội viên '{txtHoTen.Text}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var hv = await _context.HoiViens.FindAsync(_selectedMaHV);
                    if (hv != null)
                    {
                        _context.HoiViens.Remove(hv);
                        await _context.SaveChangesAsync();

                        MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        await LoadDataAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Tìm kiếm kết hợp (Họ tên && Hạng thành viên)
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoaTen = txtTimKiemTen.Text.Trim();
            string hangDuocChon = cboLocHang.SelectedItem?.ToString() ?? "-- Tất cả --";

            try
            {
                var query = _context.HoiViens.AsNoTracking().AsQueryable();

                if (!string.IsNullOrEmpty(tuKhoaTen) && hangDuocChon != "-- Tất cả --")
                {
                    query = query.Where(x => x.HoTen.Contains(tuKhoaTen) && x.HangThanhVien == hangDuocChon);
                }
                else if (!string.IsNullOrEmpty(tuKhoaTen))
                {
                    query = query.Where(x => x.HoTen.Contains(tuKhoaTen));
                }
                else if (hangDuocChon != "-- Tất cả --")
                {
                    query = query.Where(x => x.HangThanhVien == hangDuocChon);
                }

                var list = await query.Select(hv => new
                {
                    MaHV = hv.MaHv,
                    HoTen = hv.HoTen,
                    GioiTinh = hv.GioiTinh == true ? "Nam" : "Nữ",
                    NgaySinh = hv.NgaySinh.HasValue ? hv.NgaySinh.Value.ToString("dd/MM/yyyy") : "",
                    SDT = hv.Sdt,
                    HangThanhVien = hv.HangThanhVien,
                    TrangThai = hv.TrangThai == true ? "Đang hoạt động" : "Tạm ngưng"
                }).ToListAsync();

                dgvHoiVien.DataSource = list;

                if (!list.Any())
                {
                    MessageBox.Show("Không tìm thấy hội viên nào khớp với điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            await LoadDataAsync();
        }

        private void ClearForm()
        {
            _selectedMaHV = 0;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            cboHangThanhVien.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            txtTimKiemTen.Clear();
            cboLocHang.SelectedIndex = 0;
            dgvHoiVien.ClearSelection();
        }
    }
}