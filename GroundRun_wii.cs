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
    class GroundRun_wii
    {
        // 空間の宣言
        SKY sky = new SKY();

        // 世界のルールの宣言
        Action action = new Action();

        // 行動の宣言
        Flying flying = new Flying();
        public void Action(ref Vector3 cameraPos, ref Vector3 cameraFront, ref Vector3 cameraRight, ref Vector3 cameraUp, ref float speed, ref KeyboardState keyboardState, ref int skygameFlag, OBJECT[] objects, int OB_MAX, OBJECT player, ref Wii_ctrl wii)
        {
            keyboardState = Keyboard.GetState();

            // 首の向き
            float yaw = 0;
            float pitch = 0;
            float roll = 0;

            // キーボード
            //右に体重が乗ったとき
            if (wii.corse_check() == 1 || keyboardState.IsKeyDown(Keys.Left)) yaw = 1f;
            //左に体重が乗ったとき
            if (wii.corse_check() == -1 || keyboardState.IsKeyDown(Keys.Right)) yaw = -1f;
            //視点上
            if (keyboardState.IsKeyDown(Keys.Up)) pitch = 1f;
            //視点下
            if (keyboardState.IsKeyDown(Keys.Down)) pitch = -1f;
            //ロール右
            if (keyboardState.IsKeyDown(Keys.X)) roll = 1f;
            //ロール左
            if (keyboardState.IsKeyDown(Keys.Z)) roll = -1f;


            //羽ばたく
            if (wii.flaps_check_list() || keyboardState.IsKeyDown(Keys.A))
            {
                action.accel_plus(5.0f);
                //重力
                cameraPos.Y = action.Gravity(cameraPos.Y);
            }

            //着地した時に止まるようにスピード調整
            if (speed > 0)
            {
                speed -= speed * 0.01f;
                if (speed < 0.1f) speed = 0;
            }

            //加速
            if (wii.center_check() == 1 || (keyboardState.IsKeyDown(Keys.S)))
            {
                cameraPos += cameraFront * speed;
                speed += 0.05f;
                if (speed > 20)
                    speed = 20;
            }
            //減速
            if (wii.center_check() == -1 || keyboardState.IsKeyDown(Keys.D))
            {
                if (speed < 0.1)    speed = 0;
                else                speed -= 0.05f;
            }

            //重力が負にならないように
            if (action.accel < 0) action.set_accel(0.0f);

            //首にかかる重力
            if (cameraFront.Y > 0.01)
            {
                cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(-0.1f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians((float)-0.1)));
            }

            //首にかかる強制力
            if (cameraFront.Y < 0)
            {
                cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(0.3f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians((float)0.3)));
            }

            //水平に戻す
            if (cameraRight.Y < 0)
            {
                cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(-0.4f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(-0.4f)));

            }
            if (cameraRight.Y > 0)
            {
                cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(0.4f)));
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(0.4f)));
            }


            // 宇宙船の回転（Yaw）
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(yaw)));
            cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(yaw)));

            //地上の判定
            if (cameraPos.Y < 80)
            {
                //地上に落ちた
                skygameFlag = 1;
                cameraPos.Y = 80;
                action.reset_glide();

            }
            else if (cameraPos.Y > 81)
                skygameFlag = 0;    //地上から離れた

            // 宇宙船の回転（Pitch）
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));

            // 宇宙船の回転（Roll）
            //  cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));
            // cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));

            // 宇宙船の進行
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
                        if (objects[j].Hit(player.BSphere[0], i)/* || (cameraPos.Y < 80)*/)
                        {
                            action.accel = 0f;

                            tatch = true;
                            skygameFlag = 1;

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
                        skygameFlag = 1;/*
                        speed -= 0.05f;
                        if (speed < 0f)
                            speed = 0;*/
                        tatch = true;
                        break;
                    }
                }
            }
            cameraPos.X += cameraFront.X * speed / 10;
            cameraPos.Z += cameraFront.Z * speed / 10;

            //cameraPos += cameraFront;
        }
    }
}
