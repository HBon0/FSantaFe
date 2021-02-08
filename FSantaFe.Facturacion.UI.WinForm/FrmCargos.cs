using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSantaFe.Facturacion.UI.WinForm
{
    public partial class FrmCargos : Form
    {
        public FrmCargos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCargo frmCargo = new FrmCargo();
            frmCargo.StartPosition = FormStartPosition.CenterScreen;
            frmCargo.ShowDialog();
        }
    }
}
