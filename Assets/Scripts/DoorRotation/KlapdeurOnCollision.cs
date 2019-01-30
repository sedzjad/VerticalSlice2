using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlapdeurOnCollision : MonoBehaviour
{
    public Animator Anim;
    private bool DoorOpen;
    public BoxCollider Box;

    private void Start()
    {
        DoorOpen = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            
            Anim.Play("DoorOpen");
            DoorOpen = true;
            Box.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if(DoorOpen == true && other.tag == "Player")
        {
            
            Anim.Play("DoorClosed");
            DoorOpen = false;
            Box.isTrigger = false;
        }
    }
}
