using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para AdminCliente.xaml
    /// </summary>
    public partial class AdminCliente : Window
    {
        public AdminCliente()
        {
            InitializeComponent();
            sourceActividad();
            sourceTipoEmpresa();
        }
        private void sourceActividad()
        {
            try
            {
                ActividadEmpresa actividad = new ActividadEmpresa();
                List<string> vs = new List<string>();
                for (int i = 0; i < actividad.Read().Count; i++)
                {
                    vs.Add(actividad.Read()[i].Descripcion1);
                }
                combActividad.ItemsSource = vs;
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
            
        }
        private void sourceTipoEmpresa() 
        {
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            List<string> vs = new List<string>();
            for (int i = 0; i < tipoEmpresa.Read().Count; i++)
            {
                vs.Add(tipoEmpresa.Read()[i].Descripcion1);
            }
            CombTipoEmpresa.ItemsSource = vs;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Cliente> ColectionCliente;
                Cliente cliente = new Cliente();
                ColectionCliente = cliente.ReadAll("gettabla", TextRutCliente.Text, 0, 0);

                if (ColectionCliente.Count < 2)
                {
                    TextNombre.Text = ColectionCliente[0].NombreContacto1;
                    TextDireccion.Text = ColectionCliente[0].Direccion1;
                    TextMail.Text = ColectionCliente[0].MailContacto1;
                    TextTelefono.Text = ColectionCliente[0].Telefono1;
                    TextRazonSocial.Text = ColectionCliente[0].RazonSocial1;
                    combActividad.Text = ColectionCliente[0].ActividadEmpresa1;
                    CombTipoEmpresa.Text = ColectionCliente[0].TipoEmpresa1;
                }
                NoEditar(false);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!!");
            }
           
        }


        private void NoEditar(bool estado)
        {
            TextNombre.IsEnabled = estado;
            TextDireccion.IsEnabled = estado;
            TextMail.IsEnabled = estado;
            TextTelefono.IsEnabled = estado;
            TextRazonSocial.IsEnabled = estado;
            combActividad.IsEnabled = estado;
            CombTipoEmpresa.IsEnabled = estado;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            NoEditar(true);
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextRutCliente.Text != "" && TextDireccion.Text != "" && combActividad.Text != "" && CombTipoEmpresa.Text != "" && TextMail.Text != "" && TextNombre.Text != "" && TextRazonSocial.Text != "" && TextRazonSocial.Text != "" && TextTelefono.Text != "")
                {
                    Cliente nuevoCliente = new Cliente(TextRutCliente.Text, TextRazonSocial.Text, TextNombre.Text, TextMail.Text, TextDireccion.Text, TextTelefono.Text, combActividad.Text, CombTipoEmpresa.Text);
                    if (nuevoCliente.Create("InsertCliente"))
                    {
                        MessageBox.Show("Ingresado");
                    }
                    else
                    {
                        MessageBox.Show("No ingresado Cliente ya existe");
                    }
                }
                else { MessageBox.Show("Se requieren todos los datos"); }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TextRutCliente.Text = "";
            TextNombre.Text = "";
            TextDireccion.Text = "";
            TextMail.Text = "";
            TextTelefono.Text = "";
            TextRazonSocial.Text = "";
            combActividad.Text = "";
            CombTipoEmpresa.Text = "";
            NoEditar(true);
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            ListaCliente listaCliente = new ListaCliente();
            listaCliente.Show();
            this.Close();
        }

        private void btnUpdateCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente updateCliente = new Cliente(TextRutCliente.Text, TextRazonSocial.Text, TextNombre.Text, TextMail.Text, TextDireccion.Text, TextTelefono.Text, combActividad.Text, CombTipoEmpresa.Text);
                if (updateCliente.Update("updateCliente"))
                {
                    MessageBox.Show("Cliente Actualizado");
                }
                else
                {
                    MessageBox.Show("Error de update");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!!");
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar al cliente rut: " + TextRutCliente.Text + "?", "Por favor Seleccione:", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Cliente borrarCliente = new Cliente();
                    if (borrarCliente.Delete("DeleteCliente", TextRutCliente.Text))
                    {
                        MessageBox.Show("Borrado con Éxito");
                    }
                    else
                    {
                        MessageBox.Show("Cliente está asociado a un contrato");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!!!");
            }
            
        }

        public void asignacion(string TextRutCliente1, string TextNombre1, string TextDireccion1, string TextMail1, string TextTelefono1, string TextRazonSocial1, string combActividad1,
            string CombTipoEmpresa1)
        {
            TextRutCliente.Text = TextRutCliente1;
            TextNombre.Text = TextNombre1;
            TextDireccion.Text = TextDireccion1;
            TextMail.Text = TextMail1;
            TextTelefono.Text = TextTelefono1;
            TextRazonSocial.Text = TextRazonSocial1;
            combActividad.Text = combActividad1;
            CombTipoEmpresa.Text = CombTipoEmpresa1;
            NoEditar(false);
        }
    }
}
