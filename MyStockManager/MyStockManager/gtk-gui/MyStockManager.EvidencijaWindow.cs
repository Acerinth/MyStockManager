
// This file has been generated by the GUI designer. Do not modify.
namespace MyStockManager
{
	public partial class EvidencijaWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView nodeview1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button btnZatvori;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MyStockManager.EvidencijaWindow
			this.Name = "MyStockManager.EvidencijaWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Evidencija Promjena");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MyStockManager.EvidencijaWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
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
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w2.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnZatvori = new global::Gtk.Button ();
			this.btnZatvori.CanFocus = true;
			this.btnZatvori.Name = "btnZatvori";
			this.btnZatvori.UseUnderline = true;
			this.btnZatvori.Label = global::Mono.Unix.Catalog.GetString (" Zatvori ");
			this.hbox1.Add (this.btnZatvori);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnZatvori]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			w4.Padding = ((uint)(15));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 618;
			this.DefaultHeight = 450;
			this.Show ();
			this.btnZatvori.Clicked += new global::System.EventHandler (this.btnZatvori_onClick);
		}
	}
}
