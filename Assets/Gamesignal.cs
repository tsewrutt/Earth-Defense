using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamesignal : MonoBehaviour
{
    public bool win = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
