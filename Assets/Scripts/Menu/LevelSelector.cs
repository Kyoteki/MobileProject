using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private DataLevel[] levels;
    [SerializeField] private GameObject levelButtonPrefab;

    void Start()
    {
        foreach (DataLevel level in levels)
        {
            GameObject levelButton = Instantiate(levelButtonPrefab, transform);
            levelButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = level.ImagePreview.sprite;
            levelButton.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = level.LevelName;
        }
    }
}
