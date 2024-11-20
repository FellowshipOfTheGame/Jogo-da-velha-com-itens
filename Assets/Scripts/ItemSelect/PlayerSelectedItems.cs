using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSelect
{
    public class PlayerSelectedItems : PlayerItems
    {
        public override void ToggleItemSelected(ItemButton item)
        {
            currentSelectedItem?.ToggleItemSelected();
            currentSelectedItem = item;
            currentSelectedItem.ToggleItemSelected();
        }

        public override void ConfirmItemSelection()
        {
            Items.Add(currentSelectedItem);
            Instantiate(currentSelectedItem.GetComponent<Button>().image, transform);
            currentSelectedItem = null;
        }
    }
}