using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class simplebutton : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isEnabled = false;

    public UnityEvent Trigger;
    void Start()
    {
        Trigger = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            Trigger.Invoke();
            isEnabled = !isEnabled;
        }
    }
}
