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
    /// Логика взаимодействия для GlavnList.xaml
    /// </summary>
    public partial class GlavnList : Page
    {
        Frame frame1;
        List<People> people = new List<People>();
        //WpfApp2.People pep;

        public GlavnList(Frame frame)
        {
            
            InitializeComponent();
            frame1 = frame;
            people = Entities.GetContext().People.ToList();
            Llist.ItemsSource= people;
        }

       

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Add(frame1));
        }

        private void Llist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            var pep = ((ListView)sender).SelectedValue as People;
            frame1.Navigate(new update(frame1, pep));
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        public void Update() 
        {
            var poisk = Entities.GetContext().People.ToList();
            poisk = poisk.Where(p=> p.FirstName.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            Llist.ItemsSource = poisk;
        }
    }
}
