using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]private GameObject currentCursor;
    [SerializeField] private List<GameObject> cursors;
    private Vector2 cursorPos;
    private GameObject instantiatedCursor;

    private void Start()
    {
        if(currentCursor != null)
        {
            Cursor.visible = false;
            instantiatedCursor = Instantiate(currentCursor);
        }
        
    }

    private void Update()
    {
        if(currentCursor != null)
        {
            
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            instantiatedCursor.transform.position = cursorPos;
        }       
    }

    public void SetCursor(int index)
    {
        if(index < cursors.Count)
            currentCursor = cursors[index];
    }



}
