using System;
using UnityEngine;
using UnityEngine.Events;

public class DanceManager : MonoBehaviour
{
[SerializeField]
private string[] danceNames;
[SerializeField] 
private string[] songNames;
[SerializeField] 
private Animator character;
[SerializeField] 
private UnityEvent<Transform> onDanceStart;
private int currentDanceIndex = 0;

public void PlayNextDance()
{
    onDanceStart?.Invoke(character.transform);
character.Play(danceNames[currentDanceIndex]);
SoundManager.instance.PlayMusic(songNames[currentDanceIndex]);
}

public void NextDance()
{
currentDanceIndex++;
SoundManager.instance.StopMusic();
if (currentDanceIndex >= danceNames.Length)
{
currentDanceIndex = 0;
}
}
}
