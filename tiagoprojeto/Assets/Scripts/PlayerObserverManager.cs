using System;

public static class PlayerObserverManager
{
    // Evento das moedas
    public static Action<int> OnCoinCollected;

    // Método para disparar o evento
    public static void CoinCollected(int amount)
    {
        OnCoinCollected?.Invoke(amount);
    }
}