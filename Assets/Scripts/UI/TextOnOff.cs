using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnOff : MonoBehaviour
{

    public GameObject OpenPanel;
    public Text textbox;
    private float timer = 3;


    public void NoKeyText()
    {
        OpenPanel.SetActive(true);
        textbox.text = "Return and find the key!";
        for (int i = 0; i <timer; i++)
        {
            timer += Time.deltaTime;
            if(timer >= 6)
            {
                OpenPanel.SetActive(false);
            }
        }

    }
        






}
