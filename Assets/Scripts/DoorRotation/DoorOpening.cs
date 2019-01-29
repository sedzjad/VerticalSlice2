using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{

    public Animator anim;

    public bool DoorOpen;

    
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;

    // Start is called before the first frame update
    void Start()
    {
        DoorOpen = false;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DoorStatusCheck();
    }

    public void DoorStatusCheck()
    {
        if (Input.GetKeyDown(KeyCode.F) && DoorOpen == false)
        {
            WhichDoor();
            DoorOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && DoorOpen == true)
        {

            anim.Play("Door_Closing");
            DoorOpen = false;
        }
    }

    public void WhichDoor()
    {

        if (Door1)
        {
            anim.Play("Door_Opening");
        }
        else if (Door2)
        {
            anim.Play("Door_Opening2");
        }
        else if (Door3)
        {
            anim.Play("Door_Opening3");
        }

    }
}
