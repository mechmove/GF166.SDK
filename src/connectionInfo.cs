using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public sealed class ConnectionInfo
{
	string fln = "GF166.SDK.Init.txt";
	public string PID { get; set; }
	public string VID { get; set; }
	public string Desc { get; set; }
	public string CAPTION_ACTIVE { get; set; }
	public string CAPTION_STANDBY { get; set; }
	public bool DisplayNumbers { get; set; }
	public int Delay_ms { get; set; }
	public int GoFlightOpt { get; set; } // 1 = Real displays, 2 = fake
	public int RadioControlPanel { get; set; }  // if more than 1 radio is in the simulator
	public void GetConfiguration()
	{
		var contents = File.ReadAllLines(fln);
		if (contents.Length < 8)
			throw new InvalidOperationException("Config file missing required lines.");

		VID = StripOutComment(contents[0]);
		PID = StripOutComment(contents[1]);
		Desc = StripOutComment(contents[2]);

		string Captions = StripOutComment(contents[3]);
		CAPTION_ACTIVE = RtnCSVEntry(Captions, 0);
		CAPTION_STANDBY = RtnCSVEntry(Captions, 1);

		DisplayNumbers = Convert.ToBoolean(StripOutComment(contents[4]));
		Delay_ms = Convert.ToInt16(StripOutComment(contents[5]));
		GoFlightOpt = Convert.ToInt16(StripOutComment(contents[6]));
		RadioControlPanel = Convert.ToInt16(StripOutComment(contents[7]));
	}
	static string StripOutComment(string s)
	{
		int idx = s.IndexOf(';');
		return idx >= 0 ? s[..idx] : s;
	}
	static string RtnCSVEntry(string CSVLine, int NumCommas)
	{
		for (int j = 1; j <= NumCommas; j = j + 1)
		{
			CSVLine = CSVLine.Substring(CSVLine.IndexOf(",") + 1);
		}
		if (CSVLine.IndexOf(",") > 0)
		{
			return CSVLine.Substring(0, CSVLine.IndexOf(","));
		}
		else
		{
			return CSVLine;
		}
	}
}