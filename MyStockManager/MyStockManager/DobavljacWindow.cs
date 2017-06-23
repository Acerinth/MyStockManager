﻿using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class DobavljacWindow : Gtk.Window
	{
		Gtk.NodeStore store = null;

		public DobavljacWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			prepareNodeView ();
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(DobavljacTreeNode));
				List<Dobavljac> listaDobavljaci = Dobavljac.DohvatiDobavljace ();
				foreach (Dobavljac d in listaDobavljaci) {
					store.AddNode (new DobavljacTreeNode (d));
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

			this.nodeview1.AppendColumn ("ID dobavljaca", new Gtk.CellRendererText (), "text", 0);
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

		protected void btnNovi_onClick (object sender, EventArgs e)
		{
			//samo neka nova linija koda
			throw new NotImplementedException ();
		}

		protected void btnUredi_onClick (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected void btnObrisi_onClick (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}




		[Gtk.TreeNode (ListOnly=true)]
		public class DobavljacTreeNode : Gtk.TreeNode {

			public DobavljacTreeNode (Dobavljac d)
			{
				Id = d.Id;
				Naziv = d.Naziv;
				Kontakt = d.Kontakt;
				Telefon = d.Telefon;
				Email = d.Email;
				IdMjesto = d.IdMjesto;
				NazivMjesta = d.NazivMjesta;
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

