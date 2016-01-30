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

        private readonly IEntityController _controller;

        public Entity(IEntityController controller)
            : base()
        {
            _controller = controller;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity * _speed;
        }

        private void Update()
        {
            _controller.Update();
        }

        private void FixedUpdate()
        {
            SetVelocity(Vector2.right * _controller.GetMovementAxis());
        }
    }
}