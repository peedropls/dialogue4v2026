using UnityEngine;

public class PortaController : MonoBehaviour
{
    public Animator anim;
    private bool isOpen;
    private bool isInteractable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isInteractable)
        {
            InteractOM.OnInteract += OpenClose;
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isInteractable)
        {
            InteractOM.OnInteract -= OpenClose;
            isInteractable = false;
        }
    }
    
    
    private void OpenClose()
    {
        throw new System.NotImplementedException();
    }
}
