using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class OtpremnicaWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public OtpremnicaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(OtpremnicaTreeNode));
				List<Otpremnica> listaOtpremnica = Otpremnica.DohvatiOtpremnice ();
				foreach (Otpremnica o in listaOtpremnica) {
					store.AddNode (new OtpremnicaTreeNode (o));
				}
			}
			return store;
		}

		private void refreshNodeView() {
			this.store = null;
			this.nodeview1.NodeStore = getStore ();
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID otpremnice", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Datum", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Broj narudžbe kupca", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Prijevoznik", new Gtk.CellRendererText (), "text", 3);
			this.nodeview1.AppendColumn ("Zaposlenik", new Gtk.CellRendererText (), "text", 4);

			this.nodeview1.ShowAll ();
		}


		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void btnNovaOtpremnica_onClick (object sender, EventArgs e)
		{
			MyStockManager.OtpremnicaNewDetailsWindow winNovaOtpremnica = new OtpremnicaNewDetailsWindow ();
			winNovaOtpremnica.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winNovaOtpremnica.Show ();
			winNovaOtpremnica.Destroyed += new EventHandler (winNovaOtpremnica_Destroyed);
		}

		protected void winNovaOtpremnica_Destroyed(object sender, EventArgs e) {
			refreshNodeView ();
		}

		protected void btnDetaljiOtpremnice_onClick (object sender, EventArgs e)
		{
			MyStockManager.OtpremnicaNewDetailsWindow winDetaljiOtpremnica = new OtpremnicaNewDetailsWindow ();
			winDetaljiOtpremnica.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winDetaljiOtpremnica.Show ();
		}
	}


	[Gtk.TreeNode (ListOnly=true)]
	public class OtpremnicaTreeNode : Gtk.TreeNode {

		public OtpremnicaTreeNode (Otpremnica o)
		{
			IdOtpremnica = o.IdOtpremnica;
			Datum = o.Datum.ToString ("dd.MM.yyyy. HH:mm:ss");
			BrojNarudzbeKupca = o.BrojNarudzbeKupca;
			NazivPrijevoznika = o.Prijevoznik.Naziv;
			Zaposlenik = o.Zaposlenik.ToString();
		}

		[Gtk.TreeNodeValue (Column=0)]
		public String IdOtpremnica { set; get;}

		[Gtk.TreeNodeValue (Column=1)]
		public String Datum { set; get;}

		[Gtk.TreeNodeValue (Column=2)]
		public String BrojNarudzbeKupca { set; get;}

		[Gtk.TreeNodeValue (Column=3)]
		public String NazivPrijevoznika { set; get;}

		[Gtk.TreeNodeValue (Column=4)]
		public String Zaposlenik { set; get;}

	}
}

