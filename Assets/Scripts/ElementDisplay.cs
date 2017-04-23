using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ElementDisplay : MonoBehaviour {

  public Text atomicNumber;
  public Text atomicSymbol;
  public Text atomicName;
  public Text atomicMass;

  public string Number;
  public string Symbol;
  public string Name;
  public string Mass;

  public int num;
  
  public void update() {
    atomicNumber.text = Number;
    atomicSymbol.text = Symbol;
    atomicName.text = Name;
    atomicMass.text = Mass;

  }

  public void Update() {
    int largest = 0;
    foreach(Nucleus n in Nucleus.allNuclei) {
      if(n.ElectronCount > largest) {
        largest = n.ElectronCount;
      }
    }

    Set(largest);
  }

  public void Set(int number) {
    number = Mathf.Clamp(number, 0, Element.elements.Length);

    Element e = Element.get(number);
    Number = number.ToString();
    Symbol = e.symbol;
    Name = e.name;
    Mass = e.atomicMass.ToString();

    if(number == 0) {
      Number = "";
      Symbol = "";
      Name = "";
      Mass = "";
    }

    update();
  }

  private void OnValidate() {
    //update();
    num = Mathf.Clamp(num, 1, Element.elements.Length);
    Set(num);
  }

  private void Start() {
    Set(1);
  }

}
