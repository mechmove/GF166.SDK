# Getting Started

This guide walks you through using the GF‑166 SDK in a simple console application.

## 1. Install Dependencies

Add the SDK project or DLL to your solution.

## 2. Configure Dependency Injection

csharp
var services = new ServiceCollection();
services.AddSingleton<GF166ProtocolHandler>();
services.AddSingleton<GF166Device>();
services.AddSingleton<IGoFlightModules, GoFlight>();
services.AddSingleton<IGoFlightModules, FakeGoFlight>();

## 3. Subscribe to Hardware Events

device.OnHardwareStateChanged += state =>
{
    Console.WriteLine($"Large: {state.RotaryLargeInc}, Small: {state.RotarySmallInc}");
};

## 4. Write to the Displays

await goflight.SetLDisplayText("124.300", config);
await goflight.SetRDisplayText("120.950", config);

## 5. Implement Your Own Simulator Logic

The SDK does not provide simulator mappings. You define:

- how hardware events affect the simulator
- how simulator state updates the hardware
- how aircraft logic is interpreted

This keeps the SDK flexible and free of assumptions

## 6. Explore the Examples

See the examples/ folder for reference implementations.

