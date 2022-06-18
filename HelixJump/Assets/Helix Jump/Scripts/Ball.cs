using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballJumpForce=5.0f;

    private const string UNSAFETAG = "Unsafe";

    private Rigidbody rigidbody;
    private bool canJump = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (canJump && !GameManager.Instance.gameOver)
        {
            rigidbody.AddForce(ballJumpForce * Vector3.up);
            canJump = false;
        }

        if (other.gameObject.CompareTag(UNSAFETAG))
        {
            GameManager.Instance.gameOver = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        canJump = true;
    }
}
