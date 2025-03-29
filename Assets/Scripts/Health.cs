using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
[SerializeField]
private int maxHealth = 100;
[SerializeField]
private UnityEvent<float> onHealthChange;
[SerializeField]
private UnityEvent onDeath;

[SerializeField]
private UnityEvent onDmgReceived;
[SerializeField]

private float currentHealth;
public float CurrentHealth=> currentHealth;

public void InitializeHealth()
{
    SetHealth(maxHealth);
}
private void SetHealth(float Health)
{
    currentHealth = Health;
    onHealthChange?.Invoke(currentHealth/maxHealth);

}
public void TakeDamage(float dmg)
{
    SetHealth(currentHealth - dmg);
    if (currentHealth <=0)
    {
        Die();
    } else
    {
        onDmgReceived?.Invoke();
    }
}
private void Die()
{

}
}
