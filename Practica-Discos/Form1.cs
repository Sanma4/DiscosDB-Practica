using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace Practica_Discos
{
    public partial class frmDiscos : Form
    {
        private List<Disco> ListaDiscos;
        private List<Estilo> ListaEstilos;

        public frmDiscos()
        {
            InitializeComponent();
        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            cargar();
            //estiloNegocio dataBase = new estiloNegocio();
            //ListaEstilos = dataBase.listar();
            //dgvDiscos.DataSource = ListaEstilos;


        }

        private void cargar()
        {
            DiscosNegocio database = new DiscosNegocio();
            try
            {
                ListaDiscos = database.listar();
                dgvDiscos.DataSource = ListaDiscos;
                ocultarColumnas();
                cargarImagen(ListaDiscos[0].UrlImagen);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void ocultarColumnas()
        {
            dgvDiscos.Columns["urlimagen"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);
            }
            catch (Exception)
            {

                pbxDiscos.Load("https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg");
            }
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco selecionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(selecionado.UrlImagen);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoDisco disc = new frmNuevoDisco();
            disc.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            frmNuevoDisco modificar = new frmNuevoDisco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            Disco seleccionado = new Disco();
            try
            {
                DialogResult respuesta = MessageBox.Show("El disco será eliminado y no se podrá recuperar ¿Estas seguro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    if(logico)
                   
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);

                    MessageBox.Show("Eliminado exitosamente.");
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;

            string filtro = txtFiltro.Text;
            if (filtro != "")
            {
                listaFiltrada = ListaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = ListaDiscos;
            }

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultarColumnas();
        }
    }
}
