using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace Practica_Discos
{
    public partial class frmNuevoDisco : Form
    {
        public frmNuevoDisco()
        {
            InitializeComponent();
        }





        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Disco nuevo = new Disco();
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                nuevo.Titulo = txtNombre.Text;
                nuevo.CantidadCanciones = int.Parse(txtCantidad.Text);
                nuevo.UrlImagen = txtTapa.Text;

                negocio.agregar(nuevo);
                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }
    }
}
