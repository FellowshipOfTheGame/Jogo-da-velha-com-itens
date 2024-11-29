using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class VictorySceneSwapper : MonoBehaviour
{
    private Player _winner;
    public void FinishGame(Player winner)
    {
        _winner = winner;
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
        victoryText.text = _winner == Player.X
            ? "Xantheia é a vencedora do Jogo da Velha"
            : "Otto é o vencedor do Jogo da Velha";
    }
}
