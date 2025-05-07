using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private static BGMPlayer instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // ถ้ามีแล้ว ไม่ต้องสร้างอีก
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ไม่ให้ถูกทำลายตอนเปลี่ยน Scene
    }
}
