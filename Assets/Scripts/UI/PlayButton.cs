using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private EnemyPlanner _enemyPlanner;
    [SerializeField] private Transform _container;

    private Button _button;

    private void Awake()
        => _button = GetComponent<Button>();

    private void OnEnable()
    {
        _button.onClick.AddListener(_spawner.GetElement);
        _button.onClick.AddListener(_enemyPlanner.StartSpawning);
        _button.onClick.AddListener(Deactivate);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(_spawner.GetElement);
        _button.onClick.RemoveListener(_enemyPlanner.StartSpawning);
        _button.onClick.RemoveListener(Deactivate);
    }

    private void Deactivate()
        => _container.gameObject.SetActive(false);
}   