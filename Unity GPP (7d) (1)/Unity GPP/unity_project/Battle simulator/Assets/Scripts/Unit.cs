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
    private GameManager gameManager;
    private void Start()
    {
        HP = 100;
        attack = Random.Range(5, 20);
        attackSpeed = Random.Range(0.5f, 3);
        attackRange = Random.Range(0.5f, 2);
        movementSpeed = Random.Range(1, 4);
        UI_HP = GetComponentInChildren<TextMeshPro>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.gameState)
            return;
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
            if (target == null )
                target = FindTarget();
            else
            {
                MoveToward(target);   
            }
        }
        if (target && Vector3.Distance(transform.position, target.position) <= attackRange + 0.1f && attackTimer == 0)
        {
            Attack();
        }
    }

    private Transform FindTarget()
    {
       
        //find units 
        GameObject[] targets;
        targets = GameObject.FindGameObjectsWithTag(opponentTag);
        if (targets.Length <= 0)
            return null;
        
        return targets[Random.Range(0, targets.Length)].transform;
    }

    public void Attack()
    {
        Attacker attacker = new Attacker(attack, transform);
        target.SendMessage("GettingAttacked", attacker, SendMessageOptions.DontRequireReceiver);
        attackTimer = attackSpeed;
    }
    public void GettingAttacked(Attacker attacker)
    {
        if(tag == "RedTeam")
            if (target == null)
                target = attacker.attackerTransform;

        if(HP > attacker.damege)
        {
            HP -= attacker.damege;
            UI_HP.text = HP.ToString();
        }

        else
        {
            HP = 0;
            Die(tag);
        }
    }

    public void MoveToward(Transform target)
    {

        if (Vector3.Distance(transform.position, target.position) > attackRange)
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed*Time.deltaTime);
    }

    public void Die(string tag)
    {
        gameManager.reportDyingUnits(tag);
        Destroy(gameObject);
    }

    public class Attacker
    {
        
        public int damege;
        public Transform attackerTransform;

        public Attacker(int d, Transform t)
        {
            damege = d;
            attackerTransform = t;
        }
    }

   
}
