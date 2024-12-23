using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLBH
{
    public partial class frmChitiethoadon : Form
    {
        string sCon = "Data Source=DESKTOP-4GIP8O2\\MINH;Initial Catalog=QLBH;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        public frmChitiethoadon()
        {
            InitializeComponent();
        }

        private void frmChitiethoadon_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Hẹn gặp lại lần sau!");
        }

        private void frmChitiethoadon_Load(object sender, EventArgs e)
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
            string sQuery = "select * from Chitiethoadon";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Chitiethoadon");

            dataGridView1.DataSource = ds.Tables["Chitiethoadon"];

            con.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
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

            string scthdid = txtcthdid.Text;
            string shdid = txthdid.Text;
            string smonid = txtmonid.Text;
            string ssoluong = txtsl.Text;

            string sQuery = "insert into Chitiethoadon values(@CTHD_ID,@HD_ID,@MON_ID,@CTHD_SL)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@CTHD_ID", scthdid);
            cmd.Parameters.AddWithValue("@HD_ID", shdid);
            cmd.Parameters.AddWithValue("@MON_ID", smonid);
            cmd.Parameters.AddWithValue("@CTHD_SL", ssoluong);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới");
            }
            con.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Có chắc chắn xoá không", "Thông báo", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
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
                string scthdid = txtcthdid.Text;

                string sQuery = "Delete Chitiethoadon Where CTHD_ID = @CTHD_ID";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@CTHD_ID", scthdid);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xoá thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình Xoá");
                }
                con.Close();
            }
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
            string sQuery = "select * from Chitiethoadon";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Chitiethoadon");
            if (ds.Tables["Chitiethoadon"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["Chitiethoadon"];
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
            dataGridView1.DataSource = ds.Tables["Chitiethoadon"];
            con.Close();
        }
    }
}
