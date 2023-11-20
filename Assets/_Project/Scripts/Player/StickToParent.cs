using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToParent : MonoBehaviour
{
    Transform myTransform;
    Transform newParent;
    void Start()
    {
        //myTransform.parent = newParent;
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.name);
        transform.parent = col.transform;
    }

    void OnCollisionExit(Collision col)
    {
        transform.parent = null;
    }
}
