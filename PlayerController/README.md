# FpsCharacter


# How to use it

1. Create a empty GameObject wich will be your Player and create a CharacterController.
2. In this GameObject place your player looks (mesh or just cylinder) and delete any collider of it.
3. Place the Camera in your player too and place it on the top like it's the head.
4. Add MouseLock to yours Camera's components to move it with the mouse when oyu play.
5. Create a empty GameObject in your player and place it at the bottom of your player, it wiil be the groudCheck.
6. Add FpsController to the Player and think to link the groundCheck and the CharacterController it the script.

---
# FpsCamera

This script is used to lock the mouse in the center of the screen and to move the camera with the camera to make a Fps Camera.

To see the script click here [FpsCamera](./FpsCamera.cs).

---
# FpsController

this script is used to make move the player with basics transform.
it is used too for make the player jump and to detect if the player is on the ground or no to cancel any action if he is in the air.

To see the script click here [FpsController](./FpsController.cs).