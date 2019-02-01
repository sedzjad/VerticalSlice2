using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour {
	public List<Vector3> camPosCon = new List<Vector3>();
	public List<Vector3> camPosCin = new List<Vector3>();
	public Vector3 camPosPly = new Vector3 (0,2,-5);
	// Use this for initialization
	void Start () {
		for(int i = 0; i < camPosCon.Count; i++){
			GameObject camPos =  new GameObject();
			camPos.transform.parent = gameObject.transform.parent;
            Debug.Log("CameraPositionFound");

			camPos.transform.localPosition = new Vector3 (camPosCon [i].x, camPosCon[i].y, camPosCon[i].z);
	}

    }

    // Update is called once per frame

}


