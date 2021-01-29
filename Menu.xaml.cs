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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace projet_gite
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();

            listResa.Items.Clear();
           
            
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                SqlDataReader rdr = null;
                var cmd = new SqlCommand("Select nom,prenom,FORMAT (dateArrivee, 'dd/MM/yyyy '),FORMAT (dateSortie, 'dd/MM/yyyy '),chambre.nomChambre from client inner join chambre on client.id_chambre = chambre.chamberId", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listResa.Items.Add(rdr[0].ToString() +" "+ rdr[1].ToString()+ " " + rdr[2] + " au " + rdr[3] + " "+ rdr[4].ToString());
                }
            
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reservation_chambre reserv = new reservation_chambre();
           
            reserv.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            modifier_resa modifres = new modifier_resa();
            modifres.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LesReservations reservations = new LesReservations();
            reservations.ShowDialog();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            fichierClients clients = new fichierClients();
            clients.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();




        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
               
            
        }
    }
}
