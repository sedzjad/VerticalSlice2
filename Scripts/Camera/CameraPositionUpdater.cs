using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPositionUpdater : MonoBehaviour
{
    public CameraPositions positions;

    // Use this for initialization
    void Start()
    {
        positions = GetComponent<CameraPositions>();

        transform.localPosition = positions.camPosPly;

    }

    public void SetCameraToPlay()
    {
        transform.localPosition = positions.camPosPly;
    }
    public void SetCameraToInteraction(int positionNumber)
    {

        transform.localPosition = positions.camPosCon[positionNumber];


        transform.LookAt(transform.parent);
        Vector3 posRot = transform.localRotation.eulerAngles;

        posRot.x = 0;
        transform.localRotation = Quaternion.Euler(posRot);


    }
    public void SetCameraToCinematic(int positionNumber)
    {
        transform.localPosition = positions.camPosCin[positionNumber];
    }



}