using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        // сделал камеру public для того чтобы была возможность при рестарте найти ее в сцене, так как до этого при перезапуске ломалась игра
        public static Camera _camera;
        

        static GameAreaHelper()
        {
            _camera = Camera.main;
        }

        
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }


        //Метод ограничивающий x заданного вектора, для того чтобы позиция не выходила за  границы камеры, учитывая размеры объекта
        public static Vector3 ClampPosition(Vector3 position, Bounds objectBounds)
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = position;

            objectPos.x = Mathf.Clamp(objectPos.x, leftBound + objectBounds.extents.x, rightBound - objectBounds.extents.x);

            return objectPos;
        }
    }
}
