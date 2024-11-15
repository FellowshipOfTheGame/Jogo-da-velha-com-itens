using UnityEngine;
using UnityEngine.UI;

public class ConfirmSelectionButton : MonoBehaviour
{
    [SerializeField] private ItemManager ItemManager;
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ItemManager.ConfirmSelection);
    }
}