using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SoundManager SoundManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }
}
