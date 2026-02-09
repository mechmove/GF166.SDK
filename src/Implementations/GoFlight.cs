using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
public class GoFlight : IGoFlightModules, IGoFlight
{
	public int DisplayId => 1;
	enum GFDEVRESULT
	{
		GFDEV_OK = 0,
		GFDEV_ERR_INVALID_DEVICE_INDEX,
		GFDEV_ERR_INSUFFICIENT_MEMORY,
		GFDEV_ERR_DEVICE_NOT_PRESENT,
		GFDEV_ERR_COMMAND_QUEUE,
		GFDEV_ERR_HID_GET_FEATURE,
		GFDEV_ERR_HID_SET_FEATURE,
		GFDEV_ERR_SET_DATA_NOT_VERIFIED,
		GFDEV_ERR_NO_DATA_AVAIL,
		GFDEV_ERR_UNSUPPORTED_OS,
		GFDEV_ERR_DLL_NOT_FOUND,
		GFDEV_ERR_INVALID_ARG,
		GFDEV_ERR_API_NOT_INIT,
		GFDEV_ERR_FUNC_NOT_SUPPORTED

	};

	//GFDEVRESULT GF166_GetControlVals(int nDevIndex, short* pnLgDialVal, short* pnSmDialVal, unsigned char* pbSwitchVals);
	//GFDEVRESULT GF166_GetEncoderTypes(int nDevIndex, ENCODERTYPE* petLgDial, ENCODERTYPE* petSmDial);
	//GFDEVRESULT GF166_SetEncoderTypes(int nDevIndex, ENCODERTYPE etLgDial, ENCODERTYPE etSmDial);
	//GFDEVRESULT GF166_GetIndicators(int nDevIndex, unsigned char* pbIndicatorState);
	//GFDEVRESULT GF166_SetRDisplaySegments(int nDevIndex, unsigned char* pszSegData);
	//GFDEVRESULT GF166_GetBrightness(int nDevIndex, int* pnBrightLevel);
	//GFDEVRESULT GF166_SetBrightness(int nDevIndex, int nBrightLevel);

	[DllImport("GFDev.dll")]
	static extern GFDEVRESULT GF166_SetIndicators(int nDevIndex, bool bIndicatorState);

	[DllImport("GFDev.dll")]
	static extern GFDEVRESULT GF166_SetLDisplayText(int nDevIndex, StringBuilder pszText);

	//GFDEVRESULT GF166_SetLDisplaySegments(int nDevIndex, unsigned char* pszSegData);
	[DllImport("GFDev.dll")]
	static extern GFDEVRESULT GF166_SetRDisplayText(int nDevIndex, StringBuilder pszText);

	[DllImport("GFDev.dll")]
	static extern GFDEVRESULT GFDev_Terminate();

	[DllImport("GFDev.dll")]
	static extern GFDEVRESULT GFDev_Init();

	[DllImport("GFDev.dll")]
	static extern ushort GF166_GetNumDevices();
	//static extern GFDEVRESULT GF46_GetControlVals(int nDevIndex, short pnLgDialVal, short pnSmDialVal, byte pbSwitchVal);

	public static string LastLeftFreq = string.Empty;
	public bool Initialized { get; set; }
	public ushort GetNumDevices()
	{
		return GF166_GetNumDevices();
	}
	public int Init()
	{
		int Rtn = -1;
		GFDEVRESULT init = GFDev_Init();
		if (init.Equals(GFDEVRESULT.GFDEV_OK))
		{
			Rtn = 0;
		}
		return Rtn;
	}

	public void SetIndicators(int nDevIndex, bool b)
	{
		GFDEVRESULT test = GF166_SetIndicators(nDevIndex, b);
	}

	public async Task NoUpdatesSetCaptions(ConnectionInfo connectionInfo)
	{
		string s = connectionInfo.CAPTION_ACTIVE;
		await Task.Delay(connectionInfo.Delay_ms);
		StringBuilder Alpha = new StringBuilder(6);
		Alpha.Append(s);
		GFDEVRESULT test = GF166_SetLDisplayText(0, Alpha);

		s = connectionInfo.CAPTION_STANDBY;
		await Task.Delay(connectionInfo.Delay_ms);
		Alpha = new StringBuilder(6);
		Alpha.Append(s);
		test = GF166_SetRDisplayText(0, Alpha);

	}
	public async Task SetLDisplayText(string s, ConnectionInfo connectionInfo)
	{
			if (!LastLeftFreq.Equals(s))
			{
				StringBuilder Alpha = new StringBuilder(6);
				Alpha.Append(s);
				GFDEVRESULT test = GF166_SetLDisplayText(0, Alpha);
				await Task.Delay(connectionInfo.Delay_ms);
			}
			LastLeftFreq = s;
	}
	public async Task SetRDisplayText(string s, ConnectionInfo connectionInfo, bool tuning = false)
	{
			// rapid dialing of decimal portion results in entire panel freeze,
			// therefore try about 10 ms sleep for this display during tuning and active/standby swaps
			if (tuning)
			{
				await Task.Delay(connectionInfo.Delay_ms);
			}
			StringBuilder Alpha = new StringBuilder(6);
			Alpha.Append(s);
			GFDEVRESULT test = GF166_SetRDisplayText(0, Alpha);
	}

	public async Task CleanUpGoFlight(ConnectionInfo connectionInfo)
	{
		LastLeftFreq = connectionInfo.CAPTION_ACTIVE;
		connectionInfo.DisplayNumbers = true;
		await SetLDisplayText("", connectionInfo);
		await SetRDisplayText("", connectionInfo);
		GFDEVRESULT CheckExit = GFDev_Terminate();
	}

}
