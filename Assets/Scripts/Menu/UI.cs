using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [Header("UI Settings Movement")]
    [SerializeField] private TextMeshProUGUI _textMovement;

    private void Update()
    {
        _textMovement.text = $"Déplacement {MovementPlayer.NbCaseMouv.ToString()}";
    }
}
