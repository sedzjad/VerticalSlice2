using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooorNumber : MonoBehaviour
{
    DoorOpening Check;

    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckingTheDoors();
    }

    public void CheckingTheDoors()
    {
        Check = FindObjectOfType<DoorOpening>();
        
        if (Door1)
        {
            Check.DoorStatusCheck();
        }
        else if (Door2)
        {
            Check.DoorStatusCheck();
        }
        else if (Door3)
        {
            Check.DoorStatusCheck();
        }
    }
}
