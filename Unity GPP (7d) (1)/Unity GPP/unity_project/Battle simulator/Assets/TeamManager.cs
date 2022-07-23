using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public int columnLength, rowLength;
    public float x_space, y_space;
    public GameObject Player;
    public GameObject enemy;
    public int availableTroops;
    // Start is called before the first frame update
    void Start()
    {
        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {
        

    }

    public void ConstructTeam(GameObject prefab, float startArea, float endArea, int amount)
    {

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(Player, new Vector3(x_space * (i % columnLength), y_space * (i % columnLength)), Quaternion.identity);
        }
    }
}
