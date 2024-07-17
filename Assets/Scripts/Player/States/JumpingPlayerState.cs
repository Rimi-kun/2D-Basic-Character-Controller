using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// Состояние прыжка игрока.
    /// </summary>
    public class JumpingPlayerState : PlayerState
    {
        /// <summary>
        /// Конструктор состояния прыжка, инициализирующийся с контроллером игрока.
        /// </summary>
        /// <param name="controller">Контроллер игрока.</param>
        public JumpingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"Состояние изменилось на \"{controller.CurrentStateName}\"");
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