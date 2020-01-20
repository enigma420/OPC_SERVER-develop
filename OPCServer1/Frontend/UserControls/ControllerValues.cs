using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCServer1.Forms;
using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer;

namespace OPCServer1
{

   
    public partial class ControllerValues : UserControl
    {

        PlcService plcService;

        public ControllerValues()
        {
            plcService = new PlcService();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int ProductIndex = comboBox1.SelectedIndex;
            string productName = comboBox1.Text.ToString();
            MessageBox.Show($"Wykonano Pomyślnie {productName} !");
            plcService.WritePlcDataSingleVariablePackage(ProductIndex);
        }
    }
}
