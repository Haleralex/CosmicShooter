using UnityEngine;

namespace Project.Scripts.Helpers
{
    public interface IMovable
    {
        void SetPositionAndRotation(Vector3 targetPosition, Quaternion rotation);
        void Move(Vector3 direction, float speed);
    }
}
