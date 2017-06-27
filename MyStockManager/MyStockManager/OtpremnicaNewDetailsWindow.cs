using System;
using System.Collections.Generic;
using Gtk;

namespace MyStockManager
{
	public partial class OtpremnicaNewDetailsWindow : Gtk.Window
	{

		Gtk.NodeStore store = null;
		private List<Stavka> listaStavki = null;

		private String OdabranaOtpremnicaId = "";
		private Otpremnica OdabranaOtpremnica = null;

		ArtikliWindow winOdaberiStavku = null;
		PrijevoznikWindow winOdaberiPrijevoznika = null;
		ZaposlenikWindow winOdaberiZaposlenika = null;

		private Artikl noviArtikl = null;
		private Dobavljac noviDobavljac = null;
		private Prijevoznik noviPrijevoznik = null;
		private Zaposlenik noviZaposlenik = null;



		public OtpremnicaNewDetailsWindow (String odabrOtpId="") :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			OdabranaOtpremnicaId = odabrOtpId;

			if (OdabranaOtpremnicaId != "") {
				
			} else {
				listaStavki = new List<Stavka> ();
				prepareNodeView ();
				outDatum.Text = DateTime.Now.ToString ("dd.MM.yyyy. HH:mm:ss");
			}

		}

		private Gtk.NodeStore getStore(List<Stavka> lista) {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(StavkeOtpremniceTreeNode));
				foreach (Stavka s in lista) {
					store.AddNode (new StavkeOtpremniceTreeNode (s));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.outStavke.AppendColumn ("ID artikla", new Gtk.CellRendererText (), "text", 0);
			this.outStavke.AppendColumn ("Naziv artikla", new Gtk.CellRendererText (), "text", 1);
			this.outStavke.AppendColumn ("Naziv kategorije", new Gtk.CellRendererText (), "text", 2);
			this.outStavke.AppendColumn ("Količina", new Gtk.CellRendererText (), "text", 3);
		}

		private void refreshNodeView(List<Stavka> lista) {
			this.store = null;
			this.outStavke.NodeStore = getStore (lista);
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
				outPrijevoznikId.Text = noviPrijevoznik.Id.ToString ();
				outPrijevoznikNaziv.Text = noviPrijevoznik.Naziv;
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
				outZaposlenik.Text = noviZaposlenik.ToString ();
			}
		}

		protected void btnPronadjiArtikl_onClick (object sender, EventArgs e)
		{
			winOdaberiStavku = new ArtikliWindow (1);
			winOdaberiStavku.WindowPosition = Gtk.WindowPosition.CenterAlways;
			winOdaberiStavku.Show ();
			winOdaberiStavku.Destroyed += new EventHandler (winOdaberiStavku_onDestroyed);
		}

		protected void winOdaberiStavku_onDestroyed(object sender, EventArgs e) {
			if (winOdaberiStavku.IdOdabraniArtikl > 0) {
				int idNoveStavke = winOdaberiStavku.IdOdabraniArtikl;
				noviArtikl = Artikl.DohvatiArtikl (idNoveStavke);
				outArtiklId.Text = noviArtikl.Id.ToString ();
				outArtiklNaziv.Text = noviArtikl.Naziv;
			}
		}

		protected void btnDodajStavku_onClick (object sender, EventArgs e)
		{
			if (inBrojOtpremnice.Text != "") {
				int kol;
				if (int.TryParse (inKolicina.Text, out kol)) {
					if (kol > 0 && kol <= noviArtikl.Stanje) {
						Stavka novaStavka = new Stavka (inBrojOtpremnice.Text, noviArtikl.Id, noviArtikl, kol);
						listaStavki.Add (novaStavka);
						refreshNodeView (listaStavki);

					} else {
						General.GenerateMessageDialog (this, inKolicina, "Upozorenje", "Unijeli ste količinu manju od 0 ili veću od stanja artikla na skladištu.", Gtk.MessageType.Warning);
					}

				} else {
					General.GenerateMessageDialog (this, inKolicina, "Upozorenje", "Potrebno je unijeti brojčani iznos.", Gtk.MessageType.Warning);
				}


			} else {
				General.GenerateMessageDialog (this, inBrojOtpremnice, "Upozorenje", "Potrebno je unijeti broj primke!", Gtk.MessageType.Warning);
			}
		}

		protected void btnSpremi_onClick (object sender, EventArgs e)
		{
			if (inBrojOtpremnice.Text != "" && inBrojNarudzbeKupca.Text != "" && noviArtikl != null && noviPrijevoznik != null && noviZaposlenik != null && listaStavki.Count > 0) {
				Otpremnica novaOtpremnica = new Otpremnica (inBrojOtpremnice.Text, DateTime.Now, inBrojNarudzbeKupca.Text, noviPrijevoznik.Id, noviPrijevoznik, noviZaposlenik.IdZaposlenik, noviZaposlenik, listaStavki);
				if (novaOtpremnica.Spremi () > 0) {
					General.GenerateMessageDialog (this, null, "Obavijest", "Otpremnica uspješno spremljena.", MessageType.Info);
					this.Destroy ();
				} else {
					General.GenerateMessageDialog (this, null, "Pogreška!", "Greška prilikom spremanja u bazu.", MessageType.Error);
				}

			} else {
				General.GenerateMessageDialog (this, null, "Upozorenje", "Niste ispunili sve potrebne podatke!", Gtk.MessageType.Warning);
			}
		}

		protected void btnOdustani_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}


	[Gtk.TreeNode (ListOnly=true)]
	public class StavkeOtpremniceTreeNode : Gtk.TreeNode {

		public StavkeOtpremniceTreeNode (Stavka s)
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

