using System;
using System.Collections.Generic;

namespace MyStockManager
{
	public partial class PrimkaNewDetailsWindow : Gtk.Window
	{
		private String IdPrimka = "";
		private Primka OdabranaPrimka = null;
		private int Opcija; //0-new, 1-details

		Gtk.NodeStore store = null;

		public PrimkaNewDetailsWindow (String idPrimka="", int opcija=0) :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			IdPrimka = idPrimka;
			Opcija = opcija; 

			if (Opcija == 1) {
				OdabranaPrimka = Primka.DohvatiPrimku (IdPrimka);

				popuniPodatke ();
				prepareNodeView ();

				this.Title = "Detalji primke";

				onemoguciUredjenje ();
			}

		}

		private void popuniPodatke() {
			inBrojPrimke.Text = OdabranaPrimka.IdPrimka.ToString();
			inBrojDostavnice.Text = OdabranaPrimka.BrojDostavnice;
			inDobavljacId.Text = OdabranaPrimka.IdDobavljac.ToString ();
			inDobavljacNaziv.Text = OdabranaPrimka.Dobavljac.Naziv;
			inPrijevoznikId.Text = OdabranaPrimka.IdPrijevoznik.ToString ();
			inPrijevoznikNaziv.Text = OdabranaPrimka.Prijevoznik.Naziv;
			inDatum.Text = OdabranaPrimka.Datum.ToString ("dd.MM.yyyy. hh:mm:ss");
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
		}

		private Gtk.NodeStore getStore() {
			if (store == null) {
				store = new Gtk.NodeStore (typeof(StavkePrimkeTreeNode));
				foreach (Stavka s in OdabranaPrimka.ListaStavki) {
					store.AddNode (new StavkePrimkeTreeNode (s));
				}
			}
			return store;
		}

		private void prepareNodeView() {
			this.outStavke.NodeStore = getStore ();

			this.outStavke.AppendColumn ("ID artikla", new Gtk.CellRendererText (), "text", 0);
			this.outStavke.AppendColumn ("Naziv artikla", new Gtk.CellRendererText (), "text", 1);
			this.outStavke.AppendColumn ("Naziv kategorije", new Gtk.CellRendererText (), "text", 2);
			this.outStavke.AppendColumn ("Količina", new Gtk.CellRendererText (), "text", 3);

			this.outStavke.ShowAll ();
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

