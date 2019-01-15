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

    public bool C = false;                 //The boolean for the crouch toggle.
    public CapsuleCollider PlayerCollider;  //The hitbox for the player.
    
    public float StandingHeight = 1.95f;    //Standing hitbox
    public float CrouchingHeight = 1.05f;   //Crouching hitbox

    movement mov;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();    //Gets the audio source component on the gameobject.
        mov = GetComponent<movement>();             //Gets the movement script.
    }

    void Update()
    {
        //From Standing to Crouching with the sound effect.
        if (C == false && Input.GetKeyDown("c") && !Input.GetKey(KeyCode.LeftShift)) 
        {
            C = true;
            mov.speed = mov.speed / 2;              //Changes walking speed to crouching speed.
            audioData.clip = CrouchSound;
            audioData.Play(0);
        }

        //From Crouching to Standing with the sound effect.
        else if (C == true && Input.GetKeyDown("c"))
        {
            C = false;
            mov.speed = mov.speed * 2;              //Changes crouching speed to walking speed.
            audioData.clip = StandingSound;
            audioData.Play(0);
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (C == true)
            {
                mov.speed = mov.speed * 2;
                C = false;
            }
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