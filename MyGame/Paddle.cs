using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyGame {
    public class Paddle : Sprite {
        public Paddle(Texture2D texture) : base(texture) {
            Speed = 7f;
        }

        public override void Update(GameTime gametime, List<Sprite> sprites) {
            if (Input == null) {
                throw new Exception("Please give a value to Input");
            }


            if (Keyboard.GetState().IsKeyDown(Input.Left)) {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right)) {
                Velocity.X = Speed;
            }

            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - _texture.Width);

            Velocity = Vector2.Zero;
        }
    }
}
