using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ZoneStatuses {Outdoors, IndoorsHalls , IndoorsLounge , IndoorsRoom}
public class ZoneStatusUpdater : MonoBehaviour
{

    public ZoneStatuses zStatus;


    // Use this for initialization
    void Start()
    {
        zStatus = ZoneStatuses.IndoorsHalls;

    }



    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ZoneBorder")
        {
            ThresholdStatuses thrHolSta = other.GetComponent<ThresholdStatuses>();
            zStatus = thrHolSta.StatusToUpdate;
            ChangeCamPos(zStatus);
            thrHolSta.ChangeStatusToUpdate();



        }
    }

    public void ChangeCamPos(ZoneStatuses state)
    {
        Transform camera = transform.GetChild(0);
        switch (state)
        {
            case ZoneStatuses.IndoorsRoom:
                camera.transform.localRotation = Quaternion.Euler(15, 0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 0.3f;
                break;
            case ZoneStatuses.IndoorsHalls:
                camera.transform.localRotation = Quaternion.Euler(15, 0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 2;
                
                break;
            case ZoneStatuses.IndoorsLounge:
                camera.transform.localRotation = Quaternion.Euler(15,0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 4;
                
                break;
            case ZoneStatuses.Outdoors:
                camera.transform.localRotation = Quaternion.Euler(30,0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 8;
                
                break;
            
        }
    }

}
