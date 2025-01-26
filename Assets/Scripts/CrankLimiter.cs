using UnityEngine;

public class CrankLimiter : MonoBehaviour
{
    public float minRotation = 0f;    // Minimum rotation (degrees)
    public float maxRotation = 45f;  // Maximum rotation (degrees)
    public Transform crankHandle;    // Reference to the crank's transform

    public delegate void CrankTurnedEvent();
    public event CrankTurnedEvent OnCrankFullyTurned;

    private float currentRotation;

    private void Update()
    {
        // Clamp the crank's rotation
        currentRotation = Mathf.Clamp(crankHandle.localEulerAngles.x, minRotation, maxRotation);
        crankHandle.localEulerAngles = new Vector3(currentRotation, 0f, 0f);

        // Trigger event when crank is fully turned
        if (Mathf.Approximately(currentRotation, maxRotation))
        {
            OnCrankFullyTurned?.Invoke();
        }
    }
}