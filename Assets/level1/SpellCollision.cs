using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            // 1. ดึงข้อมูล Monster.cs
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                // 2. เพิ่มคะแนน
                ScoreManager.instance.AddScore(monster.GetScoreValue());

                // 3. แจ้ง GameManager ว่ากำจัดไปแล้ว 1 ตัว
                GameManager.instance.MonsterKilled();
            }

            // 4. ทำลายมอนสเตอร์และลูกเวท
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
