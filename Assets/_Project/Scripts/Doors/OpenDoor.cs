using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IDoors
{
    public bool isOpen;
    public float speed = 1f;

    public Vector3 openPos;
    public Vector3 closePos;

    void Start()
    {
        if (isOpen)
        {
            StartCoroutine(MoveDoor(openPos));
        }        
    }
    public void RequestOpenDoor()
    {
        StartCoroutine(MoveDoor(openPos));
    }
    public void RequestCloseDoor()
    {
        StartCoroutine(MoveDoor(closePos));
    }
    IEnumerator MoveDoor(Vector3 targetDoorPos)
    {
        Vector3 targetPos = new Vector3(targetDoorPos.x, targetDoorPos.y, transform.localPosition.z);
        while (transform.localPosition != targetPos)
        {
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, step);
            yield return null;
        }

    }
}
