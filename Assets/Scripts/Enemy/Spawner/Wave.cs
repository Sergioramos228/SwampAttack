using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField] private List<EnemyWaveSettings> _template;
    [SerializeField] private float _delay;

    public IEnumerable<EnemyWaveSettings> Template => _template;
    public float Delay => _delay;
}
