using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    internal abstract string Name { get; }
    internal abstract void Enter(CharacterMovement machine);
    internal abstract void Execute(CharacterMovement machine);
    internal abstract void Exit(CharacterMovement machine);
}
