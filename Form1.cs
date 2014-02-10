using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WiimoteLib;

namespace Wii_Remote
{
    public partial class Form1 : Form
    {
        Wiimote wm = new Wiimote();                               //Wiimoteの宣言
        private WiimoteState ws;
        private int count = 0;
        private int countB = 0, countA = 0;
        private int flag = 0;
        private int point = 0;
        ArrayList[] Accel = new ArrayList[1];
        private float lastdata=0.0f;
        
        public Form1()
        {
            InitializeComponent();
            //他スレッドからのコントロール呼び出し許可
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Accel[0] = new ArrayList();  //リスト定義
        }

        //接続ボタンが押されたら
        private void button1_Click(object sender, EventArgs e)
        {
            wm.Connect();                                        //Wiimoteの接続
            wm.WiimoteChanged += wm_WiimoteChanged;              //イベント関数の登録
            wm.SetReportType(InputReport.IRExtensionAccel, true);//レポートタイプの設定
            this.label1.Text = "   接続中です。";
        }
        //切断ボタンが押されたら
        private void button2_Click(object sender, EventArgs e)
        {
            wm.Disconnect();                                     //Wiimote切断
            this.label1.Text = "   切断されました。";
        }

        private void button3_Click(object sender, EventArgs e)
        {            wm.SetRumble(true);        }

        private void button4_Click(object sender, EventArgs e)
        {            wm.SetRumble(false);        }

        //Wiiリモコンの値が変化したときに呼ばれる関数
        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            ws = args.WiimoteState;      //WiimoteStateの値を取得
            Invalidate();　　　　　　　　　　////フォーム描写関数へ
            if (ws.ButtonState.A == true){
                this.label2.Text = "   Aボタンが押されました。" + countA; countA++;   }
            if (ws.ButtonState.B == true){
                this.label3.Text = "   Bボタンが押されました。" + countB; countB++;   }

            this.Accel[0].Add(ws.IRState.IRSensors[0].Position.Y-lastdata); //差分をリストに追加
            lastdata = ws.IRState.IRSensors[0].Position.Y;

            //差分の平均を求める。
            float sum=0, ave_Y;     
            for (int i = 0; i < this.Accel[0].Count; i++)
                sum = sum + (float)this.Accel[0][i];
            ave_Y = sum / this.Accel[0].Count*1000;

            this.label11.Text = "  差分の平均："+ave_Y;

            int list_max = 60;
            if (this.Accel[0].Count > list_max) { this.Accel[0].RemoveAt(0); }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int top = 70;
            int left = 300;
            int left_main = 500;
            int top_main = 500;
            int level = 500;
            int Left = left + left_main / 2;
            int Top = top + top_main / 2;
            Graphics g = e.Graphics;//グラフィックスを取得
            Brush br = new SolidBrush(Color.Black);
            g.FillRectangle(br, left, top, left_main, top_main);

            if (ws == null)
                return;

            g.FillEllipse(Brushes.CornflowerBlue, Left, Top, 4, 4);

            point+=flaps_check();
            

            //もし赤外線を１つ発見したら
            if (ws.IRState.IRSensors[0].Found)
            {
                //赤色でマーカを描写
                g.FillEllipse(Brushes.Red,
                               left + left_main + -ws.IRState.IRSensors[0].Position.X * level,
                               top + top_main + -ws.IRState.IRSensors[0].Position.Y * level, 10, 10);
                this.label5.Text = "   LEDを検出しました。";
                this.label6.Text = "   X=" + ws.IRState.IRSensors[0].Position.X;
                this.label7.Text = "   Y=" + ws.IRState.IRSensors[0].Position.Y;
            }
            else this.label5.Text = "";

            //もし赤外線を２つ発見したら
            if (ws.IRState.IRSensors[1].Found)
            {
                //青色でマーカを描写
                g.FillEllipse(Brushes.Blue,
                               left + left_main + -ws.IRState.IRSensors[1].Position.X * level,
                               top + top_main + -ws.IRState.IRSensors[1].Position.Y * level, 10, 10);
            }

            //もし赤外線を３つ発見したら
            if (ws.IRState.IRSensors[2].Found)
            {
                //黄色でマーカを描写
                g.FillEllipse(Brushes.Yellow,
                               left + left_main + -ws.IRState.IRSensors[2].Position.X * level,
                               top + top_main + -ws.IRState.IRSensors[2].Position.Y * level, 10, 10);
            }

            //もし赤外線を４つ発見したら
            if (ws.IRState.IRSensors[3].Found)
            {
                //緑色でマーカを描写
                g.FillEllipse(Brushes.Green,
                               left + left_main + -ws.IRState.IRSensors[3].Position.X * level,
                               top + top_main + -ws.IRState.IRSensors[3].Position.Y * level, 10, 10);
            }

            float Lx = 0.0f, Ly = 0.0f, Rx = 1.0f, Ry = 1.0f;
            
            for (int i=0; i < 4; i++) {
                if (!ws.IRState.IRSensors[i].Found)
                    continue;
                Lx = Math.Max(Lx, ws.IRState.IRSensors[i].Position.X);
                Rx = Math.Min(Rx, ws.IRState.IRSensors[i].Position.X);
            }
            for (int i = 0; i < 4 ; i++) {
                if (!ws.IRState.IRSensors[i].Found)
                    continue;
                if (Lx == ws.IRState.IRSensors[i].Position.X)
                    Ly = ws.IRState.IRSensors[i].Position.Y;
                if (Rx == ws.IRState.IRSensors[i].Position.X)
                    Ry = ws.IRState.IRSensors[i].Position.Y;
            }

            this.label9.Text = "  左端：X="+Lx+" Y="+Ly;
            this.label10.Text = "  右端：X="+Rx+" Y="+Ry;

            double rad = Math.Atan2(Ry - 0.5 , 1 - Rx - 0.5);
            rad = rad * 180 / Math.PI;
            if (Rx == 1) rad = 0;
            this.label12.Text = "Rx rad =" + rad;

            double rad2 = Math.Atan2(-(Ly - 0.5),-( 1 - Lx - 0.5));
            rad2 = rad2 * 180 / Math.PI;
            rad2 = rad2 * -1;
            if (Lx == 0) rad2 = 0;
            this.label13.Text = "Lx rad =" + rad2;

            if (20 < rad && rad2 < -20) this.label14.Text = "左旋回中です。";
            else if (20 < rad2 && rad < -20) this.label14.Text = "右旋回中です。";
            else this.label14.Text = "滑空中です。";

            g.Dispose();//グラフィックスの解放
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.button5.Text = "   wm.SetLEDs(" + count + ") を表示中";
            this.wm.SetLEDs(count);
            count++;
        }

        private int flaps_check()
        {
            float border_top = 0.700f;
            float border_buttom = 0.300f;
            float Y = ws.IRState.IRSensors[0].Position.Y;
            int check = 0;

            if (Y != 0 && border_top < Y)
            {
                //上方に届いていれば
                flag = 1;
            }
            else if (Y != 0 && Y < border_buttom)
            {
                //下方に届いていれば
                if (flag == 1)
                {
                    check = 1;
                    flag = 0;
                }
            }
            this.label8.Text = "   flag=" + flag + " check=" + check+" point="+point;
            return check;
        }
    }
}