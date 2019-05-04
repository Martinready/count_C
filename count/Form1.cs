using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace count
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //total:總金額,type:項目所花總費用,used:本次項目當下費用

        static void UsedMoney(ref int total, ref int type, int used,int use)
        {
            // (new)total= (old)total-use
            total -= use;
            // (new)type= (old)type-use
            type += use;
            


            //紀錄檔案資料
        }
        //

        //COMBOBOX
        public class cboDataList
        {
            public string cbo_Name { get; set; }
            public string cbo_Value { get; set; }
        }
        //運算值變數
        public static int TotalMoney = 0, eat = 0, cloth = 0, house = 0, traffic = 0, used,use=0;


        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化設定
            start();
            
            //在combobox1選單中加入選項
            List<cboDataList> lis_DataList = new List<cboDataList>()
            {
                new cboDataList
                {
                    cbo_Name = "收入",
                    cbo_Value = "1"
                },
                new cboDataList
                {
                    cbo_Name = "支出",
                    cbo_Value = "2"
                },
                
            };

            comboBox1.DataSource = lis_DataList;
            comboBox1.DisplayMember = "cbo_Name";
            comboBox1.ValueMember = "cbo_Value";
        }
        private void start()
        {

            //取消 收入與支出欄位輸入功能
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;






        }


        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //假設選單項目是空的不出錯
            if (comboBox1.SelectedValue == null)
            {
                return;
            }
            //選單變數
            string buy_sell_value = comboBox1.SelectedValue.ToString();
            //MessageBox.Show(buy_sell_value);
            switch (buy_sell_value)
            {
                //項目1:收入
                case "1":
                    comboBox1.BackColor = Color.Red;
                    check1();
                    MessageBox.Show("開始記錄收入");
                    //選單2加入項目,與項目2的內容會不同
                    List<cboDataList> lis_DataList1 = new List<cboDataList>()
            {

                new cboDataList
                {
                    cbo_Name = "薪水",
                    cbo_Value = "1"
                },
                new cboDataList
                {
                    cbo_Name = "獎金",
                    cbo_Value = "2"
                },

            };

                    comboBox2.DataSource = lis_DataList1;
                    comboBox2.DisplayMember = "cbo_Name";
                    comboBox2.ValueMember = "cbo_Value";
                    break;
                    //項目:支出
                case "2":
                    comboBox1.BackColor = Color.Blue;
                    check2();
                    MessageBox.Show("開始記錄支出");

                    //選單2加入項目,與項目1的內容會不同
                        List<cboDataList> lis_DataList = new List<cboDataList>()
            {
                        
                new cboDataList
                {
                    cbo_Name = "飲食",
                    cbo_Value = "1"
                },
                new cboDataList
                {
                    cbo_Name = "衣服",
                    cbo_Value = "2"
                },
                new cboDataList
                {
                    cbo_Name = "住",
                    cbo_Value = "3"
                },
                new cboDataList
                {
                    cbo_Name = "交通",
                    cbo_Value = "4"
                },

            };

                    comboBox2.DataSource = lis_DataList;
                    comboBox2.DisplayMember = "cbo_Name";
                    comboBox2.ValueMember = "cbo_Value";
                    break;
                default:
                    comboBox1.BackColor = Color.White;
                    break;
            }
        }
        private void check1()
        {
            //取消支出欄位輸入功能
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = true;










        }
        private void check2()
        {
            //取消收入欄位輸入功能
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = false;








        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //選單項目變更不出錯
            if (comboBox2.SelectedValue == null)
            {
                return;
            }
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //判斷第二個選單變數
            int select;
            string a = comboBox2.SelectedIndex.ToString();
            select = comboBox2.SelectedIndex;
            //沒有資料,使用者按確認不出錯
            try
            {
                int user = int.Parse(textBox2.Text.ToString());
                int cash = int.Parse(label10.Text.ToString());
                int money = int.Parse(label12.Text.ToString());
                int costn = int.Parse(label17.Text.ToString());
                int tcost = int.Parse(label11.Text.ToString());

                //判斷第一個選單的選項是否為收入
                if (comboBox1.SelectedIndex == 0)
                {

                    TotalMoney += user;
                    //計算剩餘金額
                    if (cash != 0)
                    {
                        cash = money - tcost;
                    }
                    //讓剩餘金額等於現金
                    else
                    {
                        cash = user;
                    }

                    label12.Text = TotalMoney.ToString();
                    label10.Text = cash.ToString();

                }
                //判斷第一個選單的選項是否為支出
                else
                {
                    use = int.Parse(textBox1.Text.ToString());
                    //  (new)used= (old)used+use
                    //總花費等於本次花費
                    used += use;
                    try
                    {
                        //第二個選單項目設計

                        //string buy_sell_value = comboBox2.SelectedValue.ToString();
                        switch (select)
                        {
                            case 0:
                                comboBox2.BackColor = Color.Yellow;
                                check2();
                                //MessageBox.Show("開始記錄飲食");

                                break;
                            case 1:
                                comboBox2.BackColor = Color.Yellow;
                                check2();
                                //MessageBox.Show("開始記錄衣服");

                                break;
                            case 2:
                                comboBox2.BackColor = Color.Yellow;
                                check2();
                                //MessageBox.Show("開始記錄房子");
                                break;
                            case 3:
                                comboBox2.BackColor = Color.Yellow;
                                check2();
                                //MessageBox.Show("開始記錄交通");

                                break;
                            default:
                                comboBox1.BackColor = Color.White;
                                break;
                        }
                        //判斷第二個選單項目內容
                        if (comboBox2.SelectedIndex == 0)
                        {
                            UsedMoney(ref TotalMoney, ref eat, used, use);
                            label13.Text = eat.ToString();
                            label10.Text = TotalMoney.ToString();
                            label11.Text = used.ToString();
                            label17.Text = use.ToString();
                        }
                        else if (comboBox2.SelectedIndex == 1)
                        {
                            UsedMoney(ref TotalMoney, ref cloth, used, use);
                            label14.Text = cloth.ToString();
                            label10.Text = TotalMoney.ToString();
                            label11.Text = used.ToString();
                            label17.Text = use.ToString();
                        }
                        else if (comboBox2.SelectedIndex == 2)
                        {
                            UsedMoney(ref TotalMoney, ref house, used, use);
                            label15.Text = house.ToString();
                            label10.Text = TotalMoney.ToString();
                            label11.Text = used.ToString();
                            label17.Text = use.ToString();
                        }
                        else if (comboBox2.SelectedIndex == 3)
                        {
                            UsedMoney(ref TotalMoney, ref traffic, used, use);
                            label16.Text = traffic.ToString();
                            label10.Text = TotalMoney.ToString();
                            label11.Text = used.ToString();
                            label17.Text = use.ToString();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("請輸入支出內容");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("請輸入收入內容");
                return;
            }

            


        }
    }
}
