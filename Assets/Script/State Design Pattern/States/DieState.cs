using UnityEngine;

public class DieState : BaseState
{
    internal override string Name => "Die";

    internal override void Enter(CharacterMovement machine)
    {
        
    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.Animator.Play("Die");
        machine.CharacterController.enabled = false;
    }

    internal override void Exit(CharacterMovement machine)
    {
        
    }
}
