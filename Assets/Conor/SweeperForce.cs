using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperForce : MonoBehaviour
{
    public ApplyForce applyForce;

    private void Start()
    {
        applyForce = FindObjectOfType<ApplyForce>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(55);
        }
    }
}
