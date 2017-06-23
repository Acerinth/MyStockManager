using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class PrijevoznikWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public PrijevoznikWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(PrijevoznikTreeNode));
				List<Prijevoznik> listaPrijevoznici = Prijevoznik.DohvatiPrijevoznike ();
				foreach (Prijevoznik p in listaPrijevoznici) {
					store.AddNode (new PrijevoznikTreeNode (p));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID prijevoznika", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Naziv", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Kontakt", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Telefon", new Gtk.CellRendererText (), "text", 3);
			this.nodeview1.AppendColumn ("Email", new Gtk.CellRendererText (), "text", 4);
			this.nodeview1.AppendColumn ("Postanski broj", new Gtk.CellRendererText (), "text", 5);
			this.nodeview1.AppendColumn ("Mjesto", new Gtk.CellRendererText (), "text", 6);

			this.nodeview1.ShowAll ();
		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		[Gtk.TreeNode (ListOnly=true)]
		public class PrijevoznikTreeNode : Gtk.TreeNode {

			public PrijevoznikTreeNode (Prijevoznik p)
			{
				Id = p.Id;
				Naziv = p.Naziv;
				Kontakt = p.Kontakt;
				Telefon = p.Telefon;
				Email = p.Email;
				IdMjesto = p.IdMjesto;
				NazivMjesta = p.NazivMjesta;
			}

			[Gtk.TreeNodeValue (Column=0)]
			public int Id { set; get;}

			[Gtk.TreeNodeValue (Column=1)]
			public String Naziv { set; get;}

			[Gtk.TreeNodeValue (Column=2)]
			public String Kontakt { set; get;}

			[Gtk.TreeNodeValue (Column=3)]
			public String Telefon { set; get;}

			[Gtk.TreeNodeValue (Column=4)]
			public String Email { set; get;}

			[Gtk.TreeNodeValue (Column=5)]
			public int IdMjesto { set; get;}

			[Gtk.TreeNodeValue (Column=6)]
			public String NazivMjesta { set; get;}

		}
	}
}

