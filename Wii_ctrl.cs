using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using System.Collections;

namespace SORAKAKE.Ver1
{
    public class Wii_ctrl
    {
        //Wiiremote宣言
        public int Conect = 0;                            //接続数を格納
        public WiimoteCollection wc = null;               //WiimoteCollectionの宣言
                
        WiimoteState ws;
        Wiimote wm = new Wiimote();
        ArrayList[] Accel = new ArrayList[2];
        float L_lastdata = 0.0f;
        float R_lastdata = 0.0f;
        float Lx=0, Rx=0, Ly=0, Ry=0;
        double rad=0, rad2=0;
        public bool connection = false;

        public Wii_ctrl()
        {
            this.Accel[0] = new ArrayList();  //リスト定義
            this.Accel[1] = new ArrayList();  //リスト定義
        }

        public bool Connec_check() {
            return connection;
        }
        public void Connect()
        {
            connection = true;
            wc = new WiimoteLib.WiimoteCollection(); //WiimoteCollectionを生成
            this.Conect = 0;
            this.wc.FindAllWiimotes();                    //Wiiリモコン登録を調べる

            foreach (WiimoteLib.Wiimote wmm in wc)
            {
                //Wiiリモコンが見つかった回数だけ繰り返す
                try
                {
                    wmm.Connect();                                          //接続
                    wmm.SetReportType(WiimoteLib.InputReport.IRAccel, true);//レポートタイプの設定

                    switch (this.Conect)
                    {
                        case 0:
                            wmm.WiimoteChanged += wm_WiimoteChanged_01;     //イベント設定   
                            wm = wmm;
                            break;

                        case 1:
                            wmm.WiimoteChanged += wm_WiimoteChanged_02;     //イベント設定
                            //wm = wmm;
                            break;
                    }

                    this.Conect++;//カウント++
                }
                catch   {       }
            }
        }

        //Wiiリモコンの値が変化したときに呼ばれる関数
        void wm_WiimoteChanged_01(object sender, WiimoteChangedEventArgs args)
        {
            //WiimoteStageの値を取得
            WiimoteState wss = args.WiimoteState;
            //ws = wss;
            
        }

        //Wiiリモコンの値が変化したときに呼ばれる関数
        void wm_WiimoteChanged_02(object sender, WiimoteChangedEventArgs args)
        {
            //WiimoteStageの値を取得
            WiimoteState wss = args.WiimoteState;
            ws = wss;

            float Lx = 0.0f, Ly = 0.0f, Rx = 1.0f, Ry = 1.0f;
            L_R_position(ref Lx,ref Ly,ref Rx,ref Ry);

            //差分をリストに追加
            this.Accel[0].Add(Ly - L_lastdata); //左端
            this.Accel[1].Add(Ry - R_lastdata); //右端
            L_lastdata = Ly;
            R_lastdata = Ry;

            int list_max = 60;  //リストの最大要素数
            if (this.Accel[0].Count > list_max) { this.Accel[0].RemoveAt(0); } //溢れた分を削除
            if (this.Accel[1].Count > list_max) { this.Accel[1].RemoveAt(0); }
            
        }

        public void L_R_position(ref float Lx,ref float Ly,ref float Rx,ref float Ry)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!ws.IRState.IRSensors[i].Found)
                    continue;
                Lx = Math.Max(Lx, ws.IRState.IRSensors[i].Position.X);
                Rx = Math.Min(Rx, ws.IRState.IRSensors[i].Position.X);
            }
            for (int i = 0; i < 4; i++)
            {
                if (!ws.IRState.IRSensors[i].Found)
                    continue;
                if (Lx == ws.IRState.IRSensors[i].Position.X)
                    Ly = ws.IRState.IRSensors[i].Position.Y;
                if (Rx == ws.IRState.IRSensors[i].Position.X)
                    Ry = ws.IRState.IRSensors[i].Position.Y;
            }
            this.Lx = Lx;
            this.Ly = Ly;
            this.Rx = Rx;
            this.Ry = Ry;
        }

        //旋回検出
        public int turn_check() {
            float Rx=1, Ry=1, Lx=0, Ly=0;
            int wide = 10;
            L_R_position(ref Lx,ref Ly,ref Rx,ref Ry);
            this.Lx = Lx;
            this.Ly = Ly;
            this.Rx = Rx;
            this.Ry = Ry;

            float pos_x = (Lx+Rx)/2 , pos_y = (Ly+Ry)/2;

            rad = Math.Atan2(Ry - pos_y, (pos_x - Rx));
            rad = rad * 180 / Math.PI;
            if (Rx == 1) rad = 0;

            rad2 = Math.Atan2((Ly - pos_y), (Lx - pos_x));
            rad2 = rad2 * 180 / Math.PI;
            if (Lx == 0) rad2 = 0;

            if (wide < rad && rad2 < -wide) return 1; //"左旋回中です。";
            else if (wide < rad2 && rad < -wide) return -1; //"右旋回中です。";
            else return 0; //滑空中です。
        }
        
        //はばたき検出
        public bool flaps_check_list()
        {
            if (Ave_List(Accel[0]) < -4.0f && Ave_List(Accel[1]) < -4.0f) return true; //両端の差分が-5以下なら

            return false;       //どちらでもなければ
        }

        //はばたき検出 パターン2
        public float flaps_check() {
            float Ave1 = Ave_List(Accel[0]);
            float Ave2 = Ave_List(Accel[1]);
            float level = 15f;

            if (Ave1 > 0) Ave1 = 0; Ave2 = 0;
            if (Ave2 > 0) Ave1 = 0; Ave2 = 0;

            if ((Ave1 + Ave2) == 0) return 0;
            else                    return (Ave1+Ave2)/level;
        }

        //差分平均を返す関数
        public float Ave_List(ArrayList Accel)
        {
            float sum = 0, ave_Y;
            for (int i = 0; i < Accel.Count; i++)
                sum = sum + (float)Accel[i];
            ave_Y = sum / Accel.Count * 1000;

            return ave_Y;
        }

        //重心の前後
        public int center_check()
        {
            int check = 0;
            float Y = wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y;
            float border = 6.0f;

            if (wm.WiimoteState.BalanceBoardState.WeightKg < 10.0)
                return 0;

            if (border < Y)
                check = -1;
            else if (border > Y && Y > -border)
                check = 0;
            else if (Y < -border)
                check = 1;

            return check;
        }

        //重心の左右
        public int corse_check()
        {
            int check = 0;
            float X = wm.WiimoteState.BalanceBoardState.CenterOfGravity.X;
            float border = 10.0f;

            if (wm.WiimoteState.BalanceBoardState.WeightKg < 10.0)
                return 0;

            if (border < X)
                check = -1;
            else if (border > X && X > -border)
                check = 0;
            else if (X < -border)
                check = 1;

            return check;
        }

        public float getIR_X() { return ws.IRState.IRSensors[0].Position.X; }
        public float getIR_Y() { return ws.IRState.IRSensors[0].Position.Y; }

        public float getAccel0() { return Ave_List(Accel[0]); }
        public float getAccel1() { return Ave_List(Accel[1]); }

        public double get_rad() { return rad; }
        public double get_rad2() { return rad2; }

        public void get_L(ref float Lx, ref float Ly) { Lx = this.Lx; Ly = this.Ly; }
        public void get_R(ref float Rx, ref float Ry) { Rx = this.Rx; Ry = this.Ry; }
        
        public float carryLx() { return this.Lx;        }
        public float carryLy() { return this.Ly;        }
        public float carryRx() { return this.Rx;        }
        public float carryRy() { return this.Ry;        }

        public float getWeight() { return wm.WiimoteState.BalanceBoardState.WeightKg; }

        public bool getIR_Found() { return (ws.IRState.IRSensors[0].Found || ws.IRState.IRSensors[1].Found); }

        public Wiimote get_wm() { return wm; }
        public WiimoteState get_ws() { return ws; }
    }

}
