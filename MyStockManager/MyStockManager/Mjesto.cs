using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Mjesto
	{
		public int IdMjesto { set; get; }
		public String Naziv { set; get; }

		public Mjesto ()
		{
		}

		public Mjesto (NpgsqlDataReader dr) {
			if (dr != null) {
				IdMjesto = int.Parse(dr ["id_mjesto"].ToString ());
				Naziv = dr ["naziv"].ToString ();
			}
		}

		public static List<Mjesto> DohvatiMjesta() {
			List<Mjesto> listaMjesta = new List<Mjesto> ();
			string sqlUpit = "SELECT * FROM mjesto";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			while (dr.Read ()) {
				Mjesto m = new Mjesto (dr);
				listaMjesta.Add (m);
			}
			dr.Close ();
			return listaMjesta;
		}
	}
}

