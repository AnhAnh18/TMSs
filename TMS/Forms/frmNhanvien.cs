using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Class;

namespace TMS.Forms
{
    public partial class frmNhanvien : Form
    {
        DataTable tblNV;
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            String sql;
            sql = "SELECT NV.SlsPerID,NV.SlsPerName,NV.Address,NV.CMT,Phone,SlsPerDescr FROM SalesPerson NV";
            tblNV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblNV;
            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "CMT";
            DataGridView.Columns[4].HeaderText = "Số điện thoại";
            DataGridView.Columns[5].HeaderText = "Diễn giải";
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = DataGridView.CurrentRow.Cells["SlsPerID"].Value.ToString();
            txtTenNV.Text = DataGridView.CurrentRow.Cells["SlsPerName"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["Address"].Value.ToString();
            txtCMT.Text = DataGridView.CurrentRow.Cells["CMT"].Value.ToString();
            txtPhone.Text = DataGridView.CurrentRow.Cells["Phone"].Value.ToString();
            txtDiengiai.Text = DataGridView.CurrentRow.Cells["SlsPerDescr"].Value.ToString();
        }
    }
}
