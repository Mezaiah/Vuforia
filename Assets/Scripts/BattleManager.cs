using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{
      [SerializeField]

      private List<Fighter> fighters = new List<Fighter>();
      private int fightersRequired = 2;
      [SerializeField]
      public UnityEvent onBattleStart;
      [SerializeField]
      public UnityEvent onBattleStop;
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
        onBattleStart?.Invoke();
    }
    private void StopBattle()
    {
        onBattleStop?.Invoke();
    }
}
