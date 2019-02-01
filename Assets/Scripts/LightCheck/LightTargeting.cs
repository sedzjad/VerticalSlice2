using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LightTargeting : MonoBehaviour    
{
    private GameObject Player;
    public float range = 30;

    [HideInInspector]
    public Vector3 direction;
    public Vector3 LastPlayerLocation;

    [HideInInspector]
    public Light Spotlight;

    public bool PlayerInLight = false;
    public bool PlayerSighted = false;

    public Color LightNormal;
    public Color LightDetected;
    AudioSource DetectedSound;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Spotlight = GetComponent<Light>();
        DetectedSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastCheck();
    }

    public void RaycastCheck()
    {
        RaycastHit hit;
        if (PlayerInLight)
        {
            direction = (Player.transform.position - transform.position);
            Physics.Raycast(transform.position, direction, out hit, range);

            Debug.DrawRay(transform.position, direction, Color.red, 2, false);
            if (hit.transform.tag == "Player")
            {
                LastPlayerLocation = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
                Spotlight.color = LightDetected;
                PlayerSighted = true;
                if (!DetectedSound.isPlaying)
                {
                    DetectedSound.Play(0);
                }

                
            }
            else if (hit.transform.tag != "Player")
            {
                Spotlight.color = LightNormal;
            }


        }

    }
}
