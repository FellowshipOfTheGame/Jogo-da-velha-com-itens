using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSelect
{
    public class PlayerSelectedItems : PlayerItems
    {
        public override void ConfirmItemSelection()
        {
            Items.Add(currentSelectedItem);
            Instantiate(currentSelectedItem.GetComponent<Button>().image, transform);
            currentSelectedItem = null;
        }
    }
}