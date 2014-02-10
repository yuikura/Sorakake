using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SORAKAKE.Ver1
{
    class Appeal
    {
        float grideup,gridedown;
        float turntime,grideflag=0,disflag=0;
        int turnflag =0;
        //ここから
        public int AppealStart(GameTime gameTime,Vector3 cameraUp,float speed,double TotalKm) {
            if (Trun(gameTime, cameraUp) == 2)
            {
                turnflag = 0;
                return 1;  //一回転した
            }else if(GRIDE(speed)==1){
                return 2;  //最高速度で飛び立った
            }
            /*else if (DISTANCE(TotalKm) == 1)
            {
                return 3;  //長時間飛行した
            }*/
            return 0;
        }
        //時間取得
        public float GetTimer(GameTime gameTime)
        {
            return gameTime.TotalGameTime.Seconds;
        }
        //一回転
        int Trun(GameTime gameTime,Vector3 cameraUp) {
            if (cameraUp.Y > -0.99 && cameraUp.Y < -0.97 && turnflag == 0)
            {
                turntime = GetTimer(gameTime);
                turnflag = 2;
            }
           /* if (turnflag == 1) {
                if (GetTimer(gameTime) - turntime > 3) {
                    turnflag = 2;
                }
            }*/
            return turnflag;
        }
        //飛び立つ
        int GRIDE(float speed)
        {
            turnflag = 0;
            if (speed > 4.5)
            {
                return  1;
            }
            return 0;
        }
        //走行距離
        int DISTANCE(double TotalKM)
        {
            if (TotalKM / 100 > 1000&&disflag==0)
            {
                disflag = 1;
                return 1;
            }
            else
            {
                return 0;
            }
        }
       
        
    }
}
