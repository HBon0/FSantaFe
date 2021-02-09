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
    public partial class FrmCargo : Form
    {

        Cargo cargo = new Cargo();
        public byte _idCargo = 0;

        public FrmCargo()
        {
            InitializeComponent();
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            cboEstados.DataSource = EstadoBL.ObtenerTodos();
            cboEstados.DisplayMember = "Nombre";
            cboEstados.ValueMember = "Id";

            if (_idCargo > 0)
            {
                cargarDatos();
            }
        }

        private void cargarDatos()
        {

            cargo = CargoBL.BuscarPorId(_idCargo);
            if (cargo.Id > 0)
            {
                txtNombreCargo.Text = cargo.Nombre;
                cboEstados.SelectedValue = cargo.IdEstado;

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

            if (txtNombreCargo.Text.Trim().Equals(""))
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
                    cargo.Nombre = txtNombreCargo.Text;
                    cargo.IdEstado = (byte)cboEstados.SelectedValue;
                    if (_idCargo <= 0)
                    {
                        if (CargoBL.Guardar(cargo) > 0)
                        {
                            MessageBox.Show("Registro exitoso");
                            this.Close();
                        }
                    }
                    else
                    {
                        if (CargoBL.Modificar(cargo) > 0)
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
