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

namespace FSantaFe.Facturacion.UI.WinForm
{
    public partial class FrmTipoMaterial : Form
    {
        TipoMaterial Material = new TipoMaterial();
        public byte _IdMaterial = 0;


        public FrmTipoMaterial()
        {
            InitializeComponent();
        }

        private void FrmTipoMaterial_Load(object sender, EventArgs e)
        {
            cboEstados.DataSource = EstadoBL.ObtenerTodos();
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";

            cboEstados.SelectedItem = null;
            cboEstados.SelectedText = "SELECCIONAR";

            if (_IdMaterial > 0)
            {
                cargarDatos();
            }
        }

        private void cargarDatos()
        {

            Material = TipoMaterialBL.BuscarPorId(_IdMaterial);
            if (Material.Id > 0)
            {
                txtNombreTipoMaterial.Text = Material.Nombre;
                cboEstados.SelectedValue = Material.IdEstado;

            }
            else
            {
                MessageBox.Show("Ocurrio un problema al intentar cargar Datos.");
                this.Close();
            }

        }

        private bool validarDatosFormulario()
        {
            bool validar = false;

            if (txtNombreTipoMaterial.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nombre Estado, es obligatorio");
                validar = true;
            }

            //Operador Ternario -> (condicion) ? condicion falso : condicion verdadero
            var idEstado = (cboEstados.SelectedValue == null) ? 0 : (byte)cboEstados.SelectedValue;
            if (idEstado == 0)
            {
                MessageBox.Show("Seleccionar Estado, es obligatorio");
                validar = true;
            }

            return validar;
        }

        private void Guardar()
        {
            try
            {
                if (!validarDatosFormulario())
                {
                    Material.Nombre = txtNombreTipoMaterial.Text;
                    Material.IdEstado = (byte)cboEstados.SelectedValue;
                    if (_IdMaterial <= 0)
                    {
                        if (TipoMaterialBL.Guardar(Material) > 0)
                        {
                            MessageBox.Show("Registro exitoso");
                            this.Close();
                        }
                    }
                    else
                    {
                        if (TipoMaterialBL.Modificar(Material) > 0)
                        {
                            MessageBox.Show("Registro exitoso");
                            this.Close();
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar guardar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
