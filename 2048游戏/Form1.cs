using System;
using System.Drawing;
using System.Windows.Forms;
namespace _2048游戏
{
    public partial class Form1 : Form
    {
        Label[] btn = new Label[16];
        int[,] value = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        bool change = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                btn[i] = new Label();
                btn[i].Location = new Point(10 + 85 * (i % 4), 10 + 85 * (i / 4));
                btn[i].Size = new Size(80, 80);
                btn[i].Font = new Font("微软雅黑", 18F);
                btn[i].TextAlign = ContentAlignment.MiddleCenter;
                btn[i].BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(btn[i]);
            }
            AddNum();
            AddNum();
            ShowValue();
        }
        private void ShowValue()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    btn[i * 4 + j].Text = "";
                    btn[i * 4 + j].BackColor = SystemColors.Control;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (value[i, j] != 0)
                    {
                        btn[i * 4 + j].Text = value[i, j].ToString();
                        switch (value[i, j])
                        {
                            case 2:
                                btn[i * 4 + j].BackColor = Color.Thistle;
                                break;
                            case 4:
                                btn[i * 4 + j].BackColor = Color.Aqua;
                                break;
                            case 8:
                                btn[i * 4 + j].BackColor = Color.Chartreuse;
                                break;
                            case 16:
                                btn[i * 4 + j].BackColor = Color.Coral;
                                break;
                            case 32:
                                btn[i * 4 + j].BackColor = Color.DarkKhaki;
                                break;
                            case 64:
                                btn[i * 4 + j].BackColor = Color.BlueViolet;
                                break;
                            case 128:
                                btn[i * 4 + j].BackColor = Color.Orchid;
                                break;
                            case 256:
                                btn[i * 4 + j].BackColor = Color.LightSalmon;
                                break;
                            case 512:
                                btn[i * 4 + j].BackColor = Color.Plum;
                                break;
                            case 1024:
                                btn[i * 4 + j].BackColor = Color.Tomato;
                                break;
                            case 2048:
                                btn[i * 4 + j].BackColor = Color.YellowGreen;
                                break;
                            case 4096:
                                btn[i * 4 + j].BackColor = Color.LightCoral;
                                break;
                            case 8192:
                                btn[i * 4 + j].BackColor = Color.LightGray;
                                break;
                        }
                    }
                }
            }
        }
        private void Merge(ref int t1, ref int t2, ref int t3, ref int t4)
        {
            int[] tmp = new int[4] { 0, 0, 0, 0 };
            int count = 0;
            if (t1 != 0)
            {
                tmp[count++] = t1;
            }
            if (t2 != 0)
            {
                tmp[count++] = t2;
            }
            if (t3 != 0)
            {
                tmp[count++] = t3;
            }
            if (t4 != 0)
            {
                tmp[count++] = t4;
            }
            if (tmp[0] == tmp[1])
            {
                tmp[0] *= 2;
                if (tmp[2] == tmp[3])
                {
                    tmp[1] = tmp[2] * 2;
                    tmp[2] = 0;
                }
                else
                {
                    tmp[1] = tmp[2];
                    tmp[2] = tmp[3];
                }
                tmp[3] = 0;
            }
            else if (tmp[1] == tmp[2])
            {
                tmp[1] *= 2;
                tmp[2] = tmp[3];
                tmp[3] = 0;
            }
            else if (tmp[2] == tmp[3])
            {
                tmp[2] *= 2;
                tmp[3] = 0;
            }
            if (t1 != tmp[0])
            {
                t1 = tmp[0];
                change = true;
            }
            if (t2 != tmp[1])
            {
                t2 = tmp[1];
                change = true;
            }
            if (t3 != tmp[2])
            {
                t3 = tmp[2];
                change = true;
            }
            if (t4 != tmp[3])
            {
                t4 = tmp[3];
                change = true;
            }
            if ((t1 > 10000) || (t2 > 10000) || (t3 > 10000) || (t4 > 10000))
            {
                MessageBox.Show("恭喜您完成游戏，按确认键重新开始", "提示");
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        value[i, j] = 0;
                    }
                }
                AddNum();
                AddNum();
                ShowValue();
            }
        }
        private void AddNum()
        {
            Random rd = new Random();
            int rand = 0;
        Do: rand = rd.Next();
            if (value[rand % 4, rand / 7 % 4] != 0)
            {
                goto Do;
            }
            value[rand % 4, rand / 7 % 4] = (2 + 2 * ((int)Math.Sqrt(rand) % 2));
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 37:
                    for (int i = 0; i < 4; i++)
                    {
                        Merge(ref value[i, 0], ref value[i, 1], ref value[i, 2], ref value[i, 3]);
                    }
                    if (change)
                    {
                        AddNum();
                        change = false;
                    }
                    ShowValue();
                    break;
                case 38:
                    for (int i = 0; i < 4; i++)
                    {
                        Merge(ref value[0, i], ref value[1, i], ref value[2, i], ref value[3, i]);
                    }
                    if (change)
                    {
                        AddNum();
                        change = false;
                    }
                    ShowValue();
                    break;
                case 39:
                    for (int i = 0; i < 4; i++)
                    {
                        Merge(ref value[i, 3], ref value[i, 2], ref value[i, 1], ref value[i, 0]);
                    }
                    if (change)
                    {
                        AddNum();
                        change = false;
                    }
                    ShowValue();
                    break;
                case 40:
                    for (int i = 0; i < 4; i++)
                    {
                        Merge(ref value[3, i], ref value[2, i], ref value[1, i], ref value[0, i]);
                    }
                    if (change)
                    {
                        AddNum();
                        change = false;
                    }
                    ShowValue();
                    break;
                case 13:
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            value[i, j] = 0;
                        }
                    }
                    AddNum();
                    AddNum();
                    ShowValue();
                    break;
            }
        }
    }
}