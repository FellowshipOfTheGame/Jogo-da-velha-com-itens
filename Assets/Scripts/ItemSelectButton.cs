using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    private void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    static void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
    }
}
