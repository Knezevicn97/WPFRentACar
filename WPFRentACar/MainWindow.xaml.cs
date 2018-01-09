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
		public static object selektovan;
		public void PocetniDataGrid(DataGrid grid)
		{
			try
			{
				konekcija.Open();
				string upit = @"Select ";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("Vozilo");
				dataAdapter.Fill(dt);
				grid.ItemsSource = dt.DefaultView;

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

			
			btnIzmeniVozilo.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			
			btnObrisiVozilo.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;

			PocetniDataGrid(CentralniGrid);

			
		}
		private void Button_Click_Korisnik(object sender, RoutedEventArgs e)
		{
			btnDodajKorisnika.Visibility = Visibility.Visible;

			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			
			btnIzmeniKorisnika.Visibility = Visibility.Visible;

			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			
			btnObrisiKorisnika.Visibility = Visibility.Visible;

			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;

			try
			{
				konekcija.Open();

				string upit = "select KorisnikID as ID, ImeKorisnika as Ime, PrezimeKorisnika as Prezime, JMBG," +
								" Adresa , BrojVozacke, Kontakt, Grad from tblKorisnik";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("Korisnik");
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
		private void Button_Click_Vozaci(object sender, RoutedEventArgs e)
		{
			btnDodajVozaca.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajMarku.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			
			btnIzmeniVozaca.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			
			btnObrisiVozaca.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiTipVozila.Visibility = Visibility.Collapsed;

			try
			{
				konekcija.Open();

				string upit = "select VozacID as ID, ImeVozaca , PrezimeVozaca ,  from tblVozac";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("Vozac");
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
		private void Button_Click_Marke(object sender, RoutedEventArgs e)
		{
			btnDodajMarku.Visibility = Visibility.Visible;

			btnDodajKorisnika.Visibility = Visibility.Collapsed;
			btnDodajVozaca.Visibility = Visibility.Collapsed;
			btnDodajVozilo.Visibility = Visibility.Collapsed;
			btnDodajModel.Visibility = Visibility.Collapsed;
			btnDodajTipVozila.Visibility = Visibility.Collapsed;

			
			btnIzmeniMarku.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			
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

			
			btnIzmeniModel.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;
			btnIzmeniTipVozila.Visibility = Visibility.Collapsed;

			
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

			
			btnIzmeniTipVozila.Visibility = Visibility.Visible;

			btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
			btnIzmeniVozaca.Visibility = Visibility.Collapsed;
			btnIzmeniMarku.Visibility = Visibility.Collapsed;
			btnIzmeniModel.Visibility = Visibility.Collapsed;
			btnIzmeniVozilo.Visibility = Visibility.Collapsed;

			
			btnObrisiTipVozila.Visibility = Visibility.Visible;

			btnObrisiKorisnika.Visibility = Visibility.Collapsed;
			btnObrisiVozaca.Visibility = Visibility.Collapsed;
			btnObrisiMarku.Visibility = Visibility.Collapsed;
			btnObrisiModel.Visibility = Visibility.Collapsed;
			btnObrisiVozilo.Visibility = Visibility.Collapsed;

			try
			{
				konekcija.Open();

				string upit = "select TipVozilaID as ID, Tip from tblTipVozila";
				SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
				DataTable dt = new DataTable("TipVozila");
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

		private void Button_DodajVozilo_Click(object sender, RoutedEventArgs e)
		{
			DodajVozilo prozor = new DodajVozilo();
			prozor.ShowDialog();
			PocetniDataGrid(CentralniGrid);
		}
		private void Button_DodajKorisnika_Click(object sender, RoutedEventArgs e)
		{
			DodajKorisnika prozor = new DodajKorisnika();
			prozor.ShowDialog();
			Button_Click_Korisnik(sender, e);
		}
		private void Button_DodajMarku_Click(object sender, RoutedEventArgs e)
		{
			frmMarka prozor = new frmMarka();
			prozor.ShowDialog();
			Button_Click_Marke(sender, e);
		}
		private void Button_DodajModel_Click(object sender, RoutedEventArgs e)
		{
			frmModel prozor = new frmModel();
			prozor.ShowDialog();
			Button_Click_Modeli(sender, e);
		}
		private void Button_DodajTip_Click(object sender, RoutedEventArgs e)
		{
			frmTipVozila prozor = new frmTipVozila();
			prozor.ShowDialog();
			Button_Click_Tipovi(sender, e);
		}
		private void Button_DodajVozaca_Click(object sender, RoutedEventArgs e)
		{
			DodajVozaca prozor = new DodajVozaca();
			prozor.ShowDialog();
			Button_Click_Vozaci(sender, e);
		}


		private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblKorisnik where KorisnikID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Korisnik(sender, e);
			}
		}
		private void btnObrisiMarku_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblMarka where MarkaID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Marke(sender, e);
			}
		}

		private void btnObrisiModel_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblModel where ModelID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Modeli(sender, e);
			}
		}
		private void btnObrisiTip_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblTipVozila where TipVozilaID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Tipovi(sender, e);
			}
		}
		private void btnObrisiVozilo_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblVozilo where VoziloID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Vozila(sender, e);
			}
		}
		private void btnObrisiVozaca_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				string upit = "Delete from tblVozac where VozacID=" + red["ID"];

				MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (rezultat == MessageBoxResult.Yes)
				{
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!", "Greska");
			}
			catch (SqlException)
			{
				MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "greska");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Vozaci(sender, e);
			}
		}
		private void btnIzmeniVozaca_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				DodajVozaca prozor = new DodajVozaca();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select ImeVozaca, PrezimeVozaca, BrojVozacke from tblVozac where VozacID=" + red["ID"];

				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.txtImeVozaca.Text = citac["ImeVozaca"].ToString();
					prozor.txtPrezimeVozaca.Text = citac["PrezimeVozaca"].ToString();
					prozor.txtBrojVozacke.Text = citac["BrojVozacke"].ToString();
				}
				prozor.ShowDialog();
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Vozaci(sender, e);
				azuriraj = false;
			}
		}
		private void btnIzmeniMarku_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				frmMarka prozor = new frmMarka();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select Marka from tblMarka where MarkaID=" + red["ID"];

				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.ShowDialog();
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Marke(sender, e);
				azuriraj = false;
			}
		}

		private void btnIzmeniModel_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				frmModel prozor = new frmModel();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select Model from tblModel where ModelID=" + red["ID"];

				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.txtNazivModela.Text = citac["Model"].ToString();
				}
				prozor.ShowDialog();
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Modeli(sender, e);
				azuriraj = false;
			}
		}

		private void btnIzmeniVozilo_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				DodajVozilo prozor = new DodajVozilo();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select * from tblVozilo where VoziloID=" + red["ID"];

				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.txtBrojSasije.Text = citac["BrojSasije"].ToString();
					prozor.txtKubikaza.Text = citac["Kubikaza"].ToString();
					prozor.txtKonjskaSnaga.Text = citac["KonjskaSnaga"].ToString();
					prozor.cbMarka.SelectedValue = citac["MarkaID"].ToString();
					prozor.cbModel.SelectedValue = citac["ModelID"].ToString();
					prozor.cbTip.SelectedValue = citac["TipVozilaID"].ToString();
					prozor.cbVozac.SelectedValue = citac["VozacID"].ToString();
					prozor.cbDodatnaOprema.SelectedValue = citac["DodatnaOpremaID"].ToString();

				}
				prozor.ShowDialog();
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Vozila(sender, e);
				azuriraj = false;
			}
		}

		

		private void btnIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				DodajKorisnika prozor = new DodajKorisnika();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select ImeKorisnika, PrezimeKorisnika, Adresa, Grad, Kontakt, BrojVozacke, JMBG from tblKorisnik where KorisnikID=" + red["ID"];
				
				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.txtIme.Text = citac["ImeKorisnika"].ToString();
					prozor.txtPrezime.Text = citac["PrezimeKorisnika"].ToString();
					prozor.txtAdresa.Text = citac["Adresa"].ToString();
					prozor.txtGrad.Text = citac["Grad"].ToString();
					prozor.txtKontakt.Text = citac["Kontakt"].ToString();
					prozor.txtBrojVozacke.Text = citac["BrojVozacke"].ToString();
					prozor.txtJMBG.Text = citac["JMBG"].ToString();
				}
				prozor.ShowDialog();
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Korisnik(sender, e);
				azuriraj = false;
			}
		}

		private void btnIzmeniTipVozila_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				azuriraj = true;
				frmTipVozila prozor = new frmTipVozila();

				konekcija.Open();
				DataRowView red = (DataRowView)CentralniGrid.SelectedItems[0];
				selektovan = red;
				string upit = "Select Tip,  from tblTipVozila where TipVozilaID=" + red["ID"];

				SqlCommand komanda = new SqlCommand(upit, konekcija);
				SqlDataReader citac = komanda.ExecuteReader();

				while (citac.Read())
				{
					prozor.txtNazivTipaVozila.Text = citac["Tip"].ToString();
					
				}
				prozor.ShowDialog();
			}
			catch (ArgumentOutOfRangeException)
			{
				MessageBox.Show("Potrebno je selektovati odgovarajuci red!");
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
				Button_Click_Tipovi(sender, e);
				azuriraj = false;
			}
		}

	}
}
