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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SORAKAKE.Ver1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        // �L�[�{�[�h��Ԃ̐錾
        KeyboardState keyboardState;
        // �t�H���g�̐錾
        SpriteFont font;
        //Wii�N���X�̐錾
        Wii_ctrl2 wii = new Wii_ctrl2();

        SORA sora = new SORA();

        SORAKAKE sorakake = new SORAKAKE();
        SORAKAKE_wii sorakake_wii = new SORAKAKE_wii();
        
        GroundRun groundrun = new GroundRun();
        GroundRun_wii groundrun_wii = new GroundRun_wii();
      //  SORAKAKE fm = new SORAKAKE();

        //�Q�[���̐i�s�t���O
        static int flag;

        //�n��E��̃t���O
        int SkygroundFlag ;

        //���j���[�̐錾
        Menu menu = new Menu();

        // ��Ԃ̐錾
        SKY sky = new SKY();

        // ���E�̃��[���̐錾
        Action action = new Action();

        // �s���̐錾
        Flying flying = new Flying();

        //�I�u�W�F�N�g�̐錾
        WORLD ground = new WORLD("ground", "Ground81", new Vector3(10000, 0, 0));

        // ���̖ڐ��i�J�����j���W�A�������̐錾
        Vector3 cameraPos = new Vector3(-200.0f, 100.0f, 0.0f);
        Vector3 cameraFront = new Vector3(1, 0, 0);
        Vector3 cameraRight = new Vector3(0, 0, 1);
        Vector3 cameraUp = new Vector3(0, 1, 0);

        // �X�s�[�h
        float speed;

        public Game1()
        {
            //�t���O�̐ݒ�
            flag = 0;
            //��
            SkygroundFlag=0;
            //�X�s�[�h
            speed = 5;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            sky.SetWORLD(ground);
            sora.Load(Content);
            wii.Connect();

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
            // �t�H���g�̌ďo
            font = Content.Load<SpriteFont>("font");

            //���j���[�̌Ăяo��
            menu.Load(Content);

            // ��Ԃ̌ďo
            sky.LoadSKY(Content);
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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            // TODO: Add your update logic here
            // �L�[�{�[�h��Ԃ̎擾
            keyboardState = Keyboard.GetState();

            if (flag == 0)
            {
                //���j���[��ʂł̓���
                menu.Action(ref keyboardState,ref flag);
            }
            if (flag == 1)
            {
                //���炩���̉^��(�L�[�{�[�h)
                if (menu.Operation == 0)
                {
                    if(SkygroundFlag==0)
                          sorakake.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag);
                    if (SkygroundFlag == 1) {
                        groundrun.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag);
                    }
                }else if(menu.Operation==1){
                    if (SkygroundFlag == 0)
                        sorakake_wii.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag,ref wii);
                    if (SkygroundFlag == 1)
                    {
                        groundrun_wii.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag,ref wii);
                    }
                }

            }

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            graphics.GraphicsDevice.Clear(Color.Black);
            // �[�x�o�b�t�@��L��
            graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
            if (flag == 0)
            {
                //���j���[��ʂ̕`��
                menu.Graphic(ref  graphics, ref  spriteBatch, ref  font, ref gameTime);
            }
            if (flag == 1)
            {
                //�Q�[����ʂ̕`��
                if (menu.Operation == 0)
                {
                    sorakake.Graphic(ref  cameraPos, ref  cameraFront, ref  cameraRight, ref  cameraUp,
                    ref  graphics, ref  spriteBatch, ref  font, ref gameTime);
                }
                else {
                    sorakake_wii.Graphic(ref  cameraPos, ref  cameraFront, ref  cameraRight, ref  cameraUp,
                ref  graphics, ref  spriteBatch, ref  font, ref gameTime,ref wii,speed);
                }

            }
            base.Draw(gameTime);
        }
    }
}
