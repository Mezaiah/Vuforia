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
      private float secondsToAttacks = 1f;
    
      [SerializeField]
      public UnityEvent onBattleStart;
      [SerializeField]
      public UnityEvent onBattleStop;
      private int currentfighterIndex = 0;
      private bool isBattleActive = false;


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
            StartBattle();
        }
      }

    private void StartBattle()
    {
       isBattleActive = true;
        onBattleStart?.Invoke();
       StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {

        currentfighterIndex =Random.Range(0,fighters.Count);
        Fighter attacker = fighters[currentfighterIndex];
        Fighter defender;
        do
        {
            currentfighterIndex =Random.Range(0,fighters.Count);
            defender = fighters[currentfighterIndex];
        } while (attacker == defender);
        attacker.Attack();
        float damage =attacker.GetDamage();
        defender.GetComponent<Health>().TakeDamage(damage);

        yield return new WaitForSeconds(secondsToAttacks);
        if(defender.GetComponent<Health>().CurrentHealth>0)
        {
            StartCoroutine(Attack());
        }else 
        {
            StopBattle();
        }
   }
    
    private void StopBattle()
    {
        onBattleStop?.Invoke();
    }
    
}
