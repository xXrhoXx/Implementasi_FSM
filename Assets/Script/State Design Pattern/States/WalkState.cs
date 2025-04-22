using UnityEngine;

public class WalkState : BaseState
{
    internal override string Name => "Walk";

    internal override void Enter(CharacterMovement machine)
    {
        
    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.dir.x = machine.inputDir * machine.walkSpeed * Time.deltaTime;
        machine.Animator.Play("Run");

        if (machine.jump && machine.CharacterController.isGrounded)
        {
            machine.ChangeState("Jump");
        }

        if (machine.inputDir == 0)
        {
            machine.ChangeState("Idle");
        }
    }

    internal override void Exit(CharacterMovement machine)
    {
        
    }
}
