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
//using Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework.Storage;
 
namespace MyGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private AnimatedSprite animatedSprite;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Random Random;
        private Score _score;
        private List<Sprite> _sprites;

        //private Texture2D CarRight;
        //private float angle = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
 
        protected override void Initialize()
        {
            ScreenHeight = 480;
            ScreenWidth = 800; 
            Random = new Random();
            
            base.Initialize();
        }
 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var paddleTexture = Content.Load<Texture2D>("Paddle");
            var ballTexture = Content.Load<Texture2D>("Ball");
            
            _score = new Score(Content.Load<SpriteFont>("Font"));

            _sprites = new List<Sprite> () {
                //new Sprite(Content.Load<Texture2D>("Background")),
                new Paddle(paddleTexture)
                {
                    Position = new Vector2(400 - (paddleTexture.Width / 2), 440),
                    Input = new Input()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                    }
                },
                new Paddle(paddleTexture)
                {
                    Position = new Vector2(400 - (paddleTexture.Width / 2), 20),
                    Input = new Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                    }
                },
                new Ball(ballTexture)
                {
                    Position = new Vector2(400 - (ballTexture.Width /2), (ScreenHeight / 2) - (ballTexture.Height / 2)),
                    score = _score,
                }

            };

            /*
            CarRight = Content.Load<Texture2D>("Car_Right");

            position = new Vector2(200,400); 

            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
            */

        }
 
        protected override void UnloadContent()
        {
        }
 
        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites) {
                sprite.Update(gameTime, _sprites);
            }

            //animatedSprite.Update();
 
            base.Update(gameTime);
        }
 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Maroon);
            
            spriteBatch.Begin();
            foreach (var sprite in _sprites) {
                sprite.Draw(spriteBatch);
            }
            _score.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
            /* CAR MOVING
            spriteBatch.Begin();
            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, CarRight.Width, CarRight.Height);
            Vector2 origin = new Vector2(0, 0);
            spriteBatch.Draw(CarRight, location, sourceRectangle, Color.White, angle, origin, 0.3f, SpriteEffects.None, 1);
            spriteBatch.End();
            */
            
            // SMILEY MOVING
            //animatedSprite.Draw(spriteBatch, position);
 
        }
    }
}