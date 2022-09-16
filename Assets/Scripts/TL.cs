using UnityEngine;

// tongue twister API
// TL stands for trava-língua
public static class TL {
    const float EPSILON = (float) 1e-6;

    [System.Flags]
    public enum Direction
    {
        None  = 0b0000,            //  0
        Up    = 0b0001,            //  1
        Down  = 0b0010,            //  2
        Right = 0b0100,            //  4
        Left  = 0b1000,            //  8
        UpRight   = Up   | Right,  //  5
        UpLeft    = Up   | Left,   //  9
        DownRight = Down | Right,  //  6
        DownLeft  = Down | Left    // 10
    }

    public static Direction directionOf(Vector2 v) {
        Direction d = Direction.None;
        
        //                      d = d | Direction.Right
        if(v.x > EPSILON)       d |= Direction.Right;
        else if(v.x < -EPSILON) d |= Direction.Left;

        if(v.y > EPSILON)       d |= Direction.Up;
        else if(v.y < -EPSILON) d |= Direction.Down;

        return d;
    }
}