using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpanceInvadersUltra
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : GameEnvironment
    {
        public Main()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Screen = new Point(1200, 768);

            SetFullScreen(false);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GameStateManager.AddGameState("playingState", new PlayingState());
            GameStateManager.SwitchTo("playingState");
            
        }
    }
}
