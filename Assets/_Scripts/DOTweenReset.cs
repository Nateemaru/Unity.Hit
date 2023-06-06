using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
    public class DOTweenReset : MonoBehaviour
    {
        private void Awake()
        {
            DOTween.ClearCachedTweens();
            DOTween.KillAll();
            DOTween.Clear();
        }
    }
}