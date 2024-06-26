using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollOnOff : MonoBehaviour
{
    public CapsuleCollider mainCoillider;
    public GameObject characterRig;
    public Animator characterAnimator;
    public vThirdPersonInput input;
    public vThirdPersonCamera cameraScript;
    public Camera mainCamera;
    public Camera ragdollCamera;

    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
        input = GetComponent<vThirdPersonInput>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            RagdollModeOn();
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;

    void GetRagdollBits()
    {
        ragdollColliders = characterRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = characterRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        characterAnimator.enabled = false;
        input.enabled = false;
        mainCamera.enabled = false;
        cameraScript.enabled = false;
        ragdollCamera.enabled = true;

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        
        mainCoillider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff()
    {
        input.enabled = true;

        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }

        foreach(Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        characterAnimator.enabled = true;
        mainCoillider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
