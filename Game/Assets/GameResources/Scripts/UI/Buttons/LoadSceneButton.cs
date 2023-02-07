using Infrastructure.States;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : AbstractButtonView
{
    [SerializeField]
    private string _sceneName = string.Empty;

    private IGameStateMachine _gameStateMachine = default;

    [Inject]
    private void Constructor(IGameStateMachine gameStateMachine) => 
        _gameStateMachine = gameStateMachine;

    protected override void OnButtonClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        PauseController.pause_bool = false;
        _gameStateMachine.Enter<LoadLevelState, string>(_sceneName);
    }
}
