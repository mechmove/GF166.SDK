# Display Writer Demo

This example demonstrates how to send text to the GF‑166 displays using either the real GoFlight implementation or the FakeGoFlight fallback.

## What This Example Tests

- Display update timing  
- Active/Standby formatting  
- GFDev.dll interop (when available)  
- Clean shutdown behavior  

## Usage

The example writes:

- Active frequency  
- Standby frequency  
- Captions from `ConnectionInfo`  
- Blank displays during cleanup  

This harness is useful for verifying that display output behaves correctly under different timing conditions.