
using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.IO;




namespace atmsystem
{
	public partial class Regs_frm
	{
		public Regs_frm()
		{
	
			constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\ATMsystem.accdb";
			conn = new System.Data.OleDb.OleDbConnection(constr);
			
			InitializeComponent();
			

		}
		
#region Default Instance
		
		private static Regs_frm defaultInstance;
		
		
		public static Regs_frm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Regs_frm();
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
		string constr; 
		System.Data.OleDb.OleDbDataAdapter adapt;
		System.Data.OleDb.OleDbDataAdapter adapt1 = new System.Data.OleDb.OleDbDataAdapter();
		System.Data.OleDb.OleDbConnection conn;
		DataSet dset = new DataSet();
		
		
		public void btnRegister_Click(System.Object sender, System.EventArgs e)
		{
			if (txtAcctNo.Text == "" && txtPincode.Text == "" && txtcontact.Text == "" && txtfname.Text == "" && txtlname.Text == "" && txtaddr.Text == "" && txtcontact.Text == "" && cbGender.Text == "" && cbday.Text == "" && cbmonth.Text == "" && cbyear.Text == "")
			{
				MessageBox.Show("Enter All Fields");
				
			}
			else if (txtAcctNo.Text == "" || txtPincode.Text == "" || txtcontact.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtaddr.Text == "" || txtcontact.Text == "" || cbGender.Text == "" || cbday.Text == "" || cbmonth.Text == "" || cbyear.Text == "")
			{
				MessageBox.Show("Pls Complete all Fields");
				
			}
			else
			{
				System.Data.OleDb.OleDbDataAdapter adapt1 = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo where Firstname=\'" + txtfname.Text + "\'", conn);
				DataSet dset1 = new DataSet();
				adapt1.Fill(dset1);
				if (dset1.Tables[0].Rows.Count != 0)
				{
					MessageBox.Show("Account name already exist");
				}
				else
				{
					OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb");
					string location = "C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\fingerprint";
					string path = Path.Combine(location, txtPincode.Text + ".bmp");
					con.Open();
					OleDbCommand cmd = new OleDbCommand("INSERT into tblinfo values (@account_no, @Firstname, @Lastname, @Address, @Contact_no, @Gender, @Birthday, @pin_code, @type, @balance, @Fingerprint, @Bank)", con);
					cmd.Parameters.AddWithValue("@account_no", int.Parse(txtAcctNo.Text));
					cmd.Parameters.AddWithValue("@Firstname", txtfname.Text);
					cmd.Parameters.AddWithValue("@Lastname", txtlname.Text);
					cmd.Parameters.AddWithValue("@Address", txtaddr.Text);
					cmd.Parameters.AddWithValue("@Contact_no", Int64.Parse(txtcontact.Text));
					cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
					cmd.Parameters.AddWithValue("@Birthday", (cbyear.Text + cbmonth.Text + cbday.Text));
					cmd.Parameters.AddWithValue("@pin_code", int.Parse(txtPincode.Text));
					cmd.Parameters.AddWithValue("@type", "Active");
					cmd.Parameters.AddWithValue("@balance", "1000");
					cmd.Parameters.AddWithValue("@Fingerprint", path);
					cmd.Parameters.AddWithValue("@Bank", txtBank.Text);
					Image a = pictureBox1.Image;
					cmd.ExecuteNonQuery();
					a.Save(path);
					MessageBox.Show("Fingerprint Added Successfully");
					MessageBox.Show("The Registration has been Completed. Now You Can Proceed.");
					this.Hide();
					Login_frm.Default.Show();
				}
			}

			
		}
		
		public void Regs_frm_Load(System.Object sender, System.EventArgs e)
		{
			lbldate.Text = DateTime.Now.ToString();
			
			conn.ConnectionString = constr;
			conn.Open();
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
			Login_frm.Default.Show();
		}

        private void txtAcctNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
			
        }

        private void button2_Click(object sender, EventArgs e)
        {
	
		}

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
			OpenFileDialog open = new OpenFileDialog();
			PictureBox p = sender as PictureBox;
			if (p != null)
			{
				open.Filter = "(*.bmp;) | *.bmp;";
				if (open.ShowDialog() == DialogResult.OK)
				{
					p.Image = Image.FromFile(open.FileName);
				}
			}
		}

        private void Button1_Click_1(object sender, EventArgs e)
        {
			Login_frm.Default.Show();
			this.Hide();
        }
    }
}
