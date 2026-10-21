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
using System.Windows.Threading;

namespace autoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer; //sdsasd
        private Random r = new Random();
        private double celvonal = 650;
        private List<Button> autok = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            autok = new List<Button> { auto1, auto2, auto3 };
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            autok.Shuffle();
            foreach (Button item in autok)
            {
                Mozog(item);
            }
        }

        private void Mozog(Button auto)
        {
            double aktualisPozicio = Canvas.GetLeft(auto);
            double sebesseg = r.Next(1, 6);
            double ujPozicio = aktualisPozicio + sebesseg;
            Canvas.SetLeft(auto, ujPozicio);
            if (ujPozicio >= celvonal)
            {
                timer.Stop();
                MessageBox.Show($"{auto.Content} nyert!");
                foreach (Button item in autok)
                {
                    Canvas.SetLeft(item, 20);
                }
            }
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button item in autok)
            {
                Canvas.SetLeft(item, 20);
            }
            timer.Start();
            //jajajj

        }
    }
}