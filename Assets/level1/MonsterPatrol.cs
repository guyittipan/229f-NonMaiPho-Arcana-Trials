using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    public float moveDistance = 3f; // ระยะที่เดินจากจุดเริ่ม
    private Vector3 startPos;
    private float moveSpeed;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;

        // รับความเร็วจาก Monster.cs
        Monster monster = GetComponent<Monster>();
        if (monster != null)
        {
            moveSpeed = monster.GetMoveSpeed();
        }
        else
        {
            moveSpeed = 2f; // fallback speed
        }
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}
