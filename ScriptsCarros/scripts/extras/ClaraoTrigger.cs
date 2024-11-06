using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaraoTrigger : MonoBehaviour
{
    public GameObject flash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(flash, transform);
        }
    }
}
