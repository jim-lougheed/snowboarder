using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;
    [SerializeField] float reloadDelay = 0.5f;

    private void Start() {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider)) {
            Invoke("ReloadScene", reloadDelay);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
