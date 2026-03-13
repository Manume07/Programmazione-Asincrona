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

namespace ProgrammazioneAsincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int contatoreLettere = 0;
        int lunghezza = 5;
        string frase = "";
        string lettera = "";
        Random rnd = new Random();
        char[] lettere = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public MainWindow()
        {
            InitializeComponent();
            Rolling();
            txtLunghezza.Text = "5";
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

        private async void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtLunghezza.Text, out int lungo) || lungo <= 0)
            {
                txtLunghezza.BorderThickness = new Thickness(3);
                txtLunghezza.BorderBrush = Brushes.Red; 
                MessageBox.Show("Inserisci un numero valido. Impostata lunghezza a 5");
                lunghezza = 5;
                txtLunghezza.Text = "5";
                txtLunghezza.BorderThickness = new Thickness(1);
                txtLunghezza.BorderBrush = Brushes.Gray;
            }
            else
            {
                lunghezza = lungo;
                if (contatoreLettere < lunghezza)
                {
                    frase = frase + lettera;
                    contatoreLettere++;
                }
                else
                {
                    frase = frase + "\n" + lettera; // Aggiunge a capo E la lettera corrente
                    contatoreLettere = 1; // Reset a 1 perché la prima lettera della nuova riga c'è già
                }
            }
            txtbStampa.Text = frase;
        }
    }
}