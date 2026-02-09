using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
public class GF166Device
{

	private HardwareState _currentState = new HardwareState();

	public event Action<HardwareState> OnHardwareStateChanged;
	public async Task ProcessMessage(string RawData)
	{

		string rawData = RawData;
		_currentState.LeftBtn = false;
		_currentState.CenterBtn = false;
		_currentState.RightBtn = false;

		switch (RawData.Substring(9, 2))
		{
			case "02":
				_currentState.LeftBtn = true;
				break;
			case "01":
				_currentState.CenterBtn = true;
				break;
			case "04":
				_currentState.RightBtn = true;
				break;
		}
		_currentState.RotaryLargeInc = RawData.Substring(3, 2);
		_currentState.RotarySmallInc = RawData.Substring(6, 2);

		// we are done with mapping, now push updates to the sim
		var snapshot = _currentState.Clone();
		var handler = OnHardwareStateChanged;
		if (handler != null)
			_ = Task.Run(() => handler(snapshot));
	}
}
