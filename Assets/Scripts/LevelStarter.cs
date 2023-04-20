using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private SaveManager _saveManager;
    void Awake()
    {
        _saveManager.LevelStartControl();
    }
}