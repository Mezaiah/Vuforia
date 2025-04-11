using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{
      [SerializeField]

      private List<Fighter> fighters = new List<Fighter>();
      private int fightersRequired = 2;
      [SerializeField]
      private float secondsBetweenAttacks = 1f;
    
         [SerializeField]
      private float secondsToStartBattle = 1f;
      [SerializeField]
      private float secondsToAttacks = 1f;
    
      [SerializeField]
      public UnityEvent onBattleStart;
      [SerializeField]
      public UnityEvent onBattleStop;
      [SerializeField]
      private UnityEvent onBattleEnd;
      [SerializeField]
      private UnityEvent<string> onFighterWin;
      private int currentfighterIndex = 0;
      private bool isBattleActive = false;
      private Coroutine attackCoRoutine;


      public void AddFighter(Fighter fighter)
      {
        fighters.Add(fighter);
        CheckFighters();
      }
      public void RemoveFighter(Fighter fighter)
      {
        fighters.Remove(fighter);
        CheckFighters();
      }

      private void CheckFighters()
      {
        if (fighters.Count < fightersRequired)
        {
            StopBattle();
        }
        else
        {
            Invoke ("StartBattle", secondsToStartBattle);
        }
      }

    private void StartBattle()
    {
      if (isBattleActive || fighters.Count < fightersRequired)
      {
        return;
      }
       isBattleActive = true;
        onBattleStart?.Invoke();
       attackCoRoutine =  StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
      if (!isBattleActive)
      {
        yield break;
      }

        currentfighterIndex =Random.Range(0,fighters.Count);
        Fighter attacker = fighters[currentfighterIndex];
        Fighter defender;
        do
        {
            currentfighterIndex =Random.Range(0,fighters.Count);
            defender = fighters[currentfighterIndex];
        } while (attacker == defender);

        attacker.transform.LookAt(defender.transform.position);
        defender.transform.LookAt(attacker.transform.position);
        attacker.Attack();
        yield return new WaitForSeconds(attacker.attackDuration);
        float damage =attacker.GetDamage();
        defender.GetComponent<Health>().TakeDamage(damage);

        yield return new WaitForSeconds(secondsToAttacks);
        if(defender.GetComponent<Health>().CurrentHealth>0)
        {
           attackCoRoutine = StartCoroutine(Attack());
        }else 
        {
        BattleFinish(attacker.FighterName);
        }
   }
    
    private void BattleFinish(string winnerName)
    {
    onBattleEnd?.Invoke();
            StopBattle();
            onFighterWin?.Invoke(winnerName);
    }
    private void StopBattle()
    {

      isBattleActive = false;
        if (attackCoRoutine != null)
        {
          StopCoroutine(attackCoRoutine);
          attackCoRoutine = null;
        }
        
        onBattleStop?.Invoke();

    }
    
}
