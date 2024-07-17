using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// ��������� ������� ������.
    /// </summary>
    public class IdlePlayerState : PlayerState
    {
        /// <summary>
        /// ����������� ��������� �������, ������������������ � ������������ ������.
        /// </summary>
        public IdlePlayerState(PlayerController controller) : base(controller) { }

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
            else if (controller.InputHandler.IsMoving)
            {
                controller.StateMachine.ChangeState<RunningPlayerState>();
            }
            else if (controller.InputHandler.IsGliding)
            {
                controller.StateMachine.ChangeState<GlidingPlayerState>();
            }
            else if (controller.IsFalling)
            {
                controller.StateMachine.ChangeState<FallingPlayerState>();
            }
        }
    }
}