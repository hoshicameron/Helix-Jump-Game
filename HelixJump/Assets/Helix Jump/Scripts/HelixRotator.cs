using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 90f;
    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotateTower(1);
        }

        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotateTower(-1);
        }
    }

    private void RotateTower(float rotateFactor)
    {
        transform.RotateAround(transform.position, transform.up, rotateSpeed * Time.deltaTime * rotateFactor);
    }
}
