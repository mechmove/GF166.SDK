using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class FakeGoFlight : IGoFlightModules, IGoFlight
{
	public int DisplayId => 2;
	public ushort GetNumDevices()
	{
		return 0;
	}
	public int Init()
	{
		return 0;
	}

	public void SetIndicators(int nDevIndex, bool b)
	{
		
	}
	public bool Initialized { get; set; }
	public async Task NoUpdatesSetCaptions(ConnectionInfo connectionInfo)
	{

	}
	public async Task SetLDisplayText(string s, ConnectionInfo connectionInfo)
	{
		Console.WriteLine("[Fake Goflight] Left Display:" + s);
	}
	public async Task SetRDisplayText(string s, ConnectionInfo connectionInfo, bool tuning = false)
	{
		Console.WriteLine("[Fake Goflight] Right Display:" + s);
	}

	public async Task CleanUpGoFlight(ConnectionInfo connectionInfo)
	{
	}

}
