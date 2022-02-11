using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake_cs
{
    class Snake_part : Sprite
    {
        public Snake_part(Vector2 position, Texture2D content, Rectangle screen, Direction direction) : base(position, content, screen, direction)
        {
            // parameters for Snake_cs only
        }

        public void key_board_input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (direction != Direction.down)
                    direction = Direction.up;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (direction != Direction.up)
                    direction = Direction.down;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (direction != Direction.right)
                    direction = Direction.left;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (direction != Direction.left)
                    direction = Direction.right;
            }
        }

        public void key_board_input2()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (direction != Direction.down)
                    direction = Direction.up;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (direction != Direction.up)
                    direction = Direction.down;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (direction != Direction.right)
                    direction = Direction.left;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (direction != Direction.left)
                    direction = Direction.right;
            }
        }

        protected void teleportation()
        {
            if (position.X < 0)
                position.X = screen.Width - content.Width;

            else if (position.X > screen.Width - content.Width)
                position.X = 0;

            if (position.Y < 0)
                position.Y = screen.Height - content.Height;

            else if (position.Y > screen.Height - content.Height)
                position.Y = 0;
        }

        public override void update()
        {
            switch (direction)
            {
                case Direction.up:
                    position.Y -= 20;
                    break;
                case Direction.down:
                    position.Y += 20;
                    break;
                case Direction.right:
                    position.X += 20;
                    break;
                case Direction.left:
                    position.X -= 20;
                    break;
                case Direction.none:
                    break;
            }
            teleportation();
            base.update();
        }
    }
}
