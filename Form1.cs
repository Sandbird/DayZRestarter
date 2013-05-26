using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace DayZRestarter
{
    public partial class Form1 : Form
    {
        Int32 timerRestartTARGET;
        Int32 timercount;
        
        public Form1()
        {
            InitializeComponent();
        }

        public static double ConvertMinutesToMilliseconds(int minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_restart_Tick(object sender, EventArgs e)
        {
            timercount += 1;
            progressBar1.Value = timercount;





            if (timercount == timerRestartTARGET - 30)
            {
                string message = "Server restart in 30 minutes";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd + " -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
            }

            if (timercount == timerRestartTARGET - 15)
            {
                string message = "Server restart in 15 minutes";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd + " -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
                //restart in 15minutes
            }

            if (timercount == timerRestartTARGET - 10)
            {
                string message = "Server restart in 10 minutes";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd + " -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
                //restart in 10minutes
            }

            if (timercount == timerRestartTARGET - 5)
            {
                string message = "Server restart in 5 minutes";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd + " -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
                //restart in 5minutes
            }

            if (timercount == timerRestartTARGET - 2)
            {
                string message = "Server restart in 2 minutes";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd + " -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
                //restart in 2minutes
            }

            if (timercount == timerRestartTARGET - 1)
            {
                string message = "Server restart in 1 minute";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "battlenet\\BattleNET.exe";
                startInfo.Arguments = " -host " + Properties.Settings.Default.ip + " -port " + Properties.Settings.Default.port + " -password " + Properties.Settings.Default.passwd +" -command \"say -1 " + message + "\"";
                process.StartInfo = startInfo;
                process.Start();
           
            }

            if (timercount == timerRestartTARGET)
            {
               // MessageBox.Show("RESTART");
                foreach (Process p in System.Diagnostics.Process.GetProcessesByName(textBox1.Text))
                {
                    
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                        timercount = 0;
                    }
                    catch (Win32Exception winException)
                    {
                        // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException invalidException)
                    {
                        // process has already exited - might be able to let this one go
                    }
                }
            }




            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double minutes;
            Properties.Settings.Default.processname = textBox1.Text;
            Properties.Settings.Default.ip = textBox2.Text;
            Properties.Settings.Default.port = textBox3.Text;
            Properties.Settings.Default.passwd = textBox4.Text;
            Properties.Settings.Default.restarttime = comboBox1.Text;
            Properties.Settings.Default.Save();

            try
            {
                var emptyTextboxes = from tb in this.Controls.OfType<TextBox>() where string.IsNullOrEmpty(tb.Text) select tb;
                if (!emptyTextboxes.Any())
                {
                    
                    timer_restart.Interval = 60000;                        
                    timer_restart.Start();
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    comboBox1.Enabled = false;
                    button_Start.Enabled = false;
                    button2.Enabled = true;
                   
                    timerRestartTARGET = Convert.ToInt32(comboBox1.Text) * 60;
                    timercount = 0;
                    progressBar1.Maximum = timerRestartTARGET + 1;
                }
                else
                {
                    MessageBox.Show("Missing information...Fill all textbox please.");
                }

            }
            catch (Exception)
            {  
                //throw;
            }
                                                                                            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer_restart.Stop();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            button_Start.Enabled = true;
            button2.Enabled = false;
            timercount = 0;
            timerRestartTARGET = 0;
            progressBar1.Value = 0;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.processname;
            textBox2.Text = Properties.Settings.Default.ip;
            textBox3.Text = Properties.Settings.Default.port;
            textBox4.Text = Properties.Settings.Default.passwd;
            comboBox1.Text = Properties.Settings.Default.restarttime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timercount = timerRestartTARGET - 16;
            if (timer_restart.Enabled)
            {
                progressBar1.Value = timercount;
            }
        }



        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }
        private void notifyIcon1_DoubleClick(object sender,
                                     System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Script Files (.bat)|*.bat|All Files (*.*)|*.*";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                label7.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExecuteCommand(label7.Text);

        }

        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
         //   processInfo.CreateNoWindow = false;
      //      processInfo.UseShellExecute = false;
            // *** Redirect the output ***
     //       processInfo.RedirectStandardError = true;
    //        processInfo.RedirectStandardOutput = false;

            process = Process.Start(processInfo);
            process.WaitForExit();

            //// *** Read the streams ***
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            //exitCode = process.ExitCode;

            //Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            //Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            //Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

      
    }
}
