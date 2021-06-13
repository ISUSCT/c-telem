using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemetry_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // init the com port combo box
            string[] ports = SerialPort.GetPortNames();
            comPortCombo.Items.AddRange(ports);
            comPortCombo.SelectedIndex = 0;
            closeComBtn.Enabled = false;

            // init the baud rate combo box
            string[] bauds = new String[14] { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "256000" };
            baudRateCombo.Items.AddRange(bauds);
            baudRateCombo.SelectedIndex = 10;
        }

        private void openComBtn_Click(object sender, EventArgs e)
        {
            openComBtn.Enabled = false;
            closeComBtn.Enabled = true;
            try
            {
                serialPort1.PortName = comPortCombo.Text;
                serialPort1.BaudRate = int.Parse(baudRateCombo.Text);
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeComBtn_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            closeComBtn.Enabled = false;
            openComBtn.Enabled = true;
        }


    }
}
