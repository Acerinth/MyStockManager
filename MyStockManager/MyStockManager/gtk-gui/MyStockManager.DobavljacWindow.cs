
// This file has been generated by the GUI designer. Do not modify.
namespace MyStockManager
{
	public partial class DobavljacWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button btnNovi;
		
		private global::Gtk.Button btnUredi;
		
		private global::Gtk.Button btnObrisi;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView nodeview1;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Button btnZatvori;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MyStockManager.DobavljacWindow
			this.Name = "MyStockManager.DobavljacWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Dobavljači");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MyStockManager.DobavljacWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnNovi = new global::Gtk.Button ();
			this.btnNovi.CanFocus = true;
			this.btnNovi.Name = "btnNovi";
			this.btnNovi.UseUnderline = true;
			this.btnNovi.Label = global::Mono.Unix.Catalog.GetString (" Novi  ");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.SmallToolbar);
			this.btnNovi.Image = w1;
			this.hbox1.Add (this.btnNovi);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnNovi]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(15));
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnUredi = new global::Gtk.Button ();
			this.btnUredi.CanFocus = true;
			this.btnUredi.Name = "btnUredi";
			this.btnUredi.UseUnderline = true;
			this.btnUredi.Label = global::Mono.Unix.Catalog.GetString ("  Uredi  ");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.SmallToolbar);
			this.btnUredi.Image = w3;
			this.hbox1.Add (this.btnUredi);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnUredi]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			w4.Padding = ((uint)(15));
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnObrisi = new global::Gtk.Button ();
			this.btnObrisi.CanFocus = true;
			this.btnObrisi.Name = "btnObrisi";
			this.btnObrisi.UseUnderline = true;
			this.btnObrisi.Label = global::Mono.Unix.Catalog.GetString ("  Obriši  ");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.SmallToolbar);
			this.btnObrisi.Image = w5;
			this.hbox1.Add (this.btnObrisi);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnObrisi]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			w6.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			w7.Padding = ((uint)(15));
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.BorderWidth = ((uint)(15));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.nodeview1 = new global::Gtk.NodeView ();
			this.nodeview1.CanFocus = true;
			this.nodeview1.Name = "nodeview1";
			this.GtkScrolledWindow.Add (this.nodeview1);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w9.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnZatvori = new global::Gtk.Button ();
			this.btnZatvori.CanFocus = true;
			this.btnZatvori.Name = "btnZatvori";
			this.btnZatvori.UseUnderline = true;
			this.btnZatvori.Label = global::Mono.Unix.Catalog.GetString ("  Zatvori  ");
			this.hbox2.Add (this.btnZatvori);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.btnZatvori]));
			w10.PackType = ((global::Gtk.PackType)(1));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			w10.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(15));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 867;
			this.DefaultHeight = 509;
			this.Show ();
			this.btnNovi.Clicked += new global::System.EventHandler (this.btnNovi_onClick);
			this.btnUredi.Clicked += new global::System.EventHandler (this.btnUredi_onClick);
			this.btnObrisi.Clicked += new global::System.EventHandler (this.btnObrisi_onClick);
			this.btnZatvori.Clicked += new global::System.EventHandler (this.btnZatvori_onClick);
		}
	}
}