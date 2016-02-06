using GGJ.Timer;
using UnityEngine;

namespace GGJ.Movement
{
    public class PlayerMovement : BaseMovement
    {
        private static Vector3 _position;

        private GameTimer _timer = null;
        [SerializeField]
        private float _damageTimeLose;
        [SerializeField]
        private float _doDamageTimeGain;

        public PlayerMovement()
            : base(new PlayerController())
        { }

        protected override void OnStart()
        {
            transform.position = _position;
            _timer = FindObjectOfType<GameTimer>();

            _onDamage = () => _timer.LoseTime(_damageTimeLose);
            _onDoDamage = () => _timer.GainTime(_doDamageTimeGain);

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
        }

        private void OnDestroy()
        {
            _position = transform.position;
        }
    }
}
