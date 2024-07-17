using UnityEngine;

namespace Player
{
    [System.Serializable]
    public struct PlayerMovementParams
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _glideSpeed;
        [SerializeField] private float _glideSmoothness;

        #region PublicAccessors
        public Rigidbody2D Rigidbody
        { 
            readonly get => _rigidbody;
            set => _rigidbody = value;
        }

        public float MoveSpeed
        {
            readonly get => _moveSpeed;
            set => _moveSpeed = value;
        }

        public float JumpForce
        {
            readonly get => _jumpForce;
            set => _jumpForce = value;
        }

        public float GlideSpeed
        {
            readonly get => _glideSpeed;
            set => _glideSpeed = value;
        }

        public float GlideSmoothness
        {
            readonly get => _glideSmoothness;
            set => _glideSmoothness = value;
        }
        #endregion

        public PlayerMovementParams(Rigidbody2D rigidbody, float moveSpeed, float jumpForce, float glideSpeed, float glideSmoothness)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
            _jumpForce = jumpForce;
            _glideSpeed = glideSpeed;
            _glideSmoothness = glideSmoothness;
        }
    }
}