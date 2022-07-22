
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



namespace atmsystem
{
	public partial class transreceipt
	{
		public transreceipt()
		{
			InitializeComponent();
		}
		#region Default Instance

		private static transreceipt defaultInstance;


		public static transreceipt Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new transreceipt();
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
		System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
		System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
		DataTable dt = new DataTable();
		string sql1;
		string sql2;
		System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

		private void Button1_Click(object sender, EventArgs e)
        {
			if (lblnewbal.Text == "")
			{


			}
			else
			{

				con.Open();

				int total1 = int.Parse(lblnewbal.Text);
				System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);
				sql2 = "UPDATE tblinfo SET balance=\'" + total1.ToString() + "\'" + " Where Firstname=\'" + lblname2.Text + "\'";
				cmd.CommandText = sql2;
				cmd.Connection = con;
				cmd.ExecuteNonQuery();
				cmd.Dispose();


				con.Close();

				con.Open();

				int total2 = int.Parse(lblnewbalance.Text);
				System.Data.OleDb.OleDbDataAdapter ad1 = new System.Data.OleDb.OleDbDataAdapter("select * from tblinfo", con);

				sql1 = "UPDATE tblinfo SET balance=\'" + total2.ToString() + "\'" + " Where Firstname=\'" + lblname.Text + "\'";
				cmd.CommandText = sql1;
				cmd.Connection = con;
				cmd.ExecuteNonQuery();
				cmd.Dispose();


				con.Close();



			}

			if (MessageBox.Show("Do You Want to Continue Your transaction??", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				Mainmenu.Default.Show();
			}
			else
			{
				MessageBox.Show("Thank You Come Again");

				Login_frm.Default.Show();

			}
			this.Close();
		}

        private void transreceipt_Load(object sender, EventArgs e)
        {
			con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb";
			lbldate.Text = DateTime.Now.ToString();
		}

        private void lblaccno_Click(object sender, EventArgs e)
        {

        }

        private void lblacc_Click(object sender, EventArgs e)
        {

        }

        private void lblwith_Click(object sender, EventArgs e)
        {

        }
    }
}
