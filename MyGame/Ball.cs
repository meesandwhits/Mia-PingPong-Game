using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyGame {

    public class Ball : Sprite {
        
        private float _timer = 0f;
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        public Score score;
        public int SpeedIncrementSpan = 10;

        public Ball(Texture2D texture) : base(texture) {
            Speed = 3f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            if (_startPosition == null) {
                _startPosition = Position;
                _startSpeed = Speed;
                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                _isPlaying = true;
            }

            if (!_isPlaying) {
                return;
            }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > SpeedIncrementSpan) {
                Speed++;
                _timer =0;
            }

            foreach (var sprite in sprites) {
                if (sprite == this) {
                    continue;
                }

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) {
                    this.Velocity.X = -this.Velocity.X;
                }
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite)) {
                    this.Velocity.X = -this.Velocity.X;
                }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) {
                    this.Velocity.Y = -this.Velocity.Y;
                }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)) {
                    this.Velocity.Y = -this.Velocity.Y;
                }
            }

                if (Position.X <= 0 || Position.X + _texture.Width >= Game1.ScreenWidth) { //I CHANGED THIS
                    Velocity.X = -Velocity.X; //I CHANGED THIS
                }

                if (Position.Y <= 0) { //I CHANGED THIS
                    score.score2++;
                    Restart();
                }

                if (Position.Y + _texture.Height >= Game1.ScreenHeight) { //I CHANGED THIS
                    score.score1++;
                    Restart();
                }

                Position += Velocity * Speed;
        }

        public void Restart() {
            var direction = Game1.Random.Next(0,4);
            
            switch(direction) {
                case 0:
                    Velocity = new Vector2(1,1);
                    break;
                case 1:
                    Velocity = new Vector2(1,-1);
                    break;
                case 2:
                    Velocity = new Vector2(-1,-1);
                    break;
                case 3:
                    Velocity = new Vector2(-1,1);
                    break;  

            }
            Position = (Vector2)_startPosition;
            Speed = (float)_startSpeed;
            _timer = 0;
            _isPlaying = false;
        }

    }
}