using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoors : MonoBehaviour
{
    public Animator Anim;
    public bool Open = false;

    public TextOnOff Text;

    private void Update()
    {
        LockerDoor();
    }

    void LockerDoor()
    {
        if(Text.OpenPanel == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Anim.Play("OpenLocker");
                Open = true;
                Text.textbox.text = "Q";
            }
            else if (Input.GetKeyDown(KeyCode.Q) && Open == true)
            {
                Anim.Play("CloseLocker");
                Open = false;
                Text.textbox.text = "F";
            }
        }
    }


  

}
