# GF‑166 Protocol Notes

The GF‑166 communicates over USB HID using a fixed‑length input report. The `GF166ProtocolHandler` handles:

- device enumeration  
- opening the HID handle  
- reading input reports asynchronously  
- raising `ReportReceived` events  

The SDK does not interpret HID values directly. That responsibility belongs to `GF166Device`, which parses the raw report into a strongly typed `HardwareState`.

## Input Report Structure

The GF‑166 sends a short HID packet containing:

- rotary increments  
- button states  
- device identifiers  

The SDK extracts only the fields required for hardware state. All simulator interpretation is left to the integration layer.

## Output Reports

Display updates are handled through either:

- the GoFlight GFDev.dll implementation, or  
- the FakeGoFlight test implementation  

The SDK formats display text but does not enforce simulator behavior or frequency rules.