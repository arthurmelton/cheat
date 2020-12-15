using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Memory;

namespace cheat
{
    public partial class Form2 : Form
    {
        public const string WINDOW_NAME = "LightBearers (64-bit Development PCD3D_SM5) ";
        //public const string WINDOW_NAME = "Medal";

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static IntPtr handle = FindWindow(null, WINDOW_NAME);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool GetWindowRect(IntPtr hwnd, out RECT IpRect);

        public static RECT rect;
        public struct RECT
        {
            public int left, top, right, bottom;
        }

        int formwidth;
        int formheight;
        int formwidthL;
        int formheightL;

        public bool on = true;

        public Form2()
        {
            InitializeComponent();

        }

        public Mem meme = new Mem();

        private void Form2_Load(object sender, EventArgs e)
        {
            formwidth = panel1.Width;
            formheight = panel1.Height;
            formwidthL = panel1.Location.X;
            formheightL = panel1.Location.Y;

            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x8000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Size = new Size(rect.right - rect.left, rect.bottom - (rect.top + 40));
            this.Left = rect.left + 8;

            this.Top = rect.top + 32;
            timer1.Enabled = true;

            //float nWidth = ((rect.right - rect.left) / 1360f)*formwidth;
            //float nHeigt = ((rect.bottom - (rect.top + 40)) / 768f) * formheight;

            //panel1.Size = new Size((int)Math.Round(nWidth), (int)Math.Round(nHeigt));

            //float nWidthL = ((rect.right - rect.left) / 1360f) * formwidthL;
            //float nHeigtL = ((rect.bottom - (rect.top + 40)) / 768f) * formheightL;

            //panel1.Location = new Point((int)Math.Round(nWidthL), (int)Math.Round(nHeigtL));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (on)
            {
                GetWindowRect(handle, out rect);
                this.Size = new Size(rect.right - rect.left, rect.bottom - (rect.top + 40));
                //this.TopMost = true;
                this.Left = rect.left + 8;
                this.Top = rect.top + 32;
                //float nWidth = ((rect.right - rect.left) / 1360f) * formwidth;
                //float nHeigt = ((rect.bottom - (rect.top + 40)) / 768f) * formheight;

                //panel1.Size = new Size((int)Math.Round(nWidth), (int)Math.Round(nHeigt));

                //float nWidthL = ((rect.right - rect.left) / 1360f) * formwidthL;
                //float nHeigtL = ((rect.bottom - (rect.top + 40)) / 768f) * formheightL;

                //panel1.Location = new Point((int)Math.Round(nWidthL), (int)Math.Round(nHeigtL));
            }
            else
            {
                //this.TopMost = false;
                this.Hide();
            }

            label1.Text = "Player X : " + Form1.x;
            label2.Text = "Player Y : " + Form1.y;
            label3.Text = "Player Z : " + Form1.z;
            label4.Text = "Player Pitch : " + Form1.ppitch;
            label5.Text = "Player Yaw : " + Form1.pyaw;
            //label6.Text = "Number : " + Form1.thisisatest1;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
