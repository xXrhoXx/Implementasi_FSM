using UnityEngine;

public class GlideState : BaseState
{
    internal override string Name => "Glide";

    internal override void Enter(CharacterMovement machine)
    {

    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.dir.y += Physics.gravity.y * 0.02f * Time.deltaTime;

        if (machine.velocity.y < -0.1f)
        {
            machine.Animator.Play("Glide");
        }

        if (machine.CharacterController.isGrounded)
        {
            machine.ChangeState("Idle");
        }
    }

    internal override void Exit(CharacterMovement machine)
    {

    }
}
