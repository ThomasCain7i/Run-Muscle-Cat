using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSmacker : MonoBehaviour
{
    [Header("Normal References")]
    public GameObject playerSmacker;
    public Rigidbody playerRBody;
    public Animator animator;

    [Header("Material References")]
    public Material normalMaterial;
    public Material invisibleMaterial;

    [Header("Script References")]
    public ApplyForce applyForce;
    public SoundManager soundManager;

    [Header("Settings")]
    public float speed = 50;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();

        StartPlayerSmack();
    }

    public void StartPlayerSmack()
    {
        StartCoroutine(StartSmack());
    }

    private IEnumerator StartSmack()
    {
        // Starts the smacking animation
        animator.SetBool("isSmacking", true);

        // Wait
        yield return new WaitForSeconds(3);

        // Resets The Settigs
        animator.SetBool("isSmacking", false);

        Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(100);

            soundManager.PlaySlap();

            Destroy(gameObject);
        }
    }

    /*
    private IEnumerator SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;

        yield return new WaitForSeconds(1.59f);

        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
    }
    */
}
