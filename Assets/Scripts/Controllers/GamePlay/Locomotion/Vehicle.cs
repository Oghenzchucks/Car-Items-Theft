using System;
using UnityEngine;

namespace Controllers.GamePlay.Locomotion
{
    public abstract class Vehicle : MonoBehaviour
    {
        [SerializeField] private AnimationCurve accelerateCurve;
        [SerializeField] private float speed;

        private float _timeToReachTarget;
        private float _timeElapsed;

        public void StartCar(float distance)
        {
            _timeElapsed = 0;
            _timeToReachTarget = distance / speed;
        }
        
        public void DriveToDestination(Vector3 startPoint, Vector3 endPoint, Action onArrived)
        {
            _timeElapsed += Time.deltaTime;
            var timeRatio = _timeElapsed / _timeToReachTarget;
            transform.position = Vector3.Lerp(startPoint, endPoint, accelerateCurve.Evaluate(timeRatio));
            
            if (!(Vector3.Distance(transform.position, endPoint) < 0.01f))
            {
                return;
            }

            transform.position = endPoint;
            onArrived?.Invoke();
        }
    }
}
