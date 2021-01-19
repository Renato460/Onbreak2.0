using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using Xceed.Wpf.Toolkit;

namespace OnBreak2._0
{
    /// <summary>
    /// Lógica de interacción para AdminContratos.xaml
    /// </summary>
    public partial class AdminContratos : Window
    {
        public AdminContratos()
        {
            InitializeComponent();
            List<string> listaRuts = new List<string>();
            List<string> listaContratos = new List<string>();
            Cliente cliente = new Cliente();
            Contratos contratos = new Contratos();
            for (int i = 0; i < cliente.ReadAll("gettabla", "", 0, 0).Count; i++)
            {
                listaRuts.Add(cliente.ReadAll("gettabla", "", 0, 0)[i].RutCliente1);
            }
            //System.Windows.MessageBox.Show(""+contratos.prueba("getContrato", "", "", "", 0));
            for (int i = 0; i < contratos.Read("getContrato", "", "", "", 0).Count; i++)
            {
                listaContratos.Add(contratos.Read("getContrato", "", "", "", 0)[i].NumeroContrato1);
            }
            cmbNumeroContrato.ItemsSource = listaContratos;
            cmbRutCliente.ItemsSource = listaRuts;
            TipoEvento tipoEvento = new TipoEvento();
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            
            cmbTipoEvento.ItemsSource = getTipoEventoDesc(tipoEvento.Read("getTipoEvento", 0));
            cmbModalidadEvento.ItemsSource = getModalidadEventoNom(modalidadServicio.Read("getModServicio", 0));
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbNumeroContrato.Text.Equals(""))
                {
                    System.Windows.MessageBox.Show("Ingrese un numero de contrato");
                }
                else
                {
                    Contratos buscarcontratos = new Contratos();
                    ObservableCollection<Contratos> contratos = buscarcontratos.Read("getContrato", cmbNumeroContrato.Text, "", "", 0);
                    cmbRutCliente.Text = contratos[0].RutCliente1;
                    FechaCreacionContrato.Value = contratos[0].Creacion1;
                    //FechaTerminoContrato.Value = DateTime.Parse(contratos[0].Termino1.ToString());
                    DateTime date = DateTime.Parse("31-12-3000 00:00:00");
                    if (contratos[0].Termino1 == date)
                    {
                        FechaTerminoContrato.Value = null;
                    }
                    else
                    {
                        FechaTerminoContrato.Value = contratos[0].Termino1;
                    }
                    
                    textNombreCliente.Text = contratos[0].NombreCliente1;
                    cmbTipoEvento.Text = contratos[0].TipoEvento1;
                    cmbModalidadEvento.Text = contratos[0].Modalidad1;
                    FechaInicioEvento.Value = contratos[0].FechaHoraInicio1;

                    FechaTerminoEvento.Value = contratos[0].FechaHoraTermino1;
                    textAsistentes.Text = contratos[0].Asistentes1.ToString();
                    textPersonalAdicional.Text = contratos[0].PersonalAdicional1.ToString();
                    textObservaciones.Text = contratos[0].Observaciones1;
                    ValorTotal.Content = contratos[0].ValorTotalContrato1;
                    if (contratos[0].Realizado1 == 1)
                    {
                        checkRealizado.IsChecked = true;
                    }
                    else { checkRealizado.IsChecked = false; }
                    cmbRutCliente.IsEnabled = false;
                    SetDisable(false);
                }
            }
            catch (Exception d)
            {
                System.Windows.MessageBox.Show("Error!! "+ d.Message);
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

        private void btnNuevoContrato_Click(object sender, RoutedEventArgs e)
        {
            
           
            if (FechaTerminoEvento.Text != "" && cmbRutCliente.Text != "" && cmbModalidadEvento.Text != "" && cmbTipoEvento.Text != "" &&
            textAsistentes.Text != "" && FechaInicioEvento.Text != "" && textObservaciones.Text != ""&& textPersonalAdicional.Text != "")
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    string fecha = dateTime.ToString("yyyyMMddHHmm");
                    Contratos nuevoContrato = new Contratos();
                    TipoEvento evento = new TipoEvento();
                    int _IdTipoEvento = 0;
                    ModalidadServicio modalidadServicio = new ModalidadServicio();
                    string _IdModalidad = "";
                    for (int i = 0; i < evento.Read("getTipoEvento", 0).Count; i++)
                    {
                        if (evento.Read("getTipoEvento", 0)[i].Descripcion1.Equals(cmbTipoEvento.Text))
                        {
                            _IdTipoEvento = evento.Read("getTipoEvento", 0)[i].Id1;

                        }
                    }

                    for (int i = 0; i < modalidadServicio.Read("getModServicio", 0).Count; i++)
                    {
                        if (modalidadServicio.Read("getModServicio", 0)[i].Nombre1.Equals(cmbModalidadEvento.Text))
                        {
                            _IdModalidad = modalidadServicio.Read("getModServicio", 0)[i].Id1;
                        }
                    }
                   
                    DateTime _FechaHoraInicio = DateTime.Parse(FechaInicioEvento.Text);
                    DateTime _FechaHoraTermino = DateTime.Parse(FechaTerminoEvento.Text);
                    int _Asistentes = Int32.Parse(textAsistentes.Text);
                    int _PersonalAdicional = Int32.Parse(textPersonalAdicional.Text);
                    int _Realizado = 0;
                    if (checkRealizado.IsChecked == true)
                    {
                        _Realizado = 1;
                    }

                    float _ValorTotalContrato = calculoEvento(_Asistentes, _PersonalAdicional);

                    if (nuevoContrato.Create("InsertContratos", fecha, dateTime, cmbRutCliente.Text, _IdModalidad, _IdTipoEvento, _FechaHoraInicio,
                    _FechaHoraTermino, _Asistentes, _PersonalAdicional, _Realizado, _ValorTotalContrato, textObservaciones.Text))
                    {
                        System.Windows.MessageBox.Show("Ingresado");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No ingresado Contrato ya existe");
                    }
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error de base de datos");
                }
            }
        }

        private float calculoEvento(int _Asistentes, int _PersonalAdicional) 
        {
            try
            {
                Valorizador valorizador = new Valorizador();
                float _ValorTotalContrato = valorizador.CalcularValorEvento(cmbTipoEvento.Text, cmbModalidadEvento.Text, _Asistentes, _PersonalAdicional);
                return _ValorTotalContrato;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbNumeroContrato.Text = "";
            FechaCreacionContrato.Text = "";
            FechaTerminoContrato.Text = "";
            FechaTerminoEvento.Text = "";
            cmbRutCliente.Text = "";
            cmbModalidadEvento.Text = "";
            cmbTipoEvento.Text = "";
            textAsistentes.Text = "";
            FechaInicioEvento.Text = "";
            textObservaciones.Text = "";
            textNombreCliente.Text = "";
            textPersonalAdicional.Text = "";
            checkRealizado.IsChecked = false;
            ValorTotal.Content = "";
        }

        private void btnEditarContrato_Click(object sender, RoutedEventArgs e)
        {
            SetDisable(true);
        }

        private void btnUpdateContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contratos contratos = new Contratos();
                TipoEvento evento = new TipoEvento();
                int _IdTipoEvento = 0;
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                string _IdModalidad = "";
                for (int i = 0; i < evento.Read("getTipoEvento", 0).Count; i++)
                {
                    if (evento.Read("getTipoEvento", 0)[i].Descripcion1.Equals(cmbTipoEvento.Text))
                    {
                        _IdTipoEvento = evento.Read("getTipoEvento", 0)[i].Id1;

                    }
                }

                for (int i = 0; i < modalidadServicio.Read("getModServicio", 0).Count; i++)
                {
                    if (modalidadServicio.Read("getModServicio", 0)[i].Nombre1.Equals(cmbModalidadEvento.Text))
                    {
                        _IdModalidad = modalidadServicio.Read("getModServicio", 0)[i].Id1;
                    }
                }
                int _realizado = 0;
                if (checkRealizado.IsChecked == true)
                {
                    _realizado = 1;
                }
                int _Asistentes = Int32.Parse(textAsistentes.Text);
                int _PersonalAdicional = Int32.Parse(textPersonalAdicional.Text);
                float _ValorTotalContrato = calculoEvento(_Asistentes, _PersonalAdicional);
                DateTime _FechaInicioEvento = DateTime.Parse(FechaInicioEvento.Text);
                DateTime _FechaTerminoEvento = DateTime.Parse(FechaTerminoEvento.Text);
                if (contratos.Update("UpdateContrato", cmbNumeroContrato.Text, _IdModalidad, _IdTipoEvento, _FechaInicioEvento, _FechaTerminoEvento,
                    _Asistentes, _PersonalAdicional, _realizado, _ValorTotalContrato, textObservaciones.Text))
                {
                    System.Windows.MessageBox.Show("Se hicieron correcciones!!");
                    SetDisable(false);
                }
                else
                {
                    System.Windows.MessageBox.Show("No hubo cambios!!");
                }
                
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("Error!!");
            }

        }

        private void btnSeleccListaContra_Click(object sender, RoutedEventArgs e)
        {
            ListaContratos listaContratos = new ListaContratos();
            listaContratos.Show();
            this.Close();
        }

        private void SetDisable(bool estado)
        {
            
            cmbModalidadEvento.IsEnabled = estado;
            cmbTipoEvento.IsEnabled = estado;
            FechaInicioEvento.IsEnabled = estado;
            FechaTerminoEvento.IsEnabled = estado;
            textAsistentes.IsEnabled = estado;
            textPersonalAdicional.IsEnabled = estado;
            checkRealizado.IsEnabled = estado;
            textObservaciones.IsEnabled = estado;
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

        private void textAsistentes_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int asistentes;
                int personal;
                if (textAsistentes.Text.Equals(""))
                {
                    asistentes = 0;
                }
                else
                {
                    asistentes = Int32.Parse(textAsistentes.Text);
                }

                if (textPersonalAdicional.Text.Equals(""))
                {
                    personal = 0;
                }
                else
                {
                    personal = Int32.Parse(textPersonalAdicional.Text);
                }
                ValorTotal.Content = calculoEvento(asistentes, personal) + " UF";
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("ERROR!!!");
            }
           
        }

        private void textPersonalAdicional_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int asistentes;
                int personal;
                if (textAsistentes.Text.Equals(""))
                {
                    asistentes = 0;
                }
                else
                {
                    asistentes = Int32.Parse(textAsistentes.Text);
                }

                if (textPersonalAdicional.Text.Equals(""))
                {
                    personal = 0;
                }
                else
                {
                    personal = Int32.Parse(textPersonalAdicional.Text);
                }
                ValorTotal.Content = calculoEvento(asistentes, personal) + " UF";
            }
            catch (Exception)
            {

            }
            
        }

        private void cmbRutCliente_DropDownClosed(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            for (int i = 0; i < cliente.ReadAll("gettabla", cmbRutCliente.Text, 0, 0).Count; i++)
            {
                textNombreCliente.Text = cliente.ReadAll("gettabla", cmbRutCliente.Text, 0, 0)[i].NombreContacto1.ToString();
            }
        }

        private void cmbModalidadEvento_DropDownClosed(object sender, EventArgs e)
        {
            int asistentes;
            int personal;
            if (textAsistentes.Text.Equals(""))
            {
                asistentes = 0;
            }
            else
            {
                asistentes = Int32.Parse(textAsistentes.Text);
            }

            if (textPersonalAdicional.Text.Equals(""))
            {
                personal = 0;
            }
            else
            {
                personal = Int32.Parse(textPersonalAdicional.Text);
            }
            ValorTotal.Content = calculoEvento(asistentes, personal) + " UF";
        }

        private void btnTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool v = cmbNumeroContrato.Text.Equals("");
                if (v)
                {
                    System.Windows.MessageBox.Show("Debe buscar un contrato");
                }
                else
                {
                    if (System.Windows.MessageBox.Show("¿Está seguro de terminar el contrato n°: " + cmbNumeroContrato.Text + "?", "Por favor Seleccione:", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Contratos contratos = new Contratos();
                        DateTime dateTime = DateTime.Now;
                        if (contratos.TerminoContrato("TerminoContrato", cmbNumeroContrato.Text, dateTime))
                        {
                            System.Windows.MessageBox.Show("Contrato Terminado");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error!!");
                        }
                        btnBuscar_Click(sender, e);
                    }

                }
            }
            catch (Exception)
            { 
                System.Windows.MessageBox.Show("Error en Base de datos!!");
            }
            
            
        }

        public void asignacion(string numeroContrato1, DateTime creacion1, DateTime termino1, string rutCliente1, string nombreCliente1, 
            string modalidad1, string tipoEvento1, DateTime fechaHoraInicio1, DateTime fechaHoraTermino1, int asistentes1, int personalAdicional1, int realizado1, float valorTotalContrato1, string observaciones1) 
        {
            cmbNumeroContrato.Text = numeroContrato1;
            cmbRutCliente.Text = rutCliente1;
            FechaCreacionContrato.Value = creacion1;
            FechaTerminoContrato.Value = termino1;
            textNombreCliente.Text = nombreCliente1;
            cmbTipoEvento.Text = tipoEvento1;
            cmbModalidadEvento.Text = modalidad1;
            FechaInicioEvento.Value = fechaHoraInicio1;

            FechaTerminoEvento.Value = fechaHoraTermino1;
            textAsistentes.Text = asistentes1.ToString(); ;
            textPersonalAdicional.Text = personalAdicional1.ToString();
            textObservaciones.Text = observaciones1;
            ValorTotal.Content = valorTotalContrato1.ToString();
            if (realizado1 == 1)
            {
                checkRealizado.IsChecked = true;
            }
            else { checkRealizado.IsChecked = false; }
            cmbRutCliente.IsEnabled = false;
            SetDisable(false);
        }
    }
}
