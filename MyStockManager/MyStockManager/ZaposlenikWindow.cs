using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class ZaposlenikWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public ZaposlenikWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(ZaposlenikTreeNode));
				List<Zaposlenik> listaZaposlenici = Zaposlenik.DohvatiZaposlenike ();
				foreach (Zaposlenik z in listaZaposlenici) {
					store.AddNode (new ZaposlenikTreeNode (z));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID zaspolenika", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Ime", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Prezime", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Telefon", new Gtk.CellRendererText (), "text", 3);

			this.nodeview1.ShowAll ();
		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		[Gtk.TreeNode (ListOnly=true)]
		public class ZaposlenikTreeNode : Gtk.TreeNode {

			public ZaposlenikTreeNode (Zaposlenik z)
			{
				Id = z.IdZaposlenik;
				Ime = z.Ime;
				Prezime = z.Prezime;
				Telefon = z.Telefon;
			}

			[Gtk.TreeNodeValue (Column=0)]
			public int Id { set; get;}

			[Gtk.TreeNodeValue (Column=1)]
			public String Ime { set; get;}

			[Gtk.TreeNodeValue (Column=2)]
			public String Prezime { set; get;}

			[Gtk.TreeNodeValue (Column=3)]
			public String Telefon { set; get;}
		}
	}
}

