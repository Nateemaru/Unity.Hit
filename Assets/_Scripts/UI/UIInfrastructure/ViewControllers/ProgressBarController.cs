using System;
using _Scripts.UI.UIInfrastructure.BaseComponents;
using UnityEngine;

namespace _Scripts.UI.UIInfrastructure.ViewControllers
{
    public class ProgressBarController : BaseViewController
    {
        public Action<float> OnProgressBarUpdated;

        public void UpdateProgressBar(float value)
        {
            OnProgressBarUpdated?.Invoke(value);
        }
    }
}