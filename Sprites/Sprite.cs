using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTurm_BubblePlanet
{
    public class Sprite : ICloneable
    {
        public Texture2D Texture;
        public float Rotation;
        public Vector2 Position;
        public Vector2 Origin;
        public Vector2 Direction;
        public float scale;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 10f;
        public Color color;
        public bool IsRemoved = false;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Origin = new Vector2(texture.Width / 2, 100);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, color, Rotation,Origin, scale, SpriteEffects.None, 0f);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}