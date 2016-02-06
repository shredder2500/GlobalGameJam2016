using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GGJ.Movement
{
    public class SquishController : IEntityController
    {
        public event Action Attack;
        public event Action Jump;

        private float _leftX;
        private float _rightX;
        private Transform _currentPos;
        private bool _goLeft;
        private float _input;
        private bool _stoped = false;

        public void SetLeftTarget(float x)
        {
            _leftX = x;
        }

        public void SetRightTarget(float x)
        {
            _rightX = x;
        }

        public void SetCurrentPos(Transform x)
        {
            _currentPos = x;
        }

        public float GetMovementAxis()
        {
            return _input;
        }

        public void Stop()
        {
            _stoped = true;
        }

        public void Update()
        {
            if(_stoped)
            {
                _input = 0;
            }
            else if (_goLeft && _currentPos.position.x > _leftX)
            {
                _input = -1;
            }
            else if(_goLeft && _currentPos.position.x <= _leftX)
            {
                _goLeft = false;
            }
            else if(_currentPos.position.x < _rightX)
            {
                _input = 1;
            }
            else
            {
                _goLeft = true;
            }
        }
    }
}
