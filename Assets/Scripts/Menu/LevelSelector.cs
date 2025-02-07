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
            if(i>0 && !levels[i-1].DataToSaves.IsCompleted)
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

    private void Change(int i, List<DataLevel> levels)
    {
        _levelStarter.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = levels[i].ImagePreview;
        _levelStarter.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].LevelName;
        _levelStarter.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].DataToSaves.HighScore.ToString();
        _levelStarter.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].DataToSaves.BestStep.ToString();
        _levelStarter.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[i].DataToSaves.BestTime.ToString();
        switch(levels[i].DataToSaves.NbStars)
        {
            case 0:
                _levelStarter.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                _levelStarter.transform.GetChild(2).GetChild(4).gameObject.SetActive(false);
                _levelStarter.transform.GetChild(2).GetChild(5).gameObject.SetActive(false);
                break;
            case 1:
                _levelStarter.transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
                _levelStarter.transform.GetChild(2).GetChild(4).gameObject.SetActive(false);
                _levelStarter.transform.GetChild(2).GetChild(5).gameObject.SetActive(false);
                break;
            case 2:
                _levelStarter.transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
                _levelStarter.transform.GetChild(2).GetChild(4).gameObject.SetActive(true);
                _levelStarter.transform.GetChild(2).GetChild(5).gameObject.SetActive(false);
                break;
            case 3:
                _levelStarter.transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
                _levelStarter.transform.GetChild(2).GetChild(4).gameObject.SetActive(true);
                _levelStarter.transform.GetChild(2).GetChild(5).gameObject.SetActive(true);
                break;
        }
        _levelStarter.SetActive(true);
        this.gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
}
