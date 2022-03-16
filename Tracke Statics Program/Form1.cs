using System;
using System.Windows.Forms;
using System.IO;

namespace Tracke_Statics_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Драг кориснику," +"\n" +
                "вие ја користете бесплатната верзија на оваа," + "\n"+
                "програма. Доколку сакате да ја имате најновата" + "\n" +
                "верзија со подобри опции посетете го веј сајтот." +
                "\n www.example.com", "Предупредување", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashControl cashControl = new CashControl();
            cashControl.ShowDialog();
            currentcash.Text = CashControl.addcash + " ден.";
            button3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = true;
            btnCalculate.Enabled = true;
            btnSave.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentcash.Text = "0,000,000,000 ден.";
            button3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = false;
            btnCalculate.Enabled = false;
            btnSave.Enabled = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.ShowDialog();
            dataGridView1.Rows.Add(AddProducts.id,AddProducts.product, AddProducts.priceofp);
            btnSave.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete > -1)
            {
                this.dataGridView1.Rows.RemoveAt(rowToDelete);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for( int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            lblCosts.Text = sum.ToString() + " ден.";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(lblCosts.Text == "0,000,000,000 ден.")
            {
                MessageBox.Show("Не можете да зачувате пред за пресметате.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Filter = "Text File | *.txt";
                saveFileDialog.FileName = "Трошок за "+ DateTime.Now.ToLongDateString();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = saveFileDialog.OpenFile();
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            streamWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "\t");
                        }
                        streamWriter.WriteLine("");
                    }
                    streamWriter.Write("Датум и време на зачувување: " + dateTimePicker1.Value.ToString() + "\t");
                    streamWriter.Write("\t" + "Вкупно: " + lblCosts.Text + "\t");
                    streamWriter.Write("\t" + "Внесен кеш: " + currentcash.Text + "\t");
                    streamWriter.Close();
                    fileStream.Close();
                    MessageBox.Show($"Успешно ја зачувавте датата", "Датум на зачувување: " + dateTimePicker1.Value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
