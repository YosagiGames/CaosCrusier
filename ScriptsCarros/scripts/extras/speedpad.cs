using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedpad : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Transform parent = collision.gameObject.transform.parent;
        parent.gameObject.GetComponent<Rigidbody>().AddForce(collision.transform.forward * 1500f, ForceMode.Acceleration);
    }
}
