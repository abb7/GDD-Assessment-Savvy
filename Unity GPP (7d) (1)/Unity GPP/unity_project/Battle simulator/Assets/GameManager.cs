using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameState;
    public int blueUnitsAlive , redUnitsAlive;
    public Transform playerUnitParent, enemyUnitParent;
    public GameObject ui_winning, ui_mainMenu;
    public TeamManager teamManager;

    private void Start()
    {
        ui_mainMenu.SetActive(true);
        ui_winning.SetActive(false);
        blueUnitsAlive = 5;
        redUnitsAlive = 5;
        teamManager = GameObject.FindGameObjectWithTag("TeamManager").GetComponent<TeamManager>();
    }
    private void Update()
    {
    }
    public void OnGameStart()
    {
        //remove UI
        ui_mainMenu.SetActive(false);
        //Start Game
        gameState = true;
    }

    public void OnGameRestart()
    {
        ui_mainMenu.SetActive(true);
        ui_winning.SetActive(false);
        gameState = false;
        blueUnitsAlive = 5;
        redUnitsAlive = 5;
        teamManager.ResetTeamFormation();
    }

    public void reportDyingUnits(string team) // if fals
    {
        if (team == "BlueTeam")
        {
            blueUnitsAlive -= 1;
        }
        else if (team == "RedTeam")
        {
            redUnitsAlive -= 1;
        }
        if(blueUnitsAlive == 0 || redUnitsAlive == 0)
        {
            ui_winning.SetActive(true);
        }
    }
}
