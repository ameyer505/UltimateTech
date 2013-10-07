/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 7/8/2013
 * Time: 9:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateTech
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public partial class About : Form
	{
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void About_ok_buttonClick(object sender, EventArgs e)
		{
			this.Dispose();
		}
		
		void About_caLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			String link = "http://www.crypticapplications.com";
			System.Diagnostics.Process.Start(link);
		}
		
		void About_linkedinLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			String link = "http://goo.gl/TW5Da";
			System.Diagnostics.Process.Start(link);
		}
	}
}
