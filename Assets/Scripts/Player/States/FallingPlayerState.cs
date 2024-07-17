using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// ��������� ������� ������.
    /// </summary>
    public class FallingPlayerState : PlayerState
    {
        /// <summary>
        /// ����������� ��������� �������, ������������������ � ������������ ������.
        /// </summary>
        /// <param name="controller">���������� ������.</param>
        public FallingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"��������� ���������� �� \"{controller.CurrentStateName}\"");
#endif
        }

        public override void Execute()
        {
            if (controller.InputHandler.IsGliding)
            {
                controller.StateMachine.ChangeState<GlidingPlayerState>();
            }

            if (controller.IsGrounded)
            {
                controller.StateMachine.ChangeState<IdlePlayerState>();
            }
        }
    }
}