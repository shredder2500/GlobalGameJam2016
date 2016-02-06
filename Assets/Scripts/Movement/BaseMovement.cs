﻿using UnityEngine;
using System.Collections;
using System;

namespace GGJ.Movement
{
    // TODO(After GameJam): Refactor - Doing to much, should follow single responsablity
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer),
        typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField]
        private float _attackRange;
        [SerializeField]
        private LayerMask _attackMask;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _jumpAgainTimer;
        [SerializeField]
        private Transform _groundCheck_TopLeft;
        [SerializeField]
        private Transform _groundCheck_BotRight;
        [SerializeField]
        private LayerMask _groundLayers;
        [SerializeField]
        private AudioClip _jumpStartSound;
        [SerializeField]
        private AudioClip _playerLightAttackSound;
        [SerializeField]
        private AudioClip _playerLightWalkSound;

        private AudioSource _playerAudio;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private Renderer _renderer;
        private bool _canJump = true;

        private readonly IEntityController _controller;
        protected Action _onDamage;
        protected Action _onDoDamage;

        public BaseMovement(IEntityController controller)
            : base()
        {
            _controller = controller;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _playerAudio = GetComponent<AudioSource>();

            _controller.Jump += OnJump;
            _controller.Attack += OnAttack;

            OnStart();
        }

        protected virtual void OnStart() { }
        
        private void OnAttack()
        {
            _animator.SetTrigger("Attack");
            _playerAudio.PlayOneShot(_playerLightAttackSound);
            var hit = Physics2D.Raycast(transform.position, Vector2.right, _attackRange, _attackMask);

            if (hit.collider)
            {
                var movement = hit.collider.GetComponent<BaseMovement>();
                if (movement)
                {
                    // TODO (post Game Jam): Refactor, kinda smelly 
                    movement._onDamage();
                    this._onDoDamage();
                }
            }
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

            var scale = transform.localScale;
            if(_rigidbody.velocity.x > .1)
            {
                scale.x = 1;
            }
            else if(_rigidbody.velocity.x < -.1)
            {
                scale.x = -1;
            }
            transform.localScale = scale;
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
            _animator.SetFloat("VelocityX", _rigidbody.velocity.x);
            _animator.SetFloat("VelocityY", _rigidbody.velocity.y);
            _animator.SetBool("IsGrounded", CheckIfGrounded());
        }

        private void OnJump()
        {
            if (CheckIfGrounded()
                && _canJump)
            {
                _canJump = false;
                _animator.SetBool("Jump", true);
                StartCoroutine(StartJump());
            }
        }

        private IEnumerator StartJump()
        {
            yield return new WaitForSeconds(.2f);

            _playerAudio.PlayOneShot(_jumpStartSound);
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            StartCoroutine(CheckJumpFinished());
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
            return _groundCheck_TopLeft.position;
        }

        private Vector2 GetBottomRightGroundCheck()
        {
            return _groundCheck_BotRight.position;
        }

        private float GetExtentsX()
        {
            return _renderer.bounds.extents.x;
        }

        private float GetExtentsY()
        {
            return _renderer.bounds.extents.y;
        }

        private Vector3 GetGroundCheckCenter()
        {
            return (GetTopLeftGroundCheck() + GetBottomRightGroundCheck()) / 2;
        }

        private Vector2 GetGroundCheckSize()
        {
            return new Vector2(GetBottomRightGroundCheck().x - GetTopLeftGroundCheck().x,
                GetBottomRightGroundCheck().y - GetTopLeftGroundCheck().y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * _attackRange);
            Gizmos.DrawWireCube(GetGroundCheckCenter(), GetGroundCheckSize());
        }
    }
}