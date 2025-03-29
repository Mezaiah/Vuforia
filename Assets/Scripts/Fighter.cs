using UnityEngine;
using UnityEngine.Events;

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
