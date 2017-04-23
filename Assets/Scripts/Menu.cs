using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

  public bool ShowMenu = false;
  public Image menuBackground;

  private void Update() {
    menuBackground.gameObject.SetActive(ShowMenu);

    if(Input.GetKeyDown(KeyCode.Escape)) {
      ShowMenu = !ShowMenu;
    }

  }

  public void Reset() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void QuitGame() {
    Application.Quit();
  }
}
