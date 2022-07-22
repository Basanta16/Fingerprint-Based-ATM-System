
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
using System.ComponentModel;




namespace atmsystem
{
	public partial class Login_frm
	{
		Bitmap bMap1, bMap2;
		String fBmap, sBmap;
		public Login_frm()
		{
			InitializeComponent();

		}
		
#region Default Instance
		
		private static Login_frm defaultInstance;
		

		public static Login_frm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Login_frm();
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
		public void btnlogin_Click(System.Object sender, System.EventArgs e)
		{
			fingerprint.Default.Show();
		

		}
		
		public void llblreg_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Regs_frm.Default.Show();
			
			
		}
		
		public void Login_frm_Load(System.Object sender, System.EventArgs e)
		{
			lbldate.Text = DateTime.Now.ToString();
		}
		
		public void GroupBox1_Enter(System.Object sender, System.EventArgs e)
		{
			
		}

        private void txtpin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    
        }
    }

