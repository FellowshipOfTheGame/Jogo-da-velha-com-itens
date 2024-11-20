using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : ItemButton
{
    private void Start () 
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => PlayerItems.ToggleItemSelected(this));
    }

    public override void ToggleItemSelected() 
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
}
