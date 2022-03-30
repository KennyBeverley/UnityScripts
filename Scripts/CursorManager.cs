using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]private GameObject currentCursor;
    [SerializeField] private List<GameObject> cursors;
    public List<CursorObjects> objectsToFaceCursor;

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
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (currentCursor != null)
        {                        
            instantiatedCursor.transform.position = cursorPos;
        }

        if(objectsToFaceCursor.Count > 0)        
            FaceCursor();
    }

    public void SetCursor(int index)
    {
        if(index < cursors.Count)
            currentCursor = cursors[index];
    }

    private void FaceCursor()
    {
        foreach(var val in objectsToFaceCursor)
        {
            if(val.gameObject != null)
            {
                switch (val.howToFlip)
                {
                    case WaysToFlip.none:
                        break;
                    case WaysToFlip.xOnly:
                        FlipOnAxis(Axis.x, val.gameObject);
                        break;
                    case WaysToFlip.yOnly:
                        FlipOnAxis(Axis.y, val.gameObject);
                        break;
                }

                if (val.rotateTowardsCursor)
                    FaceTarget(val.gameObject);
                
            }
            
        }
    }
    private void FaceTarget(GameObject gameObject)
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(gameObject.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FlipOnAxis(Axis axis, GameObject objectToRotate)
    {
        switch (axis)
        {
            case Axis.x:
                if (cursorPos.y > objectToRotate.transform.position.y)
                {
                    objectToRotate.transform.eulerAngles = new Vector3(180, objectToRotate.transform.eulerAngles.y, 0);
                }
                else
                {
                    objectToRotate.transform.eulerAngles = new Vector3(0, objectToRotate.transform.eulerAngles.y, 0);
                }

                break;
            case Axis.y:
                if (cursorPos.x > objectToRotate.transform.position.x)
                {
                    objectToRotate.transform.eulerAngles = new Vector3(objectToRotate.transform.eulerAngles.x, 0, 0);
                }
                else
                {
                    objectToRotate.transform.eulerAngles = new Vector3(objectToRotate.transform.eulerAngles.x, 180, 0);
                }
                break;
        }
    }


}

public enum Axis { x, y}
public enum WaysToFlip { none, xOnly, yOnly}

[System.Serializable]
public class CursorObjects
{
    public GameObject gameObject;
    public WaysToFlip howToFlip;
    public bool rotateTowardsCursor;
}
