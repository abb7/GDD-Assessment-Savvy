using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TeamManager : MonoBehaviour
{
    [Serializable]
    public class Team
    {
        public int teamId;
        public bool[] teamFormation = new bool[9];
    }

    public int columnLength, rowLength;
    public float x_space, y_space;
    public GameObject Player;
    public GameObject enemy;
    public int availableTroops;
    bool isTeamsAreFormed;

    public Team[] teamtest;
    // Start is called before the first frame update
    void Start()
    {
        isTeamsAreFormed = false;

        if (File.Exists(Application.dataPath + "/config.txt"))
        {
            string loadString = File.ReadAllText(Application.dataPath + "/config.txt");
            Team[] teams = JsonHelper.FromJson<Team>(loadString);
            Debug.Log(teams[0].teamId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {
        if (isTeamsAreFormed)
        {

        }

    }


    //Create a specific team formation for the enemy team
    public void ConstructTeam(GameObject prefab, float startArea, float endArea, int amount)
    {

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(Player, new Vector3(x_space * (i % columnLength), y_space * (i % columnLength)), Quaternion.identity);
        }
        isTeamsAreFormed = true;
    }

    public void ConstructTeamFormationUI()
    {

    }

    public void LoadTeamFormation(int id)
    {

    }

    public void Save()
    {
        if (File.Exists(Application.dataPath + "/config.txt"))
        {

        }
    }
}
