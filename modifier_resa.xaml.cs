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
    /// Logique d'interaction pour modifier_resa.xaml
    /// </summary>
    public partial class modifier_resa : Window
    {
        public modifier_resa()
        {
            InitializeComponent();
            if (chkboxClient.IsChecked == false)
            {
                lblNom.Visibility = Visibility.Hidden;
                lblPrenom.Visibility = Visibility.Hidden;
                txtboxNom.Visibility = Visibility.Hidden;
                txtboxPrenom.Visibility = Visibility.Hidden;
                btnValider.Visibility = Visibility.Hidden;
            }
            if (chkboxChambre.IsChecked == false)
            {
                comboChambre.Visibility = Visibility.Hidden;
                btnValiderModifChambre.Visibility = Visibility.Hidden;
            }
            SqlConnection conn3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            var cmd3 = new SqlCommand("select nomChambre from chambre ", conn3);
            conn3.Open();
            var rdr3 = cmd3.ExecuteReader();
            while (rdr3.Read())
            {
                //lstboxChambre.Items.Add(rdr3[0].ToString());
                comboChambre.Items.Add(rdr3[0].ToString());

            }
            conn3.Close();
            lstChambre.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlDataReader rdr = null;
            var cmd = new SqlCommand("Select * from client", conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lstChambre.Items.Add(rdr[1].ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstChambre.SelectedItem == null)
                {

                    MessageBox.Show("Veuillez selectionner une reservation", "Erreur", MessageBoxButton.OK,MessageBoxImage.Warning) ;
                }
                else
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
                    //string splitlst = lstChambre.SelectedItem.ToString();
                    // splitlst = splitlst.Remove(1, splitlst.Length - 1);

                    var cmd = new SqlCommand("Delete from client where nom = '" + lstChambre.SelectedItem.ToString() + "' ", conn) ;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete successfull");

                    conn.Close();
                }

            }
            catch(System.Data.SqlClient.SqlException)
            {
                
                
                MessageBox.Show("error");
            }

            lstChambre.Items.Clear();
            SqlConnection conn2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            var cmd2 = new SqlCommand("Select * from client", conn2);

            conn2.Open();
            var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                lstChambre.Items.Add(rdr[1].ToString());
            }
            conn2.Close();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Menu menu = new Menu();
            menu.Show();
            this.Close();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void chkboxClient_Checked(object sender, RoutedEventArgs e)
        {
            
            
                lblNom.Visibility = Visibility.Visible;
                lblPrenom.Visibility = Visibility.Visible;
                txtboxNom.Visibility = Visibility.Visible;
                txtboxPrenom.Visibility = Visibility.Visible;
                btnValider.Visibility = Visibility.Visible;

            







        }

        private void chkboxClient_Unchecked(object sender, RoutedEventArgs e)
        {
            lblNom.Visibility = Visibility.Hidden;
            lblPrenom.Visibility = Visibility.Hidden;
            txtboxNom.Visibility = Visibility.Hidden;
            txtboxPrenom.Visibility = Visibility.Hidden;
            btnValider.Visibility = Visibility.Hidden;
        }

        private void chkboxChambre_Unchecked(object sender, RoutedEventArgs e)
        {
            comboChambre.Visibility = Visibility.Hidden;
            btnValider.Visibility = Visibility.Hidden;

        }

        private void chkboxChambre_Checked(object sender, RoutedEventArgs e)
        {
            comboChambre.Visibility = Visibility.Visible;
            btnValiderModifChambre.Visibility = Visibility.Visible;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string reqSql = "update client set nom='" + txtboxNom.Text + "',prenom='" + txtboxPrenom.Text + "' WHERE nom='" + lstChambre.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(reqSql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();


            
        }

        private void btnValiderModifChambre_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            conn4.Open();
            

            
            SqlDataReader rdr = null;

            var cmd3 = new SqlCommand("Select chamberId from chambre where nomChambre = '" + comboChambre.SelectedItem + "'", conn4);
            rdr = cmd3.ExecuteReader();
            rdr.Read();
            SqlConnection conn5 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            conn5.Open();
            //DateTime.Now.ToString("dd - MM - yyyy");
            //var cmd2 = new SqlCommand("insert into client(nom,prenom,dateArrivee,dateSortie,id_chambre) values('" + txtBoxNom.Text + "', '" + txtBoxPrenom.Text + "', '" + dateArrive.SelectedDate.Value.ToString("MM-dd-yyyy") + "','" + dateSortie.SelectedDate.Value.ToString("MM-dd-yyyy") + "' , '" + rdr[0] + "' )", conn);
            var updateChambre = new SqlCommand("update client set id_chambre= '" + rdr[0] + "' where nom='" + lstChambre.SelectedItem + "'",conn5);

            

            updateChambre.ExecuteNonQuery();
            MessageBox.Show("Modification effectuée");
            rdr.Close();
            conn4.Close();
            conn5.Close();

        }
    }
}
