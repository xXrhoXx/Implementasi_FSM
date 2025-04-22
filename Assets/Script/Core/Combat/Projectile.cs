using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Stats playerStats;
    private float speed = 10f;
    private int direction = 1;
    public void Initialize(int dir, Stats playerStats)
    {
        this.playerStats = playerStats;
        direction = dir;

        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);

        if (other.gameObject.TryGetComponent(out Stats enemyHealth))
        {
            //if (enemyHealth.gameObject.layer == attack.excludeLayer)
            //return;

            enemyHealth.TakeDamage( (int) playerStats.damage / 2);
            Destroy(gameObject);
        }
    }
}
