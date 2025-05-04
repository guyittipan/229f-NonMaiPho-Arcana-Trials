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
                Debug.Log("Hit monster type: " + monster.type);
                ScoreManager.instance.AddScore(monster.GetScoreValue());
                GameManager.instance.MonsterKilled();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
