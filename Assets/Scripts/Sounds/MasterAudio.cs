using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
[RequireComponent(typeof(AudioSource))]
public class MasterAudio : MonoBehaviour
{
    //Audio clips
    AudioSource audioData;
    public AudioClip Gravel;
    public AudioClip Pavement;
    public AudioClip Grass;

    public AudioClip MuffledGravel;
    public AudioClip MuffledPavement;
    public AudioClip MuffledGrass;

    Crouch cro;
    ZoneStatusUpdater zone;

    private bool IsWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure that there's an audio clip on the audio source, and makes sure it's playable.
        audioData = GetComponent<AudioSource>();
        audioData.clip = Pavement;
        audioData.Play();
        audioData.loop = true;
        audioData.Pause();

        //Gets the crouch & zone component from the parent.
        cro = GetComponentInParent<Crouch>();
        zone = GetComponentInParent<ZoneStatusUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        //All of the audio zone if statements
        if (cro.C == true && zone.zStatus == ZoneStatuses.IndoorsHalls)
        {
            audioData.clip = MuffledPavement;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.IndoorsHalls)
        {
            audioData.clip = Pavement;
        }

        else if (cro.C == true && zone.zStatus == ZoneStatuses.Outdoors)
        {
            audioData.clip = MuffledGravel;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.Outdoors)
        {
            audioData.clip = Gravel;
        }

        //Sound effects start when pressing one or more of the buttons.
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
        {
            if(IsWalking == false)
            {
                IsWalking = true;
                ResumeSound();
            }
        }

        //Sound effect stop when all the movements buttons are released.
        else if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey("s"))
        {
            if (IsWalking == true)
            {
                IsWalking = false;
                PauseSound();
            }
        }
    }

    //Resumes the sound.
    void ResumeSound()
    {
        
        audioData.Play();
    }

    //Pauses the sound
    void PauseSound()
    {
        
        audioData.Pause();
    }
}
