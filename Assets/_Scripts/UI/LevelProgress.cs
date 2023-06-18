using _Scripts.Gameplay.Camera;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class LevelProgress : MonoBehaviour, IEnemyGroupSubscriber
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private float _duration;

        private int _enemiesGroupsCount;

        private void Start()
        {
            EventBus.Subscribe(this);
            _enemiesGroupsCount = FindObjectsOfType<TargetGroupContainer>().Length;
            _fillImage.fillAmount = 0;
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnGroupIsEmpty()
        {
            var amount = 1f / _enemiesGroupsCount;
            _fillImage.DOFillAmount(_fillImage.fillAmount + amount, _duration);
        }
    }
}