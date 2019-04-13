using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private GameObject[] cursorPositions = new GameObject[3];
    private int currentPos = 0;
    private bool isHolding = false;
    [SerializeField] private Sprite holdSprite;
    [SerializeField] private Sprite pointSprite;
    private SpriteRenderer spriteRenderer;
    Stack<GameObject> heldDisk = new Stack<GameObject>();
    StacksManager stacksManager;

    void MoveLeft()
    {
        int position = (currentPos == 0) ? 2 : currentPos - 1;
        Move(position);
    }

    void MoveRight()
    {
        int position = (currentPos + 1) % 3;
        Move(position);
    }

    public void Move(int position)
    {
        currentPos = position;
        transform.position = cursorPositions[currentPos].transform.position;
        if (heldDisk.Count != 0)
        {
            heldDisk.Peek().transform.position = transform.position;
        }   
    }

    void Hold()
    {
        if (heldDisk.Count == 0 && stacksManager.CanHold(currentPos))
        {
            heldDisk.Push(stacksManager.Hold(currentPos));
            heldDisk.Peek().transform.position = transform.position;
            Rigidbody2D rb = heldDisk.Peek().GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            isHolding = true;
            spriteRenderer.sprite = holdSprite;
        }
    }

    void Drop()
    {
        if (heldDisk.Count == 1
            && stacksManager.CanDrop(currentPos, heldDisk.Peek()))
        {
            stacksManager.Drop(currentPos, heldDisk.Pop());
            spriteRenderer.sprite = pointSprite;
            isHolding = false;
        }
    }

    public void Interact()
    {
        if (isHolding)
        {
            Drop();
        }
        else
        {
            Hold();
        }
    }

    void Start()
    {
        cursorPositions[0] = GameObject.Find("LeftCursorPos");
        cursorPositions[1] = GameObject.Find("CenterCursorPos");
        cursorPositions[2] = GameObject.Find("RightCursorPos");
        transform.position = cursorPositions[currentPos].transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        stacksManager = GameObject.Find("GameManager").GetComponent<StacksManager>();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Interact();
        else if (Input.GetAxis("Horizontal") < 0)
            MoveLeft();
        else if (Input.GetAxis("Horizontal") > 0)
            MoveRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ProcessInput();
        }
    }
}
