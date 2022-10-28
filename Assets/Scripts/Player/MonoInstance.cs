using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoInstance : MonoBehaviour
{
  public static MonoInstance Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
  }
}
