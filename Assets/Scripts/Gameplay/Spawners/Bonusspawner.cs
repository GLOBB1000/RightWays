using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonusspawner : MonoBehaviour
{
    [SerializeField]
    GameObject Bonus;

    [SerializeField]
    Transform _parent;


    private void OnDestroy()
    {
        var random = Random.Range(1, 5);
        if (random == 4)
        {
            Instantiate(Bonus, transform.position, transform.rotation);
        }
    }
}
