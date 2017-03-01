using System;
using System.Collections.Generic;
using static System.Math;

namespace MyStockManager
{
	public partial class ArtikliWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public ArtikliWindow () : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();

		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(ArtiklTreeNode));
				List<Artikl> listaArtikli = Artikl.DohvatiArtikle ();
				foreach (Artikl a in listaArtikli) {
					store.AddNode (new ArtiklTreeNode (a));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID artikla", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("ID kategorije", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Naziv kategorije", new Gtk.CellRendererText (), "text", 2);
			this.nodeview1.AppendColumn ("Naziv artikla", new Gtk.CellRendererText (), "text", 3);
			this.nodeview1.AppendColumn ("Opis", new Gtk.CellRendererText (), "text", 4);
			this.nodeview1.AppendColumn ("Cijena (kn)", new Gtk.CellRendererText (), "text", 5);
			this.nodeview1.AppendColumn ("Stanje", new Gtk.CellRendererText (), "text", 6);
			this.nodeview1.AppendColumn ("Zalihe min", new Gtk.CellRendererText (), "text", 7);
			this.nodeview1.AppendColumn ("Zalihe max", new Gtk.CellRendererText (), "text", 8);
			this.nodeview1.AppendColumn ("Jedinica mjere", new Gtk.CellRendererText (), "text", 9); 

			this.nodeview1.ShowAll ();
		}


		protected void btnNovi_onClick (object sender, EventArgs e)
		{
			ArtiklNewWindow frmArtiklNew = new ArtiklNewWindow ();
			frmArtiklNew.Show ();


			//refresh
			 /*store = null;
			prepareNodeView (); */

		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}



	[Gtk.TreeNode (ListOnly=true)]
	public class ArtiklTreeNode : Gtk.TreeNode {

		public ArtiklTreeNode (Artikl a)
		{
			Id = a.Id;
			IdKategorija = a.IdKategorija;
			NazivKategorije = a.NazivKategorija;
			Naziv = a.Naziv;
			Opis = a.Opis;
			Cijena = a.Cijena;
			Stanje = a.Stanje;
			ZalihaMin = a.ZalihaMin;
			ZalihaMax = a.ZalihaMax;
			IdJedinica = a.IdJedinica;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public int Id { set; get;}

		[Gtk.TreeNodeValue (Column=1)]
		public int IdKategorija { set; get;}

		[Gtk.TreeNodeValue (Column=2)]
		public String NazivKategorije { set; get;}

		[Gtk.TreeNodeValue (Column=3)]
		public String Naziv { set; get;}

		[Gtk.TreeNodeValue (Column=4)]
		public String Opis { set; get;}

		[Gtk.TreeNodeValue (Column=5)]
		public float Cijena { set; get;}

		[Gtk.TreeNodeValue (Column=6)]
		public int Stanje { set; get;}

		[Gtk.TreeNodeValue (Column=7)]
		public int ZalihaMin { set; get;}

		[Gtk.TreeNodeValue (Column=8)]
		public int ZalihaMax { set; get;}

		[Gtk.TreeNodeValue (Column=9)]
		public String IdJedinica { set; get;}
	}
		


}

