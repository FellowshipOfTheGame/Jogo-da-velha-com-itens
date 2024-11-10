using UnityEngine;
using UnityEngine.UI;

public class FinishSelectionButton : MonoBehaviour
{
    [SerializeField] private ItemManager ItemManager;
    private bool firstPlayerFinished = false; 
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(FinishSelection);
    }

    private void FinishSelection()
    {
        if (!firstPlayerFinished)
        {
            firstPlayerFinished = true;
            ItemManager.ChangePlayer();
        }
        else
        {
            // passar para a proxima cena
        }
    }
}
