using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private int position;
    private CursorManager cursorManager;
    void Start()
    {
        cursorManager =
            GameObject.Find("Cursor").GetComponent<CursorManager>();
    }

    void OnMouseEnter()
    {
        cursorManager.Move(position);
    }

    void OnMouseUpAsButton()
    {
        cursorManager.Move(position);
        cursorManager.Interact();
    }
}
