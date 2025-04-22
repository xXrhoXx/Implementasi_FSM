using UnityEngine;

public class AttackState : BaseState
{
    internal override string Name => "Attack";

    internal override void Enter(CharacterMovement machine)
    {
        
    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.Animator.Play("Attack");
        machine.attack.attackColllider.enabled = true;
        if (machine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            machine.ChangeState("Idle");
        }
    }

    internal override void Exit(CharacterMovement machine)
    {
        machine.attack.attackColllider.enabled = false;
    }
}
