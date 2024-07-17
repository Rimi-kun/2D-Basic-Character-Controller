namespace Player.StateMachine
{
    /// <summary>
    /// Абстрактный базовый класс для состояния игрока в конечном автомате.
    /// </summary>
    public abstract class PlayerState
    {
        protected readonly PlayerController controller;

        /// <summary>
        /// Конструктор состояния.
        /// </summary>
        protected PlayerState(PlayerController controller) => this.controller = controller;

        #region PublicMethods
        /// <summary>
        /// Метод, вызываемый при входе в состояние.
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// Метод, вызываемый каждый кадр для выполнения логики состояния.
        /// </summary>
        public virtual void Execute() { }

        /// <summary>
        /// Метод, вызываемый каждый фиксированный кадр для выполнения логики состояния.
        /// </summary>
        public virtual void FixedExecute() => controller.MovementController.Move(controller.InputHandler.Movement);

        /// <summary>
        /// Метод, вызываемый при выходе из состояния.
        /// </summary>
        public virtual void Exit() { } 
        #endregion
    }
}