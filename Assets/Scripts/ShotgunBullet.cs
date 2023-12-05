using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    private List<Enemy> _enemies = new();
    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }
}
