using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public int HP;
    public int attack;
    public float attackSpeed;
    public float attackRange;
    public float movementSpeed;
    Transform target;
    public string opponentTag;
    private float attackTimer;
    TextMeshPro UI_HP;
    private void Start()
    {
        HP = 100;
        attack = Random.Range(5, 20);
        attackSpeed = Random.Range(0.5f, 3);
        attackRange = Random.Range(0.5f, 2);
        movementSpeed = Random.Range(1, 4);
        UI_HP = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attackTimer = 0;
        }
        if (gameObject.tag == "BlueTeam")
        {
            if (target == null)
                target = FindTarget();
            else
            {
                MoveToward(target);
                if(Vector3.Distance(transform.position, target.position) <= attackRange + 0.1f && attackTimer == 0)
                {
                    Attack();
                }
            }
        }
    }

    private Transform FindTarget()
    {
        //find units 
        GameObject[] targets;
        targets = GameObject.FindGameObjectsWithTag(opponentTag);

        
        return targets[Random.Range(0, targets.Length)].transform;
    }

    public void Attack()
    {
        target.SendMessage("GettingAttacked", attack, SendMessageOptions.DontRequireReceiver);
        attackTimer = attackSpeed;
    }
    public void GettingAttacked(int damege)
    {
        if(HP > damege)
        {
            HP -= damege;
            UI_HP.text = HP.ToString();
        }

        else
        {
            HP = 0;
            Die();
        }
    }

    public void MoveToward(Transform target)
    {

        if (Vector3.Distance(transform.position, target.position) > attackRange)
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed*Time.deltaTime);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
