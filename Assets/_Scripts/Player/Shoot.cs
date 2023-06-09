using System;
using _Scripts.Services;
using _Scripts.SO;
using UnityEngine;

namespace _Scripts.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private VfxConfig _bullet;
        [SerializeField] private Transform _firePoint;
        
        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                {
                    var obj = PoolHub.Instance.GetObject(_bullet);
                        
                    obj.transform.position = _firePoint.position;
                    obj.transform.LookAt(hit.point, Vector3.up);
                }
            }
        }
    }
}