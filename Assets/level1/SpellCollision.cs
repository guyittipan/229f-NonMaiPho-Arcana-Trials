using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                ScoreManager.instance.AddScore(monster.GetScoreValue());
                GameManager.instance.MonsterKilled();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
