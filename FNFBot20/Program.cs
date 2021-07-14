using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace FNFBot20
{
    static class Program
    {
		public static DiscordRpcClient client = new DiscordRpcClient("846993950254694410");
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			var client = new DiscordRpcClient("846993950254694410");

			//Set the logger
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = "Playing the game",
				State = "Messing with Charts",
				Assets = new Assets()
				{
					LargeImageKey = "image_large",
					LargeImageText = "Lachee's Discord IPC Library",
					SmallImageKey = "image_small"
				}
			});
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}