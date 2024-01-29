using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawningPos, rot;  // Assuming you use a Transform instead of GameObject for spawning position
    public float projectileSpeed = 10f;
    [SerializeField] float timer, timerNormal;

    [SerializeField] SoundManager soundManager;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        soundManager.PlayCannon();

        // Find the player's position
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the direction from the cannon to the player
            Vector3 direction = (player.transform.position - spawningPos.position).normalized;

            // Rotate the cannon to face the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rot.rotation = targetRotation;

            // Instantiate the projectile at the specified position and rotation
            GameObject projectile = Instantiate(projectilePrefab, spawningPos.position, targetRotation);

            // Apply speed to the projectile (assuming you have a Rigidbody component)
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            if (projectileRb != null)
            {
                projectileRb.velocity = direction * projectileSpeed;
            }
        }
        timer = timerNormal;
    }
}
