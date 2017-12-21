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
using TMS.Forms;

namespace TMS
{
    public partial class frmDieuChinh : Form
    {
        public static String sochungtu,ngay;
        DataTable tblDC;
        public frmDieuChinh()
        {
            InitializeComponent();
        }
        String nam, thang;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        private void fromDieuChinh_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_TreeView();
            Load_DataGridView();
            //foreach (DataGridViewRow row in DataGridView.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
            //    if (chk.Value == chk.TrueValue)
            //    {
            //        chk.Value = chk.FalseValue;
            //    }
            //    else
            //    {
            //        chk.Value = chk.TrueValue;
            //    }
            //}
        }
        private void Load_TreeView()
        {
            //string sql = "SELECT MONTH(AdjustDate),YEAR(AdjustDate) FROM Adjust GROUP BY MONTH(AdjustDate),YEAR(AdjustDate) ORDER BY MONTH(AdjustDate) DESC,YEAR(AdjustDate) DESC";
            //nodeCha = Functions.GetDataToTable(sql);
            //for (int i=0; i < nodeCha.Rows.Count; i++)
            //{
            //    twThoigian.Nodes.Add(nodeCha.Rows[i][0].ToString());
            //    twThoigian.Nodes[i].Tag = "1";
            //}

            for(int i= year; i >= 2015; i--)
            {
                for(int j= month; j >=1; j--)
                {
                    tvThoigian.Nodes[0].Nodes.Add("Tháng " + j + "/" + i);
                    tvThoigian.ExpandAll();
                }
            }
        }
        private void Load_DataGridView()
        {

            string sql,sql1;
            sql = "SELECT ROW_NUMBER() OVER (ORDER BY A.AdjustID DESC),A.AdjustID,CONVERT(VARCHAR(10), AdjustDate, 103),CONVERT(VARCHAR(10), EnterDate, 103) AS NgayCT,AD.DAcc,AD.CAcc,KH.CustName,MTK.CustName,AccAmt,EmployeeID,AD.Descr FROM AdjustDet AD INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID INNER JOIN Customer KH ON AD.D_CustID = KH.CustID ,(SELECT KH.CustID,KH.CustName,A.AdjustID,AD.AMainID FROM AdjustDet AD INNER JOIN Customer KH ON AD.C_CustID = KH.CustID INNER JOIN Adjust A ON A.AdjustID = AD.AMainID ) AS MTK WHERE MTK.AdjustID = AD.AMainID AND MTK.CustID = AD.C_CustID AND MONTH(A.AdjustDate) = " + thang + " AND YEAR (A.AdjustDate) = " + nam + " AND MONTH(A.EnterDate) = " + thang + " AND YEAR (A.EnterDate) = " + nam + "ORDER BY A.AdjustID DESC";
            sql1 = "SELECT ROW_NUMBER() OVER (ORDER BY A.AdjustID DESC),A.AdjustID,CONVERT(VARCHAR(10), AdjustDate, 103),CONVERT(VARCHAR(10), EnterDate, 103)AS NgayCT,AD.DAcc,AD.CAcc,KH.CustName,MTK.CustName,AccAmt,EmployeeID,AD.Descr FROM AdjustDet AD INNER JOIN Adjust A  ON A.AdjustID = AD.AMainID INNER JOIN Customer KH ON AD.D_CustID = KH.CustID ,(SELECT KH.CustID,KH.CustName,A.AdjustID,AD.AMainID FROM AdjustDet AD INNER JOIN Customer KH ON AD.C_CustID = KH.CustID INNER JOIN Adjust A ON A.AdjustID = AD.AMainID ) AS MTK WHERE MTK.AdjustID = AD.AMainID AND MTK.CustID = AD.C_CustID ORDER BY A.AdjustID DESC";
            if (thang == null || nam == null)
            {
                tblDC = Functions.GetDataToTable(sql1);
            }
            else tblDC = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblDC;
            DataGridView.Columns[1].HeaderText = "STT";
            DataGridView.Columns[2].HeaderText = "Số chứng từ";
            DataGridView.Columns[3].HeaderText = "Ngày ghi sổ";
            DataGridView.Columns[4].HeaderText = "Ngày chứng từ";
            DataGridView.Columns[5].HeaderText = "TK Nợ";
            DataGridView.Columns[6].HeaderText = "TK Có";
            DataGridView.Columns[7].HeaderText = "Khách hàng nợ";
            DataGridView.Columns[8].HeaderText = "Khách hàng có";
            DataGridView.Columns[9].HeaderText = "Số tiền";
            DataGridView.Columns[10].HeaderText = "Nhân viên";
            DataGridView.Columns[11].HeaderText = "Diễn giải";
            DataGridView.RowHeadersVisible = false;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DataGridView.DataSource == null)
            //{
            //    MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            //    return;
            //}
            //if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    var senderGrid = (DataGridView)sender;

            //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.RowIndex >= 0)
            //    {
            //        sochungtu = DataGridView.CurrentRow.Cells["AdjustID"].Value.ToString();
            //        ngay = DataGridView.CurrentRow.Cells["NgayCT"].Value.ToString();
            //        frmChiTietDieuChinh f = new frmChiTietDieuChinh();
            //        f.StartPosition = FormStartPosition.CenterScreen;
            //        f.ShowDialog();
            //    }
            //}
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (DataGridView.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;

            }
            sochungtu = DataGridView.CurrentRow.Cells["AdjustID"].Value.ToString();
            ngay = DataGridView.CurrentRow.Cells["NgayCT"].Value.ToString();
            frmChiTietDieuChinh f = new frmChiTietDieuChinh();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();

        }

        private void tvThoigian_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                String tt = tvThoigian.SelectedNode.Text;
                String[] A = tt.Split('/');
                nam = A[1].Trim();
                String[] xx = A[0].Split(' ');
                thang = xx[1].Trim();
                //MessageBox.Show(xx[1].Trim() + " " + A[1].Trim());
            }
            catch (Exception ex) { }

            Load_DataGridView();
        }
    }
}
