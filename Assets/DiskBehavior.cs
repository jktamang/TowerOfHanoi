using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskBehavior : MonoBehaviour
{
    [SerializeField] private Sprite disk1Sprite;
    [SerializeField] private Sprite disk2Sprite;
    [SerializeField] private Sprite disk3Sprite;
    [SerializeField] private Sprite disk4Sprite;
    [SerializeField] private Sprite disk5Sprite;
    [SerializeField] private Sprite disk6Sprite;
    private Sprite[] diskSprites = new Sprite[6];

    public int Value { get; set; }

    void Start()
    {
        diskSprites[0] = disk1Sprite;
        diskSprites[1] = disk2Sprite;
        diskSprites[2] = disk3Sprite;
        diskSprites[3] = disk4Sprite;
        diskSprites[4] = disk5Sprite;
        diskSprites[5] = disk6Sprite;
        GetComponent<SpriteRenderer>().sprite = diskSprites[Value];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<AudioSource>().Play();
    }
}
