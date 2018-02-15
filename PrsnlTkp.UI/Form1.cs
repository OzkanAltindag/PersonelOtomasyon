using PrsnlTkp.BL;
using PrsnlTkp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrsnlTkp.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PersonelRepository pr = new PersonelRepository();
        PersonelBilgi secili;


        void verileriGoster()
        {
            dataGridView1.DataSource = pr.selectAll().ToList();
         }
        void temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                

                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox mq = (MaskedTextBox)item;
                    mq.Clear();

                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelBilgi p = new PersonelBilgi();
            p.TcKimlikNo = Int64.Parse(maskedTextBox1.Text);
            p.Unvan = textBox1.Text;
            p.Ad = textBox2.Text;
            p.Soyad = textBox3.Text;
            p.DogumTarihi = dateTimePicker1.Value;
            p.Email = textBox4.Text;
            p.Telefon = maskedTextBox2.Text;
            p.BaslangicTarihi = dateTimePicker2.Value;
            p.Adres = textBox5.Text;
            pr.Insert(p);
            verileriGoster();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)//sil
        {
           Int64 secili = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value);
            pr.Delete(secili);
            verileriGoster();
            temizle();

        }

        private void button3_Click(object sender, EventArgs e)//güncelle
        {
            try
            {
                secili.TcKimlikNo = Int64.Parse(maskedTextBox1.Text);
                secili.Unvan = textBox1.Text;
                secili.Ad = textBox2.Text;
                secili.Soyad = textBox3.Text;
                secili.DogumTarihi = dateTimePicker1.Value;
                secili.Email = textBox4.Text;
                secili.Telefon = maskedTextBox2.Text;
                secili.BaslangicTarihi = dateTimePicker2.Value;
                secili.Adres = textBox5.Text;
                pr.Update(secili);
                verileriGoster();
                temizle();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            secili = (PersonelBilgi)dataGridView1.CurrentRow.DataBoundItem;
            maskedTextBox1.Text = secili.TcKimlikNo.ToString();
            textBox1.Text = secili.Unvan;
            textBox2.Text = secili.Ad;
            textBox3.Text = secili.Soyad;
            textBox4.Text = secili.Email;
            textBox5.Text = secili.Adres;
            maskedTextBox2.Text = secili.Telefon;
            dateTimePicker1.Value = secili.DogumTarihi.Value;
            dateTimePicker2.Value = secili.BaslangicTarihi.Value;
        }
    }
}
