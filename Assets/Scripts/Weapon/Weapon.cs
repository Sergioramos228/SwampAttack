using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _attackDelay;
    [SerializeField] private bool _isBought = false;
    [SerializeField] private string _hitAnimation = "Shoot";
    [SerializeField] private string _idleAnimation = "Idle";

    [SerializeField] protected Bullet Bullet;

    public string Label => _label;
    public string HitAnimation => _hitAnimation;
    public string IdleAnimation => _idleAnimation;
    public int Price => _price;
    public Sprite Icon => _icon;
    public float AttackDelay => _attackDelay;
    public bool IsBought => _isBought;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBought = true;
    }
}
