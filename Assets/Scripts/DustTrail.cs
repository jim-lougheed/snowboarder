using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    Rigidbody2D playerBoard;
    [SerializeField] ParticleSystem snowTrail;

    private void Start() {
        playerBoard = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            snowTrail.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            snowTrail.Stop();
        }
    }
}
