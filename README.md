# GF‑166 SDK

The GF‑166 SDK provides a clean, simulator‑agnostic hardware interface for the GoFlight GF‑166 radio panel. It focuses exclusively on hardware behavior: decoding HID input, formatting display output, and exposing strongly typed state through simple, explicit contracts.

This SDK does **not** implement simulator logic, aircraft behavior, or mapping rules. Those responsibilities belong to the integration layer built by the developer using this SDK.

## Features

- Strongly typed `HardwareState` model  
- Event‑driven hardware updates  
- HID protocol handler for USB communication  
- GoFlight GFDev.dll implementation  
- FakeGoFlight implementation for testing  
- Clean contract‑based architecture  
- No simulator assumptions or dependencies  

## Philosophy

This SDK is built around clear contracts and strict separation of concerns. Hardware logic stays in the hardware layer. Simulator logic stays in the simulator layer. No assumptions cross that boundary.

If you need simulator behavior, you define it.  
If you need mappings, you implement them.  
If you need aircraft logic, you own it.

The SDK provides the tools — not the opinions.

## Documentation

- [About This Project](docs/AboutThisProject.md)  
- [Simulator‑Agnostic Design](docs/SimulatorAgnosticDesign.md)  
- [Hardware State Reference](docs/HardwareStateReference.md)  
- [GF‑166 Protocol Notes](docs/GF166ProtocolNotes.md)  
- [Getting Started](docs/GettingStarted.md)

## Examples

See the `examples/` folder for reference implementations and test harnesses.

## License

MIT — use it, learn from it, build on it.