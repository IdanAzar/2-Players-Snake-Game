using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Snake_cs
{
    // abstract - for YERUSHA
    abstract class Sprite
    {
       protected Vector2 position;
       protected Texture2D content;
       protected Rectangle screen;
       protected Direction direction;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Texture2D Content
        {
            get { return content; }
            set { content = value; }
        }
        public Rectangle Screen
        {
            get { return screen; }
            set { screen = value; }
        }
        public Sprite(Vector2 position, Texture2D content, Rectangle screen, Direction direction)
        {
            this.position = position;
            this.content = content;
            this.screen = screen;
            this.direction = direction;
        }

        // overide func
        public virtual void draw(SpriteBatch spriteBatch)
        {
            // Texture2D texture, Vector2 position, Color color
            spriteBatch.Draw(content, position, Color.White);

        }

        public virtual void update()
        {
           // TO DO
        }
    }
}
