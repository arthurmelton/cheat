using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Memory;
using System.Windows.Forms;


namespace cheat
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static int X = 0x05BB1B48;
        public static int Y = 0x05BB1B38;
        public static int Z = 0x05BB1B48;
        public static int Xoff1 = 0x320;
        public static int Yoff1 = 0x108;
        public static int Xoff2 = 0x1A4;
        public static int Yoff2 = 0x1A0;
        public static string testSZ = "base+0x05CBD978,0,20,160,1A8";
        public static string testSX = "base+0x05CBD978,0,20,160,1A4";
        public static string testSY = "base+0x05CBD978,0,20,160,1A0";

        public static string testPZ = "base+0x05C5C5D0,0,110,160,1A8";
        public static string testPX = "base+0x05C5C5D0,0,110,160,1A4";
        public static string testPY = "base+0x05C5C5D0,0,110,160,1A0";

        public static string testPPitch = "base+0x05C5C5D0,0,240,370,3A0";
        public static string testPYaw = "base+0x05C5C5D0,0,240,370,3A4";
        public static string testPCrouch = "base+0x05C5C5D0,0,110,160,1A0";

        public static string testScore = "base+0x058E0400,18,20,480";

        public static string Jump = "base+0x058DC2C0,30,B10";

        int testSZ1;
        int testSY1;
        int testSX1;
        int testPX1;
        int testPY1;
        int testPZ1;
        int JumpInt;

        //int thisisatest = 0;
        public static int thisisatest1 = 0;

        public static int x;
        public static int y;
        public static int z;

        public static int ppitch;
        public static int pyaw;

        public static string testScoreINT;

        Form2 form = new Form2();

        int PID;
        public Mem meme = new Mem();

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();

        }

        public Form1()
        {
            InitializeComponent();
            //form.Hide();
            PID = meme.getProcIDFromName("LightBearers");
            if (PID > 0)
            {
                button1.Text = "Connected to : " + PID.ToString();
            }
            else
            {
                button1.Text = "Connected to : N/A";
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testSZ1 = meme.readInt(testSZ);
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testSY1 = meme.readInt(testSY);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PID = meme.getProcIDFromName("LightBearers");
            if (PID > 0)
            {
                button1.Text = "Connected to : " + PID.ToString();
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testSX1 = meme.readInt(testSX);
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testPX1 = meme.readInt(testPX);
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testPY1 = meme.readInt(testPY);
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                testPZ1 = meme.readInt(testPZ);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PID = meme.getProcIDFromName("LightBearers");
            if(textBox4.Text != "")
            {
                PID = int.Parse(textBox4.Text.ToString());
            }
            if (PID > 0)
            {
                button1.Text = "Connected to : " + PID.ToString();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (PID > 0 && textBox1.Text.ToString() != "")
            {
                meme.OpenProcess(PID.ToString());
                meme.writeMemory(testPX, "int", textBox1.Text.ToString());
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (PID > 0 && textBox3.Text.ToString() != "")
            {
                meme.OpenProcess(PID.ToString());
                meme.writeMemory(testPZ, "int", textBox3.Text.ToString());
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (PID > 0 && textBox2.Text.ToString() != "")
            {
                meme.OpenProcess(PID.ToString());
                meme.writeMemory(testPY, "int", textBox2.Text.ToString());
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (ch == 13 && textBox1.Text != "")
            {
                if (PID > 0 && textBox1.Text.ToString() != "")
                {
                    meme.OpenProcess(PID.ToString());
                    meme.writeMemory(testPX, "int", textBox1.Text.ToString());
                }
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (ch == 13 && textBox2.Text != "")
            {
                if (PID > 0 && textBox2.Text.ToString() != "")
                {
                    meme.OpenProcess(PID.ToString());
                    meme.writeMemory(testPY, "int", textBox2.Text.ToString());
                }
            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (ch == 13 && textBox3.Text != "")
            {
                if (PID > 0 && textBox3.Text.ToString() != "")
                {
                    meme.OpenProcess(PID.ToString());
                    meme.writeMemory(testPZ, "int", textBox3.Text.ToString());
                }
            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (ch == 13 && textBox4.Text != "")
            {
                if (PID > 0 && textBox4.Text.ToString() != "")
                {
                    meme.OpenProcess(PID.ToString());
                    meme.writeMemory(testScore, "int", textBox4.Text.ToString());
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                meme.OpenProcess(PID.ToString());
                if (checkBox4.Checked == true)
                {
                    meme.writeMemory(testPZ, "int", testPZ1.ToString());
                }
                if (checkBox5.Checked == true)
                {
                    meme.writeMemory(testPY, "int", testPY1.ToString());
                }
                if (checkBox6.Checked == true)
                {
                    meme.writeMemory(testPX, "int", testPX1.ToString());
                }
                if (checkBox3.Checked == true)
                {
                    meme.writeMemory(testSX, "int", testSX1.ToString());
                }
                if (checkBox2.Checked == true)
                {
                    meme.writeMemory(testSY, "int", testSY1.ToString());
                }
                if (checkBox1.Checked == true)
                {
                    meme.writeMemory(testSZ, "int", testSZ1.ToString());
                }
                if (checkBox7.Checked == true)
                {
                    meme.writeMemory(Jump, "int", JumpInt.ToString());
                }
                if (checkBox9.Checked == true)
                {
                    meme.writeMemory(testScore, "int", testScoreINT.ToString());
                }
                if (checkBox8.Checked == true)
                {
                    if(GetAsyncKeyState(Keys.Space) < 0)
                    {
                        int old = meme.readInt(testPZ);
                        int new1 = old + int.Parse(textBox5.Text);

                        meme.writeMemory(testPZ, "int", new1.ToString());
                    }
                }
                //if (GetAsyncKeyState(Keys.Up) < 0)
                //{
                //    if(thisisatest == 10)
                //    {
                //        thisisatest1++;

                //    }
                //    if(thisisatest == 0)
                //    {
                //        thisisatest = 10;
                //    }
                //    thisisatest--;

                //}
                //else
                //{
                //    thisisatest = 10;
                //}
                label4.Text = "Player X : " + meme.readInt(testPX);
                label5.Text = "Player Y : " + meme.readInt(testPY);
                label6.Text = "Player Z : " + meme.readInt(testPZ);
                label7.Text = "Player Score : " + meme.readInt(testScore);
                x = meme.readInt(testPX);
                y = meme.readInt(testPY);
                z = meme.readInt(testPZ);
                ppitch = meme.readInt(testPPitch);
                pyaw = meme.readInt(testPYaw);
            }
        }
        
        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            JumpInt = 1065353216;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int test = meme.readInt(testPY);
            textBox2.Text = test.ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int test = meme.readInt(testPX);
            textBox1.Text = test.ToString();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int test = meme.readInt(testPZ);
            textBox3.Text = test.ToString();
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox10.Checked == true)
            {
                form.Show();
                form.on = true;
            }
            else
            {
                form.Hide();
                form.on = false;
            }
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            int test = meme.readInt(testScore);
            testScoreINT = test.ToString();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (PID > 0 && textBox6.Text.ToString() != "")
            {
                meme.OpenProcess(PID.ToString());
                meme.writeMemory(testScore, "int", textBox6.Text.ToString());
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (ch == 13 && textBox6.Text != "")
            {
                if (PID > 0 && textBox6.Text.ToString() != "")
                {
                    meme.OpenProcess(PID.ToString());
                    meme.writeMemory(testScore, "int", textBox6.Text.ToString());
                }
            }
        }
    }
}
