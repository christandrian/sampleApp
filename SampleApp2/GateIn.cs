using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleApp2
{
    public partial class GateIn : Form
    {
        public GateIn()
        {
            DataBase.readConf();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Apakah Anda Yakin Data Anda Sudah Benar?", "Peringatan!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                label6.Text = "Non-id";
                label7.Text = "No Name";
                label8.Text = Convert.ToString(DateTime.Now);
                LogDB log = new LogDB();
                Random rnd = new Random();
                int barc = rnd.Next(10000, 99999);
                string barcode = Convert.ToString(barc);
                string formatForMySql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.createDataByDefault(textBox1.Text, formatForMySql, "", barcode);
                MessageBox.Show( "Succesfull","Message\nBarcode: "+barcode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDB userdb = new UserDB();
            button2.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Apakah Anda Yakin Data Anda Sudah Benar?", "Peringatan!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                User userTemp = userdb.searchDataByRFID(textBox2.Text);
                if (userTemp == null)
                {
                    MessageBox.Show("Alert", "Unknown User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    label6.Text = userTemp.id;
                    label7.Text = userTemp.nama;
                    label8.Text = Convert.ToString(DateTime.Now);
                    LogDB log = new LogDB();
                    string formatForMySql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.createDataByRFID(textBox2.Text, formatForMySql, "");
                    MessageBox.Show("Succesfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


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
    }
}
