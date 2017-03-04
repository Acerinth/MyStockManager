using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

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
}
