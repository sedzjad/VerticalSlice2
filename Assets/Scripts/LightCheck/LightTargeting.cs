using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LightTargeting : MonoBehaviour    
{
    public GameObject Player;
    public float range = 30;

    [HideInInspector]
    public Vector3 direction;

    [HideInInspector]
    public Light Spotlight;

    public bool PlayerInLight = false;
    public bool PlayerSighted = false;

    public Color LightNormal;
    public Color LightDetected;
    AudioSource DetectedSound;

    // Start is called before the first frame update
    void Start()
    {
        Spotlight = GetComponent<Light>();
        DetectedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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

            if (hit.transform.name != "Player")
            {
                Spotlight.color = LightNormal;
            }
            else if (hit.transform.name == "Player")
            {
                Spotlight.color = LightDetected;
                PlayerSighted = true;
                if (!DetectedSound.isPlaying)
                {
                    DetectedSound.Play(0);
                }

                
            }
            


        }

    }
}
