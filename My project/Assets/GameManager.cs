using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager get;
    public bool isGame = true;

    private void Awake()
    {
        get = this;
    }
}
