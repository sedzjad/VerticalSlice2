using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdateEndGame : MonoBehaviour
{
    public Text Updater;

    public bool win;

    private void Start()
    {
        Winner();
    }

    public void Winner()
    {
        Updater.text = "You are victorious";
    }



}
