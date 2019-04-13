using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int DisksNum { get; set; }

    void Start()
    {
    	DisksNum = 3;
    	DontDestroyOnLoad(this.gameObject);
    }
}
