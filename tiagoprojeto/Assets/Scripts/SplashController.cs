using System.Collections;
using UnityEngine;
 
// Coloque este script num GameObject na cena Splash.
// Na cena: crie um Canvas > Image e arraste a imagem que quiser no componente Image.
public class SplashController : MonoBehaviour
{
    [SerializeField] private float displayTime = 2f; // segundos de exibição
 
    private void Start()
    {
        StartCoroutine(WaitAndAdvance());
    }
 
    private IEnumerator WaitAndAdvance()
    {
        Debug.Log("[SplashController] Exibindo splash por " + displayTime + " segundos...");
        yield return new WaitForSeconds(displayTime);
 
        // Pede ao GameManager para ir ao Menu Principal
        GameManager.Instance.GoToMainMenu();
    }
}