using UnityEngine;

public class MovementButton : MonoBehaviour
{
    [SerializeField] private MouvementPlayer _mouvementPlayer;

    void OnMouseDown()
    {
        _mouvementPlayer.AddPos(transform.position);
    }
}
