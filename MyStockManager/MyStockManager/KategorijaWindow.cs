using System;
using System.Collections.Generic; 
using Gtk;

namespace MyStockManager
{
	public partial class KategorijaWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public KategorijaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(KategorijaTreeNode));
				List<Kategorija> listaKategorije = Kategorija.Dohvati ();
				foreach (Kategorija k in listaKategorije) {
					store.AddNode (new KategorijaTreeNode (k));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.nodeview1.NodeStore = getStore ();

			this.nodeview1.AppendColumn ("ID", new Gtk.CellRendererText (), "text", 0);
			this.nodeview1.AppendColumn ("Naziv", new Gtk.CellRendererText (), "text", 1);
			this.nodeview1.AppendColumn ("Opis", new Gtk.CellRendererText (), "text", 2);

			this.nodeview1.ShowAll ();
		}

		private void refreshNodeView() {
			this.store = null;
			this.nodeview1.NodeStore = getStore ();
		}

		private bool isRowSelected() {
			if ((MyStockManager.KategorijaTreeNode)nodeview1.NodeSelection.SelectedNode != null) {
				return true;
			} else {
				General.GenerateMessageDialog (this, null, "Upozorenje", "Potrebno je označiti kategoriju.", MessageType.Warning);
				return false;
			}
		}


		protected void btnNew_onClick (object sender, EventArgs e)
		{
			KategorijaNewEditWindow katNewWin = new KategorijaNewEditWindow ();
			katNewWin.Show ();
			katNewWin.Destroyed += new EventHandler (kategorijaNewEditWindow_onDestroy);
		}

		protected void btnEdit_onClick (object sender, EventArgs e)
		{
			if (isRowSelected ()) {
				KategorijaTreeNode ktn = (MyStockManager.KategorijaTreeNode)nodeview1.NodeSelection.SelectedNode;
				KategorijaNewEditWindow katEditWin = new KategorijaNewEditWindow (1, ktn);
				katEditWin.Show ();
				katEditWin.Destroyed += new EventHandler (kategorijaNewEditWindow_onDestroy);
			}

		}

		protected void btnDelete_onClick (object sender, EventArgs e)
		{
			if (isRowSelected ()) {
				KategorijaTreeNode ktn = (MyStockManager.KategorijaTreeNode)nodeview1.NodeSelection.SelectedNode;
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, "Jeste li sigurni da želite obrisati kategoriju?");
				md.Title = "Brisanje kategorije";
				ResponseType rt = (ResponseType) md.Run ();
				if (rt == ResponseType.Yes) {
					Kategorija k = new Kategorija ();
					k.IdKategorija = ktn.Id;
					k.Obrisi ();
					md.Destroy ();
					refreshNodeView ();
				}
				if (rt == ResponseType.No) {
					md.Destroy ();
				}
			}

		}

		protected void kategorijaNewEditWindow_onDestroy(object o, EventArgs e) {
			refreshNodeView ();
		}

		protected void btnZatvorni_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}

	[Gtk.TreeNode (ListOnly=true)]
	public class KategorijaTreeNode : Gtk.TreeNode {

		public KategorijaTreeNode (Kategorija k)
		{
			Id = k.IdKategorija;
			Naziv = k.NazivKategorija;
			Opis = k.Opis;

		}

		[Gtk.TreeNodeValue (Column=0)]
		public int Id { set; get;}

		[Gtk.TreeNodeValue (Column=1)]
		public String Naziv { set; get;}

		[Gtk.TreeNodeValue (Column=2)]
		public String Opis { set; get;}


	}
}

