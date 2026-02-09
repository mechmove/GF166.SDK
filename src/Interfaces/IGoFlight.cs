using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
public interface IGoFlight
{
	int DisplayId { get; }
	bool Initialized { get; set; }
	ushort GetNumDevices();
	int Init();
	void SetIndicators(int nDevIndex, bool b);
	Task NoUpdatesSetCaptions(ConnectionInfo connectionInfo);
	Task SetLDisplayText(string s, ConnectionInfo connectionInfo);
	Task SetRDisplayText(string s, ConnectionInfo connectionInfo, bool tuning = false);
	Task CleanUpGoFlight(ConnectionInfo connectionInfo);
}
