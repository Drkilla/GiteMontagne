using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace projet_gite
{
    /// <summary>
    /// Logique d'interaction pour reservation_chambre.xaml
    /// </summary>
    public partial class reservation_chambre : Window
    {
        public reservation_chambre()
        {
            InitializeComponent();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBoxNom.Clear();
            txtBoxPrenom.Clear();
           
            lstChambre.SelectedItem = null;
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();
                SqlDataReader rdr = null;

                var cmd3 = new SqlCommand("Select chamberId from chambre where nomChambre = '" + lstChambre.SelectedItem + "'", conn);
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                DateTime.Now.ToString("dd - MM - yyyy");
                var cmd2 = new SqlCommand("insert into client(nom,prenom,dateArrivee,dateSortie,id_chambre) values('" + txtBoxNom.Text + "', '" + txtBoxPrenom.Text + "', '" + dateArrive.SelectedDate.Value.ToString("MM-dd-yyyy") + "','" + dateSortie.SelectedDate.Value.ToString("MM-dd-yyyy") + "' , '" + rdr[0] + "' )", conn);


                rdr.Close();

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Reservation confirmée");
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("veuillez selectionner une autre date ");
            }






        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void dateSortie_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlDataReader rdr = null;

                var cmd = new SqlCommand("SELECT nomChambre from chambre LEFT OUTER JOIN client ON (chambre.chamberId = client.id_chambre AND('" + dateArrive.SelectedDate.Value.ToString("MM-dd-yyyy") + "'BETWEEN client.dateArrivee AND client.dateSortie OR '" + dateSortie.SelectedDate.Value.ToString("MM-dd-yyyy") + "' BETWEEN client.dateArrivee AND client.dateSortie OR client.dateArrivee BETWEEN '" + dateArrive.SelectedDate.Value.ToString("MM-dd-yyyy") + "'AND '" + dateSortie.SelectedDate.Value.ToString("MM-dd-yyyy") + "' OR client.dateSortie BETWEEN '" + dateArrive.SelectedDate.Value.ToString("MM-dd-yyyy") + "' AND '" + dateSortie.SelectedDate.Value.ToString("MM-dd-yyyy") + "'))WHERE client.id_chambre IS NULL", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lstChambre.Items.Add(rdr[0].ToString());

                }

                if (lstChambre != null)
                {
                    conn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Veuillez selectionner une date");

            }
        }
    }
}
