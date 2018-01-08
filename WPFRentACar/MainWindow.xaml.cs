using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WPFRentACar.Forme;

namespace WPFRentACar
{

	public partial class MainWindow : Window
	{
		public SqlConnection konekcija = Konekcija.KreirajKonekciju();
		public static bool azuriraj;
		public static object pomocni;
		public static void PocetniDataGrid(DataGrid grid)
		{
			try
			{
				konekcija.Open();
			}
			catch (Exception ex)
			{

				System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}

		}

		public MainWindow()
		{
			InitializeComponent();
			PocetniDataGrid(CentralniGrid);
		}

		private void Button_Click_Vozila(object sender, RoutedEventArgs e)
		{
			btnDodajVozilo.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniVozilo.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiVozilo.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;
		}
		private void Button_Click_Korisnik(object sender, RoutedEventArgs e)
		{
			btnDodajKorisnika.Visibility = Visibility.Visible;

			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniKorisnika.Visibility = Visibility.Visible;

			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiKorisnika.Visibility = Visibility.Visible;

			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;
		}
		private void Button_Click_Vozaci(object sender, RoutedEventArgs e)
		{
			btnDodajVozaca.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniVozaca.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiVozaca.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;
		}
		private void Button_Click_Marke(object sender, RoutedEventArgs e)
		{
			btnDodajMarku.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniMarku.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiMarku.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;

			try
			{
				konekcija.Open();

				string upit = "select MarkaID as ID, Marka from tblMarka";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("Marka");
				dataAdapter.Fill(dt);
				CentralniGrid.ItemsSource = dt.DefaultView;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}
		}
		private void Button_Click_Modeli(object sender, RoutedEventArgs e)
		{
			btnDodajModel.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniModel.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiModel.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;

			try
			{
				konekcija.Open();

				string upit = "select ModelID as ID, Model from tblModel";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("Model");
				dataAdapter.Fill(dt);
				CentralniGrid.ItemsSource = dt.DefaultView;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}
		}
		private void Button_Click_Tipovi(object sender, RoutedEventArgs e)
		{
			btnDodajTipVozila.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;

			//IZMENI
			btnIzmeniTipVozila.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;

			//OBRISI
			btnObrisiTipVozila.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;

		}
	}
}
