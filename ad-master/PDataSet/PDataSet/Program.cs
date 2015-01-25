//GitUser>@juankza

using System;
using Gtk;

namespace PDataSet
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
