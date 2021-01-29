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
    /// Logique d'interaction pour LesReservations.xaml
    /// </summary>
    public partial class LesReservations : Window
    {
        public LesReservations()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projet Gite Montagne\projet gite\projet gite\donnees.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlDataReader rdr = null;
            var cmd = new SqlCommand("Select nom,prenom,FORMAT (dateArrivee, 'dd/MM/yyyy '),FORMAT (dateSortie, 'dd/MM/yyyy '),chambre.nomChambre from client inner join chambre on client.id_chambre = chambre.chamberId", conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lstresa.Items.Add(rdr[0].ToString() + rdr[1].ToString() + rdr[2] + " au " + rdr[3] + rdr[4].ToString());
            }

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
