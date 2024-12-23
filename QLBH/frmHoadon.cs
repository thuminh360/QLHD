using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmHoadon : Form
    {
        string sCon = "Data Source=DESKTOP-4GIP8O2\\MINH;Initial Catalog=QLBH;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        public frmHoadon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtngay_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmHoadon_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Hẹn gặp lại lần sau!", "Thông báo");
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();

                string snvid = txtnvid.Text;
                string sbstt = txtbstt.Text;
                string sngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string stong = txttong.Text;
                string skm = txtkm.Text;

                // Lấy mã FHDID
                string sQuery1 = "select DBO.FHDID()";
                SqlCommand cmd1 = new SqlCommand(sQuery1, con);
                object result1 = cmd1.ExecuteScalar();
                string shdid = result1 != null ? result1.ToString() : "";


                // Thêm dữ liệu vào bảng hoadon
                string sInsertQuery = "insert into hoadon (HD_ID, NV_ID, B_STT, HD_DATE, HD_TONG, HD_KM) values (@HD_ID, @NV_ID, @B_STT, @HD_DATE, @HD_TONG, @HD_KM)";
                SqlCommand insertcmd = new SqlCommand(sInsertQuery, con);
                insertcmd.Parameters.AddWithValue("@HD_ID", shdid);
                insertcmd.Parameters.AddWithValue("@NV_ID", snvid);
                insertcmd.Parameters.AddWithValue("@B_STT", sbstt);
                insertcmd.Parameters.AddWithValue("@HD_DATE", sngay);
                insertcmd.Parameters.AddWithValue("@HD_TONG", stong);
                insertcmd.Parameters.AddWithValue("@HD_KM", skm);

                // Thực thi lệnh thêm
                try
                {
                    insertcmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        
    } 

        private void frmHoadon_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Lấy dlieu về
            string sQuery = "select * from hoadon";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "hoadon");

            dataGridView1.DataSource = ds.Tables["hoadon"];

            con.Close();
        }

        private void txtnvid_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbstt.Text = dataGridView1.Rows[e.RowIndex].Cells["B_STT"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["HD_DATE"].Value);
            txttong.Text = dataGridView1.Rows[e.RowIndex].Cells["HD_TONG"].Value.ToString();
            txtkm.Text = dataGridView1.Rows[e.RowIndex].Cells["HD_KM"].Value.ToString();

            
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            string sQuery = "select * from Hoadon";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Hoadon");
            if (ds.Tables["Hoadon"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["Hoadon"];
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
            dataGridView1.DataSource = ds.Tables["Hoadon"];
            con.Close();
        }
    }
}
