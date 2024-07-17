using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// ��������� ������������ ������.
    /// </summary>
    public class GlidingPlayerState : PlayerState
    {
        /// <summary>
        /// ����������� ��������� ������������, ������������������ � ������������ ������.
        /// </summary>
        /// <param name="controller">���������� ������.</param>
        public GlidingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"��������� ���������� �� \"{controller.CurrentStateName}\"");
#endif

            controller.Trail.SetActive(true);
        }

        public override void Execute()
        {
            base.Execute();

            if (!controller.InputHandler.IsGliding)
            {
                controller.StateMachine.ChangeState<FallingPlayerState>();
            }

            if (controller.IsGrounded)
            {
                controller.StateMachine.ChangeState<IdlePlayerState>();
            }
        }

        public override void FixedExecute()
        {
            base.FixedExecute();

            controller.MovementController.Glide();
        }

        public override void Exit() => controller.Trail.SetActive(false);
    }
}