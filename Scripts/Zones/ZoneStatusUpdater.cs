using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ZoneStatuses {Outdoors, Indoors}
public class ZoneStatusUpdater : MonoBehaviour {

    public ZoneStatuses zStatus;


	// Use this for initialization
	void Start () {
        zStatus = ZoneStatuses.Outdoors;
		
	}



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZoneBorder")
            if (zStatus == ZoneStatuses.Outdoors)
            {
                zStatus = ZoneStatuses.Indoors;
            } else if (zStatus == ZoneStatuses.Indoors)
            {
                zStatus = ZoneStatuses.Outdoors;
            }



                }


}
