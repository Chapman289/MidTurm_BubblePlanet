using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTurm_BubblePlanet
{
    public class Singleton
    {
        public List<Sprite> Objects = new List<Sprite>();


        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return lazy.Value; } }
    }
}
