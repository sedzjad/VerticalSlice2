using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnOff : MonoBehaviour
{

    public GameObject OpenPanel;

    private void Start()
    {
          
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenPanel.SetActive(false);
        }
    }



}
