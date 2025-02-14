using System.Collections;
using TMPro;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtPressStart;
    private bool _isAnimEnd = true;
    private bool _isdirectionFadePositive = true;

    void Update()
    {
        if(_isAnimEnd)
        {
            switch(_isdirectionFadePositive)
            {
                case true:
                    _txtPressStart.color += new Color(0, 0, 0, 0.003f);
                    if(_txtPressStart.color.a >= 1)
                    {
                        _isdirectionFadePositive = false;
                    }
                    break;
                case false:
                    _txtPressStart.color -= new Color(0, 0, 0, 0.003f);
                    if(_txtPressStart.color.a <= 0)
                    {
                        _isdirectionFadePositive = true;
                    }
                    break;
            }
        }
    }
}
