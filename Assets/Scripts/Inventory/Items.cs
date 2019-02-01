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
    public GameObject ItemManager;

    public bool PlayersWeapon;



    public void Start()
    {
        Equipped = false;

        ItemManager = GameObject.FindWithTag("ItemManager");
        Weapon = GameObject.FindWithTag("Item");
        

    }

    private void Update()
    {
        if (!PlayersWeapon)
        {
            int allWeapons = ItemManager.transform.childCount;

            for (int i = 0; i < allWeapons; i++)
            {
                if (ItemManager.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Weapon = ItemManager.transform.GetChild(i).gameObject;
                }
            }
        }
        ItemUsage();
        if (Equipped)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Equipped = false;
                if(Equipped == false)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ItemUsage()
    {
        
        if (PickedUp == true)
        {        
                Equipped = true;
            
        }
    }

  
   
}
