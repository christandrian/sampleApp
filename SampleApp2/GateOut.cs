using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleApp2
{
    public partial class GateOut : Form
    {
        public GateOut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Apakah Anda Yakin Data Anda Sudah Benar?", "Peringatan!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                label8.Text = textBox2.Text;
                //ambil dari DB
                LogDB log = new LogDB();
                Log l = log.searchDataById(textBox2.Text);

                label9.Text = l.waktu_masuk;
                label10.Text = DateTime.Now.ToString("HH:mm:ss");

                log.updateById(l.id, DateTime.Now.ToString("HH:mm:ss"));
                TimeSpan duration = DateTime.Parse(label10.Text).Subtract(DateTime.Parse(label9.Text));
                string waktu = duration.ToString(@"hh");
                int harga = 1500 * (Convert.ToInt32(waktu)+1);
                label11.Text =harga+"";
                //MessageBox.Show("Succesfull", "Message\nBarcode: " + barcode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Apakah Anda Yakin Data Anda Sudah Benar?", "Peringatan!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                label8.Text = textBox3.Text;
                //ambil dari DB
                LogDB log = new LogDB();
                Log l = log.searchDataByRFID(textBox3.Text);

                label9.Text = l.waktu_masuk;
                label10.Text = DateTime.Now.ToString("HH:mm:ss");

                log.updateById(l.id, DateTime.Now.ToString("HH:mm:ss"));
                TimeSpan duration = DateTime.Parse(label10.Text).Subtract(DateTime.Parse(label9.Text));
                string waktu = duration.ToString(@"hh");
                int harga = 1500 * (Convert.ToInt32(waktu) + 1);
                label11.Text = harga + "";
                //MessageBox.Show("Succesfull", "Message\nBarcode: " + barcode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

            }
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gate Open", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gate Close", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            //ambil dari DB
            LogDB log = new LogDB();
            Log l = log.searchDataByRFID(label8.Text);
            log.finish(l.id);
            MessageBox.Show("Payment Received. Thank you.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
