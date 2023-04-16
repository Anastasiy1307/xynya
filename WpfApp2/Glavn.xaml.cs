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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Glavn.xaml
    /// </summary>
    public partial class Glavn : Page
    {
        public Frame frame1;
        List<Kod_podrazdel> kod_s = new List<Kod_podrazdel>();

        public Glavn(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
           kod_s = Entities.GetContext().Kod_podrazdel.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < kod_s.Count; i++)
            {
                if (KOD.Text == kod_s[i].Kodpodrazdel)
                {
                    frame1.Navigate(new GlavnList(frame1));
                }
                else
                {
                    MessageBox.Show("Код подразделения не верен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
