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
using Negocio;
using System.IO;
using System.Configuration;
using System.Xml.Linq;

namespace Practica_Discos
{
    public partial class frmNuevoDisco : Form
    {
        private OpenFileDialog archivo = null;
        private Disco disco = null;
        public frmNuevoDisco()
        {
            InitializeComponent();
        }
        public frmNuevoDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if (disco == null)
                    disco = new Disco();

                disco.Titulo = txtNombre.Text;
                disco.CantidadCanciones = int.Parse(txtCantidad.Text);
                disco.UrlImagen = txtTapa.Text;
                disco.Estilo = (Estilo)cboEstilo.SelectedItem;
                disco.Tipo = (tipoDisco)cboTipoDisco.SelectedItem;

                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                }

                if (archivo != null && !(txtTapa.Text.ToLower().Contains("http")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                }


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

    

        private void frmNuevoDisco_Load(object sender, EventArgs e)
        {
            estiloNegocio estiloNegocio = new estiloNegocio();
            tipoDiscoNegocio tipoDiscoNegocio = new tipoDiscoNegocio();
            try
            {
                cboEstilo.DataSource = estiloNegocio.listar();
                cboEstilo.ValueMember = "Id";
                cboEstilo.DisplayMember = "Descripcion";
                cboTipoDisco.DataSource = tipoDiscoNegocio.listar();
                cboTipoDisco.ValueMember = "Id";
                cboTipoDisco.DisplayMember = "Descripcion";

                if(disco != null)
                {
                    txtNombre.Text = disco.Titulo;
                    txtCantidad.Text = disco.CantidadCanciones.ToString();
                    txtTapa.Text = disco.UrlImagen;
                    cargarImagen(disco.UrlImagen);
                    cboEstilo.SelectedValue = disco.Estilo.Id;
                    cboTipoDisco.SelectedValue = disco.Tipo.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void txtTapa_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtTapa.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxTapa.Load(imagen);
            }
            catch (Exception)
            {

                pbxTapa.Load("https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg");
            }
        }

        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "JPEG|*.JPEG| JPG|*.jpg |png|*.png ";
            List<OpenFileDialog> lista = new List<OpenFileDialog>();
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                    txtTapa.Text = archivo.FileName;
                    cargarImagen(archivo.FileName);

                    lista.Add(archivo);
                //Guardar img

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["DiscosAPP"]);
            }

        }
    }
}
