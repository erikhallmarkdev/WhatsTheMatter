using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSpawner : MonoBehaviour {

  public GameObject prefab;
  public int count = 10;
  public int max = 10000;

  void Start() {
    Spawn(count);
  }

  private void Update() {
    if(Electron.allElectrons.Count < max && Random.Range(0, 100) < 5) {
      Spawn(count);
    }
  }

  public void Spawn(int count) {
    for(int i = 0; i < count; i++) {
      GameObject GO = Instantiate(prefab);
      GO.transform.position = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), 1);
      GO.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0));
    }
  }

}
