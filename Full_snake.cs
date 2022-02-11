using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake_cs
{

    class Full_snake: List<Snake_part>
    {
        public Full_snake()
        {
            
        }

        public void display(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < this.Count; i++)
                this[i].draw(spriteBatch);
        }
        public void Add()
        {
            this.Add(new Snake_part(this[this.Count - 1].Position,
            this[0].Content,
            this[0].Screen,
            Direction.none
            ));
        }
        public Boolean snake_collapse()
        {
            for (int i = 1; i < this.Count; i++)
            {
                if (this[0].Position == this[i].Position)
                    return true;
            }
            return false;
        }

        public void update()
        {
            for (int i = this.Count - 1; i > 0; i--)
                this[i].Position = this[i - 1].Position;
            this[0].update();
        }
    }
}
