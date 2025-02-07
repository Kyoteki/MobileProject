using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private DataLevelContainer _dataLevelContainer;
    [SerializeField] private GameObject _levelButtonPrefab;
    [SerializeField] private GameObject _levelStarter;

    void Start()
    {
        List<DataLevel> levels = new List<DataLevel>(_dataLevelContainer.Levels);
        for (int i = 0; i< levels.Count; i++)
        {
            GameObject levelButton = Instantiate(_levelButtonPrefab, transform);
            levelButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = levels[i].ImagePreviewMini;
            levelButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].LevelName;
            if(i>0 && !levels[i-1].IsCompleted)
            {
                levelButton.transform.GetChild(2).gameObject.SetActive(true);
            }
            int n = i;
            levelButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                Change(n, levels);
            });
        }
        float fixposition = (int)(levels.Count / 4) * 600;
        this.transform.position += new Vector3(fixposition, 0, 0);
    }

    void Change(int i, List<DataLevel> levels)
    {
        _levelStarter.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = levels[i].ImagePreview;
        _levelStarter.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].LevelName;
        _levelStarter.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].HighScore.ToString();
        _levelStarter.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].BestStep.ToString();
        _levelStarter.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].BestTime.ToString();
    }
}
