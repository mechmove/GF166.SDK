# Hardware State Reference

`HardwareState` represents a snapshot of the GF‑166’s physical controls. It is strongly typed, explicit, and free of raw HID values.

## Properties

- `bool LeftBtn`  
- `bool CenterBtn`  
- `bool RightBtn`  
- `string RotaryLargeInc`  
- `string RotarySmallInc`  

These values are populated by the `GF166Device` parser, which translates raw HID reports into meaningful state.

## Immutability

`HardwareState.Clone()` creates a defensive copy so event subscribers cannot mutate internal state. This ensures predictable, thread‑safe behavior.

## Usage

The SDK raises `OnHardwareStateChanged` whenever new input is received. Developers can subscribe to this event to implement their own simulator logic, mappings, or workflows.