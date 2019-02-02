using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brandon Ruigrok
public class WinOrLose : MonoBehaviour
{

    //Strings with the scene names.
    private string Dead = "GameOver";
    private string Win = "EndGame";

    //Booleans for the win / lose conditions.
    public bool GameOver = false;
    protected bool Winner = false;

    ZoneStatusUpdater Zone;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the ZoneStatuses script
        Zone = GetComponent<ZoneStatusUpdater>();
       
    }



    // Update is called once per frame
    void Update()
    {
        //Win condition
        if (Zone.zStatus == ZoneStatuses.Winner)
        {
            Winner = true;
        }

        if (GameOver == true)
        {
            SceneManager.LoadScene(Dead);
        }

        else if (Winner == true)
        {
            SceneManager.LoadScene(Win);
        }
    }
}
