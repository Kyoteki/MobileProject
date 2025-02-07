using UnityEngine;

[CreateAssetMenu(fileName = "DataLevelContainer", menuName = "ScriptableObjects/DataLevelContainer", order = 1)]
public class DataLevelContainer : ScriptableObject
{
    [SerializeField] private DataLevel[] _levels;
    [SerializeField] private int _sceneToLoad;
    public int SceneToLoad => _sceneToLoad;
    public DataLevel[] Levels => _levels;

    public DataLevel GetLevel(int id)
    {
        return _levels[id];
    }
}
