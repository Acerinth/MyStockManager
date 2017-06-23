using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class PrimkaWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public PrimkaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(PrimkaTreeNode));
				List<Primka> listaPrimki = Primka.DohvatiPrimke ();
				foreach (Primka p in listaPrimki) {
					store.AddNode (new PrimkaTreeNode (p));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID primke", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Datum", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Broj dostavnice", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Dobavljač", new Gtk.CellRendererText (), "text", 3);
			this.nodeview1.AppendColumn ("Prijevoznik", new Gtk.CellRendererText (), "text", 4);
			this.nodeview1.AppendColumn ("Zaposlenik", new Gtk.CellRendererText (), "text", 5);

			this.nodeview1.ShowAll ();
		}




		[Gtk.TreeNode (ListOnly=true)]
		public class PrimkaTreeNode : Gtk.TreeNode {

			public PrimkaTreeNode (Primka p)
			{
				IdPrimka = p.IdPrimka;
				Datum = p.Datum;
				BrojDostavnice = p.BrojDostavnice;
				NazivDobavljaca = p.Dobavljac.Naziv;
				NazivPrijevoznika = p.Prijevoznik.Naziv;
				Zaposlenik = p.Zaposlenik.ToString();
			}

			[Gtk.TreeNodeValue (Column=0)]
			public String IdPrimka { set; get;}

			[Gtk.TreeNodeValue (Column=1)]
			public DateTime Datum { set; get;}

			[Gtk.TreeNodeValue (Column=2)]
			public String BrojDostavnice { set; get;}

			[Gtk.TreeNodeValue (Column=3)]
			public String NazivDobavljaca { set; get;}

			[Gtk.TreeNodeValue (Column=4)]
			public String NazivPrijevoznika { set; get;}

			[Gtk.TreeNodeValue (Column=5)]
			public String Zaposlenik { set; get;}

		}
	}
}

