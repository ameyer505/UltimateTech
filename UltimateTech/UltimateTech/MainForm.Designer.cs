/*
 * Created by SharpDevelop.
 * User: alex.meyer
 * Date: 3/11/2013
 * Time: 8:07 AM
 * 
 * Created and Developed by Alex Meyer
 * alex.itguy@gmail.com
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 using System;
 using System.Net;
 using System.Net.Sockets;
 using System.Windows.Forms;
 using System.Net.NetworkInformation;
 using System.Management;
 using System.IO;
 using System.Diagnostics;
 using System.Linq;
 using Microsoft.Win32;
 using System.Security.Permissions;
 using System.Collections;
 using System.Collections.Generic;


 
namespace UltimateTech
{
	partial class MainForm
	{
		 int physRAM = 0;
         int freeRAM = 0;
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tab_control = new System.Windows.Forms.TabControl();
			this.local_computer_tab = new System.Windows.Forms.TabPage();
			this.domain = new System.Windows.Forms.TextBox();
			this.domain_label = new System.Windows.Forms.Label();
			this.cpu_percent_label = new System.Windows.Forms.Label();
			this.ram_inuse_label = new System.Windows.Forms.Label();
			this.current_user = new System.Windows.Forms.TextBox();
			this.current_user_label = new System.Windows.Forms.Label();
			this.cpu_percent = new System.Windows.Forms.TextBox();
			this.ram_ratio = new System.Windows.Forms.TextBox();
			this.cpu_usage = new System.Windows.Forms.ProgressBar();
			this.ram_progress_bar = new System.Windows.Forms.ProgressBar();
			this.computer_name = new System.Windows.Forms.TextBox();
			this.cpu_usage_label = new System.Windows.Forms.Label();
			this.ram_usage_label = new System.Windows.Forms.Label();
			this.computer_name_label = new System.Windows.Forms.Label();
			this.network_tab = new System.Windows.Forms.TabPage();
			this.arp_button = new System.Windows.Forms.Button();
			this.subnet = new System.Windows.Forms.TextBox();
			this.subnet_label = new System.Windows.Forms.Label();
			this.gateway = new System.Windows.Forms.TextBox();
			this.gateway_label = new System.Windows.Forms.Label();
			this.reset_net_button = new System.Windows.Forms.Button();
			this.network_test_button = new System.Windows.Forms.Button();
			this.refresh_button = new System.Windows.Forms.Button();
			this.dns = new System.Windows.Forms.TextBox();
			this.mac_addr = new System.Windows.Forms.TextBox();
			this.ip_addr = new System.Windows.Forms.TextBox();
			this.current_interface = new System.Windows.Forms.TextBox();
			this.current_interface_label = new System.Windows.Forms.Label();
			this.dns_label = new System.Windows.Forms.Label();
			this.mac_addr_label = new System.Windows.Forms.Label();
			this.ip_addr_label = new System.Windows.Forms.Label();
			this.local_storage_tab = new System.Windows.Forms.TabPage();
			this.drive_format = new System.Windows.Forms.TextBox();
			this.drive_label = new System.Windows.Forms.TextBox();
			this.drive_label_label = new System.Windows.Forms.Label();
			this.percent_used_label = new System.Windows.Forms.Label();
			this.percent_used = new System.Windows.Forms.TextBox();
			this.hdd_storage = new System.Windows.Forms.TextBox();
			this.storage_label = new System.Windows.Forms.Label();
			this.hdd_ratio_bar = new System.Windows.Forms.ProgressBar();
			this.drive_format_label = new System.Windows.Forms.Label();
			this.drive_name_combo = new System.Windows.Forms.ComboBox();
			this.chk_dsk = new System.Windows.Forms.Button();
			this.sfc_scan = new System.Windows.Forms.Button();
			this.drive_name_label = new System.Windows.Forms.Label();
			this.software_tab = new System.Windows.Forms.TabPage();
			this.osVersion = new System.Windows.Forms.TextBox();
			this.osVersion_label = new System.Windows.Forms.Label();
			this.program_list = new System.Windows.Forms.ListView();
			this.hardware_tab = new System.Windows.Forms.TabPage();
			this.hardware_list = new System.Windows.Forms.ListView();
			this.device_manager_label = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.devel = new System.Windows.Forms.Label();
			this.linked_in = new System.Windows.Forms.LinkLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputToTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutUltimateTechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tab_control.SuspendLayout();
			this.local_computer_tab.SuspendLayout();
			this.network_tab.SuspendLayout();
			this.local_storage_tab.SuspendLayout();
			this.software_tab.SuspendLayout();
			this.hardware_tab.SuspendLayout();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tab_control
			// 
			this.tab_control.Controls.Add(this.local_computer_tab);
			this.tab_control.Controls.Add(this.network_tab);
			this.tab_control.Controls.Add(this.local_storage_tab);
			this.tab_control.Controls.Add(this.software_tab);
			this.tab_control.Controls.Add(this.hardware_tab);
			this.tab_control.Location = new System.Drawing.Point(12, 23);
			this.tab_control.Name = "tab_control";
			this.tab_control.SelectedIndex = 0;
			this.tab_control.Size = new System.Drawing.Size(385, 209);
			this.tab_control.TabIndex = 0;
			// 
			// local_computer_tab
			// 
			this.local_computer_tab.Controls.Add(this.domain);
			this.local_computer_tab.Controls.Add(this.domain_label);
			this.local_computer_tab.Controls.Add(this.cpu_percent_label);
			this.local_computer_tab.Controls.Add(this.ram_inuse_label);
			this.local_computer_tab.Controls.Add(this.current_user);
			this.local_computer_tab.Controls.Add(this.current_user_label);
			this.local_computer_tab.Controls.Add(this.cpu_percent);
			this.local_computer_tab.Controls.Add(this.ram_ratio);
			this.local_computer_tab.Controls.Add(this.cpu_usage);
			this.local_computer_tab.Controls.Add(this.ram_progress_bar);
			this.local_computer_tab.Controls.Add(this.computer_name);
			this.local_computer_tab.Controls.Add(this.cpu_usage_label);
			this.local_computer_tab.Controls.Add(this.ram_usage_label);
			this.local_computer_tab.Controls.Add(this.computer_name_label);
			this.local_computer_tab.Location = new System.Drawing.Point(4, 22);
			this.local_computer_tab.Name = "local_computer_tab";
			this.local_computer_tab.Padding = new System.Windows.Forms.Padding(3);
			this.local_computer_tab.Size = new System.Drawing.Size(377, 183);
			this.local_computer_tab.TabIndex = 0;
			this.local_computer_tab.Text = "Local Computer";
			this.local_computer_tab.UseVisualStyleBackColor = true;
			// 
			// domain
			// 
			this.domain.Location = new System.Drawing.Point(241, 41);
			this.domain.Name = "domain";
			this.domain.ReadOnly = true;
			this.domain.Size = new System.Drawing.Size(130, 20);
			this.domain.TabIndex = 13;
			// 
			// domain_label
			// 
			this.domain_label.Location = new System.Drawing.Point(195, 44);
			this.domain_label.Name = "domain_label";
			this.domain_label.Size = new System.Drawing.Size(48, 23);
			this.domain_label.TabIndex = 12;
			this.domain_label.Text = "Domain:";
			// 
			// cpu_percent_label
			// 
			this.cpu_percent_label.Location = new System.Drawing.Point(124, 154);
			this.cpu_percent_label.Name = "cpu_percent_label";
			this.cpu_percent_label.Size = new System.Drawing.Size(98, 23);
			this.cpu_percent_label.TabIndex = 11;
			this.cpu_percent_label.Text = "Percentage Used:";
			// 
			// ram_inuse_label
			// 
			this.ram_inuse_label.Location = new System.Drawing.Point(144, 98);
			this.ram_inuse_label.Name = "ram_inuse_label";
			this.ram_inuse_label.Size = new System.Drawing.Size(78, 23);
			this.ram_inuse_label.TabIndex = 10;
			this.ram_inuse_label.Text = "In Use / Total:";
			// 
			// current_user
			// 
			this.current_user.Location = new System.Drawing.Point(94, 41);
			this.current_user.Name = "current_user";
			this.current_user.ReadOnly = true;
			this.current_user.Size = new System.Drawing.Size(98, 20);
			this.current_user.TabIndex = 9;
			// 
			// current_user_label
			// 
			this.current_user_label.Location = new System.Drawing.Point(6, 41);
			this.current_user_label.Name = "current_user_label";
			this.current_user_label.Size = new System.Drawing.Size(100, 23);
			this.current_user_label.TabIndex = 8;
			this.current_user_label.Text = "Current User:";
			// 
			// cpu_percent
			// 
			this.cpu_percent.Location = new System.Drawing.Point(228, 151);
			this.cpu_percent.Name = "cpu_percent";
			this.cpu_percent.ReadOnly = true;
			this.cpu_percent.Size = new System.Drawing.Size(143, 20);
			this.cpu_percent.TabIndex = 7;
			// 
			// ram_ratio
			// 
			this.ram_ratio.Location = new System.Drawing.Point(228, 98);
			this.ram_ratio.Name = "ram_ratio";
			this.ram_ratio.ReadOnly = true;
			this.ram_ratio.Size = new System.Drawing.Size(143, 20);
			this.ram_ratio.TabIndex = 6;
			// 
			// cpu_usage
			// 
			this.cpu_usage.Location = new System.Drawing.Point(94, 124);
			this.cpu_usage.Name = "cpu_usage";
			this.cpu_usage.Size = new System.Drawing.Size(244, 23);
			this.cpu_usage.TabIndex = 5;
			// 
			// ram_progress_bar
			// 
			this.ram_progress_bar.Location = new System.Drawing.Point(94, 67);
			this.ram_progress_bar.Name = "ram_progress_bar";
			this.ram_progress_bar.Size = new System.Drawing.Size(277, 23);
			this.ram_progress_bar.TabIndex = 4;
			// 
			// computer_name
			// 
			this.computer_name.Location = new System.Drawing.Point(94, 12);
			this.computer_name.Name = "computer_name";
			this.computer_name.ReadOnly = true;
			this.computer_name.Size = new System.Drawing.Size(277, 20);
			this.computer_name.TabIndex = 3;
			// 
			// cpu_usage_label
			// 
			this.cpu_usage_label.Location = new System.Drawing.Point(6, 124);
			this.cpu_usage_label.Name = "cpu_usage_label";
			this.cpu_usage_label.Size = new System.Drawing.Size(100, 23);
			this.cpu_usage_label.TabIndex = 2;
			this.cpu_usage_label.Text = "CPU Usage:";
			// 
			// ram_usage_label
			// 
			this.ram_usage_label.Location = new System.Drawing.Point(6, 67);
			this.ram_usage_label.Name = "ram_usage_label";
			this.ram_usage_label.Size = new System.Drawing.Size(100, 23);
			this.ram_usage_label.TabIndex = 1;
			this.ram_usage_label.Text = "RAM Usage:";
			// 
			// computer_name_label
			// 
			this.computer_name_label.Location = new System.Drawing.Point(6, 12);
			this.computer_name_label.Name = "computer_name_label";
			this.computer_name_label.Size = new System.Drawing.Size(100, 23);
			this.computer_name_label.TabIndex = 0;
			this.computer_name_label.Text = "Computer Name:";
			// 
			// network_tab
			// 
			this.network_tab.Controls.Add(this.arp_button);
			this.network_tab.Controls.Add(this.subnet);
			this.network_tab.Controls.Add(this.subnet_label);
			this.network_tab.Controls.Add(this.gateway);
			this.network_tab.Controls.Add(this.gateway_label);
			this.network_tab.Controls.Add(this.reset_net_button);
			this.network_tab.Controls.Add(this.network_test_button);
			this.network_tab.Controls.Add(this.refresh_button);
			this.network_tab.Controls.Add(this.dns);
			this.network_tab.Controls.Add(this.mac_addr);
			this.network_tab.Controls.Add(this.ip_addr);
			this.network_tab.Controls.Add(this.current_interface);
			this.network_tab.Controls.Add(this.current_interface_label);
			this.network_tab.Controls.Add(this.dns_label);
			this.network_tab.Controls.Add(this.mac_addr_label);
			this.network_tab.Controls.Add(this.ip_addr_label);
			this.network_tab.Location = new System.Drawing.Point(4, 22);
			this.network_tab.Name = "network_tab";
			this.network_tab.Padding = new System.Windows.Forms.Padding(3);
			this.network_tab.Size = new System.Drawing.Size(377, 183);
			this.network_tab.TabIndex = 1;
			this.network_tab.Text = "Network";
			this.network_tab.UseVisualStyleBackColor = true;
			// 
			// arp_button
			// 
			this.arp_button.Location = new System.Drawing.Point(201, 125);
			this.arp_button.Name = "arp_button";
			this.arp_button.Size = new System.Drawing.Size(135, 23);
			this.arp_button.TabIndex = 15;
			this.arp_button.Text = "Local Connections (ARP)";
			this.arp_button.UseVisualStyleBackColor = true;
			this.arp_button.Click += new System.EventHandler(this.Arp_buttonClick);
			// 
			// subnet
			// 
			this.subnet.Location = new System.Drawing.Point(6, 98);
			this.subnet.Name = "subnet";
			this.subnet.ReadOnly = true;
			this.subnet.Size = new System.Drawing.Size(166, 20);
			this.subnet.TabIndex = 14;
			this.subnet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// subnet_label
			// 
			this.subnet_label.Location = new System.Drawing.Point(41, 78);
			this.subnet_label.Name = "subnet_label";
			this.subnet_label.Size = new System.Drawing.Size(74, 23);
			this.subnet_label.TabIndex = 13;
			this.subnet_label.Text = "Subnet Mask:";
			// 
			// gateway
			// 
			this.gateway.Location = new System.Drawing.Point(187, 18);
			this.gateway.Name = "gateway";
			this.gateway.ReadOnly = true;
			this.gateway.Size = new System.Drawing.Size(176, 20);
			this.gateway.TabIndex = 12;
			this.gateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// gateway_label
			// 
			this.gateway_label.Location = new System.Drawing.Point(253, 3);
			this.gateway_label.Name = "gateway_label";
			this.gateway_label.Size = new System.Drawing.Size(55, 23);
			this.gateway_label.TabIndex = 11;
			this.gateway_label.Text = "Gateway:";
			// 
			// reset_net_button
			// 
			this.reset_net_button.Location = new System.Drawing.Point(201, 154);
			this.reset_net_button.Name = "reset_net_button";
			this.reset_net_button.Size = new System.Drawing.Size(135, 23);
			this.reset_net_button.TabIndex = 10;
			this.reset_net_button.Text = "Reset Connection";
			this.reset_net_button.UseVisualStyleBackColor = true;
			this.reset_net_button.Click += new System.EventHandler(this.Reset_net_buttonClick);
			// 
			// network_test_button
			// 
			this.network_test_button.Location = new System.Drawing.Point(41, 154);
			this.network_test_button.Name = "network_test_button";
			this.network_test_button.Size = new System.Drawing.Size(94, 23);
			this.network_test_button.TabIndex = 9;
			this.network_test_button.Text = "Network Test";
			this.network_test_button.UseVisualStyleBackColor = true;
			this.network_test_button.Click += new System.EventHandler(this.Button2Click);
			// 
			// refresh_button
			// 
			this.refresh_button.Location = new System.Drawing.Point(41, 125);
			this.refresh_button.Name = "refresh_button";
			this.refresh_button.Size = new System.Drawing.Size(94, 23);
			this.refresh_button.TabIndex = 8;
			this.refresh_button.Text = "Refresh";
			this.refresh_button.UseVisualStyleBackColor = true;
			this.refresh_button.Click += new System.EventHandler(this.Button1Click);
			// 
			// dns
			// 
			this.dns.Location = new System.Drawing.Point(187, 98);
			this.dns.Name = "dns";
			this.dns.ReadOnly = true;
			this.dns.Size = new System.Drawing.Size(176, 20);
			this.dns.TabIndex = 7;
			this.dns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// mac_addr
			// 
			this.mac_addr.Location = new System.Drawing.Point(187, 55);
			this.mac_addr.Name = "mac_addr";
			this.mac_addr.ReadOnly = true;
			this.mac_addr.Size = new System.Drawing.Size(176, 20);
			this.mac_addr.TabIndex = 6;
			this.mac_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ip_addr
			// 
			this.ip_addr.Location = new System.Drawing.Point(6, 55);
			this.ip_addr.Name = "ip_addr";
			this.ip_addr.ReadOnly = true;
			this.ip_addr.Size = new System.Drawing.Size(166, 20);
			this.ip_addr.TabIndex = 5;
			this.ip_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// current_interface
			// 
			this.current_interface.Location = new System.Drawing.Point(6, 18);
			this.current_interface.Name = "current_interface";
			this.current_interface.ReadOnly = true;
			this.current_interface.Size = new System.Drawing.Size(166, 20);
			this.current_interface.TabIndex = 4;
			this.current_interface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// current_interface_label
			// 
			this.current_interface_label.Location = new System.Drawing.Point(41, 3);
			this.current_interface_label.Name = "current_interface_label";
			this.current_interface_label.Size = new System.Drawing.Size(100, 23);
			this.current_interface_label.TabIndex = 3;
			this.current_interface_label.Text = "Current Device:";
			// 
			// dns_label
			// 
			this.dns_label.Location = new System.Drawing.Point(236, 78);
			this.dns_label.Name = "dns_label";
			this.dns_label.Size = new System.Drawing.Size(100, 23);
			this.dns_label.TabIndex = 2;
			this.dns_label.Text = "Primary DNS:";
			// 
			// mac_addr_label
			// 
			this.mac_addr_label.Location = new System.Drawing.Point(236, 41);
			this.mac_addr_label.Name = "mac_addr_label";
			this.mac_addr_label.Size = new System.Drawing.Size(100, 23);
			this.mac_addr_label.TabIndex = 1;
			this.mac_addr_label.Text = "MAC Address:";
			// 
			// ip_addr_label
			// 
			this.ip_addr_label.Location = new System.Drawing.Point(41, 41);
			this.ip_addr_label.Name = "ip_addr_label";
			this.ip_addr_label.Size = new System.Drawing.Size(74, 26);
			this.ip_addr_label.TabIndex = 0;
			this.ip_addr_label.Text = "IP Address:";
			// 
			// local_storage_tab
			// 
			this.local_storage_tab.Controls.Add(this.drive_format);
			this.local_storage_tab.Controls.Add(this.drive_label);
			this.local_storage_tab.Controls.Add(this.drive_label_label);
			this.local_storage_tab.Controls.Add(this.percent_used_label);
			this.local_storage_tab.Controls.Add(this.percent_used);
			this.local_storage_tab.Controls.Add(this.hdd_storage);
			this.local_storage_tab.Controls.Add(this.storage_label);
			this.local_storage_tab.Controls.Add(this.hdd_ratio_bar);
			this.local_storage_tab.Controls.Add(this.drive_format_label);
			this.local_storage_tab.Controls.Add(this.drive_name_combo);
			this.local_storage_tab.Controls.Add(this.chk_dsk);
			this.local_storage_tab.Controls.Add(this.sfc_scan);
			this.local_storage_tab.Controls.Add(this.drive_name_label);
			this.local_storage_tab.Location = new System.Drawing.Point(4, 22);
			this.local_storage_tab.Name = "local_storage_tab";
			this.local_storage_tab.Padding = new System.Windows.Forms.Padding(3);
			this.local_storage_tab.Size = new System.Drawing.Size(377, 183);
			this.local_storage_tab.TabIndex = 2;
			this.local_storage_tab.Text = "Local Storage";
			this.local_storage_tab.UseVisualStyleBackColor = true;
			// 
			// drive_format
			// 
			this.drive_format.Location = new System.Drawing.Point(261, 11);
			this.drive_format.Name = "drive_format";
			this.drive_format.ReadOnly = true;
			this.drive_format.Size = new System.Drawing.Size(100, 20);
			this.drive_format.TabIndex = 16;
			// 
			// drive_label
			// 
			this.drive_label.Location = new System.Drawing.Point(83, 40);
			this.drive_label.Name = "drive_label";
			this.drive_label.ReadOnly = true;
			this.drive_label.Size = new System.Drawing.Size(206, 20);
			this.drive_label.TabIndex = 15;
			// 
			// drive_label_label
			// 
			this.drive_label_label.Location = new System.Drawing.Point(15, 43);
			this.drive_label_label.Name = "drive_label_label";
			this.drive_label_label.Size = new System.Drawing.Size(100, 23);
			this.drive_label_label.TabIndex = 14;
			this.drive_label_label.Text = "Drive Label:";
			// 
			// percent_used_label
			// 
			this.percent_used_label.Location = new System.Drawing.Point(230, 139);
			this.percent_used_label.Name = "percent_used_label";
			this.percent_used_label.Size = new System.Drawing.Size(76, 20);
			this.percent_used_label.TabIndex = 13;
			this.percent_used_label.Text = "Percent Used:";
			// 
			// percent_used
			// 
			this.percent_used.Location = new System.Drawing.Point(312, 136);
			this.percent_used.Name = "percent_used";
			this.percent_used.ReadOnly = true;
			this.percent_used.Size = new System.Drawing.Size(36, 20);
			this.percent_used.TabIndex = 12;
			// 
			// hdd_storage
			// 
			this.hdd_storage.Location = new System.Drawing.Point(83, 72);
			this.hdd_storage.Name = "hdd_storage";
			this.hdd_storage.ReadOnly = true;
			this.hdd_storage.Size = new System.Drawing.Size(263, 20);
			this.hdd_storage.TabIndex = 11;
			// 
			// storage_label
			// 
			this.storage_label.Location = new System.Drawing.Point(15, 69);
			this.storage_label.Name = "storage_label";
			this.storage_label.Size = new System.Drawing.Size(62, 23);
			this.storage_label.TabIndex = 10;
			this.storage_label.Text = "Storage:";
			// 
			// hdd_ratio_bar
			// 
			this.hdd_ratio_bar.Location = new System.Drawing.Point(15, 101);
			this.hdd_ratio_bar.Name = "hdd_ratio_bar";
			this.hdd_ratio_bar.Size = new System.Drawing.Size(331, 23);
			this.hdd_ratio_bar.TabIndex = 9;
			// 
			// drive_format_label
			// 
			this.drive_format_label.Location = new System.Drawing.Point(189, 14);
			this.drive_format_label.Name = "drive_format_label";
			this.drive_format_label.Size = new System.Drawing.Size(100, 23);
			this.drive_format_label.TabIndex = 7;
			this.drive_format_label.Text = "Drive Format:";
			// 
			// drive_name_combo
			// 
			this.drive_name_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.drive_name_combo.FormattingEnabled = true;
			this.drive_name_combo.Location = new System.Drawing.Point(95, 10);
			this.drive_name_combo.Name = "drive_name_combo";
			this.drive_name_combo.Size = new System.Drawing.Size(88, 21);
			this.drive_name_combo.TabIndex = 6;
			this.drive_name_combo.SelectedIndexChanged += new System.EventHandler(this.Drive_name_comboSelectedIndexChanged);
			// 
			// chk_dsk
			// 
			this.chk_dsk.Location = new System.Drawing.Point(121, 136);
			this.chk_dsk.Name = "chk_dsk";
			this.chk_dsk.Size = new System.Drawing.Size(103, 23);
			this.chk_dsk.TabIndex = 5;
			this.chk_dsk.Text = "Schedule ChkDsk";
			this.chk_dsk.UseVisualStyleBackColor = true;
			this.chk_dsk.Click += new System.EventHandler(this.Chk_dskClick);
			// 
			// sfc_scan
			// 
			this.sfc_scan.Location = new System.Drawing.Point(15, 136);
			this.sfc_scan.Name = "sfc_scan";
			this.sfc_scan.Size = new System.Drawing.Size(100, 23);
			this.sfc_scan.TabIndex = 4;
			this.sfc_scan.Text = "Start SFC Scan";
			this.sfc_scan.UseVisualStyleBackColor = true;
			this.sfc_scan.Click += new System.EventHandler(this.Sfc_scanClick);
			// 
			// drive_name_label
			// 
			this.drive_name_label.Location = new System.Drawing.Point(15, 14);
			this.drive_name_label.Name = "drive_name_label";
			this.drive_name_label.Size = new System.Drawing.Size(100, 23);
			this.drive_name_label.TabIndex = 0;
			this.drive_name_label.Text = "Drive Volume:";
			// 
			// software_tab
			// 
			this.software_tab.Controls.Add(this.osVersion);
			this.software_tab.Controls.Add(this.osVersion_label);
			this.software_tab.Controls.Add(this.program_list);
			this.software_tab.Location = new System.Drawing.Point(4, 22);
			this.software_tab.Name = "software_tab";
			this.software_tab.Padding = new System.Windows.Forms.Padding(3);
			this.software_tab.Size = new System.Drawing.Size(377, 183);
			this.software_tab.TabIndex = 3;
			this.software_tab.Text = "Software";
			this.software_tab.UseVisualStyleBackColor = true;
			// 
			// osVersion
			// 
			this.osVersion.Location = new System.Drawing.Point(78, 4);
			this.osVersion.Name = "osVersion";
			this.osVersion.ReadOnly = true;
			this.osVersion.Size = new System.Drawing.Size(293, 20);
			this.osVersion.TabIndex = 2;
			// 
			// osVersion_label
			// 
			this.osVersion_label.Location = new System.Drawing.Point(7, 7);
			this.osVersion_label.Name = "osVersion_label";
			this.osVersion_label.Size = new System.Drawing.Size(69, 23);
			this.osVersion_label.TabIndex = 1;
			this.osVersion_label.Text = "OS Version:";
			// 
			// program_list
			// 
			this.program_list.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.program_list.HoverSelection = true;
			this.program_list.Location = new System.Drawing.Point(6, 37);
			this.program_list.Name = "program_list";
			this.program_list.Size = new System.Drawing.Size(365, 140);
			this.program_list.TabIndex = 0;
			this.program_list.UseCompatibleStateImageBehavior = false;
			this.program_list.View = System.Windows.Forms.View.Details;
			// 
			// hardware_tab
			// 
			this.hardware_tab.Controls.Add(this.hardware_list);
			this.hardware_tab.Controls.Add(this.device_manager_label);
			this.hardware_tab.Location = new System.Drawing.Point(4, 22);
			this.hardware_tab.Name = "hardware_tab";
			this.hardware_tab.Padding = new System.Windows.Forms.Padding(3);
			this.hardware_tab.Size = new System.Drawing.Size(377, 183);
			this.hardware_tab.TabIndex = 4;
			this.hardware_tab.Text = "Hardware";
			this.hardware_tab.UseVisualStyleBackColor = true;
			// 
			// hardware_list
			// 
			this.hardware_list.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.hardware_list.Location = new System.Drawing.Point(7, 19);
			this.hardware_list.Name = "hardware_list";
			this.hardware_list.Size = new System.Drawing.Size(367, 164);
			this.hardware_list.TabIndex = 0;
			this.hardware_list.UseCompatibleStateImageBehavior = false;
			this.hardware_list.View = System.Windows.Forms.View.Details;
			// 
			// device_manager_label
			// 
			this.device_manager_label.Location = new System.Drawing.Point(7, 4);
			this.device_manager_label.Name = "device_manager_label";
			this.device_manager_label.Size = new System.Drawing.Size(100, 23);
			this.device_manager_label.TabIndex = 0;
			this.device_manager_label.Text = "Device Manager:";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			// 
			// devel
			// 
			this.devel.Location = new System.Drawing.Point(12, 235);
			this.devel.Name = "devel";
			this.devel.Size = new System.Drawing.Size(196, 18);
			this.devel.TabIndex = 1;
			this.devel.Text = "Written and Developed by Alex Meyer";
			// 
			// linked_in
			// 
			this.linked_in.AllowDrop = true;
			this.linked_in.LinkArea = new System.Windows.Forms.LinkArea(0, 16);
			this.linked_in.Location = new System.Drawing.Point(297, 235);
			this.linked_in.Name = "linked_in";
			this.linked_in.Size = new System.Drawing.Size(100, 18);
			this.linked_in.TabIndex = 2;
			this.linked_in.TabStop = true;
			this.linked_in.Text = "LinkedIn Profile";
			this.linked_in.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Linked_inLinkClicked);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 24);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(409, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuStrip2
			// 
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 0);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(409, 24);
			this.menuStrip2.TabIndex = 4;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.outputToTextFileToolStripMenuItem,
									this.takeScreenshotToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// outputToTextFileToolStripMenuItem
			// 
			this.outputToTextFileToolStripMenuItem.Name = "outputToTextFileToolStripMenuItem";
			this.outputToTextFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.outputToTextFileToolStripMenuItem.Text = "Output to Text File";
			this.outputToTextFileToolStripMenuItem.Click += new System.EventHandler(this.OutputToTextFileToolStripMenuItemClick);
			// 
			// takeScreenshotToolStripMenuItem
			// 
			this.takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
			this.takeScreenshotToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.takeScreenshotToolStripMenuItem.Text = "Take Screenshot";
			this.takeScreenshotToolStripMenuItem.Click += new System.EventHandler(this.TakeScreenshotToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutUltimateTechToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// aboutUltimateTechToolStripMenuItem
			// 
			this.aboutUltimateTechToolStripMenuItem.Name = "aboutUltimateTechToolStripMenuItem";
			this.aboutUltimateTechToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.aboutUltimateTechToolStripMenuItem.Text = "About UltimateTech";
			this.aboutUltimateTechToolStripMenuItem.Click += new System.EventHandler(this.AboutUltimateTechToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 253);
			this.Controls.Add(this.linked_in);
			this.Controls.Add(this.devel);
			this.Controls.Add(this.tab_control);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.menuStrip2);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(425, 290);
			this.Name = "MainForm";
			this.Text = "UltimateTech";
			this.tab_control.ResumeLayout(false);
			this.local_computer_tab.ResumeLayout(false);
			this.local_computer_tab.PerformLayout();
			this.network_tab.ResumeLayout(false);
			this.network_tab.PerformLayout();
			this.local_storage_tab.ResumeLayout(false);
			this.local_storage_tab.PerformLayout();
			this.software_tab.ResumeLayout(false);
			this.software_tab.PerformLayout();
			this.hardware_tab.ResumeLayout(false);
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem aboutUltimateTechToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem takeScreenshotToolStripMenuItem;
		private System.Windows.Forms.Label subnet_label;
		private System.Windows.Forms.TextBox subnet;
		private System.Windows.Forms.Button arp_button;
		private System.Windows.Forms.Label device_manager_label;
		private System.Windows.Forms.ListView hardware_list;
		private System.Windows.Forms.TabPage hardware_tab;
		private System.Windows.Forms.TextBox osVersion;
		private System.Windows.Forms.Label osVersion_label;
		private System.Windows.Forms.Label gateway_label;
		private System.Windows.Forms.TextBox gateway;
		private System.Windows.Forms.Label domain_label;
		private System.Windows.Forms.TextBox domain;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputToTextFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ListView program_list;
		private System.Windows.Forms.TabPage software_tab;
		
		
		
		private System.Windows.Forms.LinkLabel linked_in;
		private System.Windows.Forms.Label devel;
		private System.Windows.Forms.Button reset_net_button;
		private System.Windows.Forms.Label drive_label_label;
		private System.Windows.Forms.TextBox drive_label;
		private System.Windows.Forms.TextBox percent_used;
		private System.Windows.Forms.Label percent_used_label;
		private System.Windows.Forms.ProgressBar hdd_ratio_bar;
		private System.Windows.Forms.Label storage_label;
		private System.Windows.Forms.TextBox hdd_storage;
		private System.Windows.Forms.Label drive_format_label;
		private System.Windows.Forms.TextBox drive_format;
		private System.Windows.Forms.ComboBox drive_name_combo;
		private System.Windows.Forms.Button sfc_scan;
		private System.Windows.Forms.Button chk_dsk;
		private System.Windows.Forms.Label drive_name_label;
		private System.Windows.Forms.TabPage local_storage_tab;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label ram_inuse_label;
		private System.Windows.Forms.Label cpu_percent_label;
		private System.Windows.Forms.Label current_user_label;
		private System.Windows.Forms.TextBox current_user;
		private System.Windows.Forms.ProgressBar ram_progress_bar;
		private System.Windows.Forms.ProgressBar cpu_usage;
		private System.Windows.Forms.TextBox ram_ratio;
		private System.Windows.Forms.TextBox cpu_percent;
		private System.Windows.Forms.Button network_test_button;
		private System.Windows.Forms.TextBox computer_name;
		private System.Windows.Forms.Button refresh_button;
		private System.Windows.Forms.TextBox current_interface;
		private System.Windows.Forms.TextBox ip_addr;
		private System.Windows.Forms.TextBox mac_addr;
		private System.Windows.Forms.TextBox dns;
		private System.Windows.Forms.Label computer_name_label;
		private System.Windows.Forms.Label ram_usage_label;
		private System.Windows.Forms.Label cpu_usage_label;
		private System.Windows.Forms.Label ip_addr_label;
		private System.Windows.Forms.Label mac_addr_label;
		private System.Windows.Forms.Label dns_label;
		private System.Windows.Forms.Label current_interface_label;
		private System.Windows.Forms.TabPage network_tab;
		private System.Windows.Forms.TabPage local_computer_tab;
		private System.Windows.Forms.TabControl tab_control;
		
	}
}
