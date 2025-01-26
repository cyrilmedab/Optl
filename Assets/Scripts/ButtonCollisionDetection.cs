using UnityEngine;
using UnityEngine.Events;

public class ButtonCollisionDetection : MonoBehaviour
{
    // UnityEvent that can be assigned from the Inspector
    [System.Serializable]
    public class CollisionEvent : UnityEvent<GameObject> { }

    // Event that gets triggered on collision
    public CollisionEvent OnCollisionEnterEvent;
    private bool hasCollided = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!hasCollided) {
            Debug.Log("Button Worked");
            hasCollided = true;
            OnCollisionEnterEvent.Invoke(collision.gameObject);
        }
        // Trigger the event, passing the collided object as a parameter
  
    }
}
