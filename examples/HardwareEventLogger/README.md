# Hardware Event Logger

This example logs all GF‑166 hardware events to disk. It is useful for debugging, reverse‑engineering HID behavior, or validating that the device is producing consistent input.

## What This Example Tests

- Raw HID report capture  
- Timestamped event logging  
- HardwareState transitions  
- End‑to‑end input pipeline  

## Output Files

- `UsbHid/HidEvents.txt` — raw HID packets  
- `DeviceEvents/EventLog.txt` — parsed hardware events  

## Usage

Run the example and interact with the GF‑166. Every rotary increment and button press will be logged automatically.

This harness is ideal for diagnosing hardware quirks or verifying that the protocol handler is functioning correctly.