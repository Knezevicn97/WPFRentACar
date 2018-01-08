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
	/// Interaction logic for frmTipVozila.xaml
	/// </summary>
	public partial class frmTipVozila : Window
	{
		public SqlConnection konekcija = Konekcija.KreirajKonekciju();

		public frmTipVozila()
		{
			InitializeComponent();
			txtNazivTipaVozila.Focus();
		}

		private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				konekcija.Open();
				
					string insert = @"insert into tblTipVozila(Tip)
                                values ('" + txtTip.Text + "');";
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
