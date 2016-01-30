using UnityEngine;
using System.Collections;

namespace GGJ.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity * _speed;
        }
    }
}