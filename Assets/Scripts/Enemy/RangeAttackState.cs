using UnityEngine;
using UnityEngine.Events;

public class RangeAttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;

    private float _lastAttackTime;
    private Animator _animator;

    public event UnityAction OnAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        OnAttack?.Invoke();
        _weapon.Shoot(_shootPoint);
        _animator.SetTrigger("Shoot");
    }
}
