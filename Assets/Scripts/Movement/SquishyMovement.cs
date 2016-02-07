using GGJ.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GGJ.Movement
{
    public class SquishyMovement : BaseMovement
    {
        
        [SerializeField]
        private Transform _leftTarget;

        [SerializeField]
        private Transform _rightTarget;
        
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _attackSound, _deathSound, _walkSound;

        private SquishController _controller;

        public SquishyMovement()
            : this (new SquishController())
            { }

        private SquishyMovement(SquishController controller)
            : base(controller)
        {
            _controller = controller;
            this._onDamage = () =>
            {
                controller.Stop();
                GetComponent<Animator>().SetTrigger("Death");
                _audioSource.clip = _deathSound;
                _audioSource.Play();
                this.tag = "Dead";
                Destroy(gameObject, 1);
            };
        }

        protected override void OnStart()
        {
            _controller.SetLeftTarget(_leftTarget.position.x);
            _controller.SetRightTarget(_rightTarget.position.x);
            _controller.SetCurrentPos(transform);
            _audioSource = this.gameObject.AddComponent<AudioSource>();
        }


    }
}
