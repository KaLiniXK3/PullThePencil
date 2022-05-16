using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
