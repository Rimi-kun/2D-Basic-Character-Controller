using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// ��������� ���� ������.
    /// </summary>
    public class RunningPlayerState : PlayerState
    {
        /// <summary>
        /// ����������� ��������� ����, ������������������ � ������������ ������.
        /// </summary>
        /// <param name="controller">���������� ������.</param>
        public RunningPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"��������� ���������� �� \"{controller.CurrentStateName}\"");
#endif
        }

        public override void Execute()
        {
            if (controller.InputHandler.IsJumping)
            {
                controller.StateMachine.ChangeState<JumpingPlayerState>();
            }

            if (!controller.InputHandler.IsMoving)
            {
                controller.StateMachine.ChangeState<IdlePlayerState>();
            }

            if (controller.InputHandler.IsGliding && !controller.IsGrounded)
            {
                controller.StateMachine.ChangeState<GlidingPlayerState>();
            }
        }
    }
}