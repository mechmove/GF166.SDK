using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class DisplayWriter
{
	public static void DisplayWriterTests()
	{
		ConnectionInfo connectionInfo = new ConnectionInfo();
		connectionInfo.GetConfiguration();

		Console.WriteLine("GF 166 SDK Device Tests");

		var services = new ServiceCollection();
		
		// if there are more 2 or more radios in your simulator, this will be the way to 
		// make the correct hardware assignment via connectionInfo.RadioControlPanel.
		// We are populating services with all delegates then selecting the 'correct'
		// final form as specified by connectionInfo:
		services.AddSingleton<IRadioControlPanelParser, SimMessageRadio1>();
		services.AddSingleton<IRadioControlPanelParser, SimMessageRadio2>();
		services.AddSingleton<IRadioControlPanel>(sp =>
		{
			var all = sp.GetServices<IRadioControlPanelParser>();
			return all.First(p => p.PanelId == connectionInfo.RadioControlPanel);
		});

		services.AddSingleton<IGoFlightModules, FakeGoFlight>();
		services.AddSingleton<IGoFlightModules, GoFlight>();
		services.AddSingleton<IGoFlight>(sp =>
		{
			var all = sp.GetServices<IGoFlightModules>();
			return all.First(p => p.DisplayId == connectionInfo.GoFlightOpt);
		});

		var provider = services.BuildServiceProvider();
		var GFDev = provider.GetRequiredService<IGoFlight>();
		var RadioControlPanel = provider.GetService<IRadioControlPanel>();

		// write some values to the display:
		// write Active Standby values
		//124.300123.950
		if (connectionInfo.DisplayNumbers)
		{
			string ActiveStandby = "124.300120.950";
			Console.WriteLine("For Radio: " + Convert.ToString(RadioControlPanel.PanelId.ToString()) + " Active/Standby:" + ActiveStandby);
			// the GFDev.dll requires build X86 in project properties
			GFDev.Init();
			GFDev.SetLDisplayText(ActiveStandby.Substring(0, 7), connectionInfo);
			GFDev.SetRDisplayText(ActiveStandby.Substring(7, 7), connectionInfo);
		}

		Console.WriteLine("press any key");
		Console.ReadKey();

		// write captions in connectionInfo
		GFDev.SetLDisplayText(connectionInfo.CAPTION_ACTIVE, connectionInfo);
		GFDev.SetRDisplayText(connectionInfo.CAPTION_STANDBY, connectionInfo);

		Console.WriteLine("press any key");
		Console.ReadKey();

		// cleanup
		GFDev.CleanUpGoFlight(connectionInfo);

		ConsoleKeyInfo keyInfo;
		do
		{
			keyInfo = Console.ReadKey(true); // 'true' hides the key
		} while (keyInfo.Key != ConsoleKey.E);



	}
}
