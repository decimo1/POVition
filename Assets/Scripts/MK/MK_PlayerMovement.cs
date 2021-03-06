﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Movement of player object.
 *  
 *  @author Konstantin
 *  
 *  Mouse for turning, W - S for moving,
 *  adjust movement in Inspector
 */
public class MK_PlayerMovement : MonoBehaviour
{
    /** Movement speed for player ca 2-5.*/
    public float speed;
    /** Main Camera, for vertical adjustment.*/
    public Camera cam;
    /** Instead of rigidbody for more player options.*/
    public CharacterController player;
    /** Rotation speed, 2 is reasonable.*/
    public float xRotSpeed;
    /** Rotation speed, 2 is reasonable.*/
    public float yRotSpeed;
    /** Tracks vertical camera position.*/
    private float yRot = 0;
    /** Used to move player to ground.*/
    private float gravity = 0;
    
    /** lock cursor on scene start or after closing pause menu.
     */
    void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /** Movement at every Tick.
     *  Character Controller used for movement.
     *  Mouse for Orientation.
     *  Player can move on ground, turn the head and fall.
     */
    void Update() {
        if (!MK_PlayerAction.swapping && !MK_MenuControl.paused) {
              
            // Mouselook
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            yRot -= mouseY*yRotSpeed;
            cam.transform.localRotation = Quaternion.Euler(yRot, 0, 0);
            transform.Rotate(0, mouseX*xRotSpeed, 0); 
            
            //Movement
            // 12f feels better than 9.81
            gravity -= 15f * Time.deltaTime;
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));
            player.Move((transform.rotation * move.normalized * speed) * Time.deltaTime);
            if (player.isGrounded){gravity = 0;}
        }
    }
}
