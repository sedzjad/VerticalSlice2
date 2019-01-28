using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
[RequireComponent(typeof(AudioSource))]
public class MasterAudio : MonoBehaviour
{
    //Audio clips for walking
    AudioSource audioData;
    public AudioClip Gravel;
    public AudioClip Pavement;
    public AudioClip Grass;

    //Audio clips for crouched walking
    public AudioClip MuffledGravel;
    public AudioClip MuffledPavement;
    public AudioClip MuffledGrass;

    Crouch cro;
    ZoneStatusUpdater zone;

    public GameObject reverb;
    public GameObject Crouch;

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
        cro = Crouch.GetComponent<Crouch>();
        zone = GetComponentInParent<ZoneStatusUpdater>();

        //Gets the Reverb component
        reverb.GetComponent<AudioReverbZone>();
    }

    // Update is called once per frame
    void Update()
    {
        //All of the audio zone if statements with crouch and standing up.
        if (cro.C == true && zone.zStatus == ZoneStatuses.IndoorsHalls || cro.C == true && zone.zStatus == ZoneStatuses.IndoorsRoom)
        {
            audioData.clip = MuffledPavement;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.IndoorsHalls || cro.C == false && zone.zStatus == ZoneStatuses.IndoorsRoom)
        {
            audioData.clip = Pavement;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
        }

        //Reverb effect triggers when entering the Lounge.
        else if (cro.C == true && zone.zStatus == ZoneStatuses.IndoorsLounge)
        {
            audioData.clip = MuffledPavement;
            reverb.GetComponent<AudioReverbZone>().enabled = true;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.IndoorsLounge)
        {
            audioData.clip = Pavement;
            reverb.GetComponent<AudioReverbZone>().enabled = true;
        }

        else if (cro.C == true && zone.zStatus == ZoneStatuses.OutdoorsGravel)
        {
            audioData.clip = MuffledGravel;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.OutdoorsGravel)
        {
            audioData.clip = Gravel;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
        }

        else if (cro.C == true && zone.zStatus == ZoneStatuses.OutdoorsGrass)
        {
            audioData.clip = MuffledGrass;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
        }

        else if (cro.C == false && zone.zStatus == ZoneStatuses.OutdoorsGrass)
        {
            audioData.clip = Grass;
            reverb.GetComponent<AudioReverbZone>().enabled = false;
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
