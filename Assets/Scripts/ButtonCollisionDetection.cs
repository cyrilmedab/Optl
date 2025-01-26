using UnityEngine;
using UnityEngine.Events;

public class ButtonCollisionDetection : MonoBehaviour
{
    [System.Serializable]
    public class CollisionEvent : UnityEvent<GameObject> { }

    public CollisionEvent OnCollisionEnterEvent;
    private bool hasCollided = false;
    private bool isInitialized = false;

    private void Start()
    {
        // Delay to let the colliders settle
        Invoke("EnableCollisionDetection", 0.5f); // Delay collision detection for 0.5 seconds
    }

    private void EnableCollisionDetection()
    {
        isInitialized = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isInitialized && !hasCollided) // Only trigger after initialization
        {
            Debug.Log($"Trigger entered by: {collision.gameObject.name}");
            hasCollided = true;
            OnCollisionEnterEvent.Invoke(collision.gameObject);
            Debug.Log("Button Worked");
        }
    }
}
