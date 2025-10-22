# State Pattern with Locomotion Example

This project demonstrates how to implement a Finite State Machine (FSM) using the State Pattern in Unity.
The player’s locomotion logic (Grounded, InAir, Crouching) is represented as separate state classes, and transitions between these states are handled dynamically without using large if or switch blocks.


## Example states:

GroundedState -> can Jump, Crouch, or Fall 

InAirState -> can Land

CrouchingState -> can Stand or Jump
