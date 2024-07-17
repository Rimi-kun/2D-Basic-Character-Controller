using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// ��������� ������ ������.
    /// </summary>
    public class JumpingPlayerState : PlayerState
    {
        /// <summary>
        /// ����������� ��������� ������, ������������������ � ������������ ������.
        /// </summary>
        /// <param name="controller">���������� ������.</param>
        public JumpingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"��������� ���������� �� \"{controller.CurrentStateName}\"");
#endif

            controller.MovementController.Jump();
        }

        public override void Execute()
        {
            if (!controller.InputHandler.IsJumping)
            {
                controller.StateMachine.ChangeState<IdlePlayerState>();
            }
        }
    }
}