using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlapdeurOnCollision : MonoBehaviour
{
    public Items item;
    public Animator Anim;
    private bool DoorOpen;
    public BoxCollider Box;


    private void Start()
    {
        DoorOpen = false;
        
    }


    private void OnCollisionStay(Collision collision) 
    {
        
        if (collision.gameObject.tag == "Player" && item.Equipped == true)
        {
            Anim.Play("DoorOpen");
            DoorOpen = true;
            Box.isTrigger = true;
        }
        else if (collision.gameObject.tag == "Player" && item.Equipped == false)
        {
            GetComponent<TextOnOff>().NoKeyText();
            
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
