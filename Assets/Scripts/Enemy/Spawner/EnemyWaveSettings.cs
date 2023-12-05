using System;
using UnityEngine;

[Serializable]
public struct EnemyWaveSettings
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _count;

    public Enemy Enemy => _enemy;
    public int Count => _count;
}