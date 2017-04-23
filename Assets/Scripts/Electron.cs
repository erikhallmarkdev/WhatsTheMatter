using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Electron : MonoBehaviour {

  public Nucleus nucleus;
  public static List<Electron> allElectrons = new List<Electron>();

  public float OrbitSize = 1;
  private float x, y;
  Rigidbody2D rb;
  CircleCollider2D col;

  void Start() {
    allElectrons.Add(this);

    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<CircleCollider2D>();
    x = Random.Range(1.9f, 2);
    y = Random.Range(1.9f, 2);

    if(nucleus) {
      rb.isKinematic = true;
    } else {
      rb.isKinematic = false;
    }

  }

  public void SetNucleus(Nucleus n, float orbitSize = 2) {
    nucleus = n;
    OrbitSize = orbitSize;
    x = Random.Range(1.5f, 2);
    y = Random.Range(1.5f, 2);
    col.enabled = false;

  }

  private void OnDestroy() {
    allElectrons.Remove(this);
  }

  // Update is called once per frame
  void Update () {

    Vector2 viewPortPos = Camera.main.WorldToViewportPoint(transform.position);

    if((viewPortPos.x > 1 || viewPortPos.x < 0) &&
       (viewPortPos.y > 1 || viewPortPos.y < 0) &&
       nucleus == null){
      allElectrons.Remove(this);
      Destroy(gameObject);
    }


    if(nucleus != null) {
      Vector3 position = new Vector3(Mathf.Sin(Time.time * x), Mathf.Cos(Time.time * y), 1) * OrbitSize;
      transform.position = nucleus.transform.position + position;
      //transform.position = position + nucleus.transform.position;
    } else {


      foreach(Nucleus n in Nucleus.allNuclei) {
        Vector3 dist = transform.position - n.transform.position;
        if(dist.magnitude < 25) {
          rb.AddForce((dist.normalized / dist.magnitude * 100 * n.ElectronCount));
        }
      }


    }



	}
}
