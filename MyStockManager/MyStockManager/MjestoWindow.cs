using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class MjestoWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public MjestoWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(MjestoTreeNode));
				List<Mjesto> listaMjesta = Mjesto.DohvatiMjesta ();
				foreach (Mjesto m in listaMjesta) {
					store.AddNode (new MjestoTreeNode (m));
				}
			}
			return store;
		}


		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("Poštanski broj", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Naziv", new Gtk.CellRendererText (), "text", 1);

			this.nodeview1.ShowAll ();
		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		[Gtk.TreeNode (ListOnly=true)]
		public class MjestoTreeNode : Gtk.TreeNode {

			public MjestoTreeNode (Mjesto m)
			{
				Id = m.IdMjesto;
				Naziv = m.Naziv;

			}

			[Gtk.TreeNodeValue (Column=0)]
			public int Id { set; get;}

			[Gtk.TreeNodeValue (Column=1)]
			public String Naziv { set; get;}


		}
	}
}

