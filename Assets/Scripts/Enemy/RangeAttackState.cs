using UnityEngine;
using UnityEngine.Events;

public class RangeAttackState : State
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;

    private float _lastAttackTime;
    private Animator _animator;

    public event UnityAction OnAttack;

    private void Start()
    {
        _lastAttackTime = _weapon.AttackDelay;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _weapon.AttackDelay;
        }
        else
        {
            _lastAttackTime -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        OnAttack?.Invoke();
        _weapon.Shoot(_shootPoint);
        _animator.SetTrigger("Shoot");
    }
}
