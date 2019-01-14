using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdStatuses : MonoBehaviour {

    public List<ZoneStatuses> statusList = new List<ZoneStatuses>();
    public ZoneStatuses StatusToUpdate;
    private int listNumber = 0;
    
    // Use this for initialization
	void Start () {
        StatusToUpdate = statusList[0];
	}

    public void ChangeStatusToUpdate()
    {
        listNumber += 1;
        if(listNumber > statusList.Count)
        {   
            listNumber = 0;
        }
        StatusToUpdate = statusList[listNumber];
    }
	

}
