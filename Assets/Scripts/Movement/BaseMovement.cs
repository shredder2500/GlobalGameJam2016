using UnityEngine;
using System.Collections;

namespace GGJ.Movement
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer),
        typeof(Collider2D))]
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _jumpAgainTimer;
        [SerializeField]
        private float _groundCheckDistance;
        [SerializeField]
        private LayerMask _groundLayers;

        private Rigidbody2D _rigidbody;
        private Renderer _renderer;
        private bool _canJump = true;

        private readonly IEntityController _controller;

        public BaseMovement(IEntityController controller)
            : base()
        {
            _controller = controller;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();

            _controller.Jump += Jump;
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = new Vector2(velocity.x * _speed,
                _rigidbody.velocity.y + velocity.y);
            _rigidbody.velocity.Set(velocity.x, _rigidbody.velocity.y + velocity.y);
        }

        private void Update()
        {
            _controller.Update();
        }

        private IEnumerator CheckJumpFinished()
        {
            yield return new WaitForEndOfFrame();

            while(!CheckIfGrounded())
            {
                yield return new WaitForEndOfFrame();
            }
            
            StartCoroutine(JumpTimer());
        }

        private void FixedUpdate()
        {
            Walk();
        }

        private void Jump()
        {
            if (CheckIfGrounded()
                && _canJump)
            {
                _canJump = false;
                _rigidbody.AddForce(Vector2.up * _jumpForce);
                StartCoroutine(CheckJumpFinished());
            }
        }

        private IEnumerator JumpTimer()
        {
            yield return new WaitForSeconds(_jumpAgainTimer);
            _canJump = true;
        }

        private void Walk()
        {
            SetVelocity(Vector2.right * _controller.GetMovementAxis());
        }

        private bool CheckIfGrounded()
        {
            return Physics2D.OverlapArea(GetTopLeftGroundCheck(), GetBottomRightGroundCheck(),
                _groundLayers);
        }

        private Vector2 GetTopLeftGroundCheck()
        {
            var pos = transform.position;

            pos.y -= GetExtentsY();
            pos.x -= GetExtentsX();

            return pos;
        }

        private Vector2 GetBottomRightGroundCheck()
        {
            var pos = GetTopLeftGroundCheck();
            pos.x += GetExtentsX() * 2;
            pos.y += _groundCheckDistance;

            return pos;
        }

        private float GetExtentsX()
        {
            return _renderer.bounds.extents.x;
        }

        private float GetExtentsY()
        {
            return _renderer.bounds.extents.x;
        }

        private Vector3 GetGroundCheckCenter()
        {
            var position = GetTopLeftGroundCheck();
            position.x += GetExtentsX();
            position.y -= _groundCheckDistance/2;

            return position;
        }

        private Vector2 GetGroundCheckSize()
        {
            return new Vector2(GetExtentsX() * 2,
                _groundCheckDistance);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(GetGroundCheckCenter(), GetGroundCheckSize());
        }
    }
}