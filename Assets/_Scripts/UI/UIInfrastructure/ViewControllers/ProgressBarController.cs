using System;
using System.Collections;
using _Scripts.Services.CoroutineRunnerService;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class ProgressBarController : BaseViewController
    {
        private bool _isDone;
        
        //just animation before game starting, in the future, we need to refactor it

        public delegate bool IsFilled();
        public Action<float> OnProgressBarUpdated;
        public IsFilled OnFilled;
        
        public bool IsDone => _isDone;

        private float _loadingStep = 0.02f;

        public void UpdateProgressBar()
        {
            if (OnFilled != null && !(bool)OnFilled?.Invoke())
            {
                OnProgressBarUpdated?.Invoke(_loadingStep);
                _isDone = (bool)OnFilled?.Invoke();
            }
        }
    }
}