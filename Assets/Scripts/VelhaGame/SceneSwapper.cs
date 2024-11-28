using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class VictorySceneSwapper : MonoBehaviour
{
    public Player winner;
    public void FinishGame(Player winner)
    {
        this.winner = winner;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(transform.gameObject);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var victoryText = GameObject.Find("VictoryText")?.GetComponent<TextMeshProUGUI>();
        if (!victoryText) return;
        victoryText.text = winner == Player.X
            ? "Xantheia é a vencedora do Jogo da Velha"
            : "Otto é o vencedor do Jogo da Velha";
        Destroy(gameObject);
    }
}
