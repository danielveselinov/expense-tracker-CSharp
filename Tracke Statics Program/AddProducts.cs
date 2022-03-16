using System;
using System.Windows.Forms;

namespace Tracke_Statics_Program
{
    public partial class AddProducts : Form
    {
        public static string product = "";
        public static string priceofp = "";
        public static string id = "";
        public AddProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") MessageBox.Show("Морате да внесете реден број, продукт и цена.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text.Length <= 0 || textBox1.Text.Length >= 40 || textBox2.Text.Length <= 0 || textBox2.Text.Length >= 10)
            {
                MessageBox.Show("Името на продуктот не може да биде под 0 или над 40 карактери. \n" +
                    "Цената на продуктот не може да биде под 0 или над 10 цифри.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.Length >= 0 || textBox1.Text.Length <= 40 || textBox2.Text.Length >= 0 || textBox2.Text.Length <= 10)
            {
                product = textBox1.Text;
                priceofp = textBox2.Text;
                id = textBox3.Text;
                this.Close();

                textBox1.ResetText();
                textBox2.ResetText();
                textBox3.ResetText();
            }
        }

        private void AddProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
        }
    }
}
