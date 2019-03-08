using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTurm_BubblePlanet
{
    public class Singleton
    {
        public Ball[,] BallTable = new Ball[8, 8];
        public List<Sprite> Objects = new List<Sprite>();


        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return lazy.Value; } }
    }
}
