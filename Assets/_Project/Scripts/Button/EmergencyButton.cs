using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyButton : MonoBehaviour
{
    public GameObject emergencyLight;
    public void Activate()
    {
        emergencyLight.SetActive(true);
        StartCoroutine(TurnLightOff());
    }

    IEnumerator TurnLightOff()
    {
        yield return new WaitForSeconds(20);
        emergencyLight.SetActive(false);
        yield return null;
    }
}
