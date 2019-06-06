using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace carichini.alessandro._5i.WpfLasagna
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        async private void Visualizza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                btnVisualizza.Background = Brushes.Yellow; //cambia il colore durante l'operazione asincrona
                List<Lasagna> lasagne = JsonConvert.DeserializeObject<List<Lasagna>>(await client.GetStringAsync("https://flr.azurewebsites.net/api/lasagna"));
                btnVisualizza.Background = Brushes.LightBlue;
                lwDati.ItemsSource = lasagne;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                btnVisualizza.Background = Brushes.LightBlue;//Ritorno vecchio colore del bottone
            }
        }

        public class Lasagna
        {
            public string Nome { get; set; }
            public string Peso { get; set; }
            public string StrPeso { get { return $"Peso: {Peso}"; } }
            public string UrlImmagine { get; set; }
        }
    }
}
