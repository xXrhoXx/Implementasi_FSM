using UnityEngine;
using UnityEngine.AI;

public class Stats : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] internal int damage = 20;
    [SerializeField] internal GameObject projectile;
    [SerializeField] internal bool isDeath { get; private set; } = false;

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDeath) return;

        isDeath = true;
        //GetComponent<Collider>().enabled = false;
    }
}
