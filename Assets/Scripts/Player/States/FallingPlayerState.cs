using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// Состояние падения игрока.
    /// </summary>
    public class FallingPlayerState : PlayerState
    {
        /// <summary>
        /// Конструктор состояния падения, инициализирующийся с контроллером игрока.
        /// </summary>
        /// <param name="controller">Контроллер игрока.</param>
        public FallingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"Состояние изменилось на \"{controller.CurrentStateName}\"");
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