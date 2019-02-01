﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public bool InventoryEnabled;

    public GameObject Inventory;

    private int AllSlots;
    private int EnabledSlots;
    public GameObject SlotHolder;

    public GameObject[] slot;


    void Start()
    {
        AllSlots = 3;
        slot = new GameObject[AllSlots];
        
        for(int i = 0; i< AllSlots; i++)
        {
            slot[i] = SlotHolder.transform.GetChild(i).gameObject;

            if(slot[i].GetComponent<Slot>().Item == null)
            {
                slot[i].GetComponent<Slot>().Empty = true;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnabled = !InventoryEnabled;
        }
        if(InventoryEnabled == true)
        {
            Inventory.SetActive(true);
        } else
        {
            Inventory.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Item")
        {
            GameObject ItemPickedUp = other.gameObject;
            Items item = ItemPickedUp.GetComponent<Items>();

            AddItem(ItemPickedUp, item.ID, item.type, item.description, item.Icon);
        }
    }
    public void AddItem(GameObject ItemObject,int ItemID, string ItemType, string ItemDescription, Sprite ItemIcon)
    {
        for( int i = 0; i < AllSlots; i++)
        {
            
            if (slot[i].GetComponent<Slot>().Empty)
            {
                

                ItemObject.GetComponent<Items>().PickedUp = true;
                slot[i].GetComponent<Slot>().Item = ItemObject;
                slot[i].GetComponent<Slot>().Icon = ItemIcon;
                slot[i].GetComponent<Slot>().type = ItemType;
                slot[i].GetComponent<Slot>().ID = ItemID;
                slot[i].GetComponent<Slot>().description = ItemDescription;

                ItemObject.transform.parent = slot[i].transform;
                ItemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().Empty = false;
            }
            return;
        }
    }
}
