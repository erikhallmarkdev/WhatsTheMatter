using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class NucleusMover : MonoBehaviour {
  public Nucleus nucleus;
  LineRenderer lr;

  private void Start() {
    lr = GetComponent<LineRenderer>();
    lr.positionCount = 2;
  }

  // Update is called once per frame
  void Update () {
    if(Input.GetMouseButtonDown(0)) {
      RaycastHit2D hit;
      if(hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward)) {
        lr.enabled = true;
        if(hit.transform.GetComponent<Nucleus>()) {
          nucleus = hit.transform.GetComponent<Nucleus>();
          nucleus.mover = this;
        }
      }
    }

    if(nucleus) {

      lr.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition));
      lr.SetPosition(1, nucleus.transform.position);

      Rigidbody2D rb = nucleus.GetComponent<Rigidbody2D>();
      Vector3 dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - nucleus.transform.position;
      rb.AddForce(dist * (dist.magnitude * 0.1f));

      if((Camera.main.transform.position - nucleus.transform.position).magnitude > 5) {
        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, nucleus.transform.position - Vector3.forward, Time.deltaTime * 5);
      } else {
        Camera.main.transform.position = nucleus.transform.position - Vector3.forward;
      }
    }


    if(Input.GetMouseButtonUp(0)) {
      if(nucleus != null) {
        nucleus.mover = null;
        nucleus = null;
      }

      lr.enabled = false;
    }
  }
}
