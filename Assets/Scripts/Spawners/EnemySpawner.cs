public class EnemySpawner : BaseSpawner<Enemy> 
{
    private void OnEnable()
        => GetElement();
}