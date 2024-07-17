using UnityEngine;

namespace Player.Input
{
    /// <summary>
    /// Система ввода для игрока.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        #region PublicAccessors
        /// <summary>
        /// Возвращает вектор движения, полученный из ввода игрока.
        /// </summary>
        public Vector2 Movement { get; private set; }

        /// <summary>
        /// Показывает, осуществляется ли в данный момент прыжок.
        /// </summary>
        public bool IsJumping { get; private set; }

        /// <summary>
        /// Показывает, осуществляется ли в данный момент планирование.
        /// </summary>
        public bool IsGliding { get; private set; }

        /// <summary>
        /// Показывает, двигается ли игрок в данный момент.
        /// </summary>
        public bool IsMoving => Movement != Vector2.zero;
        #endregion

        private CharacterInput _controls;

        #region PrivateMethods
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new CharacterInput();
                _controls.Enable();
            }

            _controls.Player.Move.performed += ctx => Movement = ctx.ReadValue<Vector2>();
            _controls.Player.Move.canceled += _ => Movement = Vector2.zero;

            _controls.Player.Jump.started += _ => IsJumping = true;
            _controls.Player.Jump.canceled += _ => IsJumping = false;

            _controls.Player.Glide.performed += _ => IsGliding = true;
            _controls.Player.Glide.canceled += _ => IsGliding = false;
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
        #endregion
    }
}