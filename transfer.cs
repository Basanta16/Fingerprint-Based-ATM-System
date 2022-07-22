using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace atmsystem
{
    public partial class transfer : Form
    {
        public transfer()
        {
            InitializeComponent();
        }
		#region Default Instance

		private static transfer defaultInstance;


		public static transfer Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new transfer();
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
        DataSet dset = new DataSet();
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
		string balance1, balance2;
		int num1;
		int num2;
		int num3;
		int total1, total2;

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			Mainmenu.Default.Show();
			this.Hide();
		}

        private void transfer_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString();
            lblaccno.Text = Mainmenu.Default.lblaccno.Text;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
			string sql1 = default(string);
			string sql2 = default(string);
			string fullname = default(string);
			string lastname = default(string);
			DataTable Log_in1 = new DataTable();
			DataTable Log_in2 = new DataTable();

			try
			{



				con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb";
				sql1 = "SELECT * FROM tblinfo where  account_no = " + txtAcc.Text + "";
				sql2= "SELECT * FROM tblinfo where  account_no = " + lblaccno.Text + "";

				cmd.Connection = con;
				cmd.CommandText = sql1;
				da.SelectCommand = cmd;
				da.Fill(Log_in1);
				if (Log_in1.Rows.Count > 0)
				{
					balance1 = (string)(Log_in1.Rows[0]["balance"]);
					fullname = (string)(Log_in1.Rows[0]["Firstname"]);
					num1 = int.Parse(balance1);
					num2 = int.Parse(txtamount.Text);
					cmd.CommandText = sql2;
					da.Fill(Log_in2);
					if (Log_in2.Rows.Count > 0)
					{
						balance2 = (string)(Log_in2.Rows[0]["balance"]);
						lastname = (string)(Log_in2.Rows[0]["Lastname"]);
						num3 = int.Parse(balance2);
					}
						if (num3 >= num2)
                    {
						if (num2 <= 500)
						{
							MessageBox.Show("You can only transferred above NPR 500....");
						}
						else if (num2 >= 25000)
						{
							MessageBox.Show("You can only transferred below NPR 25,000....");
						}
						else
						{
							
								total1 = num2 + num1;
								total2 = num3 - num2;

							transreceipt.Default.Show();

							transreceipt.Default.lblbal.Text = balance2;
							transreceipt.Default.Label4.Hide();
							transreceipt.Default.lblacc.Text = txtAcc.Text;
							transreceipt.Default.lbldep.Text = num2.ToString();
							transreceipt.Default.lblwith.Text = num2.ToString();
							transreceipt.Default.lblsend.Text = num2.ToString();
							transreceipt.Default.lblnewbalance.Text = total2.ToString();
							transreceipt.Default.lblnewbal.Text = total1.ToString();
							transreceipt.Default.lblname2.Text = fullname;
							transreceipt.Default.lbllname.Text = lastname;

							transreceipt.Default.Label5.Show();
							transreceipt.Default.Label6.Show();

							transreceipt.Default.lbllname.Show();
							transreceipt.Default.lblbal.Show();
							transreceipt.Default.Label4.Hide();
							transreceipt.Default.lblacc.Show();
							transreceipt.Default.lbldep.Hide();
							transreceipt.Default.lblwith.Show();
							transreceipt.Default.lblsend.Show();
							transreceipt.Default.lblnewbalance.Show();
							transreceipt.Default.lblname.Text = Mainmenu.Default.lblname.Text;
							this.Hide();


						}
					}
                    else
                    {
						MessageBox.Show("Insufficient fund to transfer...");
                    }
					
				}
				else
				{


				}






			}
			catch (Exception)
			{
				MessageBox.Show(" Please Enter Amount!");
			}
			txtamount.Text = "";
		}
    }
}
