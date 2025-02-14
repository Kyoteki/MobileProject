using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    [SerializeField] DataLevelContainer _levelContainer;
    private string _filePath;

    public static SaveManager Instance {  get; private set; }

    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/GameData.save";

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            if (System.IO.File.Exists(_filePath)) Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        List<DataToSaves> _gameData = new List<DataToSaves>();

        foreach (DataLevel level in _levelContainer.Levels)
        {
            _gameData.Add(level.DataToSaves);
        }

        BinaryFormatter formatter = new();
        FileStream stream = new(_filePath, FileMode.Create);
        formatter.Serialize(stream, _gameData);
        stream.Close();
    }

    private void Load()
    {
        List<DataToSaves> _gameData = new List<DataToSaves>();

        BinaryFormatter formatter = new();
        FileStream stream = new(_filePath, FileMode.Open);
        _gameData = formatter.Deserialize(stream) as List<DataToSaves>;
        stream.Close();

        int i = 0;
        foreach (DataToSaves level in _gameData)
        {
            _levelContainer.Levels[i].DataToSaves = level;
            i++;
        }
    }
}
