using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activate Win menu
        }
    }
}
