using System;
using Gtk;

namespace MyStockManager
{
	public static class General
	{
		public static void GenerateMessageDialog(Gtk.Window senderWindow, Widget focusWidget, String messTitle, String messDesc, MessageType mt) {
			MessageDialog md = new MessageDialog (senderWindow, DialogFlags.Modal, 
				mt, ButtonsType.Ok, messDesc);
			md.Title = messTitle;
			ResponseType rt = (ResponseType) md.Run ();
			if (rt == ResponseType.Ok) {
				md.Destroy ();
				if (focusWidget != null) {
					focusWidget.GrabFocus ();
				}
			}
			if (rt == ResponseType.No) {
				md.Destroy ();
			}
		}
	}
}

