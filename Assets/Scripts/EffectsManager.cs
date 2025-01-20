using System;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    public event Action<string> OnPlaySound;
    public event Action<string> OnPlayParticle;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(string soundName)
    {
        OnPlaySound?.Invoke(soundName);
        Debug.Log("Playing sound: " + soundName);
    }

    public void PlayParticleEffect(string particleName)
    {
        OnPlayParticle?.Invoke(particleName);
        Debug.Log("Playing particle effect: " + particleName);
    }
}
