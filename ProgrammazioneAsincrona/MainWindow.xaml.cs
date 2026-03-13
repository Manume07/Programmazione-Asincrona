using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgrammazioneAsincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string frase;
        string lettera = "";
        Random rnd = new Random();
        char[] lettere = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public MainWindow()
        {
            InitializeComponent();
            Rolling();
        }
        private async Task Rolling()
        {

            while (true)
            {
                lettera = lettere[rnd.Next(0, 26)].ToString().ToUpper();
                lblLetteraRotante.Content = lettera;
                await Task.Delay(100);
            }
        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            frase = frase + lettera;
            txtbStampa.Text = frase;
        }

    }
}