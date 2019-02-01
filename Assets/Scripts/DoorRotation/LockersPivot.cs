using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockersPivot : MonoBehaviour
{
    public float Speed;
    public bool DoorOpen;
    public bool HasToClose;
    


    public void Update()
    {
        if(HasToClose == true)
        {
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Slerp(transform.GetChild(0).rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
            
        }
    }

    public void OnCollisionStay(Collision obj)
    {
            DoorOpen = true;
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Slerp(transform.GetChild(0).rotation, Quaternion.Euler(0, -220, 0), Speed * Time.deltaTime);   
    }
    private void OnCollisionExit(Collision obj)
    {
        gameObject.transform.GetChild(0).transform.rotation = Quaternion.Slerp(transform.GetChild(0).rotation, Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
        HasToClose = false;
    }
}
