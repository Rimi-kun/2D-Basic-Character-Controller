using UnityEngine;

namespace Player
{
    public class MovementController
    {
        private readonly PlayerMovementParams _parameters;

        public MovementController(PlayerMovementParams parameters) => _parameters = parameters;

        /// <summary>
        /// ������������ ������.
        /// </summary>
        public void Move(Vector2 direction)
        {
            var velocity = new Vector2(direction.x * _parameters.MoveSpeed, _parameters.Rigidbody.velocity.y);
            _parameters.Rigidbody.velocity = velocity;
        }

        /// <summary>
        /// ������ ������.
        /// </summary>
        public void Jump()
        {
            _parameters.Rigidbody.velocity = new Vector2(_parameters.Rigidbody.velocity.x, _parameters.JumpForce);
        }

        /// <summary>
        /// ������������ ������.
        /// </summary>
        public void Glide()
        {
            float glideVelocity = Mathf.Lerp(_parameters.Rigidbody.velocity.y, -_parameters.GlideSpeed, Time.fixedDeltaTime * _parameters.GlideSmoothness);
            _parameters.Rigidbody.velocity = new Vector2(_parameters.Rigidbody.velocity.x, glideVelocity);
        }
    }
}