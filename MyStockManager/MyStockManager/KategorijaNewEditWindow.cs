using System;

namespace MyStockManager
{
	public partial class KategorijaNewEditWindow : Gtk.Window
	{
		KategorijaTreeNode ktn;
		int idKategorija = 0;

		public KategorijaNewEditWindow (int type=0, KategorijaTreeNode kategorijaTreeNode = null) :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			if (type == 1) {
				ktn = kategorijaTreeNode;
				idKategorija = ktn.Id;
				this.Title = "Uredi kategoriju";
				prepareGuiEdit ();
			}
		}

		private void prepareGuiEdit() {
			txtNaziv.Text = ktn.Naziv;
			txtOpis.Buffer.Text = ktn.Opis;
		}



		protected void btnOdustani_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void btnSpremi_onClick (object sender, EventArgs e)
		{
			Kategorija k = new Kategorija ();
			k.IdKategorija = idKategorija;

			if (txtNaziv.Text != "") {
				k.NazivKategorija = txtNaziv.Text;
			} else {
				General.GenerateMessageDialog (this, txtNaziv, "Pogrešan unos", "Obavezan unos teksta.", Gtk.MessageType.Warning);
				return;
			}

			k.Opis = txtOpis.Buffer.Text;

			if (k.Spremi() == 1) {
				General.GenerateMessageDialog (this, null, "Kategorija", "Kategorija uspješno spremljena!", Gtk.MessageType.Info);
				this.Destroy ();
			} else {
				General.GenerateMessageDialog (this, null, "Pogreska", "Pogreška prilikom spremanja podataka!", Gtk.MessageType.Error);
			}

		}
	}
}

