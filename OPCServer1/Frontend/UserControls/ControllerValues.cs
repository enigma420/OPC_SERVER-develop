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
            plcService.WriteEntrancePlcDataSingleVariablePackage(ProductIndex);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int ProductIndex = comboBox3.SelectedIndex;
            string productName = comboBox3.Text.ToString();
            int weight;
            int.TryParse(textBox1.Text,out weight);
            MessageBox.Show($"Ustawiono {productName} na wartość: {weight} !");
            plcService.WriteWeightPlcDataSingleVariablePackage(ProductIndex, weight);
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            int ProductIndex = comboBox3.SelectedIndex;
            string productName = comboBox3.Text.ToString();
            MessageBox.Show($"Usunięto Błąd{productName} !");
            plcService.WriteEliminateErrorsPlcDataSingleVariablePackage(ProductIndex);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
    }
}
