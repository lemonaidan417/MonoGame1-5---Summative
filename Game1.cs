using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame1_5___Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D roadTexture;
        
        Texture2D astonmartinTexture;
        Texture2D audiTexture;
        Texture2D bugattiTexture;
        Texture2D carreraTexture;
        Texture2D corvetteTexture;
        Texture2D mercedesTexture;
        Texture2D porscheTexture;
        Texture2D supraTexture;
        Texture2D viperTexture;


        Rectangle window;
        Rectangle roadRect;
        Rectangle roadRect2;
        Rectangle astonmartinRect;
        Rectangle audiRect;
        Rectangle bugattiRect;
        Rectangle carreraRect;
        Rectangle corvetteRect;
        Rectangle mercedesRect;
        Rectangle porscheRect;
        Rectangle supraRect;
        Rectangle viperRect;

        Vector2 roadSpeed;
        Vector2 porscheSpeed;
        Vector2 carRSpeed;
        Vector2 carLSpeed;

        Random generator = new Random();

        float seconds;

        int laneChoice;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 423, 700);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            astonmartinRect = new Rectangle(130, -700, 70, 150); // L
            audiRect = new Rectangle(50, -1000, 70, 150); // L
            bugattiRect = new Rectangle(130, -1400, 70, 150); // L
            carreraRect = new Rectangle(50, -300, 70, 150); // L
            corvetteRect = new Rectangle(130, -100, 70, 150); // L
            mercedesRect = new Rectangle(220, 110, 70, 150); // R
            porscheRect = new Rectangle(210, 450, 256, 256); // R
            supraRect = new Rectangle(220, 10, 70, 150); // R
            viperRect = new Rectangle(220, 10, 70, 150); // R

            porscheSpeed = new Vector2(0, 3);
            carRSpeed = new Vector2(0, 1);
            carLSpeed = new Vector2(0, -8);

            roadRect = new Rectangle(0, 0, window.Width, window.Height);
            roadRect2 = new Rectangle(0, -697, window.Width, window.Height);
            roadSpeed = new Vector2(0, -10);

            laneChoice = 0;

            seconds = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            roadTexture = Content.Load<Texture2D>("road");
            astonmartinTexture = Content.Load<Texture2D>("pixel-astonmartin");
            audiTexture = Content.Load<Texture2D>("pixel-audi");
            bugattiTexture = Content.Load<Texture2D>("pixel-bugatti");
            carreraTexture = Content.Load<Texture2D>("pixel-carrera");
            corvetteTexture = Content.Load<Texture2D>("pixel-corvette");
            mercedesTexture = Content.Load<Texture2D>("pixel-mercedes");
            porscheTexture = Content.Load<Texture2D>("pixel-porsche");
            supraTexture = Content.Load<Texture2D>("pixel-supra");
            viperTexture = Content.Load<Texture2D>("pixel-viper");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Left Cars
            {
                // Driving Loops
                {
                    if (astonmartinRect.Top > window.Height)
                    {
                        astonmartinRect.Y -= window.Height + generator.Next(10, 1500);
                    }
                    if (audiRect.Top > window.Height)
                    {
                        audiRect.Y -= window.Height + generator.Next(10, 1500);
                    }
                    if (bugattiRect.Top > window.Height)
                    {
                        bugattiRect.Y -= window.Height + generator.Next(10, 1500);
                        laneChoice = generator.Next(0, 1);
                        if (laneChoice == 0)
                        {
                            bugattiRect.X = 50;
                        }
                        else
                        {
                            bugattiRect.X = 130;
                        }
                    }
                    if (carreraRect.Top > window.Height)
                    {
                        carreraRect.Y -= window.Height + generator.Next(10, 1500);
                    }
                    if (corvetteRect.Top > window.Height)
                    {
                        corvetteRect.Y -= window.Height + generator.Next(10, 1500);
                    }

                    astonmartinRect.Y -= (int)carLSpeed.Y;
                    audiRect.Y -= (int)carLSpeed.Y;
                    bugattiRect.Y -= (int)carLSpeed.Y;
                    carreraRect.Y -= (int)carLSpeed.Y;
                    corvetteRect.Y -= (int)carLSpeed.Y;
                }
                if (seconds <= 5)
                {
                    carLSpeed.Y = -20;
                }
                else
                {
                    carLSpeed.Y = -15;
                }
            }

            // Right Cars
            {
                // Driving 
                {
                    if (mercedesRect.Bottom > window.Height)
                    {
                        mercedesRect.Y += window.Height + 150;
                    }
                    if (mercedesRect.Top > window.Height)
                    {
                        mercedesRect.Y -= window.Height + 150;
                    }
                    if (mercedesRect.Top > window.Height)
                    {
                        mercedesRect.Y -= window.Height + 150;
                    }

                    mercedesRect.Y -= (int)carRSpeed.Y;
                    supraRect.Y -= (int)carRSpeed.Y;
                    viperRect.Y -= (int)carRSpeed.Y;
                }
                if (seconds <= 5)
                {
                    carRSpeed.Y = 1;
                }
                else
                {
                    carRSpeed.Y = 8;
                }
            }

            // Main Car
            {
                if (seconds <= 5)
                {
                    porscheRect.Y -= (int)porscheSpeed.Y;

                    roadRect.Y -= (int)roadSpeed.Y;
                    if (roadRect.Top > window.Height)
                    {
                        roadRect.Y -= roadRect.Height + 694;
                    }
                    roadRect2.Y -= (int)roadSpeed.Y;
                    if (roadRect2.Top > window.Height)
                    {
                        roadRect2.Y -= roadRect2.Height + 694;
                    }
                }
                else
                {
                    roadSpeed.Y = 0;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            _spriteBatch.Draw(roadTexture, roadRect, Color.White);
            _spriteBatch.Draw(roadTexture, roadRect2, Color.White);
            _spriteBatch.Draw(astonmartinTexture, astonmartinRect, Color.White);
            _spriteBatch.Draw(audiTexture, audiRect, Color.White);
            _spriteBatch.Draw(bugattiTexture, bugattiRect, Color.White);
            _spriteBatch.Draw(carreraTexture, carreraRect, Color.White);

            _spriteBatch.Draw(corvetteTexture, corvetteRect, Color.White);
            _spriteBatch.Draw(mercedesTexture, mercedesRect, Color.White);
            _spriteBatch.Draw(porscheTexture, porscheRect, Color.White);
            _spriteBatch.Draw(supraTexture, supraRect, Color.White);
            _spriteBatch.Draw(viperTexture, viperRect, Color.White);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}