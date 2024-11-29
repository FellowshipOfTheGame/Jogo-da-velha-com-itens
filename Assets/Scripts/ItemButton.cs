using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerItems PlayerItems;
    public ItemBase Item;
    protected bool isSelected;
    [SerializeField] private ItemDescription itemDescriptionPrefab;
    
    private ItemDescription instantiatedItemDescription;
    
    protected void Start () 
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => PlayerItems.ToggleItemSelected(this));
        
        // colocar texto no botao enquanto nao tem imagem
        if (Item.Name != "Jogada comum")
            btn.GetComponentInChildren<TextMeshProUGUI>().text = $"{Item.Name} - {Item.Cost}";
    }

    public virtual void ToggleItemSelected()
    {
        if (isSelected)
        {
            isSelected = false;
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            isSelected = true;
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!itemDescriptionPrefab)
            return;
        // gambiarra total melhorar algum dia
        instantiatedItemDescription = Instantiate(itemDescriptionPrefab);
        instantiatedItemDescription.transform.SetParent(transform.parent.parent.parent.parent, false);
        instantiatedItemDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Item.Name;
        instantiatedItemDescription.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Item.Explanation;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!itemDescriptionPrefab)
            return;
        Destroy(instantiatedItemDescription.gameObject);
    }
    
    // overrides para verificar se os botoes sao iguais dentro de uma list
    public override string ToString() => Item.Name;

    public override int GetHashCode() => Item.Name.GetHashCode();
    public override bool Equals(object obj) => Item.Name == ((ItemButton)obj).Item.Name;
}
