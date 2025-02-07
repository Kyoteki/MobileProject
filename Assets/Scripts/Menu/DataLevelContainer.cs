using UnityEngine;

[CreateAssetMenu(fileName = "DataLevelContainer", menuName = "ScriptableObjects/DataLevelContainer", order = 1)]
public class DataLevelContainer : ScriptableObject
{
    [SerializeField] private DataLevel[] _levels;
    public DataLevel[] Levels => _levels;

    public DataLevel GetLevel(int id)
    {
        return _levels[id];
    }
}
