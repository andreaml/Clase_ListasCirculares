using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_ListasCirculares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ruta miRuta = new Ruta();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Base miBase = new Base(txtNombre.Text, Convert.ToInt16(txtMinutos.Text));
            miRuta.agregarBase(miBase);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            Base miBase = new Base(txtNombre.Text, Convert.ToInt16(txtMinutos.Text));
            miRuta.agregarBaseInicio(miBase);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Base miBase = new Base(txtNombre.Text, Convert.ToInt16(txtMinutos.Text));
            miRuta.insertarBaseDespuesDe(txtNombre2.Text, miBase);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miRuta.buscarBase(txtNombre.Text).ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miRuta.eliminarBase(txtNombre.Text));
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miRuta.recorrido(txtNombre.Text, dtpInicio.Value, dtpFin.Value);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miRuta.reporte();
        }
    }
}
