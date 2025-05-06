using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 180f; // Degrees per second

    void Update()
    {
        // Rotate around Z axis (2D rotation)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
