using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class HardwareEventLoggerTests
{
	public static void HardwareEventLogger()
	{
		Console.WriteLine("GF 166 SDK State and Logging Examples");

		if (!Directory.Exists("UsbHid"))
		{
			Directory.CreateDirectory("UsbHid");
		}

		if (!Directory.Exists("DeviceEvents"))
		{
			Directory.CreateDirectory("DeviceEvents");
		}

		var services = new ServiceCollection();

		services.AddSingleton<GF166ProtocolHandler>();
		services.AddSingleton<GF166Device>();
		services.AddSingleton<HardwareState>();

		var provider = services.BuildServiceProvider();

		var protocol = provider.GetRequiredService<GF166ProtocolHandler>();
		var device = provider.GetRequiredService<GF166Device>();
		var HardwareState = provider.GetRequiredService<HardwareState>();

		protocol.ReportReceived += report =>
		{
			string HIDReport = (BitConverter.ToString(report));
			device.ProcessMessage(HIDReport).Wait();
			string detailReport = "RAW HID:" + DateTime.Now + ":" + HIDReport + Environment.NewLine;
			File.AppendAllText("UsbHid\\HidEvents.txt", detailReport);
			Console.WriteLine(detailReport);
		};

		device.OnHardwareStateChanged += state =>
		{
			string CurrentState = RtnCurrentState(state);
			File.AppendAllText("DeviceEvents\\EventLog.txt", CurrentState);
			Console.WriteLine(CurrentState);
		};
		Console.WriteLine("Now start manipulating the controls....");
		Console.ReadKey();

		ConsoleKeyInfo keyInfo;
		do
		{
			keyInfo = Console.ReadKey(true); // 'true' hides the key
		} while (keyInfo.Key != ConsoleKey.E);

	}
	static string RtnCurrentState(HardwareState state)
	{
		string controlChanges = string.Empty;
		if (state.LeftBtn) controlChanges += DateTime.Now + ":" + "Left Button Pressed" + Environment.NewLine;
		if (state.CenterBtn) controlChanges += DateTime.Now + ":" + "Center Button Pressed" + Environment.NewLine;
		if (state.RightBtn) controlChanges += DateTime.Now + ":" + "Right Button Pressed" + Environment.NewLine;
		controlChanges += "RotaryLargeInc" + DateTime.Now + " Value: " + state.RotaryLargeInc + Environment.NewLine;
		controlChanges += "RotarySmallInc" + DateTime.Now + " Value: " + state.RotarySmallInc + Environment.NewLine;
		return controlChanges + Environment.NewLine;
	}
}
