using Player.StateMachine;

using UnityEngine;

namespace Player.States
{
    /// <summary>
    /// —осто€ние планировани€ игрока.
    /// </summary>
    public class GlidingPlayerState : PlayerState
    {
        /// <summary>
        ///  онструктор состо€ни€ планировани€, инициализирующийс€ с контроллером игрока.
        /// </summary>
        /// <param name="controller"> онтроллер игрока.</param>
        public GlidingPlayerState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
#if DEBUG
            Debug.Log($"—осто€ние изменилось на \"{controller.CurrentStateName}\"");
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