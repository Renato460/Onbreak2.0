using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnBreak2._0
{
    /// <summary>
    /// Lógica de interacción para ListaContratos.xaml
    /// </summary>
    public partial class ListaContratos : Window
    {
        public ListaContratos()
        {
            InitializeComponent();
            try
            {
                Contratos contratos = new Contratos();
                TipoEvento tipoEvento = new TipoEvento();
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                DataContratos.ItemsSource = contratos.Read("getContrato", "", "", "", 0);
                cmbTipoEvento.ItemsSource = getTipoEventoDesc(tipoEvento.Read("getTipoEvento", 0));
                cmbModalidadEvento.ItemsSource = getModalidadEventoNom(modalidadServicio.Read("getModServicio", 0));
            }
            catch (Exception)
            {
                MessageBox.Show("Error en BD!!");
            }
            

        }
        private List<string> getModalidadEventoNom(List<ModalidadServicio> list)
        {
            List<string> retorno = new List<string>();
            
            for (int i = 0; i < list.Count; i++)
            {
                retorno.Add(list[i].Nombre1);
            }
            return retorno;
        }
        private List<string> getTipoEventoDesc(List<TipoEvento> list) 
        {
            List<string> retorno = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                retorno.Add(list[i].Descripcion1);
            }
            return retorno;
        }
        private void btnFiltarContrato_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos();
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            TipoEvento evento = new TipoEvento();
            int IdtipoEvento = 0;
            string IdModalidadServicio = "";

            try
            {
                if (cmbTipoEvento.Text.Equals(""))
                {
                }
                else
                {
                    for (int i = 0; i < evento.Read("getTipoEvento", 0).Count; i++)
                    {
                        if (evento.Read("getTipoEvento", 0)[i].Descripcion1.Equals(cmbTipoEvento.Text))
                        {
                            IdtipoEvento = evento.Read("getTipoEvento", 0)[i].Id1;

                        }
                    }
                }

                if (cmbModalidadEvento.Text.Equals(""))
                {
                    IdModalidadServicio = "";

                }
                else
                {
                    for (int i = 0; i < modalidadServicio.Read("getModServicio", 0).Count; i++)
                    {
                        if (modalidadServicio.Read("getModServicio", 0)[i].Nombre1.Equals(cmbModalidadEvento.Text))
                        {
                            IdModalidadServicio = modalidadServicio.Read("getModServicio", 0)[i].Id1;
                            MessageBox.Show(cmbModalidadEvento.Text);
                        }
                    }
                }


                DataContratos.ItemsSource = contratos.Read("getContrato", TextNumeroContrato.Text, TextRutCliente.Text, IdModalidadServicio, IdtipoEvento);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
            
        }

        private void btnLimpiarContrato_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos();
            TipoEvento tipoEvento = new TipoEvento();
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            DataContratos.ItemsSource = contratos.Read("getContrato", "", "", "", 0);
            cmbTipoEvento.ItemsSource = getTipoEventoDesc(tipoEvento.Read("getTipoEvento", 0));
            cmbModalidadEvento.ItemsSource = getModalidadEventoNom(modalidadServicio.Read("getModServicio", 0));
            TextNumeroContrato.Text = "";
            TextRutCliente.Text = "";
            cmbModalidadEvento.Text = "";
            cmbTipoEvento.Text = "";
        }

        private void cmbTipoEvento_DropDownClosed(object sender, EventArgs e)
        {
            int IdtipoEvento = 0;
            TipoEvento evento = new TipoEvento();
            for (int i = 0; i < evento.Read("getTipoEvento", 0).Count; i++)
            {
                if (evento.Read("getTipoEvento", 0)[i].Descripcion1.Equals(cmbTipoEvento.Text))
                {
                    IdtipoEvento = evento.Read("getTipoEvento", 0)[i].Id1;
                }
            }
            ModalidadServicio modalidad = new ModalidadServicio();
            cmbModalidadEvento.ItemsSource = getModalidadEventoNom(modalidad.Read("getModServicio", IdtipoEvento));
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos cliente = new AdminContratos();
            if (DataContratos.SelectedIndex != -1)
            {
                Contratos contratoSeleccionado = this.DataContratos.SelectedItem as Contratos;
                cliente.asignacion(contratoSeleccionado.NumeroContrato1, contratoSeleccionado.Creacion1, contratoSeleccionado.Termino1, contratoSeleccionado.RutCliente1, contratoSeleccionado.NombreCliente1,
                    contratoSeleccionado.Modalidad1, contratoSeleccionado.TipoEvento1, contratoSeleccionado.FechaHoraInicio1, contratoSeleccionado.FechaHoraTermino1, contratoSeleccionado.Asistentes1, contratoSeleccionado.PersonalAdicional1,
                    contratoSeleccionado.Realizado1, contratoSeleccionado.ValorTotalContrato1, contratoSeleccionado.Observaciones1);
                //cliente.Close();
                cliente.Show();
            }
            else {}
        }
    }
}
