using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFRentACar
{
	class Konekcija
	{
		public static SqlConnection KreirajKonekciju()
		{
			SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();
			ccnSb.DataSource = @"DESKTOP-K4UUV0H\SQLEXPRESS";
			ccnSb.InitialCatalog = @"Rent a Car";
			ccnSb.IntegratedSecurity = true;

			string con = ccnSb.ToString();

			SqlConnection konekcija = new SqlConnection(con);

			return konekcija;
		}
	}
}
