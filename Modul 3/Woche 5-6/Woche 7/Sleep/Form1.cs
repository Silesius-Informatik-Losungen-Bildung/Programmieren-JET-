using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sleep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starte Aktion 1 SYNC");
            Task.Delay(5000).Wait();
            MessageBox.Show("Aktion 1 beendet");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starte Aktion 2 SYNC");
            Task.Delay(5000).Wait();
            MessageBox.Show("Aktion 1 beendet");
        }

        //--------------------------------------------------------------------------------
        private async void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starte Aktion 1 ASYNC");
            await Task.Delay(5000);
            MessageBox.Show("Aktion 1 beendet");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starte Aktion 2 ASYNC");
            await Task.Delay(5000);
            MessageBox.Show("Aktion 2 beendet");
        }
    }
}
