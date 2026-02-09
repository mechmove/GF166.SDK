# Basic Console Test

This example demonstrates the minimal setup required to use the GF‑166 SDK. It initializes the protocol handler, subscribes to hardware events, and writes simple output to the console.

The goal is to show how the SDK components fit together without introducing simulator logic or mappings.

## What This Example Tests

- USB HID connectivity  
- GF‑166 input parsing  
- HardwareState event flow  
- Dependency injection wiring  
- Basic display output  

## Running the Example

1. Install ServiceCollection to support Dependency injection.
2. Select Platform target build=x86 for GFDev.dll.
3. Build the solution. 
4. Run the console app.
5. Rotate the dials or press buttons on the GF‑166.
6. Watch the console output update in real time.

This example is for verifying that the SDK is correctly installed and communicating with the hardware.

