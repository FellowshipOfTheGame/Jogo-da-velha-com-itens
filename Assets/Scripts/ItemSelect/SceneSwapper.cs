using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    private ItemBase[] xItems;
    private ItemBase[] oItems;
    public void FinishItemSelection()
    {
        xItems = playerManager.XPlayerItems.Items.Select(i => i.Item).ToArray(); 
        oItems = playerManager.OPlayerItems.Items.Select(i => i.Item).ToArray();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerManager = GameObject.Find("PlayerManager")?.GetComponent<PlayerManager>();
        var xDeck = GameObject.Find("XItemsPanel/Deck")?.GetComponent<PlayerDeck>();
        var oDeck = GameObject.Find("OItemsPanel/Deck")?.GetComponent<PlayerDeck>();
        if (xDeck is null) return;

        xDeck.AvailableItems = xItems;
        oDeck.AvailableItems = oItems;
        Destroy(gameObject);
    }
}
