using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity2D : MonoBehaviour {

  public Transform gravityPoint;
  public float mass = 10;
  Rigidbody2D rb;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody2D>();
    rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
    Vector2 grav = gravityPoint.position - transform.position;
    rb.AddForce(grav.normalized * (50 * rb.mass) / grav.SqrMagnitude(), ForceMode2D.Force);

	}
}
