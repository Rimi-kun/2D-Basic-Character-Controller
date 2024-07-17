using UnityEngine;

namespace Player.Input
{
    /// <summary>
    /// ������� ����� ��� ������.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        #region PublicAccessors
        /// <summary>
        /// ���������� ������ ��������, ���������� �� ����� ������.
        /// </summary>
        public Vector2 Movement { get; private set; }

        /// <summary>
        /// ����������, �������������� �� � ������ ������ ������.
        /// </summary>
        public bool IsJumping { get; private set; }

        /// <summary>
        /// ����������, �������������� �� � ������ ������ ������������.
        /// </summary>
        public bool IsGliding { get; private set; }

        /// <summary>
        /// ����������, ��������� �� ����� � ������ ������.
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