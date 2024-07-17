namespace Player.StateMachine
{
    /// <summary>
    /// ����������� ������� ����� ��� ��������� ������ � �������� ��������.
    /// </summary>
    public abstract class PlayerState
    {
        protected readonly PlayerController controller;

        /// <summary>
        /// ����������� ���������.
        /// </summary>
        protected PlayerState(PlayerController controller) => this.controller = controller;

        #region PublicMethods
        /// <summary>
        /// �����, ���������� ��� ����� � ���������.
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// �����, ���������� ������ ���� ��� ���������� ������ ���������.
        /// </summary>
        public virtual void Execute() { }

        /// <summary>
        /// �����, ���������� ������ ������������� ���� ��� ���������� ������ ���������.
        /// </summary>
        public virtual void FixedExecute() => controller.MovementController.Move(controller.InputHandler.Movement);

        /// <summary>
        /// �����, ���������� ��� ������ �� ���������.
        /// </summary>
        public virtual void Exit() { } 
        #endregion
    }
}