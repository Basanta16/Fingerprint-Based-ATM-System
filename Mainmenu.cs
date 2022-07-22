
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
	public partial class Mainmenu
	{
		public Mainmenu()
		{
			InitializeComponent();
			
		}
		
#region Default Instance
		
		private static Mainmenu defaultInstance;
		
	
		public static Mainmenu Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Mainmenu();
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
		System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
		string sql;
		public void Label4_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			Login_frm.Default.Show();
			this.Hide();
		}
		
		public void Mainmenu_Load(System.Object sender, System.EventArgs e)
		{
			lbldate.Text = DateTime.Now.ToString();


		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			
			
			string sql = default(string);
			DataTable Log_in = new DataTable();
			try
			{
				
				
				
				
				con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb";
				sql = "SELECT * FROM tblinfo where  account_no = " + lblaccno.Text + "";
				
				cmd.Connection = con;
				cmd.CommandText = sql;
				da.SelectCommand = cmd;
				da.Fill(Log_in);
				if (Log_in.Rows.Count > 0)
				{
					string balance = default(string);
					string lastname = default(string);

					balance = (string) (Log_in.Rows[0]["balance"]);
					lastname = (string)(Log_in.Rows[0]["Lastname"]);
					Receipt.Default.Show();
					Receipt.Default.lblnewbal.Hide();
					Receipt.Default.lblname.Text = lblname.Text;
					Receipt.Default.lbllname.Text = lastname;
					Receipt.Default.lbllname.Show();
					Receipt.Default.lblbal.Text = balance;
					Receipt.Default.lblbal.Show();
					Receipt.Default.Label4.Hide();
					Receipt.Default.Label3.Hide();
					Receipt.Default.lbldep.Hide();
					Receipt.Default.lblwith.Hide();
					Receipt.Default.Label6.Hide();


					this.Hide();
					
					
				}
				else
				{
					MessageBox.Show("Pincode is incorrect");
					
				}
				
				
				
				
				
				
			}
			catch (Exception ex)
			{
				
				MessageBox.Show(ex.Message);
			}
			
			
		}
		
		public void btnwith_Click(System.Object sender, System.EventArgs e)
		{
			Withdraw.Default.Show();
			this.Hide();
			
		}
		
		public void btndep_Click(System.Object sender, System.EventArgs e)
		{
			Deposit.Default.Show();
			this.Hide();
		}
		
		public void lblname_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void GroupBox1_Enter(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			
		}

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
			transfer.Default.Show();
			this.Hide();
		}

        private void lbllname_Click(object sender, EventArgs e)
        {

        }
    }
}
