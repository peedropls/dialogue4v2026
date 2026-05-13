using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    private int coins = 0;

    public void AddCoin()
    {
        coins++;

        PlayerObserverManager.CoinCollected(coins);
    }
}