using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private HelixManager helixManager;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        helixManager.SpawnRing();
    }
}
