using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    [SerializeField] private GameObject[] helixRings=null;
    [SerializeField] private GameObject safeHelixRing=null;

    [SerializeField] private float ringsDistance = 5.0f;
    [SerializeField] private int numberOfRings = 10;

    private float ySpawn = 0;
    private Queue<GameObject> ringQueue = null;
    private int queueSize = 100;
    void Start()
    {
        CreateQueue();
        SpawnSafeRing();
        for (int i = 1; i < numberOfRings; i++)
        {
            SpawnRing();
        }
    }

    private void CreateQueue()
    {
        ringQueue=new Queue<GameObject>();

        for (int i = 0; i < queueSize; i++)
        {
            GameObject ring=Instantiate(helixRings[Random.Range(0,helixRings.Length)],
                                                transform.up * ySpawn, Quaternion.identity);
            ring.transform.SetParent(transform);

            ring.SetActive(false);
            ringQueue.Enqueue(ring);
        }
    }

    private GameObject GetRing()
    {
        int random = Random.Range(0, 5);

        for (int i = 0; i < random; i++)
        {
            var obj = ringQueue.Dequeue();
            ringQueue.Enqueue(obj);
        }

        GameObject ring = ringQueue.Dequeue();
        ring.SetActive(true);

        ringQueue.Enqueue(ring);

        return ring;
    }

    private void SpawnSafeRing()
    {
        GameObject safeRing = Instantiate(safeHelixRing, transform.up * ySpawn, transform.rotation);
        safeRing.transform.SetParent(transform);
        ySpawn -= ringsDistance;
    }
    public void SpawnRing()
    {
        GameObject ring = GetRing();

        ring.transform.position = transform.up * ySpawn;
        ySpawn -= ringsDistance;
    }
}
