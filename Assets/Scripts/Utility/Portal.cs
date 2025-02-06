using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{
   [Header("PortalSettings")] 
   [SerializeField] private Transform _linkPortal;

   public void Interact()
   {
      GameManager.Instance.MovementPlayer.TPAt(_linkPortal.position);
   }
}
