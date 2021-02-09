using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FSantaFe.Facturacion.EntidadesDeNegocio;
using FSantaFe.Facturacion.LogicaDeNegocio;
using FSantaFe.Facturacion.UI.WinForm.Utilidades;

namespace FSantaFe.Facturacion.UI.WinForm
{
    public partial class FrmTipoMateriales : Form
    {
        public FrmTipoMateriales()
        {
            InitializeComponent();
        }

        private void FrmTipoMateriales_Load(object sender, EventArgs e)
        {
            var listaEstados = EstadoBL.ObtenerTodos();
            listaEstados.Insert(0, new Estado() { Id = 0, Nombre = "SELECCIONAR" });
            cboEstados.DataSource = listaEstados;
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";
            MostrarTipoMateriales();
        }

        private void MostrarTipoMateriales()
        {
            dgvMateriales.DataSource = TipoMaterialBL.ObtenerTodos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoMaterial frmTipoMaterial = new FrmTipoMaterial();
            frmTipoMaterial.StartPosition = FormStartPosition.CenterScreen;
            frmTipoMaterial.ShowDialog();
            MostrarTipoMateriales();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvMateriales);
            if (id > 0)
            {
                FrmTipoMaterial frmTipoMaterial = new FrmTipoMaterial();
                frmTipoMaterial.StartPosition = FormStartPosition.CenterScreen;
                frmTipoMaterial._IdMaterial = id;
                frmTipoMaterial.ShowDialog();
                MostrarTipoMateriales();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvMateriales);
            if (id > 0)
            {
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (TipoMaterialBL.Eliminar(new TipoMaterial { Id = id }) > 0)
                    {
                        MessageBox.Show("Registro eliminado");
                        MostrarTipoMateriales();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TipoMaterial Material = new TipoMaterial
            {
                Nombre = txtNombreMaterial.Text,
                IdEstado = (byte)cboEstados.SelectedValue
            };

            dgvMateriales.DataSource = TipoMaterialBL.Buscar(Material);
        }
    }
}
