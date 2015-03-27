/*
 * Created by SharpDevelop.
 * User: anakin
 * Date: 3/27/2015
 * Time: 1:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace androidhelper
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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void picMouseMove(object sender, MouseEventArgs e)
		{
			
		}
		void picMouseClick(object sender, MouseEventArgs e)
		{
			this.Text = e.X.ToString() + " " + e.Y.ToString();
			var proc1 = new ProcessStartInfo();
	        string anyCommand; 
	        proc1.UseShellExecute = true;
	
	        proc1.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
	
	        proc1.FileName = @"C:\Windows\System32\cmd.exe";
	        proc1.Verb = "runas";
	        proc1.Arguments = "/c adb shell input touchscreen tap " + e.X.ToString() + " " + e.Y.ToString();
	        proc1.WindowStyle = ProcessWindowStyle.Hidden;
	        Process.Start(proc1);
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			
		}
		
		void runcmd(string cmd){
			var proc1 = new ProcessStartInfo();
	        proc1.UseShellExecute = true;
	
	        proc1.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
	
	        proc1.FileName = @"C:\Windows\System32\cmd.exe";
	        proc1.Verb = "runas";
	        proc1.Arguments = "/c " + cmd;
	        proc1.WindowStyle = ProcessWindowStyle.Hidden;
	        Process.Start(proc1);

		}
		void Button1Click(object sender, EventArgs e)
		{
			runcmd("adb shell input trackball roll 0 -2");
		}
		void Button2Click(object sender, EventArgs e)
		{
			runcmd("adb shell input trackball roll 0 2");
		}
		void Button3Click(object sender, EventArgs e)
		{
			try{
				this.Text = "trying...";
				
					
					
				if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\screen.png")){
					if(pictureBox1.Image != null){
						pictureBox1.Image.Dispose();
						pictureBox1.Image = null;
						
					}
					File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\screen.png");
				}
					runcmd("adb shell screencap -p /sdcard/screen.png");
					Thread.Sleep(500);
					runcmd("adb pull /sdcard/screen.png");
					Thread.Sleep(1000);
					//runcmd("adb shell rm /sdcard/screen.png");
					//Thread.Sleep(1000);
					
					pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\screen.png");
					this.Text = "done...";
				
			}catch(Exception ex){
				Debug.Print(ex.Message);
				this.Text = ex.Message;
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
				runcmd("adb shell input text "+textBox1.Text);
		}
		void Button5Click(object sender, EventArgs e)
		{
			runcmd("adb shell input keyevent ENTER");
		}
	}
}
