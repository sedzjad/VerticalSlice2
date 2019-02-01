using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPos : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Startpos;

    public GuardAniScript animator;

    public GameObject MyFlashlight;
    private GameObject Player;


    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float rotateSpeed = 20f;

    private bool startRunning = false;
    

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

        if (Startpos != transform.position && GetComponent<CatchPlayer>().IsAtPlayer)
        {
            BackToStart();
        }
        if (startRunning && !GetComponent<CatchPlayer>().IsAtPlayer)
        {
            RunToPlayer();
        }
        else if (MyFlashlight.GetComponent<LightTargeting>().PlayerSighted && !GetComponent<CatchPlayer>().IsAtPlayer)
        {
            startRunning = true;

        }
        
    }

    private void BackToStart()
    {
        float speedW = walkSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Startpos, speedW);
        if (transform.position != Startpos)
        {
            Vector3 pos = new Vector3(Startpos.x, transform.position.y, Startpos.z);
            transform.LookAt(pos);
            animator.SetSpeed(2);
            if(transform.position == pos)
            {
                animator.SetSpeed(0);
            }
        }
        else if (transform.position == Startpos)
        {
            animator.SetSpeed(0);
        }

    }

    private void RunToPlayer()
    {
        animator.SetSpeed(6);
        animator = GameObject.Find("GuardAnimations").GetComponent<GuardAniScript>();
        float speedR = runSpeed * Time.deltaTime;

        Vector3 pos = new Vector3(MyFlashlight.GetComponent<LightTargeting>().LastPlayerLocation.x,
                                  transform.position.y,
                                  MyFlashlight.GetComponent<LightTargeting>().LastPlayerLocation.z);

        transform.position = Vector3.MoveTowards(transform.position, pos, speedR);
        transform.LookAt(pos);


        Vector3 posS = new Vector3(Startpos.x, transform.position.y, Startpos.z);

        if (transform.position == pos)
        {
            animator.SetSpeed(0);
            animator.launchTrigger("LookingAround");
        }
        if(transform.position != posS)
        {
            BackToStart();
            
        }


        transform.Rotate(new Vector3(0f, 90f, 0f), Space.Self);

    }

}
