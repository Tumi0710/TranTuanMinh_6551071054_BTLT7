using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using AnKhangClinic.Models;

namespace AnKhangClinic
{
    public partial class FormLichKham : Form
    {
        private AnKhangDbContext _context;
        private int _selectedMaLich = 0;

        public FormLichKham()
        {
            InitializeComponent();
            _context = new AnKhangDbContext();
        }

        private async void FormLichKham_Load(object sender, EventArgs e)
        {
            await LoadBacSiComboBoxAsync();
            cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today.AddMonths(1);

            await LoadDataAsync();
        }

        private async Task LoadBacSiComboBoxAsync()
        {
            try
            {
                var listBS = await _context.BacSis
                    .AsNoTracking()
                    .Select(b => new
                    {
                        MaBS = b.MaBs,
                        DisplayInfo = (b.HoTen ?? "") + " - " + (b.ChuyenKhoa ?? "")
                    })
                    .ToListAsync();

                cboBacSi.DataSource = listBS.ToList();
                cboBacSi.DisplayMember = "DisplayInfo";
                cboBacSi.ValueMember = "MaBS";

                var listLoc = listBS.ToList();
                listLoc.Insert(0, new { MaBS = 0, DisplayInfo = "-- Tất cả bác sĩ --" });
                cboLocBacSi.DataSource = listLoc;
                cboLocBacSi.DisplayMember = "DisplayInfo";
                cboLocBacSi.ValueMember = "MaBS";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.LichKhams
                    .AsNoTracking()
                    .Include(l => l.MaBsNavigation)
                    .Select(l => new
                    {
                        MaLich = l.MaLich,
                        TenBenhNhan = l.TenBenhNhan,
                        SDT = l.Sdt ?? "",
                        NgayKham = l.NgayKham.HasValue ? l.NgayKham.Value.ToString("dd/MM/yyyy") : "",
                        GioKham = l.GioKham ?? "",
                        BacSi = l.MaBsNavigation != null ? ((l.MaBsNavigation.HoTen ?? "") + " - " + (l.MaBsNavigation.ChuyenKhoa ?? "")) : "",
                        ChuyenKhoa = l.MaBsNavigation != null ? (l.MaBsNavigation.ChuyenKhoa ?? "") : "",
                        TrangThai = l.TrangThai ?? ""
                    })
                    .ToListAsync();

                dgvLichKham.DataSource = list;

                if (dgvLichKham.Columns["MaLich"] != null) dgvLichKham.Columns["MaLich"].HeaderText = "Mã lịch";
                if (dgvLichKham.Columns["TenBenhNhan"] != null) dgvLichKham.Columns["TenBenhNhan"].HeaderText = "Tên bệnh nhân";
                if (dgvLichKham.Columns["SDT"] != null) dgvLichKham.Columns["SDT"].HeaderText = "SĐT";
                if (dgvLichKham.Columns["NgayKham"] != null) dgvLichKham.Columns["NgayKham"].HeaderText = "Ngày khám";
                if (dgvLichKham.Columns["GioKham"] != null) dgvLichKham.Columns["GioKham"].HeaderText = "Giờ khám";
                if (dgvLichKham.Columns["BacSi"] != null) dgvLichKham.Columns["BacSi"].HeaderText = "Bác sĩ";
                if (dgvLichKham.Columns["ChuyenKhoa"] != null) dgvLichKham.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";
                if (dgvLichKham.Columns["TrangThai"] != null) dgvLichKham.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichKham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichKham.CurrentRow != null && dgvLichKham.CurrentRow.Index >= 0)
            {
                var row = dgvLichKham.CurrentRow;
                var cellMaLich = row.Cells["MaLich"]?.Value;
                if (cellMaLich == null) return;

                _selectedMaLich = Convert.ToInt32(cellMaLich);

                var lich = _context.LichKhams.AsNoTracking().FirstOrDefault(x => x.MaLich == _selectedMaLich);
                if (lich != null)
                {
                    txtTenBenhNhan.Text = lich.TenBenhNhan ?? "";
                    txtSDT.Text = lich.Sdt ?? "";

                    if (lich.NgayKham.HasValue)
                    {
                        dtpNgayKham.Value = new DateTime(lich.NgayKham.Value.Year, lich.NgayKham.Value.Month, lich.NgayKham.Value.Day);
                    }

                    if (!string.IsNullOrEmpty(lich.GioKham) && TimeSpan.TryParse(lich.GioKham, out TimeSpan time))
                    {
                        dtpGioKham.Value = DateTime.Today.Add(time);
                    }

                    cboBacSi.SelectedValue = lich.MaBs ?? 0;
                    cboTrangThai.SelectedItem = lich.TrangThai ?? "Chờ khám";
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Tên bệnh nhân không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBenhNhan.Focus();
                return false;
            }

            if (cboBacSi.SelectedValue == null || Convert.ToInt32(cboBacSi.SelectedValue) <= 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ khám!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBacSi.Focus();
                return false;
            }

            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không được đặt lịch khám vào ngày trong quá khứ!", "Lỗi ngày khám", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }

            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var newLich = new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                    Sdt = txtSDT.Text.Trim(),
                    NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                    GioKham = dtpGioKham.Value.ToString("HH:mm"),
                    MaBs = Convert.ToInt32(cboBacSi.SelectedValue),
                    TrangThai = cboTrangThai.SelectedItem?.ToString()
                };

                _context.LichKhams.Add(newLich);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm mới lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaLich == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var lich = await _context.LichKhams.FindAsync(_selectedMaLich);
                if (lich != null)
                {
                    lich.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                    lich.Sdt = txtSDT.Text.Trim();
                    lich.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);
                    lich.GioKham = dtpGioKham.Value.ToString("HH:mm");
                    lich.MaBs = Convert.ToInt32(cboBacSi.SelectedValue);
                    lich.TrangThai = cboTrangThai.SelectedItem?.ToString();

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaLich == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám muốn xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lịch khám của bệnh nhân '{txtTenBenhNhan.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var lich = await _context.LichKhams.FindAsync(_selectedMaLich);
                    if (lich != null)
                    {
                        _context.LichKhams.Remove(lich);
                        await _context.SaveChangesAsync();

                        MessageBox.Show("Xóa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
            int maBsLoc = cboLocBacSi.SelectedValue != null ? Convert.ToInt32(cboLocBacSi.SelectedValue) : 0;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("'Từ ngày' không được lớn hơn 'Đến ngày'!", "Lỗi ngày tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var query = _context.LichKhams
                    .AsNoTracking()
                    .Include(l => l.MaBsNavigation)
                    .Where(l => l.NgayKham >= tuNgay && l.NgayKham <= denNgay);

                if (maBsLoc > 0)
                {
                    query = query.Where(l => l.MaBs == maBsLoc);
                }

                var list = await query.Select(l => new
                {
                    MaLich = l.MaLich,
                    TenBenhNhan = l.TenBenhNhan,
                    SDT = l.Sdt ?? "",
                    NgayKham = l.NgayKham.HasValue ? l.NgayKham.Value.ToString("dd/MM/yyyy") : "",
                    GioKham = l.GioKham ?? "",
                    BacSi = l.MaBsNavigation != null ? ((l.MaBsNavigation.HoTen ?? "") + " - " + (l.MaBsNavigation.ChuyenKhoa ?? "")) : "",
                    ChuyenKhoa = l.MaBsNavigation != null ? (l.MaBsNavigation.ChuyenKhoa ?? "") : "",
                    TrangThai = l.TrangThai ?? ""
                }).ToListAsync();

                dgvLichKham.DataSource = list;

                if (!list.Any())
                {
                    MessageBox.Show("Không tìm thấy lịch khám nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            await LoadDataAsync();
        }

        private void ClearForm()
        {
            _selectedMaLich = 0;
            txtTenBenhNhan.Clear();
            txtSDT.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Now;
            if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            if (cboLocBacSi.Items.Count > 0) cboLocBacSi.SelectedIndex = 0;
            dgvLichKham.ClearSelection();
        }
    }
}