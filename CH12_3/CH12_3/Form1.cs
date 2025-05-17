using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CH12_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        private delegate double Conversion(double value);


        private double FeetToInches(double feet)
        {
            return feet * 12;
        }
                
        private double YardsToInches(double yards)
        {
            return yards * 3 * 12; 
        }

        


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                double inputValue = double.Parse(textBox1.Text);

                if (inputValue <= 0)
                {
                    throw new ArgumentException("輸入數值必須為正數！");
                }

                // 根據選擇的轉換類型創建委派
                Conversion converter = null;

                if (radioButton1.Checked)
                {
                    converter = FeetToInches;
                }
                else
                {
                    converter = YardsToInches;
                }
                                
                double result = converter(inputValue);
                                
                label1.Text = $"Result : {result} 英吋";
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入有效的數字!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
