using UnityEngine;

public class Attack : MonoBehaviour
{
    internal Collider attackColllider;
    [SerializeField] Stats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackColllider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);

        if (other.gameObject.TryGetComponent(out Stats enemyHealth))
        {
            //if (enemyHealth.gameObject.layer == attack.excludeLayer)
            //return;

            enemyHealth.TakeDamage(playerStats.damage);
        }
    }
}
