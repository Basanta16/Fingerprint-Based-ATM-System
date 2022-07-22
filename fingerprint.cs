using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace atmsystem
{
    public partial class fingerprint : Form
    {

		Bitmap bMap1, bMap2;
		String fBmap, sBmap;
		public fingerprint()
        {
            InitializeComponent();
        }
		#region Default Instance

		private static fingerprint defaultInstance;


		public static fingerprint Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new fingerprint();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}

				return defaultInstance;
			}
		}

		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}

		#endregion
		System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
		System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
		DataSet ds = new DataSet();
		string sql = default(string);
		string fingerprin = default(string);
		DataTable Log_in = new DataTable();
		System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
		private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
			bool comp = ImgComStr(bMap1, bMap2);
			if (comp == true)
			{
				MessageBox.Show("Fingerprint Matched..");
				pin.Default.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Fingerprint doesn't Matched..");
			}
			bool ImgComStr(Bitmap bMap3, Bitmap bMap4)
			{
				MemoryStream Mem = new MemoryStream();
				bMap3.Save(Mem, ImageFormat.Png);
				fBmap = Convert.ToBase64String(Mem.ToArray());
				Mem.Position = 0;
				bMap4.Save(Mem, ImageFormat.Png);
				sBmap = Convert.ToBase64String(Mem.ToArray());
				if (fBmap.Equals(sBmap))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

        private void llblreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			Regs_frm.Default.Show();
			this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			OpenFileDialog opFlag = new OpenFileDialog();
			if (opFlag.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.ImageLocation = opFlag.FileName;
				bMap1 = new Bitmap(opFlag.FileName);
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			OpenFileDialog opFlag = new OpenFileDialog();

			if (opFlag.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.ImageLocation = opFlag.FileName;
				bMap2 = new Bitmap(opFlag.FileName);
			}
		}
    }
}
