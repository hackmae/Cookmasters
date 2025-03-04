using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Duration of a full day in seconds.")]
    public float dayDurationInSeconds = 120f;

    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed based on day duration
        // 360 degrees for a full rotation (one day)
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    void Update()
    {
        // Rotate around the x-axis to simulate the sun's movement
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
