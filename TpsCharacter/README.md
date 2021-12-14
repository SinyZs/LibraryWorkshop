# TpsCharacter

**Warning, Cinemachine is required for this !!**

# How to use it

1. Create a empty GameObject wich will be your Player and create a CharacterController.
2. In this GameObject place your player looks (mesh or just cylinder) and delete any collider of it.
3. Create a Cinemachine FreeLook Camera and drag your character in Follow and LookAt.
4. Modify the camera like you want in Orbits and change  the Binding Mode to World Space.
5. At the end of the Cinemachine Component, add the Cinemachine Collider extension to add the layer you want to collide with the camera and the layer you want to ignore
6. Add TpsController to the Player and think to link the CharacterController and the MainCamera and not the Freelook camera to the script.

---
# TpsController

this script is used to make move the player with basics transform in the way to a TPS game.
It is used too for make the camera move with the mouse around the player.

To see the script click here [FpsController](./Script/TpsController.cs).