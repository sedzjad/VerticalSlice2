using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items : MonoBehaviour
{
    public string type;
    public string description;
    public int ID;
    public Sprite Icon;
    public bool PickedUp;
    public bool Equipped;

    private void Update()
    {
        if (Equipped)
        {

        }
    }

    public void ItemUsage()
    {
        if(type == "Weapon")
        {
            Equipped = true;
        }

    }
   
}
