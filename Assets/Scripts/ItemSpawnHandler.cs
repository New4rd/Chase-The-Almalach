using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnHandler : MonoBehaviour
{
    static public float convectorSpawnProbability = 50f;
    static public float uraniumSpawnProbability = 50f;
    static public float musicSpawnProbability = 50f;

    [SerializeField] public GameObject convector;
    [SerializeField] public GameObject uranium;
    [SerializeField] public GameObject music;

    private void Start()
    {
        float value = Random.Range(0, 100f);
        if (value > convectorSpawnProbability)
        {
            convector.SetActive(false);
        }
        else
        {
            uranium.SetActive(false);
            music.SetActive(false);
            return;
        }

        value = Random.Range(0, 100f);
        if (value > uraniumSpawnProbability)
        {
            uranium.SetActive(false);
        }
        else
        {
            convector.SetActive(false);
            music.SetActive(false);
            return;
        }

        value = Random.Range(0, 100f);
        if (value > musicSpawnProbability)
        {
            music.SetActive(false);
        }
        else
        {
            convector.SetActive(false);
            uranium.SetActive(false);
            return;
        }
    }
}
