using System;
using Gtk; //Message Dialog
using System.Collections.Generic; // List

namespace MyStockManager
{
	public partial class ArtikliWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;
		private int Opcija;

		public int IdOdabraniArtikl = 0;

		public ArtikliWindow (int o=0) : base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();

			Opcija = o;

			if (Opcija == 1) {
				onemoguciGumbe ();
			}


		}

		private void onemoguciGumbe() {
			btnNoviArtikl.Visible = false;
			btnUredi.Visible = false;
			btnObrisi.Visible = false;
			btnOK.Visible = true;
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

		private void refreshNodeView() {
			this.store = null;
			this.nodeview1.NodeStore = getStore ();
		}

		private bool isRowSelected() {
			if ((MyStockManager.ArtiklTreeNode)nodeview1.NodeSelection.SelectedNode != null) {
				return true;
			}
			else {
				General.GenerateMessageDialog (this, null, "Upozorenje", "Potrebno je označiti artikl.", MessageType.Warning);
				return false;
			}
		}


		protected void btnNovi_onClick (object sender, EventArgs e)
		{
			ArtiklNewEditWindow frmArtiklNew = new ArtiklNewEditWindow ();
			frmArtiklNew.Show ();
			frmArtiklNew.Destroyed += new EventHandler (FrmArtiklNewEdit_onDestroyed);

		}

		private void FrmArtiklNewEdit_onDestroyed (object o, EventArgs e) {
			refreshNodeView ();
		}

		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void btnUredi_onClick (object sender, EventArgs e)
		{
			if (isRowSelected ()) {
				ArtiklTreeNode atn = (MyStockManager.ArtiklTreeNode)nodeview1.NodeSelection.SelectedNode;
				ArtiklNewEditWindow frmUrediArtikl = new ArtiklNewEditWindow (1, atn);
				frmUrediArtikl.Show ();
				frmUrediArtikl.Destroyed += new EventHandler (FrmArtiklNewEdit_onDestroyed);
			}
		}


		protected void btnDelete_onClick (object sender, EventArgs e)
		{
			if (isRowSelected()) {
				ArtiklTreeNode atn = (MyStockManager.ArtiklTreeNode)nodeview1.NodeSelection.SelectedNode;
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, "Jeste li sigurni da želite obrisati artikl?");
				md.Title = "Brisanje artikla";
				ResponseType rt = (ResponseType) md.Run ();
				if (rt == ResponseType.Yes) {
					Artikl a = new Artikl ();
					a.Id = atn.Id;
					a.Obrisi ();
					md.Destroy ();
					refreshNodeView ();
				}
				if (rt == ResponseType.No) {
					md.Destroy ();
				}
			} 
		}


		protected void btnOK_onClick (object sender, EventArgs e)
		{
			if (isRowSelected ()) {
				ArtiklTreeNode atn = (MyStockManager.ArtiklTreeNode)nodeview1.NodeSelection.SelectedNode;
				IdOdabraniArtikl = atn.Id;
				this.Destroy ();
			} else {
				General.GenerateMessageDialog (this, null, "Upozorenje", "Potrebno je označiti artikl.", MessageType.Warning);
			}

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
			Cijena = a.Cijena.ToString ("F");
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
		public String Cijena { set; get;}

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

