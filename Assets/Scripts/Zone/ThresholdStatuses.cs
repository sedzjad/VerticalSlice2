using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdStatuses : MonoBehaviour {

    public List<ZoneStatuses> statusList = new List<ZoneStatuses>();
    public ZoneStatuses StatusToUpdate;
    private bool listNumber1 = false;
    
    // Use this for initialization
	void Start () {
        StatusToUpdate = statusList[0];
	}

    public void ChangeStatusToUpdate()
    {
        if(listNumber1 == true)
        {
            Debug.Log("Hit");
            StatusToUpdate = statusList[0];
        }else if(listNumber1 == false)
        {
            Debug.Log("Hit2");
            StatusToUpdate = statusList[1];

        }

        listNumber1 = !listNumber1;
    }
	

}
