# Simulator‑Agnostic Design

The GF‑166 SDK intentionally avoids simulator‑specific behavior. Hardware panels often differ from real‑aircraft layouts, and different simulators interpret the same controls in different ways. Embedding assumptions about aircraft systems or workflows would limit flexibility and create expectations that may not apply to all users.

To keep the SDK maintainable and adaptable, the hardware layer focuses solely on:

- decoding device input  
- formatting device output  
- exposing strongly typed state  
- providing a consistent event model  

All simulator logic — including mappings, behaviors, and interpretation of hardware events — is left to the developer implementing the integration layer. This ensures that each project can define the behavior that best fits its aircraft, simulator, and workflow.