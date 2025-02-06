using UnityEngine;

public class SoulPlayer : MonoBehaviour
{
    public bool AsSoul {  get; private set; }

    public void TakeSoul()
    {
        AsSoul = true;
    }
    public void DropSoul()
    {
        AsSoul = false;
    }
}
