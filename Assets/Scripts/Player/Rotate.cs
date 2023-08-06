using UnityEngine;

namespace Player
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _rotationSpeed;

        private void Update() =>
            transform.RotateAround(_target.position, new Vector3(0f, 0f, 1), _rotationSpeed * Time.deltaTime);
    }
}