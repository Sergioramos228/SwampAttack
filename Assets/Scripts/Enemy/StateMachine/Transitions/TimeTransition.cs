using UnityEngine;
using System.Collections;

public class TimeTransition : Transition
{
    [SerializeField] private int _minTimeToTransit;
    [SerializeField] private int _maxTimeToTransit;

    private float _maxTime;
    private float _timeToTransit;
    private Coroutine _lookingTime;

    private void Awake()
    {
        _maxTime = Random.Range(_minTimeToTransit, _maxTimeToTransit + 1);
    }

    private void OnEnable()
    {
        _timeToTransit = 0;
        NeedTransit = false;
    }

    private IEnumerator LookingForTime()
    {
        _timeToTransit = 0;
        yield return null;

        while (_timeToTransit < _maxTime)
        {
            _timeToTransit += Time.deltaTime;
            yield return null;
        }

        NeedTransit = true;
        _lookingTime = null;
    }

    public override void Init(Player player)
    {
        if (_lookingTime != null)
            StopCoroutine(_lookingTime);

        NeedTransit = false;
        _lookingTime = StartCoroutine(LookingForTime());
    }
}
