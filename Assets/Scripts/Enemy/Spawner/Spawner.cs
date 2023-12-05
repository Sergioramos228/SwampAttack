using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private Queue<Enemy> _enemies;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _enemiesInCurrentWave;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy(_enemies.Dequeue());
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _enemiesInCurrentWave);
        }

        if (_enemies.Count == 0)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }


    }

    private void InstantiateEnemy(Enemy enemyPrefab)
    {
        Enemy enemy = Instantiate(enemyPrefab.gameObject, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _enemies = new();
        _spawned = 0;
        _currentWave = _waves[index];

        foreach (EnemyWaveSettings waveSettings in _currentWave.Template)
        {
            for (int i = 0; i < waveSettings.Count; i++)
            {
                _enemies.Enqueue(waveSettings.Enemy);
            }
        }

        _enemiesInCurrentWave = _enemies.Count;
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _spawned = 0;
    }
}
