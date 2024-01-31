using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Smacker Settings & References")]
    [SerializeField] private GameObject playerSmacker;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float timerToHit;
    private bool isCreated;

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            timerToHit += Time.deltaTime;
        }
        else if(Input.anyKeyDown)
        {
            timerToHit = 0;
        }

        // Failsafe incase it goes below zero
        if (timerToHit <= 0)
        {
            timerToHit = 0;
        }

        TimerTillSmack();
    }


    public void TimerTillSmack()
    {
        // Checks if the timer is five
        if (timerToHit >= 5 && !isCreated)
        {
            StartCoroutine(CreateSmacker());
        }
    }

    private IEnumerator CreateSmacker()
    {
        Instantiate(playerSmacker, spawnPoint.transform.position, spawnPoint.transform.rotation);
        isCreated = true;

        yield return new WaitForSeconds(3.5f);

        isCreated = false;
    }
}
