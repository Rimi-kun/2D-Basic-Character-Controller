using System;
using System.Collections.Generic;

namespace Player.StateMachine
{
    /// <summary>
    /// ����� ��������� �������� ��� ������.
    /// </summary>
    public class PlayerFsm
    {
        /// <summary>
        /// ������� ��������� ������.
        /// </summary>
        public PlayerState CurrentState { get; private set; }

        private readonly Dictionary<Type, PlayerState> _states = new();

        #region PublicMethods
        /// <summary>
        /// �������������� ��������� ��������� ��������� ��������.
        /// </summary>
        public void Initialize<T>() where T : PlayerState => ChangeState<T>();

        /// <summary>
        /// ��������� ��������� � �������� �������.
        /// </summary>
        /// <param name="state">������������ ���������.</param>
        public void AddState<T>(T state) where T : PlayerState => _states[typeof(T)] = state;

        /// <summary>
        /// ������ ������� ���������.
        /// </summary>
        public void ChangeState<T>() where T : PlayerState
        {
            CurrentState?.Exit();
            CurrentState = _states[typeof(T)];
            CurrentState.Enter();
        }

        /// <summary>
        /// ��������� ���������� �������� ���������.
        /// </summary>
        public void Update() => CurrentState?.Execute();

        /// <summary>
        /// ��������� ������������� ���������� �������� ���������.
        /// </summary>
        public void FixedUpdate() => CurrentState?.FixedExecute();
        #endregion
    }
}