using UnityEngine;

public class JumpState : BaseState
{
    internal override string Name => "Jump";

    internal override void Enter(CharacterMovement machine)
    {
        
    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.dir.x = machine.inputDir * machine.walkSpeed * Time.deltaTime;
        machine.dir.y = Mathf.Sqrt(machine.jumpHeight * -2f * Physics.gravity.y * Time.deltaTime);
        machine.Animator.Play("Jump");
        machine.ChangeState("Glide");
    }

    internal override void Exit(CharacterMovement machine)
    {
        
    }
}
