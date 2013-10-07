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
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Collections;

namespace UltimateTech
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
			setupTabs();
			Shown += new EventHandler(Form1_Shown);
			backgroundWorker1.DoWork += new DoWorkEventHandler(doWork);
			backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(progressChanged_RAM);
	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void setupTabs(){
			setLocal();
			setNetwork();
			setlocalStorage();
			setupSoftwareTab();
			setupHardwareTab();
		}
		
		//Refresh Button
		void Button1Click(object sender, System.EventArgs e)
		{
			setNetwork();
		}
		
		void setNetwork(){
			current_interface.Text = getCurrentInterface();
			ip_addr.Text = getIP().ToString();
			mac_addr.Text = getMAC();
			dns.Text = getDNS();
			subnet.Text = getSubnet(getIP());
		}
		
		void setLocal(){
			computer_name.Text = getComputerName();
			string[] fullName = getCurrentUser();
			domain.Text = fullName[0];
			current_user.Text = fullName[1];
			getTotalRAM();
		}
		
		void getTotalRAM(){
			ObjectQuery winQuery = new ObjectQuery("SELECT * FROM CIM_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
            ManagementObjectCollection collect = searcher.Get();
              foreach (ManagementObject item in collect)
            {
                physRAM = Convert.ToInt32(item["TotalVisibleMemorySize"]);
               
            }
            physRAM /= 1024;
		}
		
		int getFreeRAM(){
			ObjectQuery winQuery = new ObjectQuery("SELECT * FROM CIM_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
            ManagementObjectCollection collect = searcher.Get();
              foreach (ManagementObject item in collect)
            {
                freeRAM = Convert.ToInt32(item["FreePhysicalMemory"]);
            }
            freeRAM /= 1024;
            double used = physRAM-freeRAM;
			double all = physRAM;
			double dub = (used/all)*100;
			int ratio = (int)dub;
            string ramString = (physRAM-freeRAM)+@" MB / "+physRAM+" MB -> "+ratio+"%";
            ram_ratio.Text = ramString;
            getCPUUsage();
            return ratio;
		}
		
		
		string[] getCurrentUser(){
			string full = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
			string[] split = full.Split('\\');
			return split;
		}
		
		string getComputerName(){
			return System.Windows.Forms.SystemInformation.ComputerName;
		}
		
		string getCurrentInterface(){
			string internet = "";
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface nic in interfaces){
				if(nic.OperationalStatus == OperationalStatus.Up){
					internet = nic.Name;
					gateway.Text = getCurrentGateway();
					break;
				}
			}
			return internet;
		}
		
		string getCurrentGateway(){
			string gateway = "";
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface nic in interfaces){
				if(nic.OperationalStatus == OperationalStatus.Up){
					gateway = nic.GetIPProperties().GatewayAddresses.FirstOrDefault().Address.ToString();
					break;
				}
			}
			return gateway;
		}
		
		IPAddress getIP(){
			IPHostEntry host;
			IPAddress ip = null;
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress addr in host.AddressList){
				if(addr.AddressFamily == AddressFamily.InterNetwork){
					ip = addr;
					break;
					}
				}
			return ip;
		}
		
		string getMAC(){
			string mac = "";
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface nic in interfaces){
				if(nic.OperationalStatus == OperationalStatus.Up){
					mac = nic.GetPhysicalAddress().ToString();
					break;
				}
			}
			string sepMAC = "";
			for(int i = 0; i < 12; i++){
				sepMAC = sepMAC+mac[i];
				if(i%2==1 && i != 11)
					sepMAC = sepMAC+":";
			}
			return sepMAC;
		}
		
		string getDNS(){
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			string dnsServers = "";
			IPInterfaceProperties ipProps = null;
			foreach (NetworkInterface nic in interfaces){
				if(nic.OperationalStatus == OperationalStatus.Up){
					ipProps = nic.GetIPProperties();
					break;
					}
			}
				IPAddressCollection dnsAddr = ipProps.DnsAddresses;
				int numDNS = dnsAddr.Count;
				int i = 0;
				while(i < numDNS-1){
					IPAddress addr = dnsAddr[i];
					dnsServers = dnsServers+addr.ToString()+", ";
					i++;
				}
				dnsServers = dnsServers+dnsAddr[i].ToString();
			return dnsServers;
		}
		
		string getSubnet(IPAddress ip){
			string subnet = "";
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach(NetworkInterface nic in interfaces){
				foreach(UnicastIPAddressInformation unicast in nic.GetIPProperties().UnicastAddresses){
					if(unicast.Address.AddressFamily == AddressFamily.InterNetwork){
						if(ip.Equals(unicast.Address)){
							subnet = unicast.IPv4Mask.ToString();
						}
					}
				}
			}
			return subnet;
		}
		
		
		
		//Network test
		void Button2Click(object sender, EventArgs e)
		{
			Ping ping = new Ping();
			PingReply localReply = ping.Send("127.0.0.1");
			string raw_dns = getDNS();
			string[] dns = raw_dns.Split(',');
			
			
			string reply1 = "";
			string reply2 = "";
			string reply3 = "";
			
			
			if(localReply.Status == IPStatus.Success){
				reply1 = "CONNECTED";
			}
			else{
				reply1 = "NOT CONNECTED";
			}
			
			foreach (string s in dns){
				string temp = s.Replace(" ","");
				PingReply dnsReply = ping.Send(temp);
				reply2 = reply2+temp+" ... ";
				if(dnsReply.Status == IPStatus.Success){
					reply2 = reply2+"CONNECTED\n";
						}
				else{
					reply2 = reply2+"NOT CONNECTED\n";
				}
			}
			
			
			PingReply reply = ping.Send("www.google.com");
			if(reply.Status == IPStatus.Success){
				reply3 = "CONNECTED";
			}
			else{
				reply3 = "NOT CONNECTED";
			}
			MessageBox.Show("Internal NIC: ... "+reply1+"\n\nDNS:\n"+reply2+"\nInternet: ... "+reply3);
		}
		
		void setlocalStorage(){
			DriveInfo[] drive_info = DriveInfo.GetDrives();
			
			foreach (DriveInfo d in drive_info){
				if(d.IsReady == true && d.DriveType != DriveType.Network){
					string name = d.Name;
					drive_name_combo.Items.Add(name);
				}
			}
			drive_name_combo.SelectedIndex = 0;
			DriveInfo initial = drive_info[0];
			drive_format.Text = initial.DriveFormat;
			drive_label.Text = initial.VolumeLabel;
			double init_avail = ((double)(initial.AvailableFreeSpace))/1024/1024/1024;
			double init_total = ((double)(initial.TotalSize))/1024/1024/1024;
			double used = init_total-init_avail;
			hdd_storage.Text = "Used Space: "+used.ToString("#.##")+" GB  /  Total Space: "+init_total.ToString("#.##")+" GB";
			double ratio = ((double)initial.TotalSize-(double)initial.AvailableFreeSpace)/(double)initial.TotalSize;
			hdd_ratio_bar.Value = (int)(ratio*100);
			percent_used.Text = (int)(ratio*100)+"%";
			
		}
		
		void Drive_name_comboSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = (ComboBox)sender;
			string name = (string)combo.SelectedItem;
			DriveInfo drive = null;
			DriveInfo[] drive_info = DriveInfo.GetDrives();
			foreach (DriveInfo d in drive_info){
				if(name.Equals(d.Name) && d.IsReady){
					drive = d;
				drive_label.Text = drive.VolumeLabel;
				drive_format.Text = drive.DriveFormat;
				double avail = ((double)(drive.AvailableFreeSpace))/1024/1024/1024;
				double total = ((double)(drive.TotalSize))/1024/1024/1024;
				hdd_storage.Text = "Used Space: "+(total-avail).ToString("#.##")+" GB  /  Total Space: "+total.ToString("#.##")+" GB";
				double ratio = ((double)drive.TotalSize-(double)drive.AvailableFreeSpace)/(double)drive.TotalSize;
				hdd_ratio_bar.Value = (int)(ratio*100);
				percent_used.Text = (int)(ratio*100)+"%";
				}
			}		
		}
		
		void Sfc_scanClick(object sender, EventArgs e)
		{
			string command = "/C sfc /scannow";
			ProcessStartInfo cmd = new ProcessStartInfo("cmd", command);
			cmd.CreateNoWindow = false;
			Process proc = new Process();
			proc.StartInfo = cmd;
			proc.Start();
		}
		
		void Chk_dskClick(object sender, EventArgs e)
		{
			string name = (string)drive_name_combo.SelectedItem;
			string sub = name.Substring(0,2);
			string command = "/C chkdsk /R "+sub;
			ProcessStartInfo cmd = new ProcessStartInfo("cmd", command);
			cmd.CreateNoWindow = false;
			Process proc = new Process();
			proc.StartInfo = cmd;
			proc.Start();
		}
		
		
		//Resets network connection by running
		//ipconfig /release
		//ipconfig /flushdns
		//ipconfig /renew
		//And restarting network services on the machine
		void Reset_net_buttonClick(object sender, EventArgs e)
		{					
			executeCommand("ipconfig.exe", @"/release");
			executeCommand("net.exe", "stop \"dhcp client\"");
			executeCommand("net.exe", "stop \"dns client\"");
			executeCommand("net.exe", "stop \"network connections\"");
			executeCommand("net.exe", "start \"dhcp client\"");
			executeCommand("net.exe", "start \"dns client\"");
			executeCommand("net.exe", "start \"network connections\"");
			executeCommand("ipconfig.exe", @"/flushdns");
			executeCommand("ipconfig.exe", @"/renew");
			               
		}
		
		//Helper method for reset_net_buttonclick
		void executeCommand(string command, string args){
			Process proc = new Process();
			proc.StartInfo.FileName = command;
			proc.StartInfo.Arguments = args;
			proc.Start();
			proc.WaitForExit();
		}
		
		//Setups up LinkedIn link
		void Linked_inLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			String link = "http://goo.gl/TW5Da";
			System.Diagnostics.Process.Start(link);
		}
		
		void setupSoftwareTab(){
			program_list.GridLines = true;
			program_list.Columns.Add("Program Name:",215, HorizontalAlignment.Center);
			program_list.Columns.Add("Version Number:",-2,HorizontalAlignment.Center);
			string osVer = (from val in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>() select val.GetPropertyValue("Caption")).FirstOrDefault().ToString();
			osVersion.Text = osVer;
			string[] row = new string[2];
			string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
			using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(key)){
				foreach(string progName in reg.GetSubKeyNames()){
					using(RegistryKey regKey = reg.OpenSubKey(progName)){
						try{
							if(!(regKey.GetValue("DisplayName") == null) && 
							   !(regKey.GetValue("DisplayName").ToString().Contains("Security Update")) &&
							  !(regKey.GetValue("DisplayName").ToString().Contains("Update for")) &&
							  !(regKey.GetValue("DisplayName").ToString().Contains("Service Pack"))){
								row[0] = regKey.GetValue("DisplayName").ToString();
								if(!(regKey.GetValue("DisplayVersion") == null)){
									row[1] = regKey.GetValue("DisplayVersion").ToString();
								}
								else{
									row[1] = "Version not specified";
								}
							}
							
						}
						catch(Exception ex){
							
						}
					}
					if(!(row[0] == null) && !(row[0] == "")){
						ListViewItem item = new ListViewItem(row);
						program_list.Items.Add(item);
						}
					Array.Clear(row, 0, row.Length);
				}
			}
		}
		
		
		
		List<string> makeSoftwareList(){
			List<string> softList = new List<string>();
			string[] row = new string[2];
			string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
			using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(key)){
				foreach(string progName in reg.GetSubKeyNames()){
					using(RegistryKey regKey = reg.OpenSubKey(progName)){
						try{
							if(!(regKey.GetValue("DisplayName") == null) && 
							   !(regKey.GetValue("DisplayName").ToString().Contains("Security Update")) &&
							  !(regKey.GetValue("DisplayName").ToString().Contains("Update for")) &&
							  !(regKey.GetValue("DisplayName").ToString().Contains("Service Pack"))){
								row[0] = regKey.GetValue("DisplayName").ToString();
								if(!(regKey.GetValue("DisplayVersion") == null)){
									row[1] = regKey.GetValue("DisplayVersion").ToString();
								}
								else{
									row[1] = "Version not specified";
								}
							}
							
						}
						catch(Exception ex){
							
						}
					}
					if(!(row[0] == null) && !(row[0] == "")){
						softList.Add(row[0] + " --- "+row[1]);
						}
					Array.Clear(row, 0, row.Length);
				}
			}
			return softList;
		}
		
		void setupHardwareTab(){
			hardware_list.GridLines = true;
			hardware_list.Columns.Add("Device Name:",215,HorizontalAlignment.Center);
			hardware_list.Columns.Add("Status:",-2,HorizontalAlignment.Center);
			ManagementObjectSearcher deviceList = new ManagementObjectSearcher("Select Name, Status from Win32_PnPEntity");
			string[] row = new string[2];
			if(deviceList != null){
				foreach(ManagementObject device in deviceList.Get()){					
					string name = device.GetPropertyValue("Name").ToString();
					string status = device.GetPropertyValue("Status").ToString();
					if(!(status == null) && !(status == "")){
						row[0] = name;
						row[1] = status;
						ListViewItem item = new ListViewItem(row);
						hardware_list.Items.Add(item);
						Array.Clear(row,0,row.Length);
					}
				}
			}
		}
		
		List<string> makeHardwareList(){
			List<string> hardware = new List<string>();
			ManagementObjectSearcher deviceList = new ManagementObjectSearcher("Select Name, Status from Win32_PnPEntity");
			if(deviceList != null){
				foreach(ManagementObject device in deviceList.Get()){					
					string name = device.GetPropertyValue("Name").ToString();
					string status = device.GetPropertyValue("Status").ToString();
					if(!(status == null) && !(status == "")){
						hardware.Add(name+" --- "+status);
					}
				}
			}
			return hardware;
		}
		
		void writeLogFile(){
			List<string> logFile = new List<string>();
			string[] currentLogOn = getCurrentUser();
			string domain = currentLogOn[0];
			string currentUser = currentLogOn[1];
			string osVer = (from val in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>() select val.GetPropertyValue("Caption")).FirstOrDefault().ToString();
			TextWriter log = new StreamWriter(@"C:\Users\"+currentUser+@"\Desktop\Log.txt");
			logFile.Add("***ULTIMATETECH LOG FILE GENERATED ON "+DateTime.Now.ToString()+"***");
			logFile.Add("");
			logFile.Add("Local Computer:");
			logFile.Add("Operating System: "+osVer);
			logFile.Add("Domain: "+domain);
			logFile.Add("Current User: "+currentUser);
			logFile.Add("Computer Name: "+getComputerName());
			logFile.Add("");
			logFile.Add("Network Information:");
			logFile.Add("Type of Connection: "+getCurrentInterface());
			logFile.Add("MAC Address: "+getMAC());
			logFile.Add("IP: "+getIP().ToString());
			logFile.Add("Gateway: "+ getCurrentGateway());
			logFile.Add("Subnet mask: "+getSubnet(getIP()));
			logFile.Add("ARP:"+arp());
			logFile.Add("");
			logFile.Add("Local Drives:");
			DriveInfo[] drive_info = DriveInfo.GetDrives();
			foreach(DriveInfo d in drive_info){
				if(d.IsReady == true && d.DriveType != DriveType.Network){
					logFile.Add("Drive Letter: "+d.Name);
					logFile.Add("Drive Volume Name: "+d.VolumeLabel);
					logFile.Add("Drive Format: "+d.DriveFormat);
					double totalSpace = (double)(d.TotalSize)/1024/1024/1024;
					double availSpace = (double)(d.AvailableFreeSpace)/1024/1024/1024;
					logFile.Add("Total Space: "+totalSpace.ToString("#.##")+" GB");
					logFile.Add("Free Space: "+availSpace.ToString("#.##")+" GB");
					logFile.Add("");
				}
			}
			logFile.Add("");
			logFile.Add("Software:");
			List<string> softList = makeSoftwareList();
			
			
			foreach(string s in softList){
				logFile.Add(s); 
			}
			
			logFile.Add("");
			logFile.Add("");
			logFile.Add("Hardware:");
			List<string> hardList = makeHardwareList();
			foreach(string s in hardList){
				logFile.Add(s);
			}
			
			logFile.Add("");
			logFile.Add("");
			logFile.Add("***COMPLETION OF LOG FILE***");
			foreach(string s in logFile){
				log.WriteLine(s);
			}
			
			
			log.Close();
			MessageBox.Show("Log.txt has been generated and placed on your desktop");
		}
		
		
		void OutputToTextFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			writeLogFile();
		}
		
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		
		void Arp_buttonClick(object sender, EventArgs e)
		{
			string output = arp();
			MessageBox.Show(output);
		}
		
		string arp(){
			string command = "arp";
			string args = "-a";
			Process proc = new Process();
			proc.StartInfo.FileName = command;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.Arguments = args;
			proc.StartInfo.CreateNoWindow = true;
			proc.Start();
			string output = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit();
			return output;
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
			Thread.Sleep(50);
			usage += cpu.NextValue();
			Thread.Sleep(50);
			usage += cpu.NextValue();
			int use = (int)(usage/5);
			string cpuString = use.ToString();
			cpu_percent.Text = cpuString+"%";
			cpu_usage.Value = use;
		}
		
		void TakeScreenshotToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Hide();
			System.Threading.Thread.Sleep(200);
			string[] user_split = getCurrentUser();
			takeScreenshot().Save(@"C:\Users\"+user_split[1]+@"\Desktop\Screenshot.bmp");
			System.Threading.Thread.Sleep(200);
			this.Show();
			MessageBox.Show("Screenshot.bmp has been saved to your desktop");
		}
		
		Bitmap takeScreenshot(){
			Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
			Graphics screenshotGraphics = Graphics.FromImage(screenshot);
			screenshotGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,Screen.PrimaryScreen.Bounds.Y,0,0,Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
			screenshotGraphics.Dispose();
			return screenshot;
		}
		
		void AboutUltimateTechToolStripMenuItemClick(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog();
		}
	}
}
