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

		public MainWindow()
		{
			InitializeComponent();
		}


	}
}
