using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    private int coins = 0;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinPickup += AddCoin;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinPickup -= AddCoin;
    }

    private void AddCoin()
    {
        coins++;
        
        PlayerObserverManager.CoinUpdated(coins);

        Debug.Log("Moedas: " + coins);
    }
}