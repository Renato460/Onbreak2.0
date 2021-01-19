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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnBreak2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdmCliente_Click(object sender, RoutedEventArgs e)
        {
            AdminCliente adminCliente = new AdminCliente();
            adminCliente.Show();
        }

        private void ListCliente_Click(object sender, RoutedEventArgs e)
        {
            ListaCliente listaCliente = new ListaCliente();
            listaCliente.Show();
        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos adminContratos = new AdminContratos();
            adminContratos.Show();
        }

        private void ListContratos_Click(object sender, RoutedEventArgs e)
        {
            ListaContratos listaContratos = new ListaContratos();
            listaContratos.Show();
        }
    }
}
