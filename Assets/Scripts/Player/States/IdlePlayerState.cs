using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// —осто€ние просто€ игрока.
    /// </summary>
    public class IdlePlayerState : PlayerState
    {
        /// <summary>
        ///  онструктор состо€ни€ просто€, инициализирующийс€ с контроллером игрока.
        /// </summary>
        public IdlePlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"—осто€ние изменилось на \"{controller.CurrentStateName}\"");
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