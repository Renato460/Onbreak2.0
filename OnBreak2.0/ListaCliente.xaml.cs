using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para ListaCliente.xaml
    /// </summary>
    public partial class ListaCliente : Window
    {
        Cliente data;
        public ListaCliente()
        {
            InitializeComponent();
            data = new Cliente();
            DataClientes.ItemsSource = data.ReadAll("gettabla","",0,0);
            ActividadEmpresa actividad = new ActividadEmpresa();
            List<string> listaActividad = new List<string>();
            for (int i = 0; i < actividad.Read().Count; i++)
            {
                listaActividad.Add(actividad.Read()[i].Descripcion1);
            }
            combActividad.ItemsSource = listaActividad;

            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            List<string> listaTipoEmpresa = new List<string>();
            for (int i = 0; i < tipoEmpresa.Read().Count; i++)
            {
                listaTipoEmpresa.Add(tipoEmpresa.Read()[i].Descripcion1);
            }
            

            combTipoEmpresa.ItemsSource = listaTipoEmpresa;
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente filtro = new Cliente();
                filtro.Ids(combTipoEmpresa.Text, combActividad.Text);
                DataClientes.ItemsSource = filtro.ReadAll("gettabla", textRutCliente.Text, filtro.Ids(combTipoEmpresa.Text, combActividad.Text)[0], filtro.Ids(combTipoEmpresa.Text, combActividad.Text)[1]);
            }
            catch (Exception)
            {

                MessageBox.Show("Error!!!");
            }
           
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            textRutCliente.Text = "";
            combActividad.Text = "";
            combTipoEmpresa.Text = "";
            DataClientes.ItemsSource = data.ReadAll("gettabla", "", 0, 0);
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminCliente cliente = new AdminCliente();
                if (DataClientes.SelectedIndex != -1)
                {
                    Cliente clienteSeleccionado = this.DataClientes.SelectedItem as Cliente;
                    cliente.asignacion(clienteSeleccionado.RutCliente1, clienteSeleccionado.NombreContacto1, clienteSeleccionado.Direccion1, clienteSeleccionado.MailContacto1,
                        clienteSeleccionado.Telefono1, clienteSeleccionado.RazonSocial1, clienteSeleccionado.ActividadEmpresa1, clienteSeleccionado.TipoEmpresa1);
                    //cliente.Close();
                    cliente.Show();
                }
                else
                {

                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error!!!");
            }
            
        }
    }
}
