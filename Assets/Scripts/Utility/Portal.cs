using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour, IInteractable
{
   [Header("PortalSettings")] 
   [SerializeField] private Transform _linkPortal;
   [SerializeField] private UnityEvent _onTeleport;

   public void Interact()
   {
      GameManager.Instance.MovementPlayer.TPAt(_linkPortal.position);
      _onTeleport?.Invoke();
   }
}
