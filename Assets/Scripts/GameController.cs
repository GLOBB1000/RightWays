using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.Spaceships;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    [SerializeField] private PlayerShipController player;

    [SerializeField] private GameObject RestartPole;

    [SerializeField] Text counter;
    public float count;

    [SerializeField]
    GameObject LifePref;

    [SerializeField]
    List<Transform> enemy;

    private void Awake()
    {
        Time.timeScale = 1;
        count = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerShipController>();
        Spaceship.OnKilled += UpScoreAndinstantiateBonusPrefab;
    }

    private void OnDestroy()
    {
        Spaceship.OnKilled -= UpScoreAndinstantiateBonusPrefab;
    }
    void Update()
    {
        counter.text = "Enemies killed       "  + count.ToString();
        //Проверяем, есть ли игрок в сцене, если его нет общее время ставится в 0
        if (player == null)
        {
            Time.timeScale = 0;
            RestartPole.SetActive(true);
        }

    }

    //Этот метод увеличивает количество убитых врагов в UI.
    public void UpScoreAndinstantiateBonusPrefab()
    {
        count++;
    }

    //Этот метод перезапускает игру.
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
