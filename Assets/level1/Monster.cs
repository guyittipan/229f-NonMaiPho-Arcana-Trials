using UnityEngine;

public enum MonsterType { Common, Rare }

public class Monster : MonoBehaviour
{
    public MonsterType type = MonsterType.Common;

    public int GetScoreValue()
    {
        return type == MonsterType.Rare ? 5 : 1;
    }
}
