using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
  public static SoundEffectsManager instanceSEM { get; private set; }
  [SerializeField] public AudioSource slowAudioSource;
  [SerializeField] public AudioSource freezeAudioSource;
  [SerializeField] public AudioSource bigDamageAudioSource;
  [SerializeField] public AudioSource healAudioSource;

  private void Awake()
  {
    instanceSEM = this;
  }

  public void playSlowAudio()
  {
    this.slowAudioSource.Play();
  }

  public void playFreezeAudio()
  {
    this.freezeAudioSource.Play();
  }

  public void playBigDamageAudio()
  {
    this.bigDamageAudioSource.Play();
  }

  public void playHealAudio()
  {
    this.healAudioSource.Play();
  }
}
