using System;
using System.Collections.Generic;

namespace Player.StateMachine
{
    /// <summary>
    ///  ласс конечного автомата дл€ игрока.
    /// </summary>
    public class PlayerFsm
    {
        /// <summary>
        /// “екущее состо€ние игрока.
        /// </summary>
        public PlayerState CurrentState { get; private set; }

        private readonly Dictionary<Type, PlayerState> _states = new();

        #region PublicMethods
        /// <summary>
        /// »нициализирует начальное состо€ние конечного автомата.
        /// </summary>
        public void Initialize<T>() where T : PlayerState => ChangeState<T>();

        /// <summary>
        /// ƒобавл€ет состо€ние в конечный автомат.
        /// </summary>
        /// <param name="state">ѕередаваемое состо€ние.</param>
        public void AddState<T>(T state) where T : PlayerState => _states[typeof(T)] = state;

        /// <summary>
        /// ћен€ет текущее состо€ние.
        /// </summary>
        public void ChangeState<T>() where T : PlayerState
        {
            CurrentState?.Exit();
            CurrentState = _states[typeof(T)];
            CurrentState.Enter();
        }

        /// <summary>
        /// ¬ыполн€ет обновление текущего состо€ни€.
        /// </summary>
        public void Update() => CurrentState?.Execute();

        /// <summary>
        /// ¬ыполн€ет фиксированное обновление текущего состо€ни€.
        /// </summary>
        public void FixedUpdate() => CurrentState?.FixedExecute();
        #endregion
    }
}