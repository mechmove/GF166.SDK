# FakeGoFlight Demo

This example uses the `FakeGoFlight` implementation to simulate display output without requiring physical hardware. It is ideal for development on machines without GoFlight devices attached.

## What This Example Tests

- Display formatting  
- Output pipeline  
- Timing behavior  
- Integration logic without hardware  

## Console Output

The fake implementation prints display updates such as:

[Fake GoFlight] Left Display: 124.300 [Fake GoFlight] Right Display: 120.950

This allows you to test your integration logic in isolation, without worrying about USB drivers or GFDev.dll.

