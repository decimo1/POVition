﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Plate-Press and its actions
 *    
 *  @author Konstantin
 *  @date 18.12.20
 *
 *  Moves Plate down and up, makes actions happen
 */
public class Pressed : MonoBehaviour
{
    /** Object, which gets affected by Press.
     *  Can be specified in Inspector
     */
    public GameObject affectedObject;
    
    /** Number of single steps from up to down. 
     *  10 is good, defines smoothness and
     *  speed for movement ( 1/smoothness )
     */
    public int smoothness;
    
    /** Tracks position of movement.
     *  0 is down, smoothness is up
     */
    int position;
    
    /** Changes position of plate.
     */
    Vector3 movement;

    /** Is weight on pressure plate?.
     *  Changed by OnTriggerEnter()
     */
    bool triggered = false;

    void Start(){
        position = smoothness;
        movement = new Vector3(0,0.1f/smoothness,0);
    }

    /** Checks for GameObjects on top of plate.
     *  Triggers plate movement and actions
     */
    void OnTriggerEnter(Collider other){
        triggered = true;
    }

    /** Checks for Collider often.
     *  Fixes bug where after a teleport the pressure plate doesn't go down
     */
    void OnTriggerStay(Collider other){
        triggered = true;
    }

    /** Trigger stops.
     *  Moves plate up
     */
    void OnTriggerExit(Collider other){
        triggered = false;
    }

    /** All pressure plate behaviour.
     *  Moving up and down
     */
    void FixedUpdate(){ 
        if (triggered){
            if (position != 0){
                position--;
                transform.position -= movement;
                // maybe add colors changes and stuff here   
            }
            // TODO: Action for affectedObject here
        } else {
            if (position != smoothness){
                position++;
                transform.position += movement;
            }
            // TODO: Action for affectedObject here
        }
        triggered = false; //bug fix
    }
}
