
// This file has been generated by the GUI designer. Do not modify.
namespace MyStockManager
{
	public partial class OtpremnicaNewDetailsWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Entry inBrojOtpremnice;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Entry outDatum;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Entry inBrojNarudzbeKupca;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Entry outPrijevoznikId;
		
		private global::Gtk.Entry outPrijevoznikNaziv;
		
		private global::Gtk.Button btnPronadjiPrijevoznik;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Entry outZaposlenik;
		
		private global::Gtk.Button btnPronadjiZaposlenika;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Button btnPronadjiArtikl;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label label8;
		
		private global::Gtk.Label label9;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Entry outArtiklId;
		
		private global::Gtk.Entry outArtiklNaziv;
		
		private global::Gtk.Entry inKolicina;
		
		private global::Gtk.Button btnDodajStavku;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView outStavke;
		
		private global::Gtk.HBox hbox9;
		
		private global::Gtk.Button btnSpremi;
		
		private global::Gtk.Button btnOdustani;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MyStockManager.OtpremnicaNewDetailsWindow
			this.Name = "MyStockManager.OtpremnicaNewDetailsWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("OtpremnicaNewDetailsWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MyStockManager.OtpremnicaNewDetailsWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.hbox1.Add (this.label10);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label10]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Broj otpremnice:");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(10));
			// Container child hbox1.Gtk.Box+BoxChild
			this.inBrojOtpremnice = new global::Gtk.Entry ();
			this.inBrojOtpremnice.WidthRequest = 100;
			this.inBrojOtpremnice.CanFocus = true;
			this.inBrojOtpremnice.Name = "inBrojOtpremnice";
			this.inBrojOtpremnice.IsEditable = true;
			this.inBrojOtpremnice.InvisibleChar = '•';
			this.hbox1.Add (this.inBrojOtpremnice);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.inBrojOtpremnice]));
			w3.Position = 2;
			w3.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.hbox1.Add (this.label11);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label11]));
			w4.Position = 3;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			w5.Padding = ((uint)(15));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.WidthRequest = 150;
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Datum:");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			w6.Padding = ((uint)(15));
			// Container child hbox2.Gtk.Box+BoxChild
			this.outDatum = new global::Gtk.Entry ();
			this.outDatum.WidthRequest = 350;
			this.outDatum.CanFocus = true;
			this.outDatum.Name = "outDatum";
			this.outDatum.IsEditable = false;
			this.outDatum.InvisibleChar = '•';
			this.hbox2.Add (this.outDatum);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.outDatum]));
			w7.Position = 1;
			w7.Expand = false;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			w8.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 150;
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Broj narudžbe kupca:");
			this.hbox3.Add (this.label3);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label3]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			w9.Padding = ((uint)(15));
			// Container child hbox3.Gtk.Box+BoxChild
			this.inBrojNarudzbeKupca = new global::Gtk.Entry ();
			this.inBrojNarudzbeKupca.WidthRequest = 100;
			this.inBrojNarudzbeKupca.CanFocus = true;
			this.inBrojNarudzbeKupca.Name = "inBrojNarudzbeKupca";
			this.inBrojNarudzbeKupca.IsEditable = true;
			this.inBrojNarudzbeKupca.InvisibleChar = '•';
			this.hbox3.Add (this.inBrojNarudzbeKupca);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.inBrojNarudzbeKupca]));
			w10.Position = 1;
			w10.Expand = false;
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.WidthRequest = 150;
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Prijevoznik:");
			this.hbox4.Add (this.label4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label4]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			w12.Padding = ((uint)(15));
			// Container child hbox4.Gtk.Box+BoxChild
			this.outPrijevoznikId = new global::Gtk.Entry ();
			this.outPrijevoznikId.WidthRequest = 50;
			this.outPrijevoznikId.CanFocus = true;
			this.outPrijevoznikId.Name = "outPrijevoznikId";
			this.outPrijevoznikId.IsEditable = false;
			this.outPrijevoznikId.InvisibleChar = '•';
			this.hbox4.Add (this.outPrijevoznikId);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.outPrijevoznikId]));
			w13.Position = 1;
			w13.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.outPrijevoznikNaziv = new global::Gtk.Entry ();
			this.outPrijevoznikNaziv.WidthRequest = 200;
			this.outPrijevoznikNaziv.CanFocus = true;
			this.outPrijevoznikNaziv.Name = "outPrijevoznikNaziv";
			this.outPrijevoznikNaziv.IsEditable = false;
			this.outPrijevoznikNaziv.InvisibleChar = '•';
			this.hbox4.Add (this.outPrijevoznikNaziv);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.outPrijevoznikNaziv]));
			w14.Position = 2;
			w14.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnPronadjiPrijevoznik = new global::Gtk.Button ();
			this.btnPronadjiPrijevoznik.CanFocus = true;
			this.btnPronadjiPrijevoznik.Name = "btnPronadjiPrijevoznik";
			this.btnPronadjiPrijevoznik.UseUnderline = true;
			this.btnPronadjiPrijevoznik.Label = global::Mono.Unix.Catalog.GetString (" Pronađi... ");
			this.hbox4.Add (this.btnPronadjiPrijevoznik);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.btnPronadjiPrijevoznik]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			w15.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox4);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox4]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			w16.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.WidthRequest = 150;
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Zaposlenik:");
			this.hbox5.Add (this.label5);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label5]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			w17.Padding = ((uint)(15));
			// Container child hbox5.Gtk.Box+BoxChild
			this.outZaposlenik = new global::Gtk.Entry ();
			this.outZaposlenik.WidthRequest = 255;
			this.outZaposlenik.CanFocus = true;
			this.outZaposlenik.Name = "outZaposlenik";
			this.outZaposlenik.IsEditable = false;
			this.outZaposlenik.InvisibleChar = '•';
			this.hbox5.Add (this.outZaposlenik);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.outZaposlenik]));
			w18.Position = 1;
			w18.Expand = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.btnPronadjiZaposlenika = new global::Gtk.Button ();
			this.btnPronadjiZaposlenika.CanFocus = true;
			this.btnPronadjiZaposlenika.Name = "btnPronadjiZaposlenika";
			this.btnPronadjiZaposlenika.UseUnderline = true;
			this.btnPronadjiZaposlenika.Label = global::Mono.Unix.Catalog.GetString (" Pronađi... ");
			this.hbox5.Add (this.btnPronadjiZaposlenika);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.btnPronadjiZaposlenika]));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			w19.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox5);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox5]));
			w20.Position = 4;
			w20.Expand = false;
			w20.Fill = false;
			w20.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.WidthRequest = 150;
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Stavke otpremnice:");
			this.hbox6.Add (this.label6);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label6]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			w21.Padding = ((uint)(15));
			// Container child hbox6.Gtk.Box+BoxChild
			this.btnPronadjiArtikl = new global::Gtk.Button ();
			this.btnPronadjiArtikl.CanFocus = true;
			this.btnPronadjiArtikl.Name = "btnPronadjiArtikl";
			this.btnPronadjiArtikl.UseUnderline = true;
			this.btnPronadjiArtikl.Label = global::Mono.Unix.Catalog.GetString (" Pronađi artikl... ");
			this.hbox6.Add (this.btnPronadjiArtikl);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.btnPronadjiArtikl]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.vbox1.Add (this.hbox6);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox6]));
			w23.Position = 5;
			w23.Expand = false;
			w23.Fill = false;
			w23.Padding = ((uint)(10));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Šifra artikla");
			this.hbox7.Add (this.label7);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label7]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			w24.Padding = ((uint)(30));
			// Container child hbox7.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Naziv artikla");
			this.hbox7.Add (this.label8);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label8]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			w25.Padding = ((uint)(5));
			// Container child hbox7.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Količina");
			this.hbox7.Add (this.label9);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label9]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			w26.Padding = ((uint)(120));
			this.vbox1.Add (this.hbox7);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox7]));
			w27.Position = 6;
			w27.Expand = false;
			w27.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.outArtiklId = new global::Gtk.Entry ();
			this.outArtiklId.WidthRequest = 80;
			this.outArtiklId.CanFocus = true;
			this.outArtiklId.Name = "outArtiklId";
			this.outArtiklId.IsEditable = false;
			this.outArtiklId.InvisibleChar = '•';
			this.hbox8.Add (this.outArtiklId);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.outArtiklId]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Padding = ((uint)(30));
			// Container child hbox8.Gtk.Box+BoxChild
			this.outArtiklNaziv = new global::Gtk.Entry ();
			this.outArtiklNaziv.WidthRequest = 200;
			this.outArtiklNaziv.CanFocus = true;
			this.outArtiklNaziv.Name = "outArtiklNaziv";
			this.outArtiklNaziv.IsEditable = false;
			this.outArtiklNaziv.InvisibleChar = '•';
			this.hbox8.Add (this.outArtiklNaziv);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.outArtiklNaziv]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.inKolicina = new global::Gtk.Entry ();
			this.inKolicina.WidthRequest = 80;
			this.inKolicina.CanFocus = true;
			this.inKolicina.Name = "inKolicina";
			this.inKolicina.Text = global::Mono.Unix.Catalog.GetString ("1");
			this.inKolicina.IsEditable = true;
			this.inKolicina.InvisibleChar = '•';
			this.hbox8.Add (this.inKolicina);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.inKolicina]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			w30.Padding = ((uint)(15));
			// Container child hbox8.Gtk.Box+BoxChild
			this.btnDodajStavku = new global::Gtk.Button ();
			this.btnDodajStavku.CanFocus = true;
			this.btnDodajStavku.Name = "btnDodajStavku";
			this.btnDodajStavku.UseUnderline = true;
			this.btnDodajStavku.Label = global::Mono.Unix.Catalog.GetString ("Dodaj stavku");
			this.hbox8.Add (this.btnDodajStavku);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.btnDodajStavku]));
			w31.Position = 3;
			w31.Expand = false;
			w31.Fill = false;
			this.vbox1.Add (this.hbox8);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox8]));
			w32.Position = 7;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.BorderWidth = ((uint)(15));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.outStavke = new global::Gtk.NodeView ();
			this.outStavke.CanFocus = true;
			this.outStavke.Name = "outStavke";
			this.GtkScrolledWindow.Add (this.outStavke);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w34.Position = 8;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.btnSpremi = new global::Gtk.Button ();
			this.btnSpremi.CanFocus = true;
			this.btnSpremi.Name = "btnSpremi";
			this.btnSpremi.UseUnderline = true;
			this.btnSpremi.Label = global::Mono.Unix.Catalog.GetString ("Spremi");
			this.hbox9.Add (this.btnSpremi);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.btnSpremi]));
			w35.PackType = ((global::Gtk.PackType)(1));
			w35.Position = 1;
			w35.Expand = false;
			w35.Fill = false;
			w35.Padding = ((uint)(15));
			// Container child hbox9.Gtk.Box+BoxChild
			this.btnOdustani = new global::Gtk.Button ();
			this.btnOdustani.CanFocus = true;
			this.btnOdustani.Name = "btnOdustani";
			this.btnOdustani.UseUnderline = true;
			this.btnOdustani.Label = global::Mono.Unix.Catalog.GetString ("Odustani");
			this.hbox9.Add (this.btnOdustani);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.btnOdustani]));
			w36.PackType = ((global::Gtk.PackType)(1));
			w36.Position = 2;
			w36.Expand = false;
			w36.Fill = false;
			w36.Padding = ((uint)(15));
			this.vbox1.Add (this.hbox9);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox9]));
			w37.Position = 9;
			w37.Expand = false;
			w37.Fill = false;
			w37.Padding = ((uint)(15));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 690;
			this.DefaultHeight = 679;
			this.Show ();
			this.btnPronadjiPrijevoznik.Clicked += new global::System.EventHandler (this.btnPronadjiPrijevoznika_onClick);
			this.btnPronadjiZaposlenika.Clicked += new global::System.EventHandler (this.btnPronadjiZaposlenika_onClick);
			this.btnPronadjiArtikl.Clicked += new global::System.EventHandler (this.btnPronadjiArtikl_onClick);
			this.btnDodajStavku.Clicked += new global::System.EventHandler (this.btnDodajStavku_onClick);
			this.btnOdustani.Clicked += new global::System.EventHandler (this.btnOdustani_onClick);
			this.btnSpremi.Clicked += new global::System.EventHandler (this.btnSpremi_onClick);
		}
	}
}
