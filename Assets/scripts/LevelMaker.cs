using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelMaker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalNoOfCubesText;

    [SerializeField] GameObject[] cubes;
    [SerializeField] Transform[] positions;
    [SerializeField] Quaternion[] rotations =
        {
            Quaternion.Euler(0,90,0),
            Quaternion.Euler(90,90,0),
            Quaternion.Euler(180,90,0),
            Quaternion.Euler(270,90,0),
            Quaternion.Euler(45,90,0),
            Quaternion.Euler(-45,90,0),
            Quaternion.Euler(-135,90,0),
            Quaternion.Euler(135,90,0),
        };

    [SerializeField] float spawnTime=3f;
    [SerializeField] float levelStartAfterTime=3f;
    private bool levelStarted = false;

    private float timer = 0f;
    private int totalNoOfCubes = 0;
    private void Start()
    {
        GameManager.Instance.onGameOver += GameManager_onGameOver;
    }

    private void GameManager_onGameOver(object sender, System.EventArgs e)
    {
        totalNoOfCubesText.text = totalNoOfCubes.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= levelStartAfterTime && !levelStarted) { timer = 0f; levelStarted = true; }

        if (levelStarted)
        {
            if (timer >= spawnTime)
            { Instantiate(cubes[Random.Range(0,cubes.Length)], positions[Random.Range(0, positions.Length)].position, rotations[Random.Range(0, rotations.Length)] );
                timer = 0f;
                totalNoOfCubes++;
            }
        }
    }

}
