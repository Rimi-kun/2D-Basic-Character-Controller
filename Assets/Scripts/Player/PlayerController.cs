using Player.Input;
using Player.StateMachine;
using Player.States;

using UnityEngine;

namespace Player
{
    /// <summary>
    /// Управляет движением игрового персонажа и переходами между состояниями.
    /// </summary>
    [RequireComponent(typeof(InputHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        #region PublicAccessors
        /// <summary>
        /// StateMachine, управляющая состояниями игрока.
        /// </summary>
        public PlayerFsm StateMachine { get; private set; }

        /// <summary>
        /// Обработчик ввода игрока.
        /// </summary>
        public InputHandler InputHandler { get; private set; }

        /// <summary>
        /// Класс с логикой передвижения игрока.
        /// </summary>
        public MovementController MovementController { get; private set; }

        /// <summary>
        /// Показывает, находится ли игрок на земле.
        /// </summary>
        public bool IsGrounded { get; private set; }

        /// <summary>
        /// Показывает, падает ли игрок в данный момент.
        /// </summary>
        public bool IsFalling => !IsGrounded && _params.Rigidbody.velocity.y < 0;

        /// <summary>
        /// Получает GameObject для эффекта следа игрока.
        /// </summary>
        public GameObject Trail => _trail;
        #endregion

        #region SerializedFields
        [Header("Additions")]
        [SerializeField] private SpriteRenderer _skinSprite;
        [SerializeField] private GameObject _trail;

        [Header("Movement")]
        [SerializeField] private PlayerMovementParams _params;

        [Header("Ground Check")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Vector2 _boxSize = new(0.75f, 0.2f);
        [SerializeField] private float _distance = 0.95f;
        [SerializeField] private float _angle;
        #endregion

        #region PrivateAccessors
        private Animator _animator;
        private Transform _transform;

        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        #endregion

        #region PublicMethods
        /// <summary>
        /// Возвращает имя текущего состояния игрока.
        /// </summary>
        public string CurrentStateName => StateMachine.CurrentState?.GetType().Name;
        #endregion

        #region PrivateMethods
        private void Awake()
        {
            MovementController = new MovementController(_params);

            _animator = GetComponentInChildren<Animator>();

            _transform = gameObject.transform;

            InputHandler = GetComponent<InputHandler>();
            StateMachine = new PlayerFsm();

            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            StateMachine = new PlayerFsm();

            StateMachine.AddState(new IdlePlayerState(this));
            StateMachine.AddState(new RunningPlayerState(this));
            StateMachine.AddState(new JumpingPlayerState(this));
            StateMachine.AddState(new FallingPlayerState(this));
            StateMachine.AddState(new GlidingPlayerState(this));

            StateMachine.Initialize<IdlePlayerState>();
        }

        private void Update()
        {
            StateMachine.Update();

            UpdateAnimatorParameters();
            FlipSprite();
            CheckGroundStatus();
        }

        private void FixedUpdate() => StateMachine.FixedUpdate();

        private void UpdateAnimatorParameters()
        {
            _animator.SetBool(IsJumping, !IsGrounded);
            _animator.SetFloat(XVelocity, Mathf.Abs(_params.Rigidbody.velocity.x));
            _animator.SetFloat(YVelocity, _params.Rigidbody.velocity.y);
        }

        private void CheckGroundStatus() => IsGrounded =
            Physics2D.BoxCast(_transform.position, _boxSize, _angle, -_transform.up, _distance, _layerMask);

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0f, 0f, _angle), Vector3.one);
            Gizmos.DrawCube(Vector3.zero - transform.up * _distance, _boxSize);
            Gizmos.matrix = Matrix4x4.identity;
        }
#endif

        private void FlipSprite()
        {
            if (InputHandler.Movement.x < 0)
            {
                _skinSprite.flipX = InputHandler.Movement.x < 0;
            }
            else if (InputHandler.Movement.x > 0)
            {
                _skinSprite.flipX = false;
            }
        } 
        #endregion
    }
}