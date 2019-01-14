using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float speed;
	public float rotateSpeed;

	void Update () 
	{
		float xInput = Input.GetAxisRaw ("Horizontal");
		float zInput = Input.GetAxisRaw ("Vertical");

		Vector3 moveDirection = new Vector3 (0, 0, zInput);
		Vector3 rotateDirection = new Vector3 (0, xInput, 0);
		transform.Translate (moveDirection * speed * Time.deltaTime);
		transform.Rotate (rotateDirection * rotateSpeed * Time.deltaTime);
	}
}