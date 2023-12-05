using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
