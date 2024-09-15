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
    public class Score {
        public int score1;
        public int score2;
        private SpriteFont _font;

        public Score(SpriteFont font) {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(_font, score1.ToString(), new Vector2(40, 0), Color.White);
            spriteBatch.DrawString(_font, score2.ToString(), new Vector2(40, 460 -48), Color.White);
        }
    }


}