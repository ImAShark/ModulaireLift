using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactLayer;

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, interactRange, interactLayer))
            {
                IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
