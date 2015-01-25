//gitUser> @juankza

using Gtk;
using System;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			LoginWindow lWin = new LoginWindow ();
			lWin.Show ();
			Application.Run ();

		}

	}

}
