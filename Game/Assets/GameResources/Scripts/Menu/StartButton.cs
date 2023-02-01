using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : AbstractButton
{
    [SerializeField]
    private string _sceneName = string.Empty;

    public override void OnClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        PauseController.pause_bool = false;
        SceneManager.LoadSceneAsync(_sceneName);
    }
}
