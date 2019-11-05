using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIState 
{
    /// <summary>
    /// The code that runs when entering this state. OnStateExit will have been executed on the previous state before this new state
    /// </summary>
    /// <param name="previousState">The state that was active on the state machine before this one</param>
    /// <param name="stateMachine">The state machine that this AI state will be running on</param>
    void OnStateEnter(IAIState previousState, MonsterStateMachine stateMachine);

    /// <summary>
    /// The code that runs each frame during Update while this is the active state
    /// </summary>
    /// <param name="stateMachine">The state machine that this AI state is currently the active state for</param>
    void OnStateUpdate(MonsterStateMachine stateMachine);

    /// <summary>
    /// The code that runs when exting this state. This will execute before the OnStateEnter of the next state
    /// </summary>
    /// <param name="nextState">The state to change the state machine's active state to</param>
    void OnStateExit(IAIState nextState, MonsterStateMachine stateMachine);


    /// <summary>
    /// This code will run when a trigger enters the collider on the state machine's game object.
    /// </summary>
    /// <param name="other">The collider that entered the state machine's collider</param>
    void OnTriggerStay(Collider other);
}
