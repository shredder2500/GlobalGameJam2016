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

        private SquishController _controller;
        private bool _dead = false;

        public SquishyMovement()
            : this (new SquishController())
            { }

        private SquishyMovement(SquishController controller)
            : base(controller)
        {
            _controller = controller;
            this._onDamage = () =>
            {
                if (!_dead)
                {
                    controller.Stop();
                    GetComponent<Animator>().SetTrigger("Death");
                    Destroy(gameObject, 1);
                    _dead = true;
                }
            };
        }

        protected override void OnStart()
        {
            _controller.SetLeftTarget(_leftTarget.position.x);
            _controller.SetRightTarget(_rightTarget.position.x);
            _controller.SetCurrentPos(transform);
        }
    }
}
