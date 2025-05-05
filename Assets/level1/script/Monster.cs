using UnityEngine;

public enum MonsterType { Common, Rare }

public class Monster : MonoBehaviour
{
    public MonsterType type = MonsterType.Common;

    public int GetScoreValue()
    {
        return type == MonsterType.Rare ? 5 : 1;
    }
    public float GetMoveSpeed()
{
    return type == MonsterType.Rare ? 3f : 1.5f;
}

}
