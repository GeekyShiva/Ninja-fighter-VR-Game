using UnityEngine;
using System.Collections;

public class CardboardSwapper : MonoBehaviour {
 
  public GameObject[] cardboardObjects;
  public GameObject[] monoObjects;
 
  // Turn on or off VR mode
  void ActivateVRMode(bool goToVR) {
    foreach (GameObject cardboardThing in cardboardObjects) {
        cardboardThing.SetActive(goToVR);
    }
    foreach (GameObject monoThing in monoObjects) {
        monoThing.SetActive(!goToVR);
    }
    GvrViewer.Instance.VRModeEnabled = goToVR;
 
    // Tell the game over screen to redisplay itself if necessary
    gameObject.GetComponent<GameController>().RefreshGameOver();
  }
 
  public void Switch() {
		ActivateVRMode(!GvrViewer.Instance.VRModeEnabled);
  }
 
  void Update () {
		if (GvrViewer.Instance.BackButtonPressed) {
      Switch();
    }
  }
 
  void Start() {
    ActivateVRMode(false);
  }
}