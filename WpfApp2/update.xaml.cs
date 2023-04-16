using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для update.xaml
    /// </summary>
    public partial class update : Page
    {
        People thisPeople;
        public Frame frame1;
        List<People> peoples = new List<People>();

        public update(Frame frame,People people)
        {
            frame1 = frame;
            thisPeople = people;
            InitializeComponent();

           
            peoples = Entities.GetContext().People.ToList();
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].ID == thisPeople.ID)
                {
                    name.Text = peoples[i].FirstName;
                    surname.Text = peoples[i].Surname;
                    calendar1.Text = Convert.ToString(peoples[i].date_bir);
                    if (peoples[i].id_pol == 1)
                    {
                        ppol.Text = "ж";
                    }
                    else
                    {
                        ppol.Text = "м";
                    }
                    group.Text = Convert.ToString(peoples[i].id_group);
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
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

            peoples[0].FirstName = name.Text;
            peoples[0].Surname = surname.Text;
            peoples[0].date_bir = DateTime.Parse(calendar1.Text);
            if (ppol.Text == "ж")
            {
                peoples[0].id_pol = 1;
            }
            else
            {
                peoples[0].id_pol = 2;
            }
            peoples[0].id_group = Convert.ToInt32(group.Text);
            Entities.GetContext().SaveChanges();
            frame1.Navigate(new GlavnList(frame1));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].ID == thisPeople.ID) 
                {
                    Entities.GetContext().People.Remove(peoples[i]);
                    Entities.GetContext().SaveChanges();
                }
            }
            
            
            frame1.Navigate(new GlavnList(frame1));
        }
    }
}
