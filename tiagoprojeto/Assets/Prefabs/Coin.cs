using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCoin playerCoin = other.GetComponent<PlayerCoin>();

            if (playerCoin != null)
            {
                playerCoin.AddCoin();
            }

            Destroy(gameObject);
        }
    }
}