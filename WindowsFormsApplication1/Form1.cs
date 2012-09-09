using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "http://my.fit.edu/~pcassidy/BUS1601/Linkin%20Park%20-%20What%20I%27ve%20Done.mp3";
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/monday.html");
            label2.Visible = true;
            webBrowser3.Navigate("http://radionsitapp.clanteam.com/facebook.html");
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            panel2.Visible = false; 
            panel3.Visible = false; 
            panel4.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //this.Opacity = 1;
            pictureBox1.Image = WindowsFormsApplication1.Properties.Resources.round_buttons_red_active;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = WindowsFormsApplication1.Properties.Resources.round_buttons_red_deactive;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApplication1.Properties.Resources.round_buttons_yellow_active;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApplication1.Properties.Resources.round_buttons_yellow_deactive;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.facebook.com/radionsit/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://radionsit.clanteam.com/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("http://twitter.com/RadioNSIT/");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Cursor=Cursors.Hand;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Cursor = Cursors.Hand;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Cursor = Cursors.Hand;
        }

        int flag = 1;

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                flag = 0;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                label2.Visible = true;
                axWindowsMediaPlayer1.URL = "http://my.fit.edu/~pcassidy/BUS1601/Linkin%20Park%20-%20What%20I%27ve%20Done.mp3";
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
                flag = 1;
            }
            else { };
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = WindowsFormsApplication1.Properties.Resources.rss_active;
            pictureBox11.Image = WindowsFormsApplication1.Properties.Resources.aboutus_deactive;
            pictureBox10.Image = WindowsFormsApplication1.Properties.Resources.schedule_deactive;
            pictureBox16.Image = WindowsFormsApplication1.Properties.Resources.home_deactive;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = WindowsFormsApplication1.Properties.Resources.rss_deavtive;
            pictureBox11.Image = WindowsFormsApplication1.Properties.Resources.aboutus_deactive;
            pictureBox10.Image = WindowsFormsApplication1.Properties.Resources.schedule_active;
            pictureBox16.Image = WindowsFormsApplication1.Properties.Resources.home_deactive;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = WindowsFormsApplication1.Properties.Resources.rss_deavtive;
            pictureBox11.Image = WindowsFormsApplication1.Properties.Resources.aboutus_active;
            pictureBox10.Image = WindowsFormsApplication1.Properties.Resources.schedule_deactive;
            pictureBox16.Image = WindowsFormsApplication1.Properties.Resources.home_deactive;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Double Click To Maximize";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = WindowsFormsApplication1.Properties.Resources.facebook_active;
            pictureBox14.Image = WindowsFormsApplication1.Properties.Resources.twitter_deactive;
            pictureBox15.Image = WindowsFormsApplication1.Properties.Resources.wordpress_deactive;
            webBrowser3.Navigate("http://radionsitapp.clanteam.com/facebook.html");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = WindowsFormsApplication1.Properties.Resources.facebook_deactive;
            pictureBox14.Image = WindowsFormsApplication1.Properties.Resources.twitter_active;
            pictureBox15.Image = WindowsFormsApplication1.Properties.Resources.wordpress_deactive;
            webBrowser3.Navigate("http://radionsitapp.clanteam.com/twitter.html");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = WindowsFormsApplication1.Properties.Resources.facebook_deactive;
            pictureBox14.Image = WindowsFormsApplication1.Properties.Resources.twitter_deactive;
            pictureBox15.Image = WindowsFormsApplication1.Properties.Resources.wordpress_active;
            webBrowser3.Navigate("http://radionsitapp.clanteam.com/wordpress.html");
        }

        private void monday_Click(object sender, EventArgs e)
        {
            monday.ForeColor = System.Drawing.Color.SaddleBrown;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/monday.html");
        }

        private void Tuesday_Click(object sender, EventArgs e)
        {
            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.SaddleBrown;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/tuesday.html");
        }

        private void Wednesday_Click(object sender, EventArgs e)
        {
            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.SaddleBrown;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/wednesday.html");
        }

        private void Thursday_Click(object sender, EventArgs e)
        {

            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.SaddleBrown;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/thursday.html");
        }

        private void Friday_Click(object sender, EventArgs e)
        {

            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.SaddleBrown;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/friday.html");
        }

        private void Saturday_Click(object sender, EventArgs e)
        {

            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.SaddleBrown;
            Sunday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/saturday.html");
        }

        private void Sunday_Click(object sender, EventArgs e)
        {

            monday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Tuesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Wednesday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Thursday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Friday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Saturday.ForeColor = System.Drawing.Color.DarkGoldenrod;
            Sunday.ForeColor = System.Drawing.Color.SaddleBrown;
            webBrowser2.Navigate("http://radionsitapp.clanteam.com/sunday.html");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = WindowsFormsApplication1.Properties.Resources.rss_deavtive;
            pictureBox11.Image = WindowsFormsApplication1.Properties.Resources.aboutus_deactive;
            pictureBox10.Image = WindowsFormsApplication1.Properties.Resources.schedule_deactive;
            pictureBox16.Image = WindowsFormsApplication1.Properties.Resources.home_active;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

   }
}
