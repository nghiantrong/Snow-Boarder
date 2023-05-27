using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float delayScene = 2.5f;
  [SerializeField] ParticleSystem finishLine;
  bool disableFX = true;
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player" && disableFX){
      disableFX = false;
      finishLine.Play();
      GetComponent<AudioSource>().Play();
      Invoke("ReloadScene", delayScene);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
