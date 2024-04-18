using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitoramento_rede
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Desigado";
            label3.BackColor = Color.Red;
            label.Text = "__________";
            label.BackColor = Color.Transparent;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Ligado";
            label3.BackColor = Color.Green;


            Ping ping = new Ping();

            string hostName = "stackoverflow.com";
            PingReply reply = await ping.SendPingAsync(hostName);
            Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");
            if (reply .Status == IPStatus.Success)
            {
                label.Text = "Rede operando normalmente";
                label.BackColor = Color.Green;
            }
            else
            {
                label.Text = "Rede com problema";
                label.BackColor = Color.Red;
            }
        }
    }
}
