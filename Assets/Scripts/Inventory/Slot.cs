using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject Item;
    public Transform SlotIconGO;

    public string type;
    public string description;
    public int ID;

    public bool Empty;
    
    public Sprite Icon;


    private void Start()
    {
       SlotIconGO = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        SlotIconGO.GetComponent<Image>().sprite = Icon;
    }

    public void UseItem()
    {

    }
}
