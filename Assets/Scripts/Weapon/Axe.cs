using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRange;

    public override void Shoot(Transform shootPoint)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(shootPoint.position, _attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent(out Enemy tempEnemy))
                tempEnemy.TakeDamage(_damage);
        }
    }
}
