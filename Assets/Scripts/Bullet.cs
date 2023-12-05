using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent(out Wall _))
        {
            Destroy(gameObject);
        }
    }
}
