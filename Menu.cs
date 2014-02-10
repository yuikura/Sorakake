using System;
using System.Windows.Forms;
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
    public class Menu : Microsoft.Xna.Framework.Game
    {

        Texture2D BackGround;
        Texture2D Start;
        Texture2D Test;
        Texture2D Option;
        Texture2D WAKU;
        public int WakuPos;   //枠の位置
        public int menuflag;       //オプションのフラグ
        public int testflag;    //テストのフラグ
        public int Operation;    //キーボードかWii機器か
        public int count=0;
        public int select = 2;
        public bool push = false;
        Sound sound = new Sound();//サウンド
        public Menu()
        {
            Operation = 1;    //キーボード
            menuflag = 0;     //押されていない
            testflag = 0;
            WakuPos = 395;
        }

        public void Load(ContentManager content)
        {
            BackGround = content.Load<Texture2D>("sampleBG2");
            Start = content.Load<Texture2D>("sampleStart3");
            Test = content.Load<Texture2D>("sampleTest3");
            Option = content.Load<Texture2D>("sampleOption3");
            WAKU = content.Load<Texture2D>("sampleWaku3");
        }

        //メニューでの動き
        public void Action(ref KeyboardState keyboardState, ref int flag, SoundBank soundBank, AudioEngine engine, Cue bgm, Wii_ctrl wii, ref Test test)
        {
            count++;
            if (!keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)
                && !keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                push = false;

            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W)
                && keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
            {
                //Ctrl+WでWiiモードかつスタート
                Operation = 1;
                flag = 1;
            }

            //上を押したら
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up) && push==false)
            {
                push = true;
                select++;
                if (select > 2)
                    select = 2;

                //ボタンのサウンド
                sound.BGM(soundBank, engine, bgm, "Button");
            }
            //下を押したら
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down) && push==false)
            {
                push = true;
                select--;
                if (select < 0)
                    select = 0;
                //ボタンのサウンド
                sound.BGM(soundBank, engine, bgm, "Button");
            }

            //枠の位置設定
            if (select == 2)
                WakuPos = 395;
            else if (select == 1)
                WakuPos = 445;
            else
                WakuPos = 495;

            //テストフォーム更新
            if (testflag == 1 && test != null && count%5==0)
                test.Test_inv();

            //スタートでエンターを押したら
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && select == 2)
            {
                flag = 1;
            }
            //テストを選択
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && select == 1)
            {
                if (testflag == 0)
                {
                    //フォームの表示
                    test = new Test(wii, this);
                    test.Show();
                    testflag = 1;
                }
            }
            //オプションでエンターを押したら
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && select == 0)
            {
                if (menuflag == 0)
                {
                    //フォームの表示
                    MenuForm form = new MenuForm(this);
                    form.Show();
                    menuflag = 1;
                }
            }
        }

        //メニューの描画
        public void Graphic(ref GraphicsDeviceManager graphics, ref SpriteBatch spriteBatch, ref SpriteFont font, ref GameTime gameTime)
        {
            // spriteBatch.Begin();
            spriteBatch.Draw(BackGround, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Start, new Vector2(600, 400), Color.White);
            spriteBatch.Draw(Test, new Vector2(600, 450), Color.White);
            spriteBatch.Draw(Option, new Vector2(600, 500), Color.White);
            spriteBatch.Draw(WAKU, new Vector2(570, WakuPos), Color.White);
            //spriteBatch.End();
        }
    }
}
