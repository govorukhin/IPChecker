using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form_DiapasonAddressChoser : Form, IDiapasonAddressChanger
    {
        public Form_DiapasonAddressChoser()
        {
            InitializeComponent();
        }

        public event Action<DiapasonChoiserData> AddingAdresses_Required = delegate { };
        public event Action<DiapasonChoiserData> RemovingAdresses_Required = delegate { };

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                AddingAdresses_Required(CreateDiapasonChoiserData());
            }                            
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {                
                RemovingAdresses_Required(CreateDiapasonChoiserData());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private DiapasonChoiserData CreateDiapasonChoiserData()
        {
            DiapasonChoiserData result = new DiapasonChoiserData();

            try
            { result.IP_From = IPAddress.Parse(textBox_IPFrom.Text); }
            catch (Exception e)
            { throw new Exception("Не удалось распознать IP Min"); }

            try
            { result.IP_To = IPAddress.Parse(textBox_IPTo.Text); }
            catch (Exception e)
            { throw new Exception("Не удалось распознать IP Max"); }

            if (result.IP_From.AddressFamily != result.IP_To.AddressFamily)
                throw new Exception("Версии IP должны быть одинаковыми");

            if (new BigInteger(result.IP_From.GetAddressBytes().Reverse().ToArray()) >
                new BigInteger(result.IP_To.GetAddressBytes().Reverse().ToArray())
               )
                throw new Exception("Значение Min IP должено быть не больше Max IP");

            try
            {
                if (textBox_Port.Text == "")
                    result.Port = null;
                else
                    result.Port = Convert.ToUInt16(textBox_Port.Text);
            }
            catch (Exception e)
            { throw new Exception("Значение порта должно быть от 0 до 65535. \r\n Или отсутствовать."); }

            result.AddressFamily = result.IP_From.AddressFamily;
            result.Scheme = textBox_Protocol.Text;
            result.Path = textBox_Path.Text;


            return result;
        }
    }
}






