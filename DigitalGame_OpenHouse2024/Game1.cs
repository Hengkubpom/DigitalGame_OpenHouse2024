using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DigitalGame_OpenHouse2024
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D whiteblock_test, darkmap;
        private SpriteFont pixelfont;
        private MouseState mouse_state, old_mouse_state;
        private KeyboardState key_state, old_key_state;
        private char character;
        private string player_name = "", virtual_name = "";
        enum ScreenState
        {
            MainMenu,
            Gameplay
        }
        ScreenState OnScreen = ScreenState.MainMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.TextInput += TextInputHandler;
            base.Initialize();
        }
        


        private void TextInputHandler(object sender, TextInputEventArgs args)
        {
            var pressedKey = args.Key;
            character = args.Character;
            if (name_popup && char.IsLetterOrDigit(character) && char.IsAscii(character))
            {
                player_name += character;
            }
        }

        protected override void LoadContent()
        {
            whiteblock_test = Content.Load<Texture2D>("whiteblock");
            darkmap = Content.Load<Texture2D>("ingre/dark");
            pixelfont = Content.Load<SpriteFont>("font/Pixelfont");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouse_state = Mouse.GetState();
            key_state = Keyboard.GetState();
            switch (OnScreen)
            {
                case ScreenState.MainMenu:
                    Update_Mainmenu(gameTime); break;
                case ScreenState.Gameplay:
                    Update_Gameplay(gameTime); break;
            }
            old_mouse_state = mouse_state;
            old_key_state = key_state;
            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            switch (OnScreen)
            {
                case ScreenState.MainMenu:
                    Draw_Mainmenu(gameTime); break;
                case ScreenState.Gameplay:
                    Draw_Gameplay(gameTime); break;
            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }




        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        ////////////////// MainMenu ////////////////////////
        Rectangle StartButton = new Rectangle(700, 600, 300, 200);
        Rectangle EnterButton = new Rectangle(800, 650, 150, 100);
        bool name_popup = false;
        protected void Update_Mainmenu(GameTime gameTIme)
        {
            
            
            if (!name_popup)
            {
                if (StartButton.Contains(mouse_state.X, mouse_state.Y))
                {
                    if (mouse_state.LeftButton == ButtonState.Pressed && old_mouse_state.LeftButton == ButtonState.Released)
                    {
                        name_popup = true;
                    }
                }
            }
            else
            {
                if(key_state.IsKeyDown(Keys.Escape) && old_key_state.IsKeyUp(Keys.Escape))
                {
                    player_name = "";
                    name_popup = false;
                }
                Console.WriteLine(player_name.Length.ToString());
                if (key_state.IsKeyDown(Keys.Back) && old_key_state.IsKeyUp(Keys.Back) && player_name.Length > 0)
                {
                    player_name = player_name.Substring(0,player_name.Length-1);
                }
                if(key_state.IsKeyDown(Keys.Enter) && old_key_state.IsKeyUp(Keys.Enter) || EnterButton.Contains(mouse_state.X,mouse_state.Y) && mouse_state.LeftButton == ButtonState.Pressed && old_mouse_state.LeftButton == ButtonState.Released)
                {
                    OnScreen = ScreenState.Gameplay;
                }
                
            }
        }

        protected void Draw_Mainmenu(GameTime gameTime)
        {
            _spriteBatch.Draw(whiteblock_test, StartButton, Color.Lime);
            if(name_popup)
            {
                _spriteBatch.Draw(darkmap, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.Draw(whiteblock_test, new Rectangle(500, 400, 600, 400), Color.Red);
                _spriteBatch.Draw(whiteblock_test, EnterButton, Color.Lime);
                if (player_name.Length > 0)
                {
                    _spriteBatch.DrawString(pixelfont, player_name, Vector2.Zero, Color.White);
                }
                
            }
        }


        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////
        ////////////// Gameplay ////////////////

        protected void Update_Gameplay(GameTime gameTime)
        {

        }

        protected void Draw_Gameplay(GameTime gameTime)
        {

        }

    }
}