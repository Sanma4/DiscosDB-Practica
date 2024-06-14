﻿using System;
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
                dgvDiscos.Columns["urlimagen"].Visible = false;
                dgvDiscos.Columns["Id"].Visible = false;
                cargarImagen(ListaDiscos[0].UrlImagen);
            }
            catch (Exception ex)
            {

                throw ex;
            }

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
            Disco selecionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(selecionado.UrlImagen);
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
    }
}
