using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Nucleus : MonoBehaviour {

  public static List<Nucleus> allNuclei = new List<Nucleus>();
  public bool isDead = false;
  public NucleusMover mover;
  //public Nucleus replacement;

  public int ElectronCount { get { return electrons.Count; } }
  Collider2D coll;

  public List<Electron> electrons = new List<Electron>();
  Rigidbody2D rb;
  CircleCollider2D col;
  SpriteRenderer sr;

	// Use this for initialization
	void Start () {
    col = GetComponent<CircleCollider2D>();
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
    allNuclei.Add(this);
	}
	
	// Update is called once per frame
	void Update () {

    foreach(Nucleus n in allNuclei) {
      Vector3 dist = transform.position - n.transform.position;
      if(dist.magnitude < 25) {
        rb.AddForce((dist.normalized * ElectronCount * n.ElectronCount)  * 0.75f);

      }
    }

    //sr.color = new Color(255 - ElectronCount * 2.5f * (255/1), 255 - ElectronCount * 1.58f * (255 / 1), 220 - ElectronCount * 2 * (255 / 1));
    sr.color = Color.white / (ElectronCount * 0.01f);
  }

  private void OnDestroy() {
    allNuclei.Remove(this);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.GetComponent<Electron>() && !other.GetComponent<Electron>().nucleus && ElectronCount < Element.elements.Length) {
      Electron e = other.GetComponent<Electron>();
      electrons.Add(e);
      e.SetNucleus(this, electrons.Count * 0.25f + 1.5f);
      rb.drag = ElectronCount  * 0.5f;
      //col.radius = electrons.Count / 12.5f + 0.1f;
    }

    if(other.GetComponent<Nucleus>()) {
      Nucleus n = other.GetComponent<Nucleus>();

      if(ElectronCount >= 1 && n.ElectronCount >= 1 && ElectronCount + n.ElectronCount < Element.elements.Length && !isDead) {
        allNuclei.Remove(n);
        foreach(Electron e in n.electrons) {
          electrons.Add(e);
          e.SetNucleus(this, electrons.Count * 0.25f + 1.5f);
          rb.drag = ElectronCount * 0.5f;
        }

        n.electrons.Clear();

        if(n.mover != null) {
          n.mover.nucleus = this;
        }

        n.enabled = false;
        n.isDead = true;
        Destroy(n.gameObject);

      }
    }
  }
}
