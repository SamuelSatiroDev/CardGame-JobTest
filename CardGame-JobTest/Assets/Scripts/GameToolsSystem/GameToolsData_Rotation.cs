using UnityEngine;

namespace GameToolsSystem
{
    [CreateAssetMenu(fileName = "RotationTools", menuName = "Game Manager/Game Tools System/Rotation")]
    public sealed class GameToolsData_Rotation : GameToolsData_base
    {
        [Header("Random Rotation")]
        [SerializeField] private Vector2 _xRotationRange = new Vector2(0f, 360f);
        [SerializeField] private Vector2 _yRotationRange = new Vector2(0f, 360f);
        [SerializeField] private Vector2 _zRotationRange = new Vector2(0f, 360f);

        public void HandlerRandomRotation(Transform transform)
        {
            float randomX = Random.Range(_xRotationRange.x, _xRotationRange.y);
            float randomY = Random.Range(_yRotationRange.x, _yRotationRange.y);
            float randomZ = Random.Range(_zRotationRange.x, _zRotationRange.y);

            transform.rotation = Quaternion.Euler(randomX, randomY, randomZ);
        }

        public void HandlerRandomLocalRotation(Transform transform)
        {
            float randomX = Random.Range(_xRotationRange.x, _xRotationRange.y);
            float randomY = Random.Range(_yRotationRange.x, _yRotationRange.y);
            float randomZ = Random.Range(_zRotationRange.x, _zRotationRange.y);

            transform.localRotation = Quaternion.Euler(randomX, randomY, randomZ);
        }
    }
}