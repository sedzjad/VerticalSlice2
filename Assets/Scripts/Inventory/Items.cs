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

    [HideInInspector]
    public bool Equipped;
    [HideInInspector]
    public GameObject Weapon;
    [HideInInspector]
    public GameObject Key;
    [HideInInspector]
    public GameObject WeaponManager;

    public bool PlayersWeapon;
    public bool PlayersKey;
    public bool DoorKey;

    [SerializeField]
    private GameObject _sleutel;

    public void Start()
    {
         if (!PlayersKey)
        {
            int allKeys = _sleutel.transform.childCount;
            for(int i = 0; i<allKeys; i++)
            {
                if(_sleutel.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Key = _sleutel.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
       if (Equipped)
        {

        }
    }

    public void ItemUsage()
    {
        if (type == "Weapon")
        {
          
            Equipped = true;
        }
        else if (type == "Key")
        {
            DoorKey = true;   
        }
    }

  
   
}
