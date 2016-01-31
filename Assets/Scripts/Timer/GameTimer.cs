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
            LoseTime(Time.deltaTime);

            TimeUpdated.Invoke(1 - (_currentTime / _time));

            if(_currentTime >= _time)
            {
                Elapsed.Invoke();
            }
        }

        internal void GainTime(float doDamageTimeGain)
        {
            _currentTime -= doDamageTimeGain;
            
            if(_currentTime < 0)
            {
                _currentTime = 0;
            }
        }

        internal void LoseTime(float damageTimeLose)
        {
            _currentTime += damageTimeLose;

            if(_currentTime > _time)
            {
                _currentTime = _time;
            }
        }
    }
}
