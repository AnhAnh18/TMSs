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
    public partial class frmChiTietDieuChinh : Form
    {
        public frmChiTietDieuChinh()
        {
            InitializeComponent();
        }
        DataTable tblCTDC;
        private void frmChiTietDieuChinh_Load(object sender, EventArgs e)
        {
            txtSophieu.Text = frmDieuChinh.sochungtu;
            txtNgay.Text = frmDieuChinh.ngay;
            Load_DataGridView();
            txtTongtien.Text = Functions.GetFieldValues("SELECT SUM(AccAmt) FROM AdjustDet WHERE AMainID = " + frmDieuChinh.sochungtu);

        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT AD.DAcc,AD.D_CustID,KH.CustName,AD.CAcc,C_CustID,C_CustID as tenk,AccAmt,AD.Descr FROM AdjustDet AD INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID INNER JOIN Customer KH ON AD.D_CustID = KH.CustID WHERE A.AdjustID = " + frmDieuChinh.sochungtu ;
            tblCTDC = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblCTDC;


            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            DataGridView.Columns.Add(chk);
            chk.HeaderText = "Check Data";
            chk.Name = "chk";
            DataGridView.Rows[0].Cells[8].Value = true;
            DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            {
                button1.Name = "MaKHCo";
                button1.HeaderText = "Mã KH Có";
                button1.Text = "...";
                button1.UseColumnTextForButtonValue = true; //dont forget this line
                DataGridView.Columns.Add(button1);
            }
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "MaKHNo";
                button.HeaderText = "Mã KH Nợ";
                button.Text = "...";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                DataGridView.Columns.Add(button);

            }
            DataGridView.Columns[0].HeaderText = "TK Nợ";
            DataGridView.Columns[1].HeaderText = "Mã KH Nợ";
            DataGridView.Columns[2].HeaderText = "Khách hàng nợ";
            DataGridView.Columns[3].HeaderText = "TK có";
            DataGridView.Columns[4].HeaderText = "Mã KH Có";
            DataGridView.Columns[5].HeaderText = "Khách hàng có";
            DataGridView.Columns[6].HeaderText = "Số tiền";
            DataGridView.Columns[7].HeaderText = "Diễn giải";
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            frmNhanvien f = new frmNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                frmKhachhang f = new frmKhachhang();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();
            }
        }
    }
}
