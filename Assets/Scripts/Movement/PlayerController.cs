using UnityEngine;

namespace GGJ.Movement
{
    public class PlayerController:IEntityController
    {
        public float GetMovementAxis(){
          return _horizontalAxis;
        }
        public event Action Jump;
        public event Action Attack;
        private float _horizontalAxis;
        public void Update(){
          _horizontalAxis = Input.GetAxis("Horizontal");
          if (input.GetAxis("Vertical") >= 0.1f){
            if(Jump != null){
                Jump();
            }
          }
          if(input.GetKey(KeyCode.Space)){
            if(Attack != null){
                Attack();
            }
          }
        }

    }
}
