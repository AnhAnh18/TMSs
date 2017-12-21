using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Class;

namespace TMS.Forms
{
    public partial class frmKhachhang : Form
    {
        DataTable tblKH;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        String tt, vip;
        public frmKhachhang()
        {
            InitializeComponent();
        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            String sql;
            sql = "SELECT * FROM CUSTOMER KH";
            //sql = "SELECT CustID,CustName,CustType,KH.Address,Fax,VATCode FROM CUSTOMER KH";
            tblKH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKH;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //DataGridView.AllowUserToAddRows = false;
            //DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            //String sql;
            //sql = "SELECT * FROM CUSTOMER KH";
            //tblKH = Functions.GetDataToTable(sql);
            //DataGridView.DataSource = tblKH;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = DataGridView.CurrentRow.Cells["CustID"].Value.ToString();
            txtTenKH.Text = DataGridView.CurrentRow.Cells["CustName"].Value.ToString();
            txtDienthoai.Text = DataGridView.CurrentRow.Cells["Phone"].Value.ToString();
            txtFax.Text = DataGridView.CurrentRow.Cells["Fax"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["Address"].Value.ToString();
            txtDiengiai.Text = DataGridView.CurrentRow.Cells["CustDescr"].Value.ToString();
            txtCMT.Text = DataGridView.CurrentRow.Cells["CMT"].Value.ToString();
            txtMST.Text = DataGridView.CurrentRow.Cells["VATCode"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(Functions.Mydata);
                Functions.Mydata.Update(Functions.table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (chkVIP.Checked == true)
                vip = "1";
            else
                vip = "";
            if (cboTrangthai.Text == "Còn hiệu lực")
            {
                tt = "1";
            }
            else tt = "";
            try
            {
                string sql;
                sql = "SELECT CustID FROM  Customer";
                if (Functions.CheckKey(sql))
                {
                    sql = "UPDATE Customer SET CustName = N'" + txtTenKH.Text +
                                    "', Address = N'" + txtDiachi.Text +
                                    "', CMT = N'" + txtCMT.Text +
                                    "', Phone = N'" + txtDienthoai.Text.Trim().ToString() +
                                    "', Fax = N'" + txtFax.Text.Trim().ToString() +
                                    "', VATCode = N'" + txtMST.Text.Trim().ToString() +
                                    "', CustType = N'" + vip +
                                    "', Status = N'" + tt +
                                    "', CustDescr =N'" + txtDiengiai.Text.Trim().ToString() +
                                    "' WHERE CustID = N'" + txtMaKH.Text + "'";
                    Functions.RunSql(sql);
                    Load_DataGridView();
                    ResetValues();
                }
                else
                {
                    sql = "INSERT INTO Customer(CustID,CustName,Address,CMT,Phone,Fax,VATCode,CustType,Status,CustDescr)  VALUES(N'" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() +
                       "',N'" + txtDiachi.Text +
                       "',N'" + txtCMT.Text.Trim() +
                       "',N'" + txtDienthoai.Text.Trim() +
                       "',N'" + txtFax.Text.Trim() +
                       "',N'" + txtMST.Text.Trim() +
                       "',N'" + vip +
                       "',N'" + tt +
                       "',N'" + txtDiengiai.Text + "')";
                    Functions.RunSql(sql);
                    Load_DataGridView();
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ResetValues()
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    if (C.Text == "")
                    {
                        C.Text = null;
                    }
                }
            }
        }
    }
}
