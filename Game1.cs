using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Snake_cs
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // screen params
        private Rectangle screen;
        int screen_width = 800;
        int screen_hight = 800;

        // snakes params
        private Full_snake snake1;
        private Full_snake snake2;
        Random rnd;
        int part_size = 20;

        // fruit params
        private Fruit fruit;


        // timer 
        float timer = 0;
        float delay = 80;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_hight;
            screen = new Rectangle(0, 0, screen_width, screen_hight);
            rnd = new Random();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snake1 = new Full_snake();
            snake1.Add(new Snake_part(new Vector2(rnd.Next(0, screen_width / part_size) * part_size, rnd.Next(0, screen_hight / part_size) * part_size),
                Content.Load<Texture2D>("red"),
                screen,
                Direction.right
                ));

            snake2 = new Full_snake();
            snake2.Add(new Snake_part(new Vector2(rnd.Next(0, screen_width / part_size) * part_size, rnd.Next(0, screen_hight / part_size) * part_size),
                Content.Load<Texture2D>("green"),
                screen,
                Direction.right
                ));

            fruit = new Fruit(new Vector2(rnd.Next(0, screen_width / part_size) * part_size, rnd.Next(0, screen_hight / part_size) * part_size),
                Content.Load<Texture2D>("green"),
                screen,
                Direction.none
                );

            // giving parts for each snake
            for(int i = 0; i < 5; i++)
            {
                snake1.Add();
                snake2.Add();
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            snake1[0].key_board_input();
            snake2[0].key_board_input2();
            timer += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);
            if (timer > delay)
            {
                if (fruit.Position == snake1[0].Position)
                {
                    // change fruit pos
                    fruit.Position = new Vector2(rnd.Next(0, screen_width / part_size) * part_size, rnd.Next(0, screen_hight / part_size) * part_size);
                    // increase snake part
                    snake1.Add();
                }

                if (fruit.Position == snake2[0].Position)
                {
                    // change fruit pos
                    fruit.Position = new Vector2(rnd.Next(0, screen_width / part_size) * part_size, rnd.Next(0, screen_hight / part_size) * part_size);
                    // increase snake part
                    snake2.Add();
                }

                snake1.update();
                snake2.update();

                // game end
                if (snake1.snake_collapse() || snake2.snake_collapse() || snakes_touch())
                    LoadContent();

                timer = 0;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            fruit.draw(spriteBatch);
            snake1.display(spriteBatch);
            snake2.display(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected Boolean snakes_touch()
        {
            // cheack head's first to the seconde body and head
            for(int i = 0; i < snake2.Count; i++)
            {
                if (snake1[0].Position == snake2[i].Position)
                    return true;
            }

            // cheack head's seconde to the first body and head
            for (int i = 0; i < snake1.Count; i++)
            {
                if (snake2[0].Position == snake1[i].Position)
                    return true;
            }

            // they don't touch each other
            return false;
        }
    }
}
