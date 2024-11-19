using romb.cs.RombosApp;
using System;
using System.Windows.Forms;



namespace RombosApp
{
    public partial class frmPrincipal : Form
    {
        private RepositorioRombos repositorio = new RepositorioRombos();
        private object dgvRombos;
        private const string RutaArchivo = "rombos.txt";

        public frmPrincipal()
        {
            repositorio.CargarDesdeArchivo(RutaArchivo);
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formulario = new ();
            if (formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    repositorio.Agregar(formulario.Rombo);
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRombos.SelectedRows.Count == 0) return;

            var romboSeleccionado = (Rombo)dgvRombos.SelectedRows[0].DataBoundItem;
            var formulario = new frmRombo (romboSeleccionado);
            if (formulario.ShowDialog() == DialogResult.OK)
            {
                ActualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRombos.SelectedRows.Count == 0) return;

            var romboSeleccionado = (Rombo)dgvRombos.SelectedRows[0].DataBoundItem;
            repositorio.Eliminar(romboSeleccionado);
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvRombos.DataSource = null;
            dgvRombos.DataSource = repositorio.ObtenerTodos();
            txtCantidad.Text = repositorio.Contar().ToString();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            repositorio.GuardarEnArchivo(RutaArchivo);
        }
    }
}
