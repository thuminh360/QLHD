using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void xemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemChiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChitiethoadon chitiet = new frmChitiethoadon();
            chitiet.MdiParent = this;
            chitiet.Show();
        }

        private void thêmMớiHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoadon hoadon = new frmHoadon();
            hoadon.MdiParent = this;
            hoadon.Show();
        }

        private void xemHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoadon hoadon = new frmHoadon();
            hoadon.MdiParent = this;
            hoadon.Show();
        }

        private void thêmChiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChitiethoadon chitiet = new frmChitiethoadon();
            chitiet.MdiParent = this;
            chitiet.Show();
        }

        private void xoáChiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChitiethoadon chitiet = new frmChitiethoadon();
            chitiet.MdiParent = this;
            chitiet.Show();
        }
    }
}
