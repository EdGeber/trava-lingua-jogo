using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  private TL TL;
  public PaintBomb BombPrefab;
  private Camera cam;
  [SerializeField] public AbilityManager abilityManager;

  // Start is called before the first frame update
  void Start()
  {
    cam = Camera.main;
    TL = GameObject.Find("/System/TL").GetComponent<TL>();
  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetButtonDown("Bomb")) throwBomb();

    if (Input.GetKeyDown(KeyCode.Mouse1))
    {
      abilityManager.callBigDamageAbility();
    }

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      abilityManager.callSlowEnemiesAbility();
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      abilityManager.callCureAbility();
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
