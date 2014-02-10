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
    class SORAKAKE
    {

        // 空間の宣言
        SKY sky = new SKY();

        SORA sora = new SORA();

        // 世界のルールの宣言
        Action action = new Action();

        // 行動の宣言
        Flying flying = new Flying();

        DrawRectangle Rectangle ;

        // レンダリングターゲット
        public RenderTarget2D texRender;
        public DepthStencilBuffer depthRender;

        BasicEffect basicEffect;

        public Matrix view;
        public Matrix projection;

        Vector3 Gravity ;

        Vector3 cameraFront2 = new Vector3(0, 0, 0);
        Vector3 cameraRight2 = new Vector3(0, 0, 0);

        float Radians=0;//視点の方向

        public int modefun = 99;

        //サウンドのための変数
        public int Flysound ;
        Sound sound = new Sound();
        public float second = 0;
        public float dx= 0;
        public float dy=0;

        public int raputa=0,raputaflag=0;
        public int ship = 0, shipflag = 0,shipflag2=0;
        public int Ringgame = 0;
        public int[] Ringpoint=new int[7];
        public void dx_dy_reset(){
            this.dx=0f;
            this.dy=0f;
        }
        
        public void Action(ref Vector3 cameraPos, ref Vector3 cameraFront, ref Vector3 cameraRight, ref Vector3 cameraUp, ref float speed, ref KeyboardState keyboardState, ref int skygameFlag, SoundBank soundBank, AudioEngine engine, Cue bgm, OBJECT[] objects, int OB_MAX, OBJECT player)
        {
            keyboardState = Keyboard.GetState();

            // 首の向き
            float yaw = 0;
            float pitch = 0;
            float roll = 0;
            float dx_accel=0.05f;
            float dy_accel = 0.03f;
            
            //回転の加速度をゼロに近づける
            dx = dx * (1 - 1 / 20f);
            dy = dy * (1 - 1 / 20f);

            // キーボード
            //右移動
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                speed -= 0.01f;
                //yaw = 0.25f;
                dx += dx_accel;
             
                second-=0.5f;
            }
            //左移動
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                speed -= 0.01f;
                //yaw = -0.25f;
                dx-=dx_accel;

                second-=0.5f;
            }
            //移動反映
            yaw = dx;
            pitch = dy;

            //視点上
            if (keyboardState.IsKeyDown(Keys.Up)) {
                dy += dy_accel;
                //pitch = 1f; 
            }
            //視点下
            if (keyboardState.IsKeyDown(Keys.Down)){
                dy -= dy_accel;
                //pitch = -1f;
            }

            //ロール右
            if (keyboardState.IsKeyDown(Keys.X)) roll = 1f;
            //ロール左
            if (keyboardState.IsKeyDown(Keys.Z)) roll = -1f;

            

            //右に視点移動
            if (keyboardState.IsKeyDown(Keys.P)) Radians -= 1f;
            if (Radians > 75)
                Radians = 75;
            //左に視点移動
            if (keyboardState.IsKeyDown(Keys.O)) Radians +=1f;
            if (Radians < -75)
                Radians = -75;

            //自動で視点を戻す
            if (Radians > 0)
                Radians -=0.5f ;
            if (Radians < 0)
                Radians += 0.5f;

            //滑空判定
            second++;
            if (second > 60)  //5秒間羽ばたきがなければ
                action.set_glide();


            //常に少しずつ加速する
            if (action.check_glide_mode())  //滑空モードの時
            {
                //下を向いていたら
                if (cameraFront.Y < -0.7)
                {
                    speed += 0.15f;
                }
                else
                {
                    if (speed > 100)
                        speed =100f;
                    else speed += 0.1f;
                }
            }
            else  //はばたきモードの時
            {
                speed += 0.001f;
                if (speed > 20)
                    speed -= 0.1f;
            }

            //上を向いて減速
            if (cameraFront.Y > 0.4)
                speed =speed-speed*0.01f;

            //スピードがマイナスの時の処理
            if (speed < 0)
                speed = 0;

            //羽ばたく
            if (keyboardState.IsKeyDown(Keys.A))
            {
                action.accel_plus(0.5f);
                //羽ばたいたときのサウンド
                //Flysound = 1;
                sound.BGM(soundBank, engine, bgm, "Fly");
                action.reset_glide();
                second=0;
            }

            //加速
            if (keyboardState.IsKeyDown(Keys.S))
            {
                speed += 0.1f;
            }
            //減速
            if (keyboardState.IsKeyDown(Keys.D))
            {
                speed -= 0.1f;
            }

            //風の音
           // sound.BGM(soundBank, engine, bgm, "KAZE");


           //首にかかる重力
            if (cameraFront.Y > 0.01)
            {
                cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(-0.1f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians((float)-0.1)));
                
            }


            //水平に戻す
            if (cameraRight.Y < 0)
            {
                cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(-0.1f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(-0.1f)));

            }
            if (cameraRight.Y > 0)
            {
                cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(0.1f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(0.1f)));
            }


            // 宇宙船の回転（Yaw）
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(yaw)));
            cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(yaw)));

            //地上の判定
           /* if (cameraPos.Y < 80)
            {
                //cameraPos -= Gravity * (float)0.001;
               // 地上に落ちた
                skygameFlag = 1;
                cameraPos.Y = 80;
                action.set_accel(0.0f);
                action.reset_glide();
            }*/

            // 宇宙船の回転（Pitch）
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));

            // 宇宙船の回転（Roll）
            cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));

            // 宇宙船の進行
            cameraPos += cameraFront * speed;
            Vector3 cameraPos_buffer2 = cameraPos;
            Vector3 cameraPos_buffer = cameraPos;
            float speed_buffer = speed;

            // ぶつかったときの動作
            player.BSphere[0].Center = cameraPos;
            player.BSphere[0].Radius = 10f;
            bool tatch;



            while (true)
            {
                tatch = false;
                for (int j = 0; j < OB_MAX; j++)
                {
                    for (int i = 0; i < objects[j].BS_MAX; i++)
                    {
                        if (objects[j].Hit(player.BSphere[0], i) /*|| (cameraPos.Y < 80)*/)
                        {
                            action.accel = 0f;
                            tatch = true;
                            skygameFlag = 1;
                            dx_dy_reset();

                            cameraPos.Y += 1;
                            player.BSphere[0].Center = cameraPos;
                            break;
                        }
                    }
                }
                if (!tatch) break;
            }

            player.BSphere[1].Center = cameraPos;
            player.BSphere[1].Radius = 20f;
            for (int j = 0; j < OB_MAX; j++)
            {
                for (int i = 0; i < objects[j].BS_MAX; i++)
                {
                    tatch = false;
                    if (objects[j].Hit(player.BSphere[1], i) /*|| (cameraPos.Y < 80)*/)
                    {
                        
                        skygameFlag = 1;
                        dx_dy_reset();
                        /*
                        speed -= 0.05f;
                        if (speed < 0f)
                            speed = 0;*/
                        tatch = true;
                        
                        //ラピュタフラグ
                        if (raputaflag == 0 && objects[77].Hit(player.BSphere[1], i))
                        {
                            raputaflag = 1;
                            raputa = 1;
                        }
                        //船フラグ
                        if (j<77&&j>64&&shipflag == 0 && objects[j].Hit(player.BSphere[1], i)&&speed<5)
                        {
                            shipflag = 1;
                            ship = 1;
                        }
                        //リングゲームフラグ
                        if (Ringgame == 0 && objects[36].Hit(player.BSphere[1], i))
                        {
                            Ringgame = 1; 
                        }
                        if (j > 78 && j < 86)
                        {
                            skygameFlag = 0;
                        }
                        //リングゲームプレイ
                        if (j>78&&j<86&&Ringgame == 1 && objects[j].Hit(player.BSphere[1], i))
                        {
                            Ringpoint[j-79]=1;
                        }
                        break;
                    }
                }
            }

            if (!tatch)
            {
                //重力
                cameraPos.Y = action.Gravity(cameraPos.Y);
                cameraPos += Gravity * (float)0.0001;
            }

            

        }

        public void Initialize(ref GraphicsDeviceManager graphics)
        {
            Rectangle = new DrawRectangle();
            // TODO: Add your initialization logic here
            // レンダリングターゲット
            texRender = new RenderTarget2D(graphics.GraphicsDevice,
                800, 600, 1, SurfaceFormat.Color);
            depthRender = new DepthStencilBuffer(graphics.GraphicsDevice,
                800, 600, DepthFormat.Depth24Stencil8, MultiSampleType.None, 0);
            
        }
        public void ikarosu() {
            action.accelminer();
        }
        //モードチェック
        public bool checkmode() {
            return action.check_glide_mode();
        }

        public void Graphic(Vector3 cameraPos, Vector3 cameraFront,  Vector3 cameraRight,  Vector3 cameraUp,
             GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime, RenderTarget2D texRender, RenderTarget2D texRender2,float speed
            , OBJECT[] objects, int OB_MAX,int wordflag,GraphicsDevice GDevice,White white)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;

            //視点の変更
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(Radians)));
            cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(Radians)));
           

            // ビュー座標変換行列
            view = Matrix.CreateLookAt(
                cameraPos,  //カメラ位置
                cameraPos + cameraFront,    //カメラ方向
                cameraUp    //カメラ上方向
                );

            // 射影変換行列
            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f),
                (float)graphics.GraphicsDevice.Viewport.Width /
                graphics.GraphicsDevice.Viewport.Height,
                0.1f,
                400000.0f);

            // 宇宙空間の表示
            sky.Draw( view, projection, cameraPos.X, 0, cameraPos.Z);

            sora.Draw(view, projection,20,100);
            

            if (wordflag == 1)
            {
                // 座標
                spriteBatch.DrawString(font, "[Position]", new Vector2(10, 10), Color.YellowGreen);
                spriteBatch.DrawString(font, "X: " + cameraPos.X.ToString(), new Vector2(10, 30), Color.YellowGreen);
                spriteBatch.DrawString(font, "Y: " + cameraPos.Y.ToString(), new Vector2(10, 50), Color.YellowGreen);
                spriteBatch.DrawString(font, "Z: " + cameraPos.Z.ToString(), new Vector2(10, 70), Color.YellowGreen);


                // 方向
                spriteBatch.DrawString(font, "[Front]", new Vector2(160, 10), Color.YellowGreen);
                spriteBatch.DrawString(font, "X: " + cameraFront.X.ToString(), new Vector2(160, 30), Color.YellowGreen);
                spriteBatch.DrawString(font, "Y: " + cameraFront.Y.ToString(), new Vector2(160, 50), Color.YellowGreen);
                spriteBatch.DrawString(font, "Z: " + cameraFront.Z.ToString(), new Vector2(160, 70), Color.YellowGreen);
                // 方向
                spriteBatch.DrawString(font, "[Right]", new Vector2(450, 10), Color.YellowGreen);
                spriteBatch.DrawString(font, "X: " + cameraRight.X.ToString(), new Vector2(450, 30), Color.YellowGreen);
                spriteBatch.DrawString(font, "Y: " + cameraRight.Y.ToString(), new Vector2(450, 50), Color.YellowGreen);
                spriteBatch.DrawString(font, "Z: " + cameraRight.Z.ToString(), new Vector2(450, 70), Color.YellowGreen);

                // 方向
                spriteBatch.DrawString(font, "[Up]", new Vector2(310, 10), Color.YellowGreen);
                spriteBatch.DrawString(font, "X: " + cameraUp.X.ToString(), new Vector2(310, 30), Color.YellowGreen);
                spriteBatch.DrawString(font, "Y: " + cameraUp.Y.ToString(), new Vector2(310, 50), Color.YellowGreen);
                spriteBatch.DrawString(font, "Z: " + cameraUp.Z.ToString(), new Vector2(310, 70), Color.YellowGreen);
            }
            BoundingFrustum enabler_model = new BoundingFrustum(view * projection);
            // モデルの表示
            for (int j = 0; j < OB_MAX; j++)
            {
                for (int i = 0; i < objects[j].BS_MAX; i++)
                {
                    Vector2 cameraPos_XZ = new Vector2(cameraPos.X, cameraPos.Z);
                    Vector2 objectsPos_XZ = new Vector2(objects[j].position.X, objects[j].position.Z);

                    if (Vector2.Distance(cameraPos_XZ, objectsPos_XZ) <= 20 * cameraPos.Y + 10000)
                    if (enabler_model.Intersects(objects[j].BSphere[i]))
                    {
                        if (j > 78 && j < 86 && Ringgame == 0)
                        {
                            break;
                        }
                        if (j > 78 && j < 86 && Ringgame == 1&&Ringpoint[j-79]==1)
                        {
                            break;
                        } 
                        switch (objects[j].object_type)
                        {
                            case 1:
                                if (Vector3.Distance(cameraPos, objects[j].position) <= 12000)
                                    objects[j].Draw(view, projection);
                                break;
                            default:
                                if (Vector3.Distance(cameraPos, objects[j].position) <= 25000)
                                    objects[j].Draw(view, projection);
                                break;
                        }
                        objects[j].Update();
                        objects[j].Draw(view, projection);
                        break;
                    }
                }
            }

            /*
            graphics.GraphicsDevice.RenderState.FillMode = FillMode.WireFrame;
            for (int i = 0; i < OB_MAX; i++)
            {
                objects[i].DrawBounding(view, projection);
            }
            graphics.GraphicsDevice.RenderState.FillMode = FillMode.Solid;
                   */
            // 太陽による明度調節
            float alpha = 0f;

            Vector3 v3 = GDevice.Viewport.Project(new Vector3(100000, 100000, 100000), projection, view, Matrix.Identity);
            Vector2 v2 = new Vector2(v3.X, v3.Y);

            //spriteBatch.DrawString(font, v2.X + "," + v2.Y, new Vector2(0, 0), Color.White);

            alpha = Vector2.Distance(v2, new Vector2(400, 300));

            Vector2 vec = new Vector2();
            float alpha2 = alpha / 350f;
            if (alpha2 > 1.0f)
                alpha2 = 1.0f;
            alpha2 = 1.0f - alpha2;
            if (cameraFront.Y > 0)
            {
                // 太陽
                white.Draw(ref graphics, ref spriteBatch, v2);
                // レンズに映る太陽の光(1ブロック)
                vec = -1.0f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 1.0f);
                vec = -0.9f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.8f);
                vec = -0.6f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.3f);
                vec = -0.55f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.3f);
                vec = -0.5f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.4f);
                vec = -0.4f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.3f);
                vec = -0.2f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.6f);
                vec = 0.2f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.1f);
                vec = 0.1f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.05f);
                vec = 1.4f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.1f);
                vec = 1.5f * (v2 - new Vector2(400, 300)) + new Vector2(400, 300);
                white.Draw(ref graphics, ref spriteBatch, alpha2, vec, 0.05f);

                alpha2 = alpha / 300f;
                if (alpha2 > 1.0f)
                    alpha2 = 1.0f;
                alpha2 = 1.0f - alpha2;
                white.Draw(ref graphics, ref spriteBatch, alpha2);
            }

        }
    }
}
    


