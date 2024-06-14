using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpportal : MonoBehaviour
{
    public GameObject persona;

    Vector3 tpLocation = new Vector3(3227.7f, -12.5f, 79.583f);
 
    private void OnTriggerEnter(Collider other)
    {
        CharacterController cc = persona.GetComponent<CharacterController>();

        cc.enabled = false;
        persona.transform.position = tpLocation;
        cc.enabled = true;
    }
}
