using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPos : MonoBehaviour
{
    Vector3 Startpos;

    public GameObject MyFlashlight;
    private GameObject Player;

    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float rotateSpeed = 20f;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Startpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);       
    }

    void Update()
    {
        CheckIfSpotted();
        
    }

    private void CheckIfSpotted()
    {
        if (Startpos != transform.position && MyFlashlight.GetComponent<LightTargeting>().PlayerSighted)
        {
            float speedW = walkSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Startpos, speedW);
        }
        if (MyFlashlight.GetComponent<LightTargeting>().PlayerSighted && !GetComponent<CatchPlayer>().IsAtPlayer)
        {
            RunToPlayer();
        }
        
    }

    private void RunToPlayer()
    {

        float speedR = runSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, MyFlashlight.GetComponent<LightTargeting>().LastPlayerLocation, speedR);
        RotationCheck();
    }

    private void RotationCheck()
    {
        
        if (!GetComponent<CatchPlayer>().IsAtPlayer && !Equals(MyFlashlight.GetComponent<LightTargeting>().LastPlayerLocation))
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }


}
