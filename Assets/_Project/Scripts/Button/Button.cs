using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    public Material available;
    public Material active;

    [SerializeField]
    private bool buttonPressed = false;
    
    [SerializeField]
    [Tooltip("This function trigger the button.")]
    private bool debugTrigger = false;

    public UnityEvent Trigger;

    void Start()
    {
        
    }
    void Update()
    {
        if (debugTrigger)
        {
            debugTrigger = false;
            Trigger.Invoke();
        }
    }

    /// <summary>
    ///     This function trigger the button.
    /// </summary>
    
    public void Interact()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            gameObject.GetComponent<Renderer>().material = active;
            StartCoroutine(ButtonAvailable());
            Trigger.Invoke();
        }
    }

    IEnumerator ButtonAvailable()
    {
        yield return new WaitForSeconds(1);
        buttonPressed = false;
        gameObject.GetComponent<Renderer>().material = available;
    }
}
