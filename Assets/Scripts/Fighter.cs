using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class Fighter : MonoBehaviour
{
    [SerializeField]
private UnityEvent onCharacterStart;
private Fighter enemyFighter;
[SerializeField]
private UnityEvent onAttack;

[SerializeField]
public float minDmg = 5f;

[SerializeField]
public float maxDmg = 50f;

[SerializeField]
private string fighterName = "Fighter";
public string FighterName => fighterName;
private float AttackDuration = 1f;
public float attackDuration => AttackDuration;

public void OnCharacterStart()
{
onCharacterStart?.Invoke();

}
public void SetEnemyFighter(Fighter enemy)
{
    enemyFighter = enemy;
}
public void Attack()
{
onAttack?.Invoke();
}

public float GetDamage()
{
return Random.Range(minDmg,maxDmg);
}
}
