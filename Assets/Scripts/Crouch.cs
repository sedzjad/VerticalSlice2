using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Crouch : MonoBehaviour
{
    //Audio clips for Crouching and standing up.
    AudioSource audioData;
    public AudioClip CrouchSound;
    public AudioClip StandingSound;

    public bool C = false;                           //The boolean for the crouch toggle.
    public bool Standing = true;                     //The boolean to fix the overextension for the standing hitbox
    public bool Crouching = false;                   //The boolean to fix the overextension for the crouching hitbox

    public CapsuleCollider PlayerCollider;           //The hitbox for the player.
    
    public float StandingHeight = 0.07480522f;       //Standing hitbox
    public float CrouchingHeight = 0.02f;            //Crouching hitbox

    public float CrouchingOffsetY = -0.05f;          //Offsets for the crouching animation
    public float StandingOffsetY = 0.05f;

    //Should be around 0.0022f
    public float differ;                             //Is the float for changing the heights

    public Vector3 CapsuleCrouchHeight;


    movement mov;

    

    private void Start()
    {
        audioData = GetComponentInParent<AudioSource>();    //Gets the audio source component on the gameobject.
        mov = GetComponentInParent<movement>();             //Gets the movement script.
    }

    void Update()
    {
        //From Standing to Crouching with the sound effect.
        if (C == false && Input.GetKeyDown("c") && !Input.GetKey(KeyCode.LeftShift)) 
        {
            C = true;
            mov.speed = mov.speed / 2;              //Changes walking speed to crouching speed.
            audioData.clip = CrouchSound;
            audioData.Play();
        }

        //From Crouching to Standing with the sound effect.
        else if (C == true && Input.GetKeyDown("c"))
        {
            C = false;
            mov.speed = mov.speed * 2;              //Changes crouching speed to walking speed.
            audioData.clip = StandingSound;
            audioData.Play();
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (C == true)
            {
                mov.speed = mov.speed * 2;          //Changes crouching speed to walking speed.
                C = false;
            }
        }

        //The hitbox for Standing to Crouching.
        if (C == true && PlayerCollider.height >= CrouchingHeight && Crouching == false)
        {
            PlayerCollider.height = PlayerCollider.height - differ;
            Standing = false;
            
            //Changes the position of the hit box to the crouching position.
            transform.Translate(0, CrouchingOffsetY, 0);

            CapsuleCrouchHeight.y = 0.005f;

            PlayerCollider.center = CapsuleCrouchHeight; 
            //If it reaches, or gets lower then the crouching heights, it stops lowering the height.
            if (PlayerCollider.height <= CrouchingHeight)
            {
                Crouching = true;
            }
        }

        //The hitbox for Crouching to Standing.
        else if (C == false && PlayerCollider.height <= StandingHeight && Standing == false)
        {
            PlayerCollider.height = PlayerCollider.height + differ;
            Crouching = false;

            // Changes the position of the hit box to the standing position
            transform.Translate(0, StandingOffsetY, 0);

            CapsuleCrouchHeight.y = 0f;

            PlayerCollider.center = CapsuleCrouchHeight;
            //If it reaches, or gets bigger then the crouching heights, it stops making the height bigger.
            if (PlayerCollider.height >= StandingHeight)
            {
                Standing = true;
            }
        }
    }
}