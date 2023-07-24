using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    [SerializeField] private int _damage;
    public override void Shoot(Transform shootPoint)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 1);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(_damage);
        }
    }
}
