using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); // ไว้ดูใน Editor
        Application.Quit(); // ใช้ได้เมื่อ build เกมแล้ว
    }
}
