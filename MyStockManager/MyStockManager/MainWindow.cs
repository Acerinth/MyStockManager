using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.Title = "My Stock Manager";
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void onClick_Pregled (object sender, EventArgs e)
	{
		MyStockManager.ArtikliWindow winArtikli = new MyStockManager.ArtikliWindow ();
		winArtikli.WindowPosition = WindowPosition.CenterAlways;
		winArtikli.Show ();

	}


	protected void onClick_Izlaz (object sender, EventArgs e)
	{
		Application.Quit ();
	}


	protected void btnKategorije_onClick (object sender, EventArgs e)
	{
		MyStockManager.KategorijaWindow winKategorija = new MyStockManager.KategorijaWindow ();
		winKategorija.WindowPosition = WindowPosition.CenterAlways;
		winKategorija.Show ();
	}

	protected void dobavljaci_onClick (object sender, EventArgs e)
	{
		MyStockManager.DobavljacWindow winDobavljac = new MyStockManager.DobavljacWindow ();
		winDobavljac.WindowPosition = WindowPosition.CenterAlways;
		winDobavljac.Show ();
	}


	protected void mjesta_onClick (object sender, EventArgs e)
	{
		MyStockManager.MjestoWindow winMjesto = new MyStockManager.MjestoWindow ();
		winMjesto.WindowPosition = WindowPosition.CenterAlways;
		winMjesto.Show ();
	}

	protected void zaposlenici_onClick (object sender, EventArgs e)
	{
		MyStockManager.ZaposlenikWindow winZaposlenik = new MyStockManager.ZaposlenikWindow ();
		winZaposlenik.WindowPosition = WindowPosition.CenterAlways;
		winZaposlenik.Show ();
	}

	protected void prijevoznici_onClick (object sender, EventArgs e)
	{
		MyStockManager.PrijevoznikWindow winPrijevoznik = new MyStockManager.PrijevoznikWindow ();
		winPrijevoznik.WindowPosition = WindowPosition.CenterAlways;
		winPrijevoznik.Show ();
	}

	protected void primke_onClick (object sender, EventArgs e)
	{
		MyStockManager.PrimkaWindow winPrimka = new MyStockManager.PrimkaWindow ();
		winPrimka.WindowPosition = WindowPosition.CenterAlways;
		winPrimka.Show ();
	}

	protected void evidencijaPromjena_onClick (object sender, EventArgs e)
	{
		MyStockManager.EvidencijaWindow winEvidencija = new MyStockManager.EvidencijaWindow ();
		winEvidencija.WindowPosition = WindowPosition.CenterAlways;
		winEvidencija.Show ();
	}

	protected void otpremnice_onClick (object sender, EventArgs e)
	{
		MyStockManager.OtpremnicaWindow winOtpremnice = new MyStockManager.OtpremnicaWindow ();
		winOtpremnice.WindowPosition = WindowPosition.CenterAlways;
		winOtpremnice.Show ();
	}

}
