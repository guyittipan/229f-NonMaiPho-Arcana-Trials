using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;         // ตำแหน่งยิง
    [SerializeField] Rigidbody2D bulletPrefab;     // พรีแฟบของเวทมนตร์
    [SerializeField] float flightTime = 1f;        // ระยะเวลาที่ต้องการให้ลูกเวทถึงเป้าหมาย

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, mouseWorldPos, flightTime);

            Rigidbody2D bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.linearVelocity = velocity;
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float vx = distance.x / time;
        float vy = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(vx, vy);
    }
}
