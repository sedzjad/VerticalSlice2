using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnOff : MonoBehaviour
{

    public GameObject OpenPanel;
    public Text textbox;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
