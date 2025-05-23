using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // so pode ter um music player,
        // quando trocar de cena tem que deletar caso seja criado um novo
        GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (musicPlayers.Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
