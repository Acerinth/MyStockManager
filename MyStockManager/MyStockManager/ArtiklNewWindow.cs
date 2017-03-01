using System;
using Gtk;
using System.Collections.Generic;
using System.Collections;

namespace MyStockManager
{
	public partial class ArtiklNewWindow : Gtk.Window
	{
		public ArtiklNewWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			prepareComboBoxKategorija ();

			prepareComboBoxJedinicaMjere ();

		}

		private void prepareComboBoxKategorija() {
			cbKategorija.Clear();
			List<Kategorija> listaKategorija = Kategorija.Dohvati ();

			ListStore listStore = new ListStore(typeof(int), typeof(string));
			foreach (Kategorija k in listaKategorija) {
				listStore.AppendValues (k.IdKategorija, k.NazivKategorija);
			}

			cbKategorija.Model = listStore; 
			CellRendererText text = new CellRendererText();
			cbKategorija.PackStart(text, false);
			cbKategorija.AddAttribute(text, "text", 1); 

		}

		private void prepareComboBoxJedinicaMjere() {
			cbJedinicaMjere.Clear ();
			List<JedinicaMjere> listaJedinica = JedinicaMjere.Dohvati ();

			ListStore listStore = new ListStore (typeof(string), typeof(string));
			foreach (JedinicaMjere jm in listaJedinica) {
				listStore.AppendValues (jm.IdJedinice, jm.NazivJedinice);
			}

			cbJedinicaMjere.Model = listStore;
			CellRendererText text = new CellRendererText();
			cbJedinicaMjere.PackStart(text, false);
			cbJedinicaMjere.AddAttribute(text, "text", 1); 
		}

		protected void btnOdustani_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void btnSpremi_onClick (object sender, EventArgs e)
		{
			Artikl a = new Artikl ();
			a.Id = 0;

			if (txtNaziv.Text != "") {
				a.Naziv = txtNaziv.Text;
			} else {
				generateMessDialog (txtNaziv, "Pogrešan unos", "Obavezan unos naziva!", MessageType.Warning);
				return;
			}
				

			TreeIter tree;

			if (cbKategorija.GetActiveIter(out tree) == true) {
				int kat = int.Parse(cbKategorija.Model.GetValue (tree, 0).ToString ());
				a.IdKategorija = kat;
			} else {
				generateMessDialog (cbKategorija, "Pogrešan unos", "Obavezan izbor kategorije!", MessageType.Warning);
				return;
			}


			a.Opis = txtOpis.Buffer.Text;

			float cijena;
			if (float.TryParse (txtCijena.Text.ToString (), out cijena)) {
				a.Cijena = cijena;
			} else {
				generateMessDialog (txtCijena, "Pogrešan unos", "Pogrešan unos cijene!", MessageType.Warning);
				return;
			}
			a.Stanje = int.Parse (txtStanje.Text);
			a.ZalihaMax = int.Parse (txtZaliheMax.Text);
			a.ZalihaMin = int.Parse (txtZaliheMin.Text);
			cbJedinicaMjere.GetActiveIter (out tree);
			String selectedValue2 = cbJedinicaMjere.Model.GetValue (tree, 0).ToString();
			a.IdJedinica = selectedValue2;

			if (a.Spremi () == 1) {
				generateMessDialog (null, "Novi artikl", "Artikl uspješno spremljen!", MessageType.Info);
				this.Destroy ();
			} else {
				generateMessDialog (null, "Pogreska", "Pogreška prilikom spremanja podataka!", MessageType.Error);
				/*MessageDialog mdSpremi = new MessageDialog (this, DialogFlags.Modal,
					                         MessageType.Error, ButtonsType.Ok, "Greška prilikom spremanja podataka!");
				mdSpremi.Title = "Pogreška";
				ResponseType rtSpremi = (ResponseType)mdSpremi.Run ();
				if (rtSpremi == ResponseType.Ok) {
					mdSpremi.Destroy ();
				} */
			}


		}


		private void generateMessDialog(Widget focusWidget, String messTitle, String messDesc, MessageType mt) {
			MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
				mt, ButtonsType.Ok, messDesc);
			md.Title = messTitle;
			ResponseType rt = (ResponseType) md.Run ();
			if (rt == ResponseType.Ok) {
				md.Destroy ();
				if (focusWidget != null) {
					focusWidget.GrabFocus ();
				}

			}
		}
			
	}
}

