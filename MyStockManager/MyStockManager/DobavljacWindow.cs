using System;

namespace MyStockManager
{
	public partial class DobavljacWindow : Gtk.Window
	{
		public DobavljacWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}






		protected void btnZatvori_onClick (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void btnNovi_onClick (object sender, EventArgs e)
		{
			//samo neka nova linija koda
			throw new NotImplementedException ();
		}

		protected void btnUredi_onClick (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected void btnObrisi_onClick (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}
	}
}

