using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Caidaaas
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] textABC2 = new Texture2D[27];
        Texture2D[] cajaABC2 = new Texture2D[27];
        int[] posY = new int[10] { 20, 120, 220, 320, 420, 520, 620, 720, 820, 920 };
        int[] cosas = new int[10];
        int[] pressedY = new int[10];
        int[] pressedX = new int[10];
        int[] fueTocado = new int[10];
        string[] abc = new string[27] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "Ò", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] cabc = new string[27] { "cajaA", "cajaB", "cajaC", "cajaD", "cajaE", "cajaF", "cajaG", "cajaH", "cajaI", "cajaJ", "cajaK", "cajaL", "cajaM", "cajaN", "caja—", "cajaO", "cajaP", "cajaQ", "cajaR", "cajaS", "cajaT", "cajaU", "cajaV", "cajaW", "cajaX", "cajaY", "cajaZ" };
        Rectangle[] recABC2 = new Rectangle[27];
        Rectangle[] recCajaABC2 = new Rectangle[27];
        Texture2D[] textABC = new Texture2D[10];
        Texture2D[] cajaABC = new Texture2D[3];
        Rectangle[] recABC = new Rectangle[10];
        Rectangle[] recCajaABC = new Rectangle[3];
        List<int> listRand = new List<int>();
        List<int> listRand3 = new List<int>();
        int x = 20;
        int y = 20;
        int iSele=-1;
        int gana = 0;
        bool click = false;
        bool click2 = false;
        Texture2D yupi;
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 650;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            yupi = Content.Load<Texture2D>("yupi");
           
            for (int i = 0; i < textABC.Length; i++)
            {
                fueTocado[i] = 0;
                cosas[i] = 0;
                textABC2[i] = Content.Load<Texture2D>(abc[i]);
                recABC2[i] = new Rectangle(x, cosas[i], textABC2[i].Width, textABC2[i].Height);
                cajaABC2[i] = Content.Load<Texture2D>(cabc[i]);
                x = x + textABC2[i].Width;
            }
            Jugar();

        }
        int num;
        public void Jugar()
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                num = rand.Next(27);
                if (!listRand.Contains(num))
                {
                    listRand.Add(num);
                    textABC[i] = Content.Load<Texture2D>(abc[num]);
                    textABC[i].Name = abc[num];
                    recABC[i] = new Rectangle(x, cosas[i], textABC[i].Width, textABC[i].Height);

                    x = x + textABC[i].Width;
                }
                else
                    i--;
            }
            Random rand2 = new Random();
            int num2;
            for (int i = 0; i < 3; i++)
            {
                num2 = rand.Next(27);
                if (!listRand3.Contains(num2) && listRand.Contains(num2))
                {
                    listRand3.Add(num2);
                    cajaABC[i] = Content.Load<Texture2D>(cabc[num2]);
                    cajaABC[i].Name = abc[num2];

                }
                else
                    i--;
            }

        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        MouseState currentMouseState;
        MouseState previousMouseState;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            for (int i = 0; i < textABC.Length; i++)
            {
                if (!click)
                {
                    recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);   
                }
                else
                {
                    if (fueTocado[i]==1)
                    {
                        cosas[i] = pressedY[i];
                    recABC[i] = new Rectangle(pressedX[i], cosas[i], textABC[i].Width, textABC[i].Height);
                    }
                    
                }
               

            }
            for (int i = 0; i < textABC.Length; i++)
            {
               
                if (recABC[i].Contains(currentMouseState.X, currentMouseState.Y) && (recABC[i].Contains(previousMouseState.X, previousMouseState.Y)) && (previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed))
                {
                    if (iSele>=0)
                    {
                        fueTocado[iSele] = 0;
                    }
                    

                    iSele = i;
                    i = textABC.Length - 1;
                }
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                click = true;
                click2 = false;
                fueTocado[iSele] = 1;
                pressedX[iSele] = currentMouseState.X - 30;
                pressedY[iSele] = currentMouseState.Y - 30;                
                recABC[iSele] = new Rectangle(currentMouseState.X - 30, currentMouseState.Y - 30, textABC[iSele].Width, textABC[iSele].Height);
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Pressed)
            {
                click = true;
                click2 = false;
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Released)
            {
                click = false;
                click2 = true;
               
            }
            else if (previousMouseState.LeftButton == ButtonState.Pressed & currentMouseState.LeftButton == ButtonState.Released)
            {
                click = false;
                click2 = true;
                
            }
            //////////////////////////////////////
            //Como fijarse los intersect sin que se salga del indice
            //Yupi desaparece aunque gana=1(no deberia aparecer)
            ////////////////////
            if (click2)
            {
                if (gana<4)
                {
                    
                    if (iSele>=0)
                    {
                        recABC[iSele] = new Rectangle(currentMouseState.X - 30, currentMouseState.Y - 30, textABC[iSele].Width, textABC[iSele].Height);
                        if (recCajaABC[0].Intersects(recABC[iSele]) && cajaABC[0].Name == textABC[iSele].Name)
                        {
                            gana++;
                        }
                        else if (recCajaABC[1].Intersects(recABC[iSele]) && cajaABC[1].Name == textABC[iSele].Name)
                        {
                            gana++;
                        }
                        else if (recCajaABC[2].Intersects(recABC[iSele]) && cajaABC[2].Name == textABC[iSele].Name)
                        {
                            gana++;
                        }
                    }
                    
                }
                    
                
            }
            recCajaABC[0] = new Rectangle(250, 500, cajaABC[0].Width, cajaABC[0].Height);
            recCajaABC[1] = new Rectangle(450, 500, cajaABC[1].Width, cajaABC[1].Height);
            recCajaABC[2] = new Rectangle(650, 500, cajaABC[2].Width, cajaABC[2].Height);



            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(cajaABC[0], new Vector2(250, 500), Color.White);
            spriteBatch.Draw(cajaABC[1], new Vector2(450, 500), Color.White);
            spriteBatch.Draw(cajaABC[2], new Vector2(650, 500), Color.White);
            if (gana<3)
            {
                if (!click)
                {
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        cosas[i]++;
                        spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                        recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                    }
                }
                else
                {
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        if (i != iSele)
                        {
                            cosas[i]++;
                            spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                            recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                        }
                        else
                        {
                            spriteBatch.Draw(textABC[i], new Vector2(currentMouseState.X - 30, currentMouseState.Y - 30), Color.White);
                        }
                    }
                }
            }
            else if (gana == 3)
            {
                spriteBatch.Draw(yupi, new Vector2(100,100), Color.White);
                
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
