/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 7/8/2013
 * Time: 9:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UltimateTech
{
	partial class About
	{
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
			this.about_created_label = new System.Windows.Forms.Label();
			this.about_email_label = new System.Windows.Forms.Label();
			this.about_dev_label = new System.Windows.Forms.Label();
			this.about_ok_button = new System.Windows.Forms.Button();
			this.about_created = new System.Windows.Forms.TextBox();
			this.about_contact = new System.Windows.Forms.TextBox();
			this.about_caLink = new System.Windows.Forms.LinkLabel();
			this.about_linkedin = new System.Windows.Forms.LinkLabel();
			this.about_version_label = new System.Windows.Forms.Label();
			this.about_version = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// about_created_label
			// 
			this.about_created_label.Location = new System.Drawing.Point(13, 13);
			this.about_created_label.Name = "about_created_label";
			this.about_created_label.Size = new System.Drawing.Size(100, 23);
			this.about_created_label.TabIndex = 0;
			this.about_created_label.Text = "Created by:";
			// 
			// about_email_label
			// 
			this.about_email_label.Location = new System.Drawing.Point(13, 40);
			this.about_email_label.Name = "about_email_label";
			this.about_email_label.Size = new System.Drawing.Size(100, 23);
			this.about_email_label.TabIndex = 1;
			this.about_email_label.Text = "Contact Email:";
			// 
			// about_dev_label
			// 
			this.about_dev_label.Location = new System.Drawing.Point(13, 67);
			this.about_dev_label.Name = "about_dev_label";
			this.about_dev_label.Size = new System.Drawing.Size(109, 23);
			this.about_dev_label.TabIndex = 2;
			this.about_dev_label.Text = "Development Group:";
			// 
			// about_ok_button
			// 
			this.about_ok_button.Location = new System.Drawing.Point(119, 139);
			this.about_ok_button.Name = "about_ok_button";
			this.about_ok_button.Size = new System.Drawing.Size(129, 28);
			this.about_ok_button.TabIndex = 3;
			this.about_ok_button.Text = "OK";
			this.about_ok_button.UseVisualStyleBackColor = true;
			this.about_ok_button.Click += new System.EventHandler(this.About_ok_buttonClick);
			// 
			// about_created
			// 
			this.about_created.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_created.Location = new System.Drawing.Point(119, 13);
			this.about_created.Name = "about_created";
			this.about_created.ReadOnly = true;
			this.about_created.Size = new System.Drawing.Size(129, 20);
			this.about_created.TabIndex = 4;
			this.about_created.Text = "Alex Meyer";
			// 
			// about_contact
			// 
			this.about_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_contact.Location = new System.Drawing.Point(119, 40);
			this.about_contact.Name = "about_contact";
			this.about_contact.ReadOnly = true;
			this.about_contact.Size = new System.Drawing.Size(129, 20);
			this.about_contact.TabIndex = 5;
			this.about_contact.Text = "alex.itguy@gmail.com";
			// 
			// about_caLink
			// 
			this.about_caLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_caLink.Location = new System.Drawing.Point(119, 67);
			this.about_caLink.Name = "about_caLink";
			this.about_caLink.Size = new System.Drawing.Size(129, 23);
			this.about_caLink.TabIndex = 6;
			this.about_caLink.TabStop = true;
			this.about_caLink.Text = "Cryptic Applications";
			this.about_caLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.About_caLinkLinkClicked);
			// 
			// about_linkedin
			// 
			this.about_linkedin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_linkedin.Location = new System.Drawing.Point(119, 94);
			this.about_linkedin.Name = "about_linkedin";
			this.about_linkedin.Size = new System.Drawing.Size(100, 23);
			this.about_linkedin.TabIndex = 7;
			this.about_linkedin.TabStop = true;
			this.about_linkedin.Text = "LinkedIn Profile";
			this.about_linkedin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.About_linkedinLinkClicked);
			// 
			// about_version_label
			// 
			this.about_version_label.Location = new System.Drawing.Point(13, 116);
			this.about_version_label.Name = "about_version_label";
			this.about_version_label.Size = new System.Drawing.Size(100, 23);
			this.about_version_label.TabIndex = 8;
			this.about_version_label.Text = "Version:";
			// 
			// about_version
			// 
			this.about_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.about_version.Location = new System.Drawing.Point(119, 116);
			this.about_version.Name = "about_version";
			this.about_version.ReadOnly = true;
			this.about_version.Size = new System.Drawing.Size(129, 20);
			this.about_version.TabIndex = 9;
			this.about_version.Text = "1.0";
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 174);
			this.Controls.Add(this.about_version);
			this.Controls.Add(this.about_version_label);
			this.Controls.Add(this.about_linkedin);
			this.Controls.Add(this.about_caLink);
			this.Controls.Add(this.about_contact);
			this.Controls.Add(this.about_created);
			this.Controls.Add(this.about_ok_button);
			this.Controls.Add(this.about_dev_label);
			this.Controls.Add(this.about_email_label);
			this.Controls.Add(this.about_created_label);
			this.Name = "About";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox about_version;
		private System.Windows.Forms.Label about_version_label;
		private System.Windows.Forms.LinkLabel about_linkedin;
		private System.Windows.Forms.LinkLabel about_caLink;
		private System.Windows.Forms.TextBox about_contact;
		private System.Windows.Forms.TextBox about_created;
		private System.Windows.Forms.Button about_ok_button;
		private System.Windows.Forms.Label about_dev_label;
		private System.Windows.Forms.Label about_email_label;
		private System.Windows.Forms.Label about_created_label;
		}
}
