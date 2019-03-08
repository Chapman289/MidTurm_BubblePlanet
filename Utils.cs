using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MidTurm_BubblePlanet
{
    public class Utils
    {
        private static Random random = new Random();

        public static Color RandomColor()
        {
            switch (random.Next(0, 6))
            {
                case 0:
                    return Color.White;
                    
                case 1:
                    return Color.Blue;
                   
                case 2:
                    return Color.Orange;
                   
                case 3:
                    return Color.Red;
                    
                case 4:
                    return Color.Green;
            }
            return Color.White;
        }

        public static bool Collision(Ball A,Ball B)
        {
            return Vector2.Distance(A.Position, B.Position) < A.Texture.Width*0.18f;
        }
    }
}
