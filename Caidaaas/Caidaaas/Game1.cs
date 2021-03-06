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
using System.Timers;
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
        Texture2D[] cajaAB2 = new Texture2D[27];
        int[] posY = new int[10] { 130, 230, 330, 430, 530, 630, 730, 830, 930, 1030 };
        int[] cosas = new int[10];
        int[] pressedY = new int[10];
        int[] pressedX = new int[10];
        int[] fueTocado = new int[10];
        bool[] mostrar = new bool[10];
        string[] abc = new string[27] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "�", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] cabc = new string[27] { "cajaA", "cajaB", "cajaC", "cajaD", "cajaE", "cajaF", "cajaG", "cajaH", "cajaI", "cajaJ", "cajaK", "cajaL", "cajaM", "cajaN", "caja�", "cajaO", "cajaP", "cajaQ", "cajaR", "cajaS", "cajaT", "cajaU", "cajaV", "cajaW", "cajaX", "cajaY", "cajaZ" };
        Rectangle[] recABC2 = new Rectangle[27];
        Rectangle[] recCajaAB2 = new Rectangle[27];
        Texture2D[] textABC = new Texture2D[10];        
        Rectangle[] recABC = new Rectangle[10];
        Texture2D[] cajaABC = new Texture2D[3];
        Rectangle[] recCajaABC = new Rectangle[3];
        Texture2D[] cajaABC2 = new Texture2D[4];
        Rectangle[] recCajaABC2 = new Rectangle[4];
        Texture2D[] cajaABC3 = new Texture2D[5];
        Rectangle[] recCajaABC3 = new Rectangle[5];
        List<int> listRand = new List<int>();
        List<int> listRand3 = new List<int>();
        List<int> listRand4 = new List<int>();
        List<int> listRand5 = new List<int>();
        int x = 20;
        int y = 20;
        int iSele=-1;
        int gana = 0;
        bool click = false;
        bool click2 = false;
        int flag1 = 0;
        int flag2 = 0;
        int flag3 = 0;
        int flag4 = 0;
        int flag5 = 0;
        int letra1 = -1;
        int letra2=-1;
        int letra3=-1;
        Texture2D yupi;
        Texture2D background;
        Texture2D background2;
        Texture2D home;
        Rectangle recHome;
        Texture2D back;
        Rectangle recBack;
        Texture2D play;
        Rectangle recPlay;
        Texture2D uno;
        Rectangle recUno;
        Texture2D dos;
        Rectangle recDos;
        Texture2D tres;
        Rectangle recTres;

        private static readonly TimeSpan intervalBetweenAttack1 = TimeSpan.FromMilliseconds(10);
        private TimeSpan lastTimeAttack;
        int ahora, antes;
        bool tarda = false;
        Timer t = new Timer(3000f); 



        public enum EstadoJuego
        {
            Inicio,
            Niveles,
            Juego,
        }
        public enum Niveles
        {
            Uno,
            Dos,
            Tres,
            inicial,
        }
        EstadoJuego estado = EstadoJuego.Inicio;
        EstadoJuego estadoViejo = EstadoJuego.Inicio;
        Niveles nivel= Niveles.inicial;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #region cosas
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
            //graphics.IsFullScreen = true;
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
            background = Content.Load<Texture2D>("background");
            background2 = Content.Load<Texture2D>("background2");
            home = Content.Load<Texture2D>("homepage");
            back = Content.Load<Texture2D>("back");
            play = Content.Load<Texture2D>("play");
            uno = Content.Load<Texture2D>("1");
            dos = Content.Load<Texture2D>("2");
            tres = Content.Load<Texture2D>("3");
            for (int i = 0; i < textABC.Length; i++)
            {
                fueTocado[i] = 0;
                cosas[i] = 0;
                mostrar[i] = true;
                textABC2[i] = Content.Load<Texture2D>(abc[i]);
                recABC2[i] = new Rectangle(x, cosas[i], textABC2[i].Width, textABC2[i].Height);
                cajaAB2[i] = Content.Load<Texture2D>(cabc[i]);
                x = x + textABC2[i].Width;
            }
            Jugar1();
            Jugar2();
            Jugar3();

        }
        int num;
        public void Jugar1()
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
        public void Jugar2()
        {
            Random rand = new Random();
            listRand.Clear();
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
            for (int i = 0; i < 4; i++)
            {
                num2 = rand.Next(27);
                if (!listRand4.Contains(num2) && listRand.Contains(num2))
                {
                    listRand4.Add(num2);
                    cajaABC2[i] = Content.Load<Texture2D>(cabc[num2]);
                    cajaABC2[i].Name = abc[num2];

                }
                else
                    i--;
            }

        }
        public void Jugar3()
        {
            Random rand = new Random();
            listRand.Clear();
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
            for (int i = 0; i < 5; i++)
            {
                num2 = rand.Next(27);
                if (!listRand5.Contains(num2) && listRand.Contains(num2))
                {
                    listRand4.Add(num2);
                    cajaABC3[i] = Content.Load<Texture2D>(cabc[num2]);
                    cajaABC3[i].Name = abc[num2];

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
        #endregion

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
            if (estado==EstadoJuego.Inicio)
            {
                recPlay = new Rectangle(550, 250, play.Width, play.Height);
                if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recPlay.Contains(currentMouseState.X, currentMouseState.Y)))
                {
                    estado = EstadoJuego.Niveles;
                }

            }
            if (estado==EstadoJuego.Niveles)
            {
                recUno = new Rectangle(350, 250, uno.Width, uno.Height);
                recDos = new Rectangle(200, 250, dos.Width, dos.Height);
                recTres = new Rectangle(650, 250, tres.Width, tres.Height);
                if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recUno.Contains(currentMouseState.X, currentMouseState.Y)))
                {
                    estado = EstadoJuego.Juego;
                    nivel = Niveles.Uno;
                }
                if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recDos.Contains(currentMouseState.X, currentMouseState.Y)))
                {
                    estado = EstadoJuego.Juego;
                    nivel = Niveles.Dos;
                }
                if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recTres.Contains(currentMouseState.X, currentMouseState.Y)))
                {
                    estado = EstadoJuego.Juego;
                    nivel = Niveles.Tres;
                }
            }
            
            
            if (estado==EstadoJuego.Juego)
            {
                if (nivel==Niveles.Uno)
                {
                    #region Uno
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        fueTocado[i] = 0;
                        cosas[i] = 0;
                        mostrar[i] = true;
                    }
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        if (!click)
                        {
                            recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                        }
                        else
                        {
                            if (fueTocado[i] == 1)
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
                            if (iSele >= 0)
                            {
                                fueTocado[iSele] = 0;
                            }

                            iSele = i;
                            i = textABC.Length - 1;
                        }
                    }
                    if (iSele != -1)
                    {
                        if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recABC[iSele].Contains(previousMouseState.X, previousMouseState.Y) && (recABC[iSele].Contains(currentMouseState.X, currentMouseState.Y))))
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

                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recHome.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Inicio;
                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recBack.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Niveles;
                    }
                    if (click2)
                    {
                        if (gana < 4)
                        {

                            if (iSele >= 0)
                            {
                                recABC[iSele] = new Rectangle(currentMouseState.X - 30, currentMouseState.Y - 30, textABC[iSele].Width, textABC[iSele].Height);
                                if ((recCajaABC[0].Intersects(recABC[iSele]) && cajaABC[0].Name == textABC[iSele].Name) && flag1 == 0)
                                {
                                    gana++;
                                    flag1 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC[1].Intersects(recABC[iSele]) && cajaABC[1].Name == textABC[iSele].Name) && flag2 == 0)
                                {
                                    gana++;
                                    flag2 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC[2].Intersects(recABC[iSele]) && cajaABC[2].Name == textABC[iSele].Name) && flag3 == 0)
                                {
                                    gana++;
                                    flag3 = 1;
                                    mostrar[iSele] = false;
                                }
                            }

                        }

                    }

                    recCajaABC[0] = new Rectangle(250, 500, cajaABC[0].Width, cajaABC[0].Height);
                    recCajaABC[1] = new Rectangle(450, 500, cajaABC[1].Width, cajaABC[1].Height);
                    recCajaABC[2] = new Rectangle(650, 500, cajaABC[2].Width, cajaABC[2].Height);
                    recHome = new Rectangle(1200, 30, home.Width, home.Height);
                    recBack = new Rectangle(1100, 30, back.Width, back.Height);
                    if (lastTimeAttack + intervalBetweenAttack1 < gameTime.TotalGameTime)
                    {
                        int esto = Convert.ToInt32(gameTime.TotalGameTime.Milliseconds);
                        if (esto % 2 == 0)
                        {
                            tarda = true;
                        }
                        else
                        {
                            tarda = false;
                        }


                        lastTimeAttack = gameTime.TotalGameTime;
                    }
                    #endregion   
                }
                if (nivel==Niveles.Dos)
                {
                    #region Dos
                    gana = 0;
                    flag1 = 0;
                    flag2 = 0;
                    flag3 = 0;
                    flag4 = 0;
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        fueTocado[i] = 0;
                        cosas[i] = 0;
                        mostrar[i] = true;
                    }
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        if (!click)
                        {
                            recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                        }
                        else
                        {
                            if (fueTocado[i] == 1)
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
                            if (iSele >= 0)
                            {
                                fueTocado[iSele] = 0;
                            }

                            iSele = i;
                            i = textABC.Length - 1;
                        }
                    }
                    if (iSele != -1)
                    {
                        if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recABC[iSele].Contains(previousMouseState.X, previousMouseState.Y) && (recABC[iSele].Contains(currentMouseState.X, currentMouseState.Y))))
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

                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recHome.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Inicio;
                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recBack.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Niveles;
                    }
                    if (click2)
                    {
                        if (gana < 5)
                        {

                            if (iSele >= 0)
                            {
                                recABC[iSele] = new Rectangle(currentMouseState.X - 30, currentMouseState.Y - 30, textABC[iSele].Width, textABC[iSele].Height);
                                if ((recCajaABC2[0].Intersects(recABC[iSele]) && cajaABC2[0].Name == textABC[iSele].Name) && flag1 == 0)
                                {
                                    gana++;
                                    flag1 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC2[1].Intersects(recABC[iSele]) && cajaABC2[1].Name == textABC[iSele].Name) && flag2 == 0)
                                {
                                    gana++;
                                    flag2 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC2[2].Intersects(recABC[iSele]) && cajaABC2[2].Name == textABC[iSele].Name) && flag3 == 0)
                                {
                                    gana++;
                                    flag3 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC2[3].Intersects(recABC[iSele]) && cajaABC2[3].Name == textABC[iSele].Name) && flag4 == 0)
                                {
                                    gana++;
                                    flag4 = 1;
                                    mostrar[iSele] = false;
                                }

                            }

                        }

                    }

                    recCajaABC2[0] = new Rectangle(250, 500, cajaABC2[0].Width, cajaABC2[0].Height);
                    recCajaABC2[1] = new Rectangle(450, 500, cajaABC2[1].Width, cajaABC2[1].Height);
                    recCajaABC2[2] = new Rectangle(650, 500, cajaABC2[2].Width, cajaABC2[2].Height);
                    recCajaABC2[3] = new Rectangle(850, 500, cajaABC2[3].Width, cajaABC2[3].Height);
                    recHome = new Rectangle(1100, 30, back.Width, back.Height);
                    recHome = new Rectangle(1200, 30, home.Width, home.Height);
                    if (lastTimeAttack + intervalBetweenAttack1 < gameTime.TotalGameTime)
                    {
                        int esto = Convert.ToInt32(gameTime.TotalGameTime.Milliseconds);
                        if (esto % 2 == 0)
                        {
                            tarda = true;
                        }
                        else
                        {
                            tarda = false;
                        }


                        lastTimeAttack = gameTime.TotalGameTime;
                    }
                    #endregion
                }
                if (nivel == Niveles.Tres)
                {
                    #region Tres
                    gana = 0;
                    flag1 = 0;
                    flag2 = 0;
                    flag3 = 0;
                    flag4 = 0;
                    flag5 = 0;
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        fueTocado[i] = 0;
                        cosas[i] = 0;
                        mostrar[i] = true;
                    }
                    for (int i = 0; i < textABC.Length; i++)
                    {
                        if (!click)
                        {
                            recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                        }
                        else
                        {
                            if (fueTocado[i] == 1)
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
                            if (iSele >= 0)
                            {
                                fueTocado[iSele] = 0;
                            }

                            iSele = i;
                            i = textABC.Length - 1;
                        }
                    }
                    if (iSele != -1)
                    {
                        if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recABC[iSele].Contains(previousMouseState.X, previousMouseState.Y) && (recABC[iSele].Contains(currentMouseState.X, currentMouseState.Y))))
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

                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recHome.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Inicio;
                    }
                    if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recBack.Contains(currentMouseState.X, currentMouseState.Y)))
                    {
                        estado = EstadoJuego.Niveles;
                    }
                    if (click2)
                    {
                        if (gana < 6)
                        {

                            if (iSele >= 0)
                            {
                                recABC[iSele] = new Rectangle(currentMouseState.X - 30, currentMouseState.Y - 30, textABC[iSele].Width, textABC[iSele].Height);
                                if ((recCajaABC3[0].Intersects(recABC[iSele]) && cajaABC3[0].Name == textABC[iSele].Name) && flag1 == 0)
                                {
                                    gana++;
                                    flag1 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC3[1].Intersects(recABC[iSele]) && cajaABC3[1].Name == textABC[iSele].Name) && flag2 == 0)
                                {
                                    gana++;
                                    flag2 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC3[2].Intersects(recABC[iSele]) && cajaABC3[2].Name == textABC[iSele].Name) && flag3 == 0)
                                {
                                    gana++;
                                    flag3 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC3[3].Intersects(recABC[iSele]) && cajaABC3[3].Name == textABC[iSele].Name) && flag4 == 0)
                                {
                                    gana++;
                                    flag4 = 1;
                                    mostrar[iSele] = false;
                                }
                                else if ((recCajaABC3[3].Intersects(recABC[iSele]) && cajaABC3[3].Name == textABC[iSele].Name) && flag4 == 0)
                                {
                                    gana++;
                                    flag5 = 1;
                                    mostrar[iSele] = false;
                                }
                            }

                        }

                    }

                    recCajaABC3[0] = new Rectangle(200, 500, cajaABC3[0].Width, cajaABC3[0].Height);
                    recCajaABC3[1] = new Rectangle(400, 500, cajaABC3[1].Width, cajaABC3[1].Height);
                    recCajaABC3[2] = new Rectangle(600, 500, cajaABC3[2].Width, cajaABC3[2].Height);
                    recCajaABC3[3] = new Rectangle(800, 500, cajaABC3[3].Width, cajaABC3[3].Height);
                    recCajaABC3[3] = new Rectangle(1000, 500, cajaABC3[3].Width, cajaABC3[3].Height);
                    recHome = new Rectangle(1100, 30, back.Width, back.Height);
                    recHome = new Rectangle(1200, 30, home.Width, home.Height);
                    if (lastTimeAttack + intervalBetweenAttack1 < gameTime.TotalGameTime)
                    {
                        int esto = Convert.ToInt32(gameTime.TotalGameTime.Milliseconds);
                        if (esto % 2 == 0)
                        {
                            tarda = true;
                        }
                        else
                        {
                            tarda = false;
                        }


                        lastTimeAttack = gameTime.TotalGameTime;
                    }
                    #endregion
                }
                
            }

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
            GraphicsDevice.Clear(Color.Orange);
            
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            
            if (estado==EstadoJuego.Inicio)
            {
                GraphicsDevice.Clear(Color.Orange);
                spriteBatch.Draw(background2, new Rectangle(0, 0, background2.Width, background2.Height), Color.White);
                spriteBatch.Draw(play, new Vector2(550, 250), Color.White);
            }
            if (estado==EstadoJuego.Niveles)
            {
                spriteBatch.Draw(background2, new Rectangle(0, 0, background2.Width, background2.Height), Color.White);
                spriteBatch.Draw(uno, new Vector2(350, 250), Color.White);
                spriteBatch.Draw(dos, new Vector2(200, 250), Color.White);
                spriteBatch.Draw(tres, new Vector2(650, 250), Color.White);
            }
            if (estado == EstadoJuego.Juego)
            {

                spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
                
                if (nivel==Niveles.Uno)
                {
                    #region UnoD
                    spriteBatch.Draw(home, new Vector2(1200, 30), Color.White);
                    spriteBatch.Draw(back, new Vector2(1100, 30), Color.White);
                    spriteBatch.Draw(cajaABC[0], new Vector2(250, 500), Color.White);
                    spriteBatch.Draw(cajaABC[1], new Vector2(450, 500), Color.White);
                    spriteBatch.Draw(cajaABC[2], new Vector2(650, 500), Color.White);
                    if (gana < 3)
                    {
                        if (!click)
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (mostrar[i])
                                {
                                    // if (tarda)
                                    //{
                                    cosas[i]++;
                                    //}

                                    spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                    recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);

                                }


                            }
                        }
                        else
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (i != iSele)
                                {
                                    if (mostrar[i])
                                    {
                                        cosas[i]++;
                                        spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                        recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                                    }

                                }
                                else
                                {
                                    if (mostrar[i])
                                    {
                                        spriteBatch.Draw(textABC[i], new Vector2(currentMouseState.X - 30, currentMouseState.Y - 30), Color.White);
                                    }

                                }
                            }
                        }

                    }
                    else if (gana == 3)
                    {
                        spriteBatch.Draw(yupi, new Vector2(100, 100), Color.White);

                    }

                    #endregion
                }
                if (nivel==Niveles.Dos)
                {
                    #region DosD
                    spriteBatch.Draw(home, new Vector2(1200, 30), Color.White);
                    spriteBatch.Draw(back, new Vector2(1100, 30), Color.White);
                    spriteBatch.Draw(cajaABC2[0], new Vector2(250, 500), Color.White);
                    spriteBatch.Draw(cajaABC2[1], new Vector2(450, 500), Color.White);
                    spriteBatch.Draw(cajaABC2[2], new Vector2(650, 500), Color.White);
                    spriteBatch.Draw(cajaABC2[3], new Vector2(850, 500), Color.White);
                    if (gana < 4)
                    {
                        if (!click)
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (mostrar[i])
                                {

                                    if (tarda)
                                    {
                                        cosas[i]++;
                                    }

                                    spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                    recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);

                                }


                            }
                        }
                        else
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (i != iSele)
                                {
                                    if (mostrar[i])
                                    {
                                        cosas[i]++;
                                        spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                        recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                                    }

                                }
                                else
                                {
                                    if (mostrar[i])
                                    {
                                        spriteBatch.Draw(textABC[i], new Vector2(currentMouseState.X - 30, currentMouseState.Y - 30), Color.White);
                                    }

                                }
                            }
                        }

                    }
                    else if (gana == 4)
                    {
                        spriteBatch.Draw(yupi, new Vector2(100, 100), Color.White);

                    }

                    #endregion
                }
                if (nivel == Niveles.Tres)
                {
                    #region TresD
                    spriteBatch.Draw(home, new Vector2(1200, 30), Color.White);
                    spriteBatch.Draw(back, new Vector2(1100, 30), Color.White);
                    spriteBatch.Draw(cajaABC3[0], new Vector2(200, 500), Color.White);
                    spriteBatch.Draw(cajaABC3[1], new Vector2(400, 500), Color.White);
                    spriteBatch.Draw(cajaABC3[2], new Vector2(600, 500), Color.White);
                    spriteBatch.Draw(cajaABC3[3], new Vector2(800, 500), Color.White);
                    spriteBatch.Draw(cajaABC3[4], new Vector2(1000, 500), Color.White);
                    if (gana < 5)
                    {
                        if (!click)
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (mostrar[i])
                                {

                                    if (tarda)
                                    {
                                        cosas[i]++;
                                    }

                                    spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                    recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);

                                }


                            }
                        }
                        else
                        {
                            for (int i = 0; i < textABC.Length; i++)
                            {
                                if (i != iSele)
                                {
                                    if (mostrar[i])
                                    {
                                        cosas[i]++;
                                        spriteBatch.Draw(textABC[i], new Vector2(posY[i], cosas[i]), Color.White);
                                        recABC[i] = new Rectangle(posY[i], cosas[i], textABC[i].Width, textABC[i].Height);
                                    }

                                }
                                else
                                {
                                    if (mostrar[i])
                                    {
                                        spriteBatch.Draw(textABC[i], new Vector2(currentMouseState.X - 30, currentMouseState.Y - 30), Color.White);
                                    }

                                }
                            }
                        }

                    }
                    else if (gana == 5)
                    {
                        spriteBatch.Draw(yupi, new Vector2(100, 100), Color.White);

                    }

                    #endregion
                }
             /*   switch (nivel)
                {
                    case Niveles.Uno:
                        
                        break;
                    case Niveles.Dos:
                        
                        break;
                    case Niveles.Tres:
                        
                        break;
                    default:
                        break;
                }*/


                //////////////////////////////////////////////
            }


            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
