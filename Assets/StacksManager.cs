using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacksManager : MonoBehaviour
{
    Stack<GameObject>[] stacks = new Stack<GameObject>[3];
    int disksNum = 0;
    [SerializeField] private GameObject diskPrefab;
    float verticalDiskSpace = 2.0f;
    private GameObject startingPosition;

    void Start()
    {
        for (int i = 0 ; i < 3 ; i++)
        {
            stacks[i] = new Stack<GameObject>();
        }
        startingPosition = GameObject.Find("LeftBasePos");
    }

    public void Initialize(int N)
    {
        disksNum = N;
        for (int i = 0 ; i < disksNum ; i++)
        {
            Vector3 temp = startingPosition.transform.position;
            temp.y += (i * verticalDiskSpace);
            
            GameObject disk =
                Instantiate(diskPrefab, temp, Quaternion.identity);

            disk.GetComponent<DiskBehavior>().Value = disksNum - 1 - i;
            stacks[0].Push(disk);
        }
        Destroy(diskPrefab);
    }

    public bool CanHold(int cursorPos)
    {
        return stacks[cursorPos].Count != 0;
    }

    public bool CanDrop(int cursorPos, GameObject disk)
    {
        if (stacks[cursorPos].Count == 0)
            return true;

        int diskValue = disk.GetComponent<DiskBehavior>().Value;
        int topDiskValue = stacks[cursorPos].Peek().GetComponent<DiskBehavior>().Value;
        return topDiskValue > diskValue;
    }

    public GameObject Hold(int cursorPos)
    {
        stacks[cursorPos].Peek().GetComponent<AudioSource>().Play();
        return stacks[cursorPos].Pop();
    }

    public void Drop(int cursorPos, GameObject disk)
    {
        disk.GetComponent<Rigidbody2D>().isKinematic = false;
        stacks[cursorPos].Push(disk);
    }

    public bool isFinished()
    {
        for (int i = 1 ; i < 3 ; i++)
        {
            if (stacks[i].Count == disksNum)
            {
                return true;
            }
        }
        return false;
    }
}
