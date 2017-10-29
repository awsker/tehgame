using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace tehgame.game.util
{
    public static class GameDebug
    {
        static GameDebug()
        {
            Messages = new List<string>();
        }

        public static IList<string> Messages { get; }

        public static bool Log(string title, bool value)
        {
            Messages.Add($"{title}: {value}");
            return value;
        }

        public static int Log(string title, int value)
        {
            Messages.Add($"{title}: {value}");
            return value;
        }

        public static float Log(string title, float value)
        {
            Messages.Add($"{title}: {value}");
            return value;
        }

        public static Vector2 Log(string title, Vector2 value)
        {
            Messages.Add($"{title}: X={value.X:0.00}, Y={value.Y:0.00}");
            return value;
        }

        public static Vector3 Log(string title, Vector3 value)
        {
            Messages.Add($"{title}: X={value.X:0.00}, Y={value.Y:0.00}, Z={value.Z:0:00}");
            return value;
        }
    }
}