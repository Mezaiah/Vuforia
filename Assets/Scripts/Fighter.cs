using UnityEngine;
using UnityEngine.Events;

public class Fighter : MonoBehaviour
{
    [SerializeField]
private UnityEvent onCharacterStart;
private Fighter enemyFighter;

public void OnCharacterStart()
{
onCharacterStart?.Invoke();

}
public void SetEnemyFighter(Fighter enemy)
{
    enemyFighter = enemy;
}


}
