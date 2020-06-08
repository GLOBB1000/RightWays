using System.Collections;
using System.Collections.Generic;
using Gameplay.Helpers;
using UnityEngine;
using Gameplay.ShipSystems;

public class OutOfBorderPosition : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _representation;

    [SerializeField]
    private GameObject game;

    [SerializeField]
    Transform _transform;
    //метод служит для того, чтобы найти камеру в сцене
    private void Awake()
    {
        GameAreaHelper._camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckBorders();
    }

    private void CheckBorders()
    {
        //проверка позиции игрока, чтобы он не уходил за границы камеры
        transform.position = GameAreaHelper.ClampPosition(transform.position, _representation.bounds);
    }
}
