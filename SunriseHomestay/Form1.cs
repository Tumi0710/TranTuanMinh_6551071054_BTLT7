using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

namespace SunriseHomestay
{
    public partial class FormPhong : Form
    {
        private SunriseDbContext _context;
        private int _selectedMaPhong = 0;
        private string _selectedFileName = "";
        private readonly string _imageFolder = Path.Combine(Application.StartupPath, "Images");

        public FormPhong()
        {
            InitializeComponent();
            _context = new SunriseDbContext();

            if (!Directory.Exists(_imageFolder))
            {
                Directory.CreateDirectory(_imageFolder);
            }
        }

        private async void FormPhong_Load(object sender, EventArgs e)
        {
            await LoadLoaiPhongComboBoxAsync();
            cboTinhTrang.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;
            await LoadDataAsync();
        }

        // Tải danh sách Loại phòng nạp vào ComboBox
        private async Task LoadLoaiPhongComboBoxAsync()
        {
            try
            {
                var listLoai = await _context.LoaiPhongs.AsNoTracking().ToListAsync();

                cboLoaiPhong.DataSource = listLoai.ToList();
                cboLoaiPhong.DisplayMember = "TenLoai";
                cboLoaiPhong.ValueMember = "MaLoai";

                var listLoc = listLoai.ToList();
                listLoc.Insert(0, new LoaiPhong { MaLoai = 0, TenLoai = "-- Lọc theo loại phòng --" });
                cboLocLoai.DataSource = listLoc;
                cboLocLoai.DisplayMember = "TenLoai";
                cboLocLoai.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải dữ liệu hiển thị (kèm cột ảnh thumbnail)
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await _context.Phongs
                    .AsNoTracking()
                    .Include(p => p.MaLoaiNavigation)
                    .Select(p => new
                    {
                        MaPhong = p.MaPhong,
                        HinhAnh = p.HinhAnh,
                        SoPhong = p.SoPhong,
                        Tang = p.TangSo,
                        LoaiPhong = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.TenLoai : "",
                        GiaMoiDem = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.GiaMoiDem : 0,
                        TinhTrang = p.TinhTrang
                    })
                    .ToListAsync();

                SetupDataGridView(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView(System.Collections.IEnumerable data)
        {
            dgvPhong.Columns.Clear();

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPhong", HeaderText = "Mã phòng", Name = "MaPhong" });

            var imgCol = new DataGridViewImageColumn
            {
                HeaderText = "Ảnh",
                Name = "ColHinhAnh",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            };
            dgvPhong.Columns.Add(imgCol);

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoPhong", HeaderText = "Số phòng", Name = "SoPhong" });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tang", HeaderText = "Tầng", Name = "Tang" });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiPhong", HeaderText = "Loại phòng", Name = "LoaiPhong" });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaMoiDem", HeaderText = "Giá/đêm", Name = "GiaMoiDem" });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TinhTrang", HeaderText = "Tình trạng", Name = "TinhTrang" });

            dgvPhong.DataSource = data;

            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string? fileName = row.Cells["HinhAnh"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(_imageFolder, fileName);
                    if (File.Exists(fullPath))
                    {
                        using (var img = Image.FromFile(fullPath))
                        {
                            row.Cells["ColHinhAnh"].Value = new Bitmap(img);
                        }
                    }
                }
            }
        }

        // Đổ dữ liệu lên TextBox và hiển thị ảnh lên PictureBox
        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow != null && dgvPhong.CurrentRow.Index >= 0)
            {
                var row = dgvPhong.CurrentRow;
                _selectedMaPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);

                var phong = _context.Phongs.AsNoTracking().FirstOrDefault(x => x.MaPhong == _selectedMaPhong);
                if (phong != null)
                {
                    txtSoPhong.Text = phong.SoPhong;
                    nudTangSo.Value = phong.TangSo ?? 1;
                    cboLoaiPhong.SelectedValue = phong.MaLoai ?? 0;
                    cboTinhTrang.SelectedItem = phong.TinhTrang ?? "Trống";

                    _selectedFileName = phong.HinhAnh ?? "";
                    HienThiAnh(_selectedFileName);
                }
            }
        }

        private void HienThiAnh(string fileName)
        {
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                string fullPath = Path.Combine(_imageFolder, fileName);
                if (File.Exists(fullPath))
                {
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                }
            }
        }

        // Chọn ảnh upload
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
                ofd.Title = "Chọn ảnh phòng";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName);
                    _selectedFileName = $"phong_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
                    string destPath = Path.Combine(_imageFolder, _selectedFileName);

                    File.Copy(ofd.FileName, destPath, true);
                    HienThiAnh(_selectedFileName);
                }
            }
        }

        // Thêm phòng mới
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Số phòng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            try
            {
                var phong = new Phong
                {
                    SoPhong = soPhong,
                    TangSo = (int)nudTangSo.Value,
                    MaLoai = cboLoaiPhong.SelectedValue != null ? Convert.ToInt32(cboLoaiPhong.SelectedValue) : (int?)null,
                    TinhTrang = cboTinhTrang.SelectedItem?.ToString(),
                    HinhAnh = _selectedFileName
                };

                _context.Phongs.Add(phong);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm mới phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa phòng
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var phong = await _context.Phongs.FindAsync(_selectedMaPhong);
                if (phong != null)
                {
                    phong.SoPhong = txtSoPhong.Text.Trim();
                    phong.TangSo = (int)nudTangSo.Value;
                    phong.MaLoai = cboLoaiPhong.SelectedValue != null ? Convert.ToInt32(cboLoaiPhong.SelectedValue) : (int?)null;
                    phong.TinhTrang = cboTinhTrang.SelectedItem?.ToString();
                    phong.HinhAnh = _selectedFileName;

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa phòng
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng {txtSoPhong.Text} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var phong = await _context.Phongs.FindAsync(_selectedMaPhong);
                    if (phong != null)
                    {
                        _context.Phongs.Remove(phong);
                        await _context.SaveChangesAsync();

                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Tìm kiếm đa điều kiện
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            int maLoaiLoc = cboLocLoai.SelectedValue != null ? Convert.ToInt32(cboLocLoai.SelectedValue) : 0;
            string tinhTrangLoc = cboLocTinhTrang.SelectedItem?.ToString() ?? "-- Tất cả tình trạng --";

            try
            {
                var query = _context.Phongs
                    .AsNoTracking()
                    .Include(p => p.MaLoaiNavigation)
                    .AsQueryable();

                if (maLoaiLoc > 0 && tinhTrangLoc != "-- Tất cả tình trạng --")
                {
                    query = query.Where(p => p.MaLoai == maLoaiLoc && p.TinhTrang == tinhTrangLoc);
                }
                else if (maLoaiLoc > 0)
                {
                    query = query.Where(p => p.MaLoai == maLoaiLoc);
                }
                else if (tinhTrangLoc != "-- Tất cả tình trạng --")
                {
                    query = query.Where(p => p.TinhTrang == tinhTrangLoc);
                }

                var list = await query.Select(p => new
                {
                    MaPhong = p.MaPhong,
                    HinhAnh = p.HinhAnh,
                    SoPhong = p.SoPhong,
                    Tang = p.TangSo,
                    LoaiPhong = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.TenLoai : "",
                    GiaMoiDem = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.GiaMoiDem : 0,
                    TinhTrang = p.TinhTrang
                }).ToListAsync();

                SetupDataGridView(list);

                if (!list.Any())
                {
                    MessageBox.Show("Không có phòng nào thỏa mãn điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _selectedMaPhong = 0;
            _selectedFileName = "";
            txtSoPhong.Clear();
            nudTangSo.Value = 1;
            cboTinhTrang.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;
            cboLocLoai.SelectedIndex = 0;

            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            dgvPhong.ClearSelection();
        }
    }
}