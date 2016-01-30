using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace GGJ.Timer
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField]
        private float _time;
        private float _currentTime;

        public UnityEvent Elapsed;
        public UnityFloatEvent TimeUpdated;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            TimeUpdated.Invoke(1 - (_currentTime / _time));

            if(_currentTime >= _time)
            {
                Elapsed.Invoke();
            }
        }
    }
}
