using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public ApplyForce applyForce;
    public SoundManager soundManager;

    private void Start()
    {
        applyForce = FindObjectOfType<ApplyForce>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(80);

            soundManager.PlayBananaSlip();

            Destroy(gameObject);
        }
    }
}
