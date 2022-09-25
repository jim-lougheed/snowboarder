using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;
    bool hasCrashed = false;
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffectBlood;
    [SerializeField] ParticleSystem crashEffectSnow;
    [SerializeField] AudioClip crashSFX;

    private void Start() {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed) {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffectBlood.Play();
            crashEffectSnow.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
            hasCrashed = true;

        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
