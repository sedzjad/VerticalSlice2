using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ZoneStatuses {OutdoorsGravel, OutdoorsGrass, IndoorsHalls , IndoorsLounge , IndoorsRoom, Winner}
public class ZoneStatusUpdater : MonoBehaviour
{

    public ZoneStatuses zStatus;

    //CameraCollision cam;

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
        //Gets the camera on the player object. The number after GetChild stands for the hierarchy number.
        Transform camera = transform.GetChild(0);
        switch (state)
        {
            case ZoneStatuses.IndoorsRoom:
                camera.transform.localRotation = Quaternion.Euler(15, 0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = -0.02f;
               
                break;
            case ZoneStatuses.IndoorsHalls:
                camera.transform.localRotation = Quaternion.Euler(15, 0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 0.07f;
               
                break;
            case ZoneStatuses.IndoorsLounge:
                camera.transform.localRotation = Quaternion.Euler(15,0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 0.1f;
                
                break;
            case ZoneStatuses.OutdoorsGravel:
                camera.transform.localRotation = Quaternion.Euler(30,0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 0.12f;
                
                break;
            case ZoneStatuses.OutdoorsGrass:
                camera.transform.localRotation = Quaternion.Euler(30, 0, 0);
                camera.GetComponent<CameraCollision>().maxDistance = 0.12f;

                break;

        }
    }

}
