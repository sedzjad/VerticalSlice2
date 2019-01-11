using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPos : MonoBehaviour
{
    Vector3 Startpos;

    public GameObject MyFlashlight;
    public GameObject Player;

    public float walkSpeed = 5;
    public float runSpeed = 7;

    // Start is called before the first frame update
    void Start()
    {
        Startpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSpotted();
        
    }

    private void CheckIfSpotted()
    {
        if (Startpos != transform.position && MyFlashlight.GetComponent<LightTargeting>().PlayerSighted)
        {
            float speed = walkSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Startpos, speed);
        }
        if (MyFlashlight.GetComponent<LightTargeting>().PlayerSighted && !GetComponent<CatchPlayer>().IsAtPlayer)
        {
            RunToPlayer();
        }
        
    }

    private void RunToPlayer()
    {        
        float speed = runSpeed * Time.deltaTime;            
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);        
    }

}
