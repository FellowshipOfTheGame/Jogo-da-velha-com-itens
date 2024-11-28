using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleScreenButton : MonoBehaviour
{
    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
