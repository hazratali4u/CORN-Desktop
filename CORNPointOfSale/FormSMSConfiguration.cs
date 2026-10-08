using System;
using System.Windows.Forms;
using System.IO.Ports;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Threading;

namespace CORNPointOfSale
{
    public partial class FormSMSConfiguration : Form
    {
        public SerialPort _serialPort;
        public FormSMSConfiguration()
        {
            InitializeComponent();
        }

        private void FormSMSConfiguration_Shown(object sender, EventArgs e)
        {
            GetPortsName();
            try
            {
                drpPortSpeed.SelectedIndex = 4;
                drpPortNumber.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }
        public void GetPortsName()
        {
            try
            {
                drpPortNumber.Items.Clear();
                string[] _OpenPorts = SerialPort.GetPortNames();
                foreach (string _Allport in _OpenPorts)
                {
                    drpPortNumber.Items.Add(_Allport);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtDistributorPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            if (txtMobileNumber.Text == "")
            {
                ToastNotification.Show(this, "Enter Mobile Number", CORNPointOfSale.Properties.Resources.cross, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
            }
            else
            {
                SendMessage();
            }
        }
        public void SendMessage()
        {
            //int _logic = SMSConfigFunctions.GetSMSConfig();
            //if (_logic == 0)
            //{
            //    ToastNotification.Show(this, "Please Configure SMG Modem", CORNPointOfSale.Properties.Resources.cross, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
            //}
            //else
            {
                
                _serialPort = new SerialPort("COM7", Convert.ToInt32(drpPortSpeed.Text));
                Thread.Sleep(100);
                _serialPort.Open();
                Thread.Sleep(100);
                _serialPort.Write("AT+CMGF=1\r");
                Thread.Sleep(100);
                _serialPort.Write("AT+CMGS=\"" + txtMobileNumber.Text + "\"\r\n");
                Thread.Sleep(100);
                _serialPort.Write(drpPortSpeed.Text + "\x1A");
                Thread.Sleep(300);
                _serialPort.Close();
                ToastNotification.Show(this, "Send Successfuly", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.BottomCenter);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
