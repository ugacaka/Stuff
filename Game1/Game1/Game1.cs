using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#pragma warning disable CS0618
namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D igrac;
        Vector2 pozIgraca;
        Color[] bojaIgraca;
        bool levo, desno,naZemlji,skok=false;
        KeyboardState previousState;
        float p=17;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            pozIgraca= new Vector2(0, 0);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            igrac = new Texture2D(GraphicsDevice, 20, 50);
            bojaIgraca = new Color[20 * 50];
            for (int i = 0; i < 1000; i++)
                bojaIgraca[i] = new Color(50, 127, (i*5 / 20) % 255);
            igrac.SetData(bojaIgraca);
            previousState = Keyboard.GetState();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
                Exit();
            if (state.IsKeyDown(Keys.Left)) levo = true;
            else levo = false;
            if (state.IsKeyDown(Keys.Right)) desno = true;
            else desno = false;
            if (levo) pozIgraca.X -= 5;
            if (desno) pozIgraca.X += 5;
            if (state.IsKeyDown(Keys.Space)&&naZemlji)
            {
                skok = true;
                naZemlji = false;
            }
            if (pozIgraca.Y + 50 < GraphicsDevice.Viewport.Height && !skok) pozIgraca.Y += 10;
            else if (skok)
            {
                if (p > 0) { p-=1; pozIgraca.Y -= p; }
                else { skok = false; p = 17; }
            }
            if (pozIgraca.Y + 50 > GraphicsDevice.Viewport.Height) pozIgraca.Y = GraphicsDevice.Viewport.Height - 50;
            if (pozIgraca.Y + 50 == GraphicsDevice.Viewport.Height) naZemlji = true;
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(igrac, pozIgraca);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
