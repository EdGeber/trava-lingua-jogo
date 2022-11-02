using System.Collections;
using UnityEngine;
using System;

// tongue twister API
// TL stands for trava-língua
public class TL : MonoBehaviour
{
  const float EPSILON = (float)1e-6;

  public static TL TLInstance;
  public static float recognitionDelay = 5.0f;

  private void Awake()
  {
    // If there is an instance, and it's not me, delete myself.

    if (TLInstance != null && TLInstance != this)
    {
      Destroy(this);
    }
    else
    {
      TLInstance = this;
    }
  }

  // DO NOT ADD NON-STATIC PROPERTIES!!!

  [System.Flags]
  public enum Direction
  {
    None = 0b0000,            //  0
    Up = 0b0001,            //  1
    Down = 0b0010,            //  2
    Right = 0b0100,            //  4
    Left = 0b1000,            //  8
    UpRight = Up | Right,  //  5
    UpLeft = Up | Left,   //  9
    DownRight = Down | Right,  //  6
    DownLeft = Down | Left    // 10
  }

  public Direction directionOf(Vector2 v)
  {
    Direction d = Direction.None;

    //                      d = d | Direction.Right
    if (v.x > EPSILON) d |= Direction.Right;
    else if (v.x < -EPSILON) d |= Direction.Left;

    if (v.y > EPSILON) d |= Direction.Up;
    else if (v.y < -EPSILON) d |= Direction.Down;

    return d;
  }

  private IEnumerator runAfterDelayHelper(System.Action callback, float delay)
  {
    // This works as expected even if the game pauses;
    // see https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
    yield return new WaitForSeconds(delay);
    callback();
  }

  public void runAfterDelay(System.Action callback, float delay)
  {
    // if you want to learn about it: https://docs.unity3d.com/Manual/Coroutines.html
    StartCoroutine(runAfterDelayHelper(callback, delay));
  }


  static string[] travalinguas = System.IO.File.ReadAllLines(@"Assets/Scripts/TRAVALINGUAS/TRAVALINGUAS.txt");
  static System.Random rnd = new System.Random();

  public static string pegaTravaLinguas()
  {
    return travalinguas[rnd.Next(travalinguas.Length)];
  }
}