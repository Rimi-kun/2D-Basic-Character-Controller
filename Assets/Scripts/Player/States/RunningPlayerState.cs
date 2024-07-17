using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// Состояние бега игрока.
    /// </summary>
    public class RunningPlayerState : PlayerState
    {
        /// <summary>
        /// Конструктор состояния бега, инициализирующийся с контроллером игрока.
        /// </summary>
        /// <param name="controller">Контроллер игрока.</param>
        public RunningPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"Состояние изменилось на \"{controller.CurrentStateName}\"");
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