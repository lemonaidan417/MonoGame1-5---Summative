using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame1_5___Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D roadTexture;

        Rectangle window;
        Rectangle roadRect;
        Rectangle roadRect2;

        Vector2 roadSpeed;

        int passes;
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



            roadRect = new Rectangle(0, 0, window.Width, window.Height);
            roadRect2 = new Rectangle(0, -697, window.Width, window.Height);
            roadSpeed = new Vector2(0, -9);

            passes = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            roadTexture = Content.Load<Texture2D>("road");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            roadRect.Y -= (int)roadSpeed.Y;
            if (roadRect.Top > window.Height)
            {
                passes++;
                roadRect.Y -= roadRect.Height + 694;
            }
            roadRect2.Y -= (int)roadSpeed.Y;
            if (roadRect2.Top > window.Height)
            {
                passes++;
                roadRect2.Y -= roadRect2.Height + 694;
            }

            if (passes >= 2)
            {
                
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




            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}