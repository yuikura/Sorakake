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
    class Character
    {
        Texture2D WAKUimg;
        String str;
        int flag = 0,flag2=0,N=0,N2=0;
        float timestart, timestart2,ringtime,ringpoint;
        public void Load(ContentManager content){
            WAKUimg = content.Load<Texture2D>("MessageWindow");

        }
        //時間を取得
        public float GetTimer(GameTime gameTime)
        {
            float X;
            X = gameTime.TotalGameTime.Seconds;
            if ((int)X == 0 && N2 == 0)
            {
                N++;
                N2 = 1;
            }
            else if ((int)X == 1)
            {
                N2 = 0;
            }
            return X + (N-1) * 60;
        }
        //表示する文字の選択
        public void CharacterSelect(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime)
        {
            str = "今日の天気は晴れなようです";
            //Grahpics(str,graphics, spriteBatch, font,gameTime);
        
        }
        //時間取得
        public void GetMiddle(int TIME) {
            ringtime = TIME;
        }
        //リング取得
        public void GetRing(int N) {
            ringpoint=N;
        }
        //文字の表示
        public void Grahpics(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime,ref int N)
        {
            if(N==1){  //初めての挨拶
                 if (flag == 0) {    
                     timestart=GetTimer(gameTime);
                     flag = 1;
                 }
                 if (5 > GetTimer(gameTime) - timestart)
                 {
                     spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                     spriteBatch.DrawString(font, "そらかけ!の世界にようこそ!\n                     Have a good time", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                 }
                 else {
                     N = 99;
                 }
            }
            else if (N == 2)
            {    //高度が高すぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (2 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "高度が高過ぎます。\n      下降してください。", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
            }
            else if (N == 3)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "遠くにいき過ぎです!\n            引き返しますね", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 4)
            {    //一回転したとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました!\n       1回転に成功しました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 5)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました! \n       大きく助走をつけて飛び立ちしました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 6)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました \n     エベレストほどの高さを距離を飛行しました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 7)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました\n    オリンピックマラソンの距離を飛びました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 8)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました!\n    最高速度に達しました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 9)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました\n    天空の城に降り立ちました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 10)
            {    //最高速度で飛び立ったとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! アピールに成功しました\n    冒険者達の船の上に降り立ちました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
           /* else if (N == 6)
            {    //長時間で飛び続けたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > gameTime.TotalGameTime.Seconds - timestart)
                {
                    spriteBatch.DrawString(font, "アピール成功! 長時間飛行を達成しました!", new Vector2(150, 520), Color.White);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }*/
            else if (N == 92)
            {    //ゲームスタート
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (3 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "リングゲームスタート!!!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 93)
            {    //達成
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "Congratulation! 達成者よ! \n  すべてのリングを獲得しました!\n  TIMEは" + ringtime + "でした", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 94)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    int Num = 7;
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "リングを獲得しました!\n    残り" + (Num - ringpoint) + "です!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 94)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (3 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "リングをすべて獲得しました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 95)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "おめでとうございます\n    大気圏を抜けるまで飛びました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 96)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "おめでとうございます\n      地球1周分飛びました!", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 97)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "おめでとうございます\n     月まであなたは飛びました", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else if (N == 98)
            {    //遠くに行き過ぎたとき
                if (flag == 0)
                {
                    timestart = GetTimer(gameTime);
                    flag = 1;
                }
                if (5 > GetTimer(gameTime) - timestart)
                {
                    spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                    spriteBatch.DrawString(font, "水没しました...\n       マップの中心から始めます", new Vector2(40, 515), Color.Black);
                    // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                }
                else
                {
                    N = 99;
                }
                //その他
            }
            else
            {
                // spriteBatch.DrawString(font, "                               ", new Vector2(200, 520), Color.White);
                //spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
                flag = 0;
                N = 99;
                spriteBatch.DrawString(font, "                              \n                               ", new Vector2(10, 520), Color.White);
            }
            spriteBatch.DrawString(font, "                              ", new Vector2(10, 520), Color.White);
           // spriteBatch.Draw(WAKUimg, new Vector2(10,480), Color.White);
        }
        public void Grahpics2(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime, int TIME) {
            if (flag2 == 0)
            {
                timestart2 = GetTimer(gameTime);
                flag2 = 1;
            }
            if (5 > GetTimer(gameTime) - timestart2)
            {
                spriteBatch.Draw(WAKUimg, new Vector2(10, 480), Color.White);
                spriteBatch.DrawString(font, "Congratulation! 達成者よ! \n  すべてのリングを獲得しました!\n    TIMEは" + ringtime + "でした", new Vector2(40, 515), Color.Black);
                // spriteBatch.DrawString(font, gameTime.ElapsedGameTime.Seconds.ToString(), new Vector2(400, 520), Color.White);
            }
        }
    }
}
