using UnityEngine;
using System;

namespace GGJ.Movement
{
    public class PlayerController : IEntityController
    {
        private float _horizontalAxis;

        public event Action Attack;
        public event Action Jump;

        public float GetMovementAxis()
        {
            return _horizontalAxis;
        }

        public void GetHorizontalAxis()
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
        }

        private void GetJumpAction()
        {
            if (Input.GetAxis("Vertical") >= 0.1f)
            {
                if (Jump != null)
                {
                    Jump();
                }
            }
        }

        private void GetAttackAction()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Attack != null)
                {
                    Attack();
                }
            }
        }

        public void Update()
        {
            GetHorizontalAxis();
            GetJumpAction();
            GetAttackAction();
        }

    }
}
