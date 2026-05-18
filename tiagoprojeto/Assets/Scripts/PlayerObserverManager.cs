using System;

public static class PlayerObserverManager
{
    
    public static Action OnCoinPickup;

    
    public static Action<int> OnCoinUpdated;

    
    public static void CoinPickup()
    {
        OnCoinPickup?.Invoke();
    }

    
    public static void CoinUpdated(int amount)
    {
        OnCoinUpdated?.Invoke(amount);
    }
}