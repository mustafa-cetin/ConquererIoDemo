using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class LordBot : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    [SerializeField]
    private D_LordBot lordBotData;

    private Lord lord;
    private Rigidbody2D rb;
    public Seeker Seeker{get;private set;}
    private LayerMask castleLayer;
    private LayerMask villageLayer;
    private LayerMask lordLayer;



    void Start()
    {
        Seeker=GetComponent<Seeker>();
        lord=GetComponent<Lord>();
        rb=GetComponent<Rigidbody2D>();
        stateMachine=new FiniteStateMachine();


        castleLayer=LayerMask.GetMask("Castle");
        villageLayer=LayerMask.GetMask("Village");
        lordLayer=LayerMask.GetMask("Lord");

    }


    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
     private void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }


    public Castle CheckOwnCastlesUnderAttack()
    {
        foreach (Castle item in lord.castles)
        {
            if (item.underAttack == true)
            {
                return item;
            }
        }
        return null;
    }

#region Lord Detect
 public Lord[] GetLordsOfSight()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position,
         lordBotData.enemyLordDetectRange,
         lordLayer);
        Lord[] lords= new Lord[objectsInRange.Length];
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            Lord lord = objectsInRange[i].GetComponent<Lord>();
            lords[i]=lord;
        }
        return lords;
    }





#endregion



 #region Castle Detect

    public Castle[] GetConquarableCastlesOfSight()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position,
         lordBotData.castleDetectRange,
         castleLayer);
        Castle[] castles= new Castle[objectsInRange.Length];
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            Castle castle = objectsInRange[i].GetComponent<Castle>();
            if (lord.canConquer(castle))
            {
                castles[i]=castle;
            }
        }
        return castles;
    }
    public Castle GetMinSoldierCountCastle(){
        Castle[] castles=GetConquarableCastlesOfSight();
        Castle minSoldierCountCastle=null;
        int soldierCount=int.MaxValue;
        foreach (Castle castle in castles)
        {
            if (castle!=null)
            {
                if (soldierCount>castle.garrison)
                {
                    minSoldierCountCastle=castle;
                    soldierCount=castle.garrison;
                }
            }
        }
    return minSoldierCountCastle;
    }



#endregion

#region Village Detect

    public Village[] GetVillagesOfSight()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position,
         lordBotData.villageDetectRange,
         villageLayer);
        Village[] villages= new Village[objectsInRange.Length];
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            Village village = objectsInRange[i].GetComponent<Village>();
            if (village.canTakeSoldier())
            {
                villages[i]=village;
            }
        }
        return villages;
    }

    public Village GetClosestVillage(){
        Village[] villages = GetVillagesOfSight();
        float minDistance=Mathf.Infinity;
        Village closestVillage=null;
        foreach (Village village in villages)
        {
            if (village!=null)
            {
                float distance= Vector2.Distance(transform.position,village.transform.position);
                if (minDistance>distance)
                {
                    minDistance=distance;
                    closestVillage=village;
                }

            }
        }
        return closestVillage;
    }



#endregion



    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lordBotData.enemyLordDetectRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lordBotData.villageDetectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lordBotData.castleDetectRange);
    }
}
