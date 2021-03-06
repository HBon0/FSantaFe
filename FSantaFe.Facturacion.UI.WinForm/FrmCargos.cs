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
    public partial class FrmCargos : Form
    {
        public FrmCargos()
        {
            InitializeComponent();
        }

        //Mostrar el Form para Guardadar/Modificar un registro.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCargo frmCargo = new FrmCargo();
            frmCargo.StartPosition = FormStartPosition.CenterScreen;
            frmCargo.ShowDialog();
            MostrarCargos();
        }

        //Metodo para Mostrar los Estados en el ComboBox 
        private void FrmCargos_Load(object sender, EventArgs e)
        {
            var listaEstados = EstadoBL.ObtenerTodos();
            listaEstados.Insert(0, new Estado() { Id = 0, Nombre = "SELECCIONAR" });
            cboEstados.DataSource = listaEstados;
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";
            MostrarCargos();
        }

        //Mostrar los registros en el DataGriedView
        private void MostrarCargos()
        {
            dgvCargos.DataSource = CargoBL.ObtenerTodos();
        }

        //Metodo para Modificar un registro.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvCargos);
            if (id > 0)
            {
                FrmCargo frmCargo = new FrmCargo();
                frmCargo.StartPosition = FormStartPosition.CenterScreen;
                frmCargo._idCargo = id;
                frmCargo.ShowDialog();
                MostrarCargos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para modificar");
            }
        }


        //Meteodo para eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            byte id = (byte)UFormulario.ObtenerIdGrid(dgvCargos);
            if (id > 0)
            {
                if (MessageBox.Show("Desea eliminar el registro", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (CargoBL.Eliminar(new Cargo { Id = id }) > 0)
                    {
                        MessageBox.Show("Registro eliminado");
                        MostrarCargos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }


        //Metodo para Buscar un Registro mediante coincidencias
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo
            {
                Nombre = txtNombreCargo.Text,
                IdEstado = (byte)cboEstados.SelectedValue
            };

            dgvCargos.DataSource = CargoBL.Buscar(cargo);
        }
    }
}
