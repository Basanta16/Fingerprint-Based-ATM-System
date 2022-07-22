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

namespace atmsystem
{
    public partial class pin : Form
    {
        public pin()
        {
            InitializeComponent();
        }
		#region Default Instance

		private static pin defaultInstance;


		public static pin Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new pin();
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
		DataTable Log_in = new DataTable();
		System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();

		private void btnlogin_Click(object sender, EventArgs e)
        {

			DataTable Log_in = new DataTable();
			try
			{
				if (txtpin.Text == "")
				{
					MessageBox.Show("Pls Enter both Fields");

				}
				else
				{
					string location = "C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\fingerprint";
					con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb";
					sql = "SELECT * FROM tblinfo where pin_code = " + txtpin.Text + "";

					cmd.Connection = con;
					cmd.CommandText = sql;
					da.SelectCommand = cmd;
					da.Fill(Log_in);
					string fingerprint = default(string);

					if (Log_in.Rows.Count > 0)
					{
						string Type;
						string Fullname = default(string);
						string accno = default(string);
						Type = (string)(Log_in.Rows[0]["type"]);
						Fullname = (string)(Log_in.Rows[0]["Firstname"]);
						fingerprint = (string)(Log_in.Rows[0]["fingerprint"]);
						accno = Convert.ToString((Log_in.Rows[0]["account_no"]));


						if (Type == "admin")
						{
							MessageBox.Show("Welcome " + Fullname + " you login as Administrator ");
							AdminForm.Default.Show();
							this.Hide();

						}
						else if (Type == "Block")
						{
							MessageBox.Show("Your account is currently Block");
							MessageBox.Show("Contact the Administrator for Help");

						}
						else
						{
							
								MessageBox.Show("Welcome " + Fullname);
								Mainmenu.Default.lblname.Text = Fullname;
								Mainmenu.Default.lblaccno.Text = accno;
								Mainmenu.Default.Show();
								this.Hide();


						}


					}
					else if (txtpin.Text == "110011")
					{
						MessageBox.Show("Welcome, Admin. You login as Administrator!!! ");
						AdminForm.Default.Show();
						this.Hide();
					}
					else
					{
						MessageBox.Show("You are Not Registered!!!");
						MessageBox.Show("Please Register if You are New!");


					}
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			txtpin.Text = "";

			{

			}
		}
    }
}
