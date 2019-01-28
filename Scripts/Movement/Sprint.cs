using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Sprint : MonoBehaviour
{
    movement mov;

    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<movement>(); //Gets the movement script.
    }

    // Update is called once per frame
    void Update()
    {
        SprintFunctie();
    }

    void SprintFunctie()
    {
        //Checks if left shift is pressed, and changes speed to the sprinting speed.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mov.speed = mov.speed * 1.5f;
        }

        //Checks if left shift is released, and changes speed to the walking speed.
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            mov.speed = mov.speed / 1.5f;
        }
    }
}
