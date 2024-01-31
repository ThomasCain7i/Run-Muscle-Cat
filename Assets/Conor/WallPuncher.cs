using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuncher : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(80);

            soundManager.PlayPunch();

        }
    }
}
