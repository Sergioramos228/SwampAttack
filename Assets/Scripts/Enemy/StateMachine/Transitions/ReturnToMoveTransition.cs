using UnityEngine;

public class ReturnToMoveTransition : Transition
{
    [SerializeField] private RangeAttackState _shooter;

    private void OnEnable()
    {
        _shooter.OnAttack += OnTakingDamage;
    }

    private void OnDisable()
    {
        _shooter.OnAttack -= OnTakingDamage;
    }

    private void OnTakingDamage()
    {
        NeedTransit = true;
    }

    public override void Init(Player target)
    {
        base.Init(target);
        NeedTransit = false;
    }
}
