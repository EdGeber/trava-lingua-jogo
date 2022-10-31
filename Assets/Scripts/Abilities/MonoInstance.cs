using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoInstance : MonoBehaviour
{
  public static MonoInstance Instance { get; private set; }
  public static float recognitionDelay = 5.0f;

  private void Awake()
  {
    Instance = this;
  }

  private IEnumerator runAfterDelayHelper(System.Action callback, float delay)
  {
    yield return new WaitForSeconds(delay);
    callback();
  }

  public void runAfterDelay(System.Action callback, float delay)
  {
    // if you want to learn about it: https://docs.unity3d.com/Manual/Coroutines.html
    StartCoroutine(runAfterDelayHelper(callback, delay));
  }
}
