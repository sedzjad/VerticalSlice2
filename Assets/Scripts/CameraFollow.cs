using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float cameraSpeed = 120f;
    public GameObject camera;
    Vector3 Followpos;
    public float clampAngle = 80f;
    public float inputSensetivity = 150f;
    public GameObject cameraObj;
    public GameObject playObj;
    public float camDIstanceXTOPlayer;
    public float camDIstanceYTOPlayer;
    public float camDIstanceZTOPlayer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
