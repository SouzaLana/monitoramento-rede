using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monitoramento_rede
{
    public partial class Form1 : Form
    {
        private Timer networkCheckTimer;

        public Form1()
        {
            InitializeComponent();

            networkCheckTimer = new Timer();
            networkCheckTimer.Interval = 7000;
            networkCheckTimer.Tick += NetworkCheckTimer_Tick;
            networkCheckTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Desigado";
            label3.BackColor = Color.Red;
            label.Text = "__________";
            label.BackColor = Color.Transparent;

            networkCheckTimer.Stop();
        }

        private async Task CheckNetwork()
        {
            Ping ping = new Ping();

            string hostName = "stackoverflow.com";
            string hostName1 = "google.com";
            PingReply reply = await ping.SendPingAsync(hostName);
            PingReply reply1 = await ping.SendPingAsync(hostName1);
            Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");
            Console.WriteLine($"Ping status for ({hostName1}): {reply1.Status}");
            if (reply.Status == IPStatus.Success && reply1.Status == IPStatus.Success)
            {
                label.Text = "Rede operando normalmente";
                label.BackColor = Color.Green;
            }
            else
            {
                label.Text = "Rede com problema";
                label.BackColor = Color.Red;
            }

            //    Ping ping = new Ping();

            //string[] hostNames = { "stackoverflow.com", "google.com" }; // Adicione os sites que deseja verificar aqui

            //bool isNetworkAvailable = false;

            //foreach (var hostName in hostNames)
            //{
            //    PingReply reply = await ping.SendPingAsync(hostName);

            //    Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");

            //    if (reply.Status == IPStatus.Success)
            //    {
            //        isNetworkAvailable = true;
            //        break; // Se um dos sites estiver disponível, saia do loop
            //    }
            //}

            //if (isNetworkAvailable)
            //{
            //    label.Text = "Rede operando normalmente";
            //    label.BackColor = Color.Green;
            //}
            //else
            //{
            //    label.Text = "Rede com problema";
            //    label.BackColor = Color.Red;
            //}
        }

        private async void NetworkCheckTimer_Tick(object sender, EventArgs e)
        {
            await CheckNetwork();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Ligado";
            label3.BackColor = Color.Green;

            networkCheckTimer.Start();

            await CheckNetwork();
        }
    }
}
