using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;         // The position from which the projectile will be fired
    [SerializeField] Rigidbody2D bulletPrefab;     // Prefab of the magic projectile
    [SerializeField] float flightTime = 1f;        // Time it takes for the projectile to reach the target
    [SerializeField] float cooldown = 1f;          // Time delay between each shot (cooldown in seconds)

    private float lastShotTime = -Mathf.Infinity;  // Time of the last shot fired

    void Update()
    {
        // Check for left mouse click and cooldown
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShotTime + cooldown)
        {
            // Convert mouse position to world coordinates
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            // Calculate velocity needed to reach target in flightTime
            Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, mouseWorldPos, flightTime);

            // Instantiate the bullet and set its velocity
            Rigidbody2D bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.linearVelocity = velocity;

            // Update the time of the last shot
            lastShotTime = Time.time;
        }
    }

    // Function to calculate initial velocity based on desired flight time
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        // Horizontal velocity = distance.x / time
        float vx = distance.x / time;

        // Vertical velocity = distance.y / time + (gravity * time) / 2
        float vy = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(vx, vy);
    }
}
