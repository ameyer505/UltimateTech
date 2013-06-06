/*
 * Created by SharpDevelop.
 * User: alex.meyer
 * Date: 3/11/2013
 * Time: 8:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace ComputerStatus
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Shown += new EventHandler(Form1_Shown);
			backgroundWorker1.DoWork += new DoWorkEventHandler(doWork);
			backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(progressChanged_RAM);
	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void Form1_Shown(object sender, EventArgs e){
			backgroundWorker1.RunWorkerAsync();
		}
		
		void progressChanged_RAM(object sender, ProgressChangedEventArgs e){
			ram_progress_bar.Value = e.ProgressPercentage;
		}		
	
		void doWork(Object sender, DoWorkEventArgs e){
				int ratio = 0;
				while(true){
				this.Invoke(new MethodInvoker(delegate{ratio = getFreeRAM();}));
				backgroundWorker1.ReportProgress(ratio);
				Thread.Sleep(500);
				}
		}
		
		void getCPUUsage(){
			PerformanceCounter cpu = new PerformanceCounter("Processor","% Processor Time","_Total");
			float temp = cpu.NextValue();
			Thread.Sleep(50);
			float usage = cpu.NextValue();
			Thread.Sleep(50);
			usage += cpu.NextValue();
			Thread.Sleep(50);
			usage += cpu.NextValue();
			int use = (int)(usage/3);
			string cpuString = use.ToString();
			cpu_percent.Text = cpuString+"%";
			cpu_usage.Value = use;
		}
	}
}
