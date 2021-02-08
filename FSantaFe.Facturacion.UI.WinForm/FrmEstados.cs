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
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEstado frmEstado = new FrmEstado();
            frmEstado.StartPosition = FormStartPosition.CenterScreen;
            frmEstado.ShowDialog();
        }
    }
}
