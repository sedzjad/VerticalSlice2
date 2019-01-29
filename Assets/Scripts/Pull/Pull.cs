using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    GameObject Object;
    Rigidbody rb;

    private bool Pullable = false;
    private bool Pulling = false;



    public float pullForce = 0;


    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pullable")
        {
            Pullable = true;
            Object = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pullable")
        {
            Pullable = false;
            Object = null;
        }
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        PullObject();
    }

    private void PullObject()
    {
        if (Pullable && Input.GetButton("Interact"))
        {   
            Pulling = true;
        }
        else
        {
            Pulling = false;
        }

        if (Pulling)
        {
          
          CalculateNewPos();

        }
    }

    private void CalculateNewPos()
    {
        Vector3 ObjectPos = Object.transform.position;

        Vector3 forceDirection = ObjectPos - transform.position;
        rb = Object.GetComponent<Rigidbody>();
        Object.transform.LookAt(transform.position);

        rb.AddRelativeForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime, ForceMode.Force);
        Debug.Log("kaas");
    }
}
