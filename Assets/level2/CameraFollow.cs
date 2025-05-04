using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 2f;
    public float yOffset = 1.5f;

    private float lowestY;

    void Start()
    {
        if (player != null)
            lowestY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float targetY = player.position.y + yOffset;

        // กล้องจะเลื่อนเฉพาะเมื่อ Player กระโดดสูงขึ้นเท่านั้น (ไม่เลื่อนลง)
        if (targetY > lowestY)
        {
            Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
            lowestY = transform.position.y;
        }
    }
}
