using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public float movementSpeed = 10;

	// Update is called once per frame
	void Update () {
    transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed));
	}
}
