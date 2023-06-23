using _Scripts.CodeSugar;
using _Scripts.Services.AudioSystem;
using _Scripts.Services.GameStateMachine;
using _Scripts.Services.GameStateMachine.GameStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;

namespace _Scripts.UI.UIInfrastructure
{
    public class SettingsScreenController : BaseViewController
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly AudioController _audioController;

        public SettingsScreenController(IGameStateMachine gameStateMachine, AudioController audioController)
        {
            _gameStateMachine = gameStateMachine;
            _audioController = audioController;
        }

        public void OnSliderValueChanged(float value)
        {
            _audioController.ChangeVolume(value);
        }
        
        public void OnCloseButtonClicked()
        {
            _gameStateMachine.ChangeState<GameRunState>();
        }
        
        public void OnOpenButtonClicked()
        {
            _gameStateMachine.ChangeState<GamePauseState>();
        }
    }
}