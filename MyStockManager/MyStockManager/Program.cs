using System;
using Gtk;

namespace MyStockManager
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			//Gtk.Settings.Default.ThemeName = "Theme/gtk-2.0/gtkrc";
			//Gtk.Rc.Parse ("./Theme/gtk-2.0/gtkrc");
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
