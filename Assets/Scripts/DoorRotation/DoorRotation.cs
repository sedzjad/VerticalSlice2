using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    public float TimeLeft = 0f;

    public RaycastHit hit;

    public Transform CurrentDoor;

    public bool Open;

    public bool IsOpeningDoor;

    public Transform Cam;

    public LayerMask mask;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && TimeLeft == 0.0f)
        {
            CheckDoor();
        }
        if (IsOpeningDoor)
        {
            OpenAndCloseDoor();
        }
    }

    public void CheckDoor()
    {
        if (Physics.Raycast(Cam.position, Cam.forward, out hit, 5, mask))
        {
            Open = false;
            if (hit.transform.localRotation.eulerAngles.y > 45)
            {
                Open = true;
                IsOpeningDoor = true;
                CurrentDoor = hit.transform;
            }
        }
    }

    public void OpenAndCloseDoor()
    {
        TimeLeft += Time.deltaTime;

        if (Open)
        {
            CurrentDoor.localRotation = Quaternion.Slerp(CurrentDoor.localRotation, Quaternion.Euler(0,0,0),TimeLeft);
        }
        else
        {
            CurrentDoor.localRotation = Quaternion.Slerp(CurrentDoor.localRotation, Quaternion.Euler(0,90,0), TimeLeft);

        }
        if (TimeLeft > 1)
        {
            TimeLeft = 0;
            IsOpeningDoor = false;
        }
    }

}
