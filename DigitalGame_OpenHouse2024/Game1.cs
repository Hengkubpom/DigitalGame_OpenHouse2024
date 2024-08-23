using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DigitalGame_OpenHouse2024
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D darkmap, codeforblock, charactert, Map2, bg_main, logo, start1,start2, inputname;
        static public Texture2D whiteblock_test;
        private Texture2D level1, level2, studentcard;
        private SpriteFont pixelfont, Bigpixel;
        static public MouseState mouse_state, old_mouse_state;
        static public KeyboardState key_state, old_key_state;
        private bool IsTutorial = true;
        private float Time = 0;
        private int minute, second;
        private char character;
        private string player_name = "";
        private Player player_character;
        private List<CodeBlock> blocks = new List<CodeBlock>();
        private List<Room> rooms = new List<Room>();
        static public List<SoundEffect> sEffect = new List<SoundEffect>();
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
            if (name_popup && char.IsLetterOrDigit(character) && char.IsAscii(character) && player_name.Length <= 10 && OnScreen == ScreenState.MainMenu)
            {
                player_name += character;
            }
        }

        protected override void LoadContent()
        {
            Map2 = Content.Load<Texture2D>("Room");
            whiteblock_test = Content.Load<Texture2D>("whiteblock");
            codeforblock = Content.Load<Texture2D>("codeblock");
            darkmap = Content.Load<Texture2D>("ingre/dark");
            pixelfont = Content.Load<SpriteFont>("font/Pixelfont");
            Bigpixel = Content.Load<SpriteFont>("font/BigPixel");
            charactert = Content.Load<Texture2D>("character_upscale");
            bg_main = Content.Load<Texture2D>("menu/bg_main");
            logo = Content.Load<Texture2D>("menu/logo");
            start1 = Content.Load<Texture2D>("menu/startbutton");
            start2 = Content.Load<Texture2D>("menu/startbutton_2");
            inputname = Content.Load<Texture2D>("menu/NameInput");
            level1 = Content.Load<Texture2D>("Gameplay/Level1");
            level2 = Content.Load<Texture2D>("Gameplay/Level2");
            studentcard = Content.Load<Texture2D>("Gameplay/Srudentcard");
            sEffect.Add(Content.Load<SoundEffect>("Sound/change_state"));
            sEffect.Add(Content.Load<SoundEffect>("Sound/ButtonClick"));
            sEffect.Add(Content.Load<SoundEffect>("Sound/CodeFill"));
            player_character = new Player(charactert, 6, 8, 5, pixelfont, Map2, 1);
            blocks.Add(new CodeBlock("Left", new Vector2(945, 595), codeforblock));
            blocks.Add(new CodeBlock("Down", new Vector2(945,685), codeforblock));
            blocks.Add(new CodeBlock("Up", new Vector2(1200, 595), codeforblock));
            blocks.Add(new CodeBlock("Right", new Vector2(1200, 685), codeforblock));
            rooms.Add(new Room(new Vector2(890, 190), darkmap));
            rooms.Add(new Room(new Vector2(1075, 190), darkmap));
            rooms.Add(new Room(new Vector2(1260, 190), darkmap));
            rooms.Add(new Room(new Vector2(890, 250), darkmap));
            rooms.Add(new Room(new Vector2(1075, 250), darkmap));
            rooms.Add(new Room(new Vector2(1260, 250), darkmap));
            rooms.Add(new Room(new Vector2(890, 310), darkmap));
            rooms.Add(new Room(new Vector2(1075, 310), darkmap));
            rooms.Add(new Room(new Vector2(1260, 310), darkmap));
            rooms.Add(new Room(new Vector2(890, 370), darkmap));
            rooms.Add(new Room(new Vector2(1075, 370), darkmap));
            rooms.Add(new Room(new Vector2(1260, 370), darkmap));
            rooms.Add(new Room(new Vector2(890, 430), darkmap));
            rooms.Add(new Room(new Vector2(1075, 430), darkmap));
            rooms.Add(new Room(new Vector2(1260, 430), darkmap));
            rooms.Add(new Room(new Vector2(890, 490), darkmap));
            rooms.Add(new Room(new Vector2(1075, 490), darkmap));
            rooms.Add(new Room(new Vector2(1260, 490), darkmap));

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
            GraphicsDevice.Clear(Color.Black);
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
        Rectangle StartButton = new Rectangle(732, 475, 140, 148);
        Rectangle EnterButton = new Rectangle(1060, 460, 180, 70);
        bool name_popup = false;
        protected void Update_Mainmenu(GameTime gameTIme)
        {
            
            
            if (!name_popup)
            {
                if (StartButton.Contains(mouse_state.X, mouse_state.Y))
                {
                    if (mouse_state.LeftButton == ButtonState.Pressed && old_mouse_state.LeftButton == ButtonState.Released)
                    {
                        var instance = sEffect[1].CreateInstance();
                        instance.Volume = 0.5f;
                        instance.Play();
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
                    player_character.name = player_name;
                    var instance = sEffect[1].CreateInstance();
                    instance.Volume = 0.5f;
                    instance.Play();
                    OnScreen = ScreenState.Gameplay;
                }
                
            }
        }

        protected void Draw_Mainmenu(GameTime gameTime)
        {
            _spriteBatch.Draw(bg_main, Vector2.Zero,Color.White);
            _spriteBatch.Draw(logo, new Vector2(180,150), Color.White);
            if (StartButton.Contains(mouse_state.X,mouse_state.Y))
            {
                _spriteBatch.Draw(start2, StartButton, Color.White);
            }
            else
            {
                _spriteBatch.Draw(start1, StartButton, Color.White);
            }
            if(name_popup)
            {
                _spriteBatch.Draw(darkmap, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.Draw(inputname, Vector2.Zero, Color.White);
                if (player_name.Length > 0)
                {
                    _spriteBatch.DrawString(pixelfont, player_name, new Vector2(1225,275), Color.Black);
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

        private Rectangle apartment = new Rectangle(860, 160, 600, 400);
        private Rectangle Restart = new Rectangle(710, 20, 45, 40);
        protected void Update_Gameplay(GameTime gameTime)
        {
            Console.WriteLine(player_character.IsWin);
            if (!player_character.IsWin)
            {
                if (!IsTutorial)
                {
                    Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (Time >= 60)
                    {
                        minute = (int)(Time / 60);
                        second = (int)(Time - (minute * 60));
                    }
                    else
                    {
                        second = (int)(Time);
                    }
                }
                player_character.Player_Update(gameTime);


                foreach (CodeBlock minicode in blocks)
                {
                    minicode.Code_Update(gameTime);
                    if (minicode.hitbox.Contains(mouse_state.X, mouse_state.Y) && mouse_state.LeftButton == ButtonState.Pressed && old_mouse_state.LeftButton == ButtonState.Released)
                    {
                        minicode.follow_ms = true;
                    }
                    if (mouse_state.LeftButton == ButtonState.Released)
                    {
                        if (apartment.Contains(mouse_state.Position.ToVector2()) && minicode.follow_ms)
                        {
                            int count_room = 0;
                            foreach (Room miniroom in rooms)
                            {
                                if (miniroom.IsEmpty)
                                {
                                    var instance = sEffect[2].CreateInstance();
                                    instance.Volume = 0.2f;
                                    instance.Play();
                                    miniroom.fill_code(minicode);
                                    break;
                                }
                                count_room++;
                            }
                            if (count_room == rooms.Count)
                            {
                                for (int i = 0; i < count_room; i++)
                                {
                                    if (i + 1 < count_room - 1)
                                    {
                                        rooms[i] = rooms[i + 1];
                                    }
                                    else
                                    {
                                        rooms[i].fill_code(minicode);
                                        var instance = sEffect[2].CreateInstance();
                                        instance.Volume = 0.2f;
                                        instance.Play();
                                    }
                                }
                            }
                        }

                        minicode.follow_ms = false;
                    }

                    //Restart button
                    if (Restart.Contains(mouse_state.Position.ToVector2()) && mouse_state.LeftButton == ButtonState.Pressed && old_mouse_state.LeftButton == ButtonState.Released)
                    {
                        Time = 0;
                        minute = 0;
                        second = 0;
                        player_character.Reset();
                        foreach (Room miniroom in rooms)
                        {
                            miniroom.Restart();

                        }
                    }


                }
            }
            else
            {
                if(player_character.level == 1)
                {
                    if(key_state.IsKeyDown(Keys.Enter))
                    {
                        player_character.Reset();
                        player_character.ChangeLevel(2);
                        player_character.Reset();
                        IsTutorial = false;
                    }
                }
                else if(player_character.level == 2)
                {
                    //student card
                }
            }
        }

        protected void Draw_Gameplay(GameTime gameTime)
        {

            player_character.Player_draw(_spriteBatch);
            //_spriteBatch.Draw(Map2, Vector2.Zero, Color.White);
            if (player_character.level == 1)
            {
                _spriteBatch.Draw(level1, Vector2.Zero, Color.White);
            }
            else
            {
                _spriteBatch.Draw(level2, Vector2.Zero, Color.White);
            }

            _spriteBatch.DrawString(Bigpixel, player_name, new Vector2(300, 130), Color.Black);
            _spriteBatch.DrawString(Bigpixel, minute +"M "+ second +"S", new Vector2(1350, 130), Color.Black);
            foreach (Room miniroom in rooms)
            {
                miniroom.Draw_room(_spriteBatch);
            }
            foreach(CodeBlock minicode in blocks)
            {
                minicode.Code_draw(_spriteBatch);
            }

            //_spriteBatch.Draw(darkmap, apartment, Color.White);



            //_spriteBatch.Draw(whiteblock_test, Restart, Color.Red);
        }

    }
}