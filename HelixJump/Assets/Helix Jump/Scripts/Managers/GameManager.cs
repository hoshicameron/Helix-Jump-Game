using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; set; }
    private void Awake()
    {
        if (Instance !=null && Instance!=this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    public bool gameOver = false;
    public bool levelCompleted = false;

    private void Update()
    {
        if (gameOver)
        {
            //Todo Show gameOver popup
            //
        }
    }
}
