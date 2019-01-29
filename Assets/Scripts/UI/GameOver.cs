using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text Updater;
    // Start is called before the first frame update
    void Start()
    {
        Loser();
    }

    public void Loser()
    {
        Updater.text = "Try Again..";
    }
}
