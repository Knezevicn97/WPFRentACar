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
    /// Interaction logic for DodajVozilo.xaml
    /// </summary>
    public partial class DodajVozilo : Window
    {
		SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public DodajVozilo()
        {
            InitializeComponent();
			try
			{
				konekcija.Open();
				string vratiTipVozila = @"select TipVozilaID, Tip from tblTipVozila";
				DataTable dtTip = new DataTable();
				SqlDataAdapter daTip = new SqlDataAdapter(vratiTipVozila, konekcija);
				daTip.Fill(dtTip);
				cbTip.ItemsSource = dtTip.DefaultView;

				string vratiMarke = @"select MarkaID, Marka from tblMarka";
				DataTable dtMarka = new DataTable();
				SqlDataAdapter daMarka = new SqlDataAdapter(vratiMarke, konekcija);
				daMarka.Fill(dtMarka);
				cbMarka.ItemsSource = dtMarka.DefaultView;

				string vratiModele = @"select ModelID, Model from tblModel";
				DataTable dtModel = new DataTable();
				SqlDataAdapter daModel = new SqlDataAdapter(vratiModele, konekcija);
				daModel.Fill(dtModel);
				cbModel.ItemsSource = dtModel.DefaultView;

				string vratiVozace = @"select VozacID, ImeVozaca , PrezimeVozaca, BrojVozacke from tblVozac";
				DataTable dtVozac = new DataTable();
				SqlDataAdapter daVozac = new SqlDataAdapter(vratiVozace, konekcija);
				daVozac.Fill(dtVozac);
				cbVozac.ItemsSource = dtVozac.DefaultView;

				string vratiDodatnuOpremu = @"select DodatnaOpremaID, Navigacija, Automatik from tblDodatnaOprema";
				DataTable dtDodatnaOprema = new DataTable();
				SqlDataAdapter daDodatnaOprema = new SqlDataAdapter(vratiDodatnuOpremu, konekcija);
				daDodatnaOprema.Fill(dtDodatnaOprema);
				cbDodatnaOprema.ItemsSource = dtDodatnaOprema.DefaultView;
			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}
        }
		public void btnSacuvaj_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				if (MainWindow.azuriraj)
				{
					DataRowView red = (DataRowView)MainWindow.selektovan;
					string upit = @"Update tblVozilo Set BrojSasije ='" + txtBrojSasije.Text + "' , Kubikaza = " + txtKubikaza.Text + "," + " KonjskaSnaga = " + txtKonjskaSnaga.Text + " , MarkaID =" + cbMarka.SelectedValue + ", " + " ModelID =" + cbModel.SelectedValue + " , TipVozilaID =" + cbTip.SelectedValue + " ," + " VozacID = " + cbVozac.SelectedValue + "DodatnaOprema =" + cbDodatnaOprema.SelectedValue + "Where VoziloID = " + red["ID"];
					SqlCommand cmd = new SqlCommand(upit, konekcija);
					cmd.ExecuteNonQuery();
					MainWindow.selektovan = null;
					this.Close();
				}
				else
				{
					string insert = @" insert into tblVozilo(TipVozilaID, MarkaID, ModelID, VozacID, DodatnaOpremaID, BrojSasije, Kubikaza, KonjskaSnaga)
								values ('" + cbTip.SelectedValue + ", " + cbMarka.SelectedValue + ", " + cbModel.SelectedValue + ", " + cbVozac.SelectedValue + ", " + cbDodatnaOprema.SelectedValue + ", " + txtBrojSasije + ", " + txtKubikaza + ", " + txtKonjskaSnaga + ")";
					SqlCommand cmd = new SqlCommand(insert, konekcija);
					cmd.ExecuteNonQuery();
					this.Close();
				}
			}
			catch (SqlException)
			{
				MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

			}
			finally
			{
				if (konekcija != null)
				{
					konekcija.Close();
				}
			}
		}
		public void btnZatvori_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
    }
}
