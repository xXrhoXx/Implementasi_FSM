using UnityEngine;

public class IdleState : BaseState
{
    internal override string Name => "Idle";

    internal override void Enter(CharacterMovement machine)
    {
        
    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.Animator.Play("Idle");

        if (machine.jump && machine.CharacterController.isGrounded)
        {
            machine.ChangeState("Jump");
        }

        if (machine.inputDir != 0)
        {
            machine.ChangeState("Walk");
        }

        if (machine.leftMouse)
        {
            machine.ChangeState("Attack");
        }
        if (machine.rightMouse)
        {
            machine.ChangeState("RangeAttack");
        }
    }

    internal override void Exit(CharacterMovement machine)
    {

    }
}
