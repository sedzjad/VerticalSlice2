using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    public GameObject Parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Parent.GetComponent<LightTargeting>().PlayerInLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Parent.GetComponent<LightTargeting>().PlayerInLight = false;
            Parent.GetComponent<LightTargeting>().Spotlight.color = Parent.GetComponent<LightTargeting>().LightNormal;
        }
    }
}
