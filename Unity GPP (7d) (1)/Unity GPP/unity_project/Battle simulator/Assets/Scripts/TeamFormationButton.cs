using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamFormationButton : MonoBehaviour
{
    private int id;
    TeamManager teamManager;
    private void Start()
    {
        teamManager = GameObject.FindGameObjectWithTag("TeamManager").GetComponent<TeamManager>();
        
    }

    public void setText(int newId)
    {
        id = newId;
        transform.GetChild(0).GetComponent<Text>().text = "Team " + id;
    }
    // Start is called before the first frame update
    public void OnTeamFormationButtonClicked()
    {
        teamManager.ResetEnemyFormation();
        teamManager.LoadTeamFormation(id);
    }
}
