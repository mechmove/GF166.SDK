public class HardwareState
{
	public bool LeftBtn { get; set; }
	public bool CenterBtn { get; set; }
	public bool RightBtn { get; set; }

	public string RotaryLargeInc { get; set; }
	public string RotarySmallInc { get; set; }

	// Clone method for immutability
	public HardwareState Clone()
	{
		return new HardwareState
		{
			LeftBtn = this.LeftBtn,
			CenterBtn = this.CenterBtn,
			RightBtn = this.RightBtn,
			RotaryLargeInc = this.RotaryLargeInc,
			RotarySmallInc = this.RotarySmallInc
		};
	}
}