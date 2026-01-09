using UnityEngine;

public class EnemySpawner : BaseSpawner<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private EnemyPlanner _planner;

    private void OnEnable()
        => _planner.Spawning += GetElement;

    private void OnDisable()
        => _planner.Spawning -= GetElement;

    public override Enemy GetElement(Vector2 position)
    {
        Enemy enemy = base.GetElement(position);
        enemy.Shooter.Shooting += _bulletSpawner.GetElement;

        return enemy;
    }

    protected override void Release(ISpawnable element)
    {
        if (element is Enemy enemy)
        {
            enemy.Shooter.Shooting -= _bulletSpawner.GetElement;
            base.Release(enemy);
        }
    }
}