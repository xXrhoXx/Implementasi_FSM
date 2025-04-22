using UnityEngine;

public class RangeAttackState : BaseState
{
    internal override string Name => "RangeAttack";
    private bool hasSpawnedProjectile = false;

    internal override void Enter(CharacterMovement machine)
    {

    }

    internal override void Execute(CharacterMovement machine)
    {
        machine.Animator.Play("RangeAttack");
        if (!hasSpawnedProjectile)
        {
            var projectile = Instantiate(machine.stats.projectile, machine.attack.transform.position, Quaternion.identity);
            var direction = (machine.facingRight) ? 1 : -1;
            projectile.GetComponent<Projectile>().Initialize(direction, machine.stats);
            Destroy(projectile, 5);

            hasSpawnedProjectile = true;
        }

        if (machine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            machine.ChangeState("Idle");
        }
    }

    internal override void Exit(CharacterMovement machine)
    {

    }
}
