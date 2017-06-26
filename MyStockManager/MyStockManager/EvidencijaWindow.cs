using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class EvidencijaWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public EvidencijaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(EvidencijaTreeNode));
				List<Evidencija> listaEvidencija = Evidencija.DohvatiEvidenciju ();
				foreach (Evidencija e in listaEvidencija) {
					store.AddNode (new EvidencijaTreeNode (e));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID artikla", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Naziv artikla", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Datum", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Stanje", new Gtk.CellRendererText (), "text", 3);

			this.nodeview1.ShowAll ();
		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}

	[Gtk.TreeNode (ListOnly=true)]
	public class EvidencijaTreeNode : Gtk.TreeNode {

		public EvidencijaTreeNode (Evidencija e)
		{
			IdArtikl = e.IdArtikl;
			NazivArtikla = e.Artikl.Naziv;
			Datum = e.Datum.ToString("dd.MM.yyyy. HH:mm:ss");
			Stanje = e.Stanje;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public int IdArtikl { set; get;}

		[Gtk.TreeNodeValue (Column=1)]
		public String NazivArtikla { set; get;}

		[Gtk.TreeNodeValue (Column=2)]
		public String Datum { set; get;}

		[Gtk.TreeNodeValue (Column=3)]
		public int Stanje { set; get;}

	}
}

