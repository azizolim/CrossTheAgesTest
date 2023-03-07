using UnityEngine;

namespace Math
{
    public class CircleFollower : MonoBehaviour
    {
        [SerializeField] private float radius = 2.0f;
        [SerializeField] private Transform point;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            // Get the mouse position in world space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0.0f;

            // Calculate the distance between the mouse position and the center of the circle
            float distance = Vector3.Distance(mousePos, _startPosition);

            // If the mouse is outside the circle, clamp it to the circle's perimeter
            if (distance > radius)
            {
                Vector3 direction = mousePos - _startPosition;
                direction.Normalize();
                point.position = _startPosition + direction * radius;
            }
            else
            {
                // Otherwise, move the point to the mouse position
                point.position = mousePos;
            }
        }

        private void OnDrawGizmosSelected()
        {
            // Draw the circle in the Unity Editor
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}