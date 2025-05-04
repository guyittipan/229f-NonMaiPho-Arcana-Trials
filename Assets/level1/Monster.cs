using UnityEngine;

public enum MonsterType { Common, Rare }

public class Monster : MonoBehaviour
{
    public MonsterType type = MonsterType.Common;

    // กำหนดความเร็วเคลื่อนที่ให้มอนสเตอร์ตามประเภท
    public float GetMoveSpeed()
    {
        if (type == MonsterType.Rare)
            return 3.5f; // เร็วกว่า
        else
            return 2f; // ธรรมดา
    }

    // คืนค่าคะแนนเมื่อถูกยิง
    public int GetScoreValue()
    {
        if (type == MonsterType.Rare)
            return 5; // แต้มเยอะ
        else
            return 1; // แต้มธรรมดา
    }
}
