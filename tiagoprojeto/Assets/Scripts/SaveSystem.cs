using UnityEditor.Overlays;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Saves = new List<Save>();
            Saves.Add(new Save());
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private List<Save> Saves;

    public bool SavePlayerLevel(int level, int slot = 0)
    {
        if (Saves.Count < slot && Saves[slot] == null) return false;
        Saves[slot].PlayerLevel = level;
        return true;
    }
    
    public bool LoadPlayerLevel(out int level, int slot = 0)
    {
        if (Saves.Count < slot && Saves[slot] == null)
        {
            level = -1;
            return false;
        }

        level = Saves[slot].PlayerLevel;
        return true;
    }

    public int LoadPlayerLevel(out int level, int slot = 0)
    {
        
    }
    public class Save
    {
        private int playerLevel;
        public string playerName;
        
        public Save(int playerLevel)
    }
}
