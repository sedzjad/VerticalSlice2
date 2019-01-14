using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMainHall : MonoBehaviour {

    Light MainLight;
    public float MinWaitTime;
    public float MaxWaitTime;

    private void Start()
    {
        MainLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWaitTime,MaxWaitTime));
            MainLight.enabled = !MainLight.enabled;
        }
    }
}

