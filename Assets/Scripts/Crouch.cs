using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Crouch : MonoBehaviour
{

    private bool C = false;                 //The boolean for the crouch toggle
    public CapsuleCollider PlayerCollider;  //The hitbox for the player

    public float StandingHeight = 1.95f;
    public float CrouchingHeight = 1.05f;

    // Update is called once per frame
    void Update()
    {
        //From Standing to Crouching.
        if (C == false && Input.GetKeyDown("c")) 
        {
            C = true;
        }

        //From Crouching to Standing.
        else if (C == true && Input.GetKeyDown("c"))
        {
            C = false;
        }

        //The hitbox for Standing to Crouching.
        if (C == true && PlayerCollider.height >= CrouchingHeight)
        {
            PlayerCollider.height = PlayerCollider.height - 0.05f;
        }

        //The hitbox for Crouching to Standing.
        else if (C == false && PlayerCollider.height <= StandingHeight)
        {
            PlayerCollider.height = PlayerCollider.height + 0.05f;
        }
    }
}