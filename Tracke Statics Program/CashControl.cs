using System;
using System.Windows.Forms;

namespace Tracke_Statics_Program
{
    public partial class CashControl : Form
    {
        public static string addcash = "";

        public CashControl()
        {
            InitializeComponent();
        }

        private void CashControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Внесете колку кеш имате.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.Length <= 0) MessageBox.Show("Не може да биде празно.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text.Length >= 11) MessageBox.Show("Не можете над 11 цифри.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text.Length >= 0 || textBox1.Text.Length <= 11)
            {
                addcash = textBox1.Text;
                this.Close();
            }
        }
    }
}
