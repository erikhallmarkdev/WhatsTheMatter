using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleusSpawner : MonoBehaviour {

  public GameObject GO;
  public int count;
 int max;

  private void Start() {
    Spawn(count);
  }

  void Update() {

    max = Nucleus.allNuclei.Count * 2;


    if(Nucleus.allNuclei.Count > max) {
      for(int i = 0; i < count; i++) {
        float x = Random.Range(-count * 10, count * 10),
              y = Random.Range(-count * 10, count * 10);

        GameObject g = Instantiate(GO);
        g.transform.position = new Vector2(x, y);
        g.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));

      }
    }
  }

  public void Spawn(int count) {
    for(int i = 0; i < count; i++) {
      float x = Random.Range(-count * 10, count * 10),
            y = Random.Range(-count * 10, count * 10);

      GameObject g = Instantiate(GO);
      g.transform.position = new Vector2(x, y);
      g.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
      
    }
  }
}
