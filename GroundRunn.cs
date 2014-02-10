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
    class GroundRun
    {
        // 空間の宣言
        SKY sky = new SKY();

        // 世界のルールの宣言
        Action action = new Action();

        // 行動の宣言
        Flying flying = new Flying();
        public void Action(ref Vector3 cameraPos, ref Vector3 cameraFront, ref Vector3 cameraRight, ref Vector3 cameraUp, ref float speed, ref KeyboardState keyboardState, ref int skygameFlag)
        {
            keyboardState = Keyboard.GetState();

            // 首の向き
            float yaw = 0;
            float pitch = 0;
            float roll = 0;

            // キーボード
            //右に体重が乗ったとき
            if (keyboardState.IsKeyDown(Keys.Left)) yaw = 1f;
            //左に体重が乗ったとき
            if (keyboardState.IsKeyDown(Keys.Right)) yaw = -1f;
            //後ろに体重が乗ったとき
            if (keyboardState.IsKeyDown(Keys.Up)) pitch = 1f;
            //前に体重が乗ったとき
            if (keyboardState.IsKeyDown(Keys.Down)) pitch = -1f;
            //ロール右
            if (keyboardState.IsKeyDown(Keys.X)) roll = 1f;
            //ロール左
            if (keyboardState.IsKeyDown(Keys.Z)) roll = -1f;

            //羽ばたく
            if (keyboardState.IsKeyDown(Keys.A))
            {
                //空へ飛び立つ
                skygameFlag = 0;
                cameraPos.Y = flying.Flaps(cameraPos.Y,20);
            }

            //加速
            if (keyboardState.IsKeyDown(Keys.S))
            {
                cameraPos += cameraFront * speed;
                speed += 0.2f;
                if (speed > 20)
                    speed = 20;
            }
            //減速
            if (keyboardState.IsKeyDown(Keys.D))
            {
                speed -= 0.2f;
                if (speed < 0)
                    speed = 0;
            }



           

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
            if (cameraPos.Y < 80)
            {
                //地上に落ちた
                skygameFlag = 1;
                cameraPos.Y = 80;
            }

            // 宇宙船の回転（Pitch）
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(pitch)));

            // 宇宙船の回転（Roll）
          //  cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));
           // cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraFront, MathHelper.ToRadians(roll)));

            // 宇宙船の進行
            //cameraPos += cameraFront;


           // cameraPos += cameraFront * speed;

        }
    }
}
