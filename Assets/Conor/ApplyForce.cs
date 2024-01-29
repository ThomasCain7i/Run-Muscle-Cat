using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Rigidbody[] rb;

    private void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }

    public void ApplyForceToPlayer(float magnitude)
    {
        foreach (Rigidbody rb in rb)
        {
            // Get the current rotation of the object
            Quaternion rotation = transform.rotation;

            // Convert the rotation to a forward vector
            Vector3 forceDirection = rotation * Vector3.forward;

            // Apply force in the direction of the current y rotation
            rb.AddForce(forceDirection * magnitude, ForceMode.Impulse);
        }
    }
}
