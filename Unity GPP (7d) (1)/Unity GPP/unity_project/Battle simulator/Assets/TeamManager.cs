using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

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

    public Team[] teams;
    public Transform playerUnitParent;
    public Transform enemyUnitParent;
    //UI Construction
    public GameObject UI_TeamContainer;
    public GameObject teamButton;

    // Start is called before the first frame update
    void Start()
    {
        isTeamsAreFormed = false;
        ConstructTeamFormationUI();


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
    public void ConstructTeam(GameObject prefab, float xStart, float yStart, int id, Transform parent)
    {

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            if (teams[id].teamFormation[i])
            {
                GameObject unit = Instantiate(prefab, new Vector3(xStart + (x_space * (i % columnLength)), 1, -yStart + (y_space * (i / columnLength))), Quaternion.identity);
                unit.transform.SetParent(parent);
            }
        }
        isTeamsAreFormed = true;
    }

    public void ConstructTeamFormationUI()
    {
        if (File.Exists(Application.dataPath + "/config.txt"))
        {
            string loadString = File.ReadAllText(Application.dataPath + "/config.txt");
            teams = JsonHelper.FromJson<Team>(loadString);
            LoadTeamFormation(0);
            LoadTeamFormation(1);

            //create enemy Team Formation UI
            for (int i = 1; i< teams.Length; i++)
            {
                GameObject newButton = Instantiate(teamButton, UI_TeamContainer.transform);
                newButton.GetComponent<TeamFormationButton>().setText(i);
            }
        }
    }

    public void LoadTeamFormation(int id)
    {
        if (id == 0)
        {
            ConstructTeam(Player, -9, 2, id, playerUnitParent);
        }
        else
        {
            ConstructTeam(enemy, 5, 2, id, enemyUnitParent);
        }
    }

    public void ResetEnemyFormation()
    {
        foreach (Transform child in enemyUnitParent)
        {
            Destroy(child.gameObject);
        }
    }


}
