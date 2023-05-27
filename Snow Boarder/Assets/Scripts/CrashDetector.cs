using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayScene = 2.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool disableFX = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && disableFX) {
            disableFX = false;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().DisableControl();
            Invoke("ReloadScene", delayScene);
        }
    }
    void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    
}
