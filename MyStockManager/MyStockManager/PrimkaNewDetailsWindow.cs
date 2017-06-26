using System;
using System.Collections.Generic;
using Gtk;

namespace MyStockManager
{
	public partial class PrimkaNewDetailsWindow : Gtk.Window
	{
		private String IdPrimka = "";
		private Primka OdabranaPrimka = null;
		private int Opcija; //0-new, 1-details

		Gtk.NodeStore store = null;

		ArtikliWindow winOdaberiStavku = null;
		DobavljacWindow winOdaberiDobavljaca = null;
		PrijevoznikWindow winOdaberiPrijevoznika = null;
		ZaposlenikWindow winOdaberiZaposlenika = null;

		private List<Stavka> listaStavki = null;
		private Artikl noviArtikl = null;
		private Dobavljac noviDobavljac = null;
		private Prijevoznik noviPrijevoznik = null;
		private Zaposlenik noviZaposlenik = null;


		public PrimkaNewDetailsWindow (String idPrimka="", int opcija=0) :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			IdPrimka = idPrimka;
			Opcija = opcija; 

			if (Opcija == 1) {
				OdabranaPrimka = Primka.DohvatiPrimku (IdPrimka);

				popuniPodatke ();
				this.outStavke.NodeStore = getStore (OdabranaPrimka.ListaStavki);
				prepareNodeView ();
				this.outStavke.ShowAll ();

				this.Title = "Detalji primke";

				onemoguciUredjenje ();
			} else {
				listaStavki = new List<Stavka> ();
				prepareNodeView ();
				inDatum.Text = DateTime.Now.ToString ("dd.MM.yyyy. HH:mm:ss");
			}

		}

		private void popuniPodatke() {
			inBrojPrimke.Text = OdabranaPrimka.IdPrimka.ToString();
			inBrojDostavnice.Text = OdabranaPrimka.BrojDostavnice;
			inDobavljacId.Text = OdabranaPrimka.IdDobavljac.ToString ();
			inDobavljacNaziv.Text = OdabranaPrimka.Dobavljac.Naziv;
			inPrijevoznikId.Text = OdabranaPrimka.IdPrijevoznik.ToString ();
			inPrijevoznikNaziv.Text = OdabranaPrimka.Prijevoznik.Naziv;
			inDatum.Text = OdabranaPrimka.Datum.ToString ("dd.MM.yyyy. HH:mm:ss");
			inZaposlenik.Text = OdabranaPrimka.Zaposlenik.ToString ();
		}

		private void onemoguciUredjenje() {
			inBrojPrimke.IsEditable = false;
			inBrojDostavnice.IsEditable = false;
			inDobavljacId.IsEditable = false;
			inDobavljacNaziv.IsEditable = false;
			inPrijevoznikId.IsEditable = false;
			inPrijevoznikNaziv.IsEditable = false;
			inDatum.IsEditable = false;
			inZaposlenik.IsEditable = false;
			btnSpremi.Visible = false;
			btnPronadjiPrijevoznika.Visible = false;
			btnPronadjiDobavljaca.Visible = false;
			btnPronadjiStavku.Visible = false;
			btnPronadjiZaposlenika.Visible = false;
			btnOdustani.Label = "Zatvori";
			hbox10.Visible = false;
			hbox9.Visible = false;
		}

		private Gtk.NodeStore getStore(List<Stavka> lista) {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(StavkePrimkeTreeNode));
				foreach (Stavka s in lista) {
					store.AddNode (new StavkePrimkeTreeNode (s));
				}
			}
			return store;
		}

		private void refreshNodeView(List<Stavka> lista) {
			this.store = null;
			this.outStavke.NodeStore = getStore (lista);
		}

		private void prepareNodeView() {
			this.outStavke.AppendColumn ("ID artikla", new Gtk.CellRendererText (), "text", 0);
			this.outStavke.AppendColumn ("Naziv artikla", new Gtk.CellRendererText (), "text", 1);
			this.outStavke.AppendColumn ("Naziv kategorije", new Gtk.CellRendererText (), "text", 2);
			this.outStavke.AppendColumn ("Količina", new Gtk.CellRendererText (), "text", 3);
		}




		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void winOdaberiStavku_onDestroyed(object sender, EventArgs e) {

			if (winOdaberiStavku.IdOdabraniArtikl > 0) {
				int idNoveStavke = winOdaberiStavku.IdOdabraniArtikl;
				noviArtikl = Artikl.DohvatiArtikl (idNoveStavke);
				outIdArtikla.Text = noviArtikl.Id.ToString ();
				outNazivArtikla.Text = noviArtikl.Naziv;
			}


		}

		protected void btnPronadjiArtikl_onClick (object sender, EventArgs e)
		{
			winOdaberiStavku = new ArtikliWindow (1);
			winOdaberiStavku.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winOdaberiStavku.Show ();
			winOdaberiStavku.Destroyed += new EventHandler (winOdaberiStavku_onDestroyed);
		}

		protected void btnDodajStavku_onClick (object sender, EventArgs e)
		{
			if (inBrojPrimke.Text != "") {
				int kol;
				if (int.TryParse (inKolicina.Text, out kol)) {
					if (kol > 0 && kol <= noviArtikl.Stanje) {
						Stavka novaStavka = new Stavka (inBrojPrimke.Text, noviArtikl.Id, noviArtikl, kol);
						listaStavki.Add (novaStavka);
						refreshNodeView (listaStavki);

					} else {
						General.GenerateMessageDialog (this, inKolicina, "Upozorenje", "Unijeli ste količinu manju od 0 ili veću od stanja artikla na skladištu.", Gtk.MessageType.Warning);
					}
				
				} else {
					General.GenerateMessageDialog (this, inKolicina, "Upozorenje", "Potrebno je unijeti brojčani iznos.", Gtk.MessageType.Warning);
				}


			} else {
				General.GenerateMessageDialog (this, inBrojPrimke, "Upozorenje", "Potrebno je unijeti broj primke!", Gtk.MessageType.Warning);
			}
		}

		protected void btnPronadjiPrijevoznika_onClick (object sender, EventArgs e)
		{
			winOdaberiPrijevoznika = new PrijevoznikWindow (1);
			winOdaberiPrijevoznika.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winOdaberiPrijevoznika.Show ();
			winOdaberiPrijevoznika.Destroyed += new EventHandler (winOdaberiPrijevoznika_onDestroyed);
		}

		protected void winOdaberiPrijevoznika_onDestroyed(object sender, EventArgs e) {
			if (winOdaberiPrijevoznika.odabraniPrijevoznik != null) {
				int idPrijev = winOdaberiPrijevoznika.odabraniPrijevoznik.Id;
				noviPrijevoznik = Prijevoznik.DohvatiPrijevoznika (idPrijev);
				inPrijevoznikId.Text = noviPrijevoznik.Id.ToString ();
				inPrijevoznikNaziv.Text = noviPrijevoznik.Naziv;
			}
		}
			
		protected void btnPronadjiDobavljaca_onClick (object sender, EventArgs e)
		{
			winOdaberiDobavljaca = new DobavljacWindow (1);
			winOdaberiDobavljaca.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winOdaberiDobavljaca.Show ();
			winOdaberiDobavljaca.Destroyed += new EventHandler (winOdaberiDobavljaca_onDestroyed);
		}

		protected void winOdaberiDobavljaca_onDestroyed(object sender, EventArgs e) {
			if (winOdaberiDobavljaca.odabraniDobavljac != null) {
				int idDob = winOdaberiDobavljaca.odabraniDobavljac.Id;
				noviDobavljac = Dobavljac.DohvatiDobavljaca (idDob);
				inDobavljacId.Text = noviDobavljac.Id.ToString();
				inDobavljacNaziv.Text = noviDobavljac.Naziv;
			}
		}

		protected void btnPronadjiZaposlenika_onClick (object sender, EventArgs e)
		{
			winOdaberiZaposlenika = new ZaposlenikWindow (1);
			winOdaberiZaposlenika.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winOdaberiZaposlenika.Show ();
			winOdaberiZaposlenika.Destroyed += new EventHandler (winOdaberiZaposlenika_onDestroyed);
		}

		protected void winOdaberiZaposlenika_onDestroyed(object sender, EventArgs e) {
			if (winOdaberiZaposlenika.odabraniZaposlenik != null) {
				int idZap = winOdaberiZaposlenika.odabraniZaposlenik.Id;
				noviZaposlenik = Zaposlenik.DohvatiZaposlenika (idZap);
				inZaposlenik.Text = noviZaposlenik.ToString ();
			}
		}

		protected void btnSpremi_onClick (object sender, EventArgs e)
		{
			if (inBrojPrimke.Text != "" && inBrojDostavnice.Text != "" && noviArtikl != null && noviDobavljac != null && noviPrijevoznik != null && noviZaposlenik != null && listaStavki.Count > 0) {
				Primka novaPrimka = new Primka (inBrojPrimke.Text, DateTime.Now, inBrojDostavnice.Text, noviPrijevoznik.Id, noviPrijevoznik, noviDobavljac.Id, noviDobavljac, noviZaposlenik.IdZaposlenik, noviZaposlenik, listaStavki);
				if (novaPrimka.Spremi () > 0) {
					General.GenerateMessageDialog (this, null, "Obavijest", "Primka uspješno spremljena.", MessageType.Info);
					this.Destroy ();
				} else {
					General.GenerateMessageDialog (this, null, "Pogreška!", "Greška prilikom spremanja u bazu.", MessageType.Error);
				}

			} else {
				General.GenerateMessageDialog (this, null, "Upozorenje", "Niste ispunili sve potrebne podatke!", Gtk.MessageType.Warning);
			}
		}
	}

	[Gtk.TreeNode (ListOnly=true)]
	public class StavkePrimkeTreeNode : Gtk.TreeNode {

		public StavkePrimkeTreeNode (Stavka s)
		{
			IdArtikla = s.IdArtikl;
			NazivArtikla = s.Artikl.Naziv;
			NazivKategorije = s.Artikl.NazivKategorija;
			Kolicina = s.Kolicina;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public int IdArtikla { set; get;}

		[Gtk.TreeNodeValue (Column=1)]
		public String NazivArtikla { set; get;}

		[Gtk.TreeNodeValue (Column=2)]
		public String NazivKategorije { set; get;}

		[Gtk.TreeNodeValue (Column=3)]
		public int Kolicina { set; get;}
	}
}

