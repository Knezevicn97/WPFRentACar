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
using System.Data;
using System.Data.SqlClient;

namespace WPFRentACar.Forme
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class DodajVlasnika : Window
	{
		public SqlConnection konekcija = Konekcija.KreirajKonekciju();

		public DodajVlasnika()
		{
	
			InitializeComponent();
			txtImeKorisnika.Focus();
		}
		private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
					string insert = @"insert into tblKorisnik(ImeKorisnika, PrezimeKorisnika, JMBG , Adresa, Grad, Kontakt, BrojVozacke)
                                values ('" + txtImeKorisnika.Text + "', '" + txtPrezimeKorisnika.Text + "', '" + txtJMBG.Text+ "', '" + txtBrojVozacke.Text + "', '" + txtAdresa.Text + "', '" + txtKontakt.Text + "', '" + txtGrad.Text + "');";
					SqlCommand cmd = new SqlCommand(insert, konekcija);
					cmd.ExecuteNonQuery();
					this.Close(); //zatvori prozor
				
			}
			catch (SqlException)
			{
				MessageBox.Show("Unos odredjenih vrednosti nije validan.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}
		}
		private void btnOtkazi_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
