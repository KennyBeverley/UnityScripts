using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTools
{
    public static Vector3 SetVelocity(Vector3 target, Vector3 origin, float speed)
    {
        return (Vector3.Normalize(target - origin) * speed);
    }

    public static void FaceTarget(Transform objectToRotate, Transform targetObject)
    {
        if(targetObject.position.x > objectToRotate.position.x) //it is to the right
        {
            objectToRotate.eulerAngles = new Vector3(objectToRotate.eulerAngles.x, 0, 0);
        }
        if(targetObject.position.x < objectToRotate.position.x)
        {
            objectToRotate.eulerAngles = new Vector3(objectToRotate.eulerAngles.x, 180, 0);
        }
    }

}
