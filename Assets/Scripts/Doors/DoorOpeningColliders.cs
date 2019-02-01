using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningColliders : MonoBehaviour
{
 
    public Animator Anim;
    private bool DoorOpen;
    public BoxCollider Box;
    public float exitTime = 2f;

    private void Start()
    {
        //Box.isTrigger = false;
        DoorOpen = false;
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && DoorOpen == false)
        {
            Anim.Play("door_opening_ani");
            DoorOpen = true;
            Box.isTrigger = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(DoorOpen && exitTime == 2f)
        {
            
            Anim.Play("door_closing_ani") ;
            DoorOpen = false;
            Box.isTrigger = false;
        }
    }


}
