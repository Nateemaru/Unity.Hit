using _Scripts.Services.AudioSystem;
using _Scripts.Services.StateMachines.LevelStateMachine;
using _Scripts.Services.StateMachines.LevelStateMachine.LevelStates;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class SettingsScreenController : BaseViewController
    {
        private readonly ILevelStateMachine _levelStateMachine;
        private readonly AudioController _audioController;

        public SettingsScreenController(ILevelStateMachine levelStateMachine, AudioController audioController)
        {
            _levelStateMachine = levelStateMachine;
            _audioController = audioController;
        }

        public void OnSliderValueChanged(float value)
        {
            _audioController.ChangeVolume(Mathf.Lerp(-80, 0, value));
        }
        
        public void OnCloseButtonClicked()
        {
            _levelStateMachine.ChangeState<LevelRunState>();
        }
        
        public void OnOpenButtonClicked()
        {
            _levelStateMachine.ChangeState<LevelPauseState>();
        }
    }
}