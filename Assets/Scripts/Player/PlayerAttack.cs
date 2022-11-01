using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  private TL TL;
  public PaintBomb BombPrefab;
  private Camera cam;
  [SerializeField] public AbilityManager abilityManager;

  void Start()
  {
    cam = Camera.main;
    TL = GameObject.Find("/System/TL").GetComponent<TL>();
    abilityManager.StartWithAbilitiesReady();
  }

  void Update()
  {
    if (!PauseBehaviour.GameIsPaused)
    {
      if (Input.GetButtonDown("Bomb")) throwBomb();

      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        abilityManager.callBigDamageAbility();
      }

      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        abilityManager.callSlowEnemiesAbility();
      }
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
        abilityManager.callCureAbility();
      }
      if (Input.GetKeyDown(KeyCode.Alpha4))
      {
        abilityManager.callFreezeAbility();
      }
    }
  }

  void throwBomb()
  {
    // Transforms the Screen position to World position using the current mouse position
    // Reference: https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
    Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
    Instantiate(BombPrefab, mouseWorldPos, transform.rotation);
  }
}
