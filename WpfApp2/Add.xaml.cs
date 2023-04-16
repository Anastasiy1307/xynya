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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Frame frame1;
        List<Pol> pols = new List<Pol>();
        List<People> people = new List<People> ();

        public Add(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            pols = Entities.GetContext().Pol.ToList();
            people = Entities.GetContext().People.ToList();

            //calendar1.SelectedDate = DateTime.Parse("31.12.2011 23:59:59");
            //int age = DateTime.Now.Year - calendar1.SelectedDate.Value.Year;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ADD();
            frame1.Navigate(new GlavnList(frame1));
        }
        public void ADD()
        {
            DateTime BD = DateTime.Parse(calendar1.Text);
            DateTime n = DateTime.Now;
            TimeSpan timeSpan = n.Subtract(BD);
            string days = Convert.ToString(timeSpan);
            string[] day = days.Split('.');
            days = day[0];
            double age = int.Parse(days) / 365;
            if (1 <= age && age < 3)
            {
                group.Text = "1";
            }
            else if (3 <= age && age < 7)
            {
                group.Text = "2";
            }
            else if (7 <= age && age < 14)
            {
                group.Text = "3";
            }
            else if (14 <= age && age < 18)
            {
                group.Text = "4";
            }

            people[0].FirstName = name.Text;
            people[0].Surname = surname.Text;
            people[0].date_bir = calendar1.SelectedDate;
            people[0].id_group = Convert.ToInt32(group.Text);
            if (ppol.Text == "ж")
            {
                people[0].id_pol = 1;
            }
            else
            {
                people[0].id_pol = 2;
            }
            Entities.GetContext().People.Add(people[0]);
            Entities.GetContext().SaveChanges();
        }
    }
}
