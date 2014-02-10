using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;

namespace SORAKAKE.Ver1
{
    public partial class Test : Form
    {
        Wii_ctrl wii = new Wii_ctrl();
        WiimoteState ws;
        Wiimote wm;
        Menu menu;

        public Test(Wii_ctrl wii,Menu game)
        {
            this.menu = game;
            this.wii = wii;
            InitializeComponent();
        }

        public void Test_inv(){
            this.DoubleBuffered = true;
            this.Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.ws = wii.get_ws();
            this.wm = wii.get_wm();

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

            g.FillEllipse(Brushes.White, Left, Top, 4, 4);


            //もし赤外線を１つ発見したら
            if (ws.IRState.IRSensors[0].Found)
            {
                //赤色でマーカを描写
                g.FillEllipse(Brushes.Red,
                               left + left_main + -ws.IRState.IRSensors[0].Position.X * level,
                               top + top_main + -ws.IRState.IRSensors[0].Position.Y * level, 10, 10);
            }

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

            float Rx = 1, Ry = 1, Lx = 0, Ly = 0;
            wii.L_R_position(ref Lx, ref Ly, ref Rx, ref Ry);
            float pos_x = (Lx + Rx) / 2, pos_y = (Ly + Ry) / 2;

            double rad = Math.Atan2(Ry - pos_y, (pos_x - Rx));
            rad = rad * 180 / Math.PI;
            if (Rx == 1) rad = 0;

            double rad2 = Math.Atan2((Ly - pos_y), (Lx - pos_x));
            rad2 = rad2 * 180 / Math.PI;
            if (Lx == 0) rad2 = 0;


            this.label6.Text =
                  "Left  X="+wii.carryLx()+
                "\n      Y="+wii.carryLy()+
                "\nRight X="+wii.carryRx()+
                "\n      Y="+wii.carryRy();
            

            //以下バランスボードの記述

            int left2 = 50, top2 = 100;
            g.FillRectangle(br, left2, top2, 200, 200);

            //X、Y座標の計算
            float x =
                (wm.WiimoteState.BalanceBoardState.CenterOfGravity.X) * 4;    //表示位置(X座標)を求める
            float y =
                (wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y) * 5;    //表示位置(Y座標)を求める

            //赤色でマーカを描写
            float Kg = wm.WiimoteState.BalanceBoardState.WeightKg;
            if(Kg > 5.0f)
                g.FillEllipse(Brushes.Red, 150+x, 200+y, 10, 10);
            this.label1.Text = "X = " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.X
                + "\nY = " + wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y
                + "\nKg = " + Kg;

            //判定メッセージ
            String mes1 = "重心は傾いています。";
            String mes2 = "腕は傾いています。";

            if ((Math.Abs(wm.WiimoteState.BalanceBoardState.CenterOfGravity.X) < 4.0f)
                && (Math.Abs(wm.WiimoteState.BalanceBoardState.CenterOfGravity.Y) < 4.0f))
                mes1 = "重心は中央にあります。";

            if ((Math.Abs(rad) < 10) && (Math.Abs(rad2) < 10))
                mes2 = "腕は水平になっています。";

            this.label8.Text =
                "重心　：　" + mes1 +
              "\n羽根　：　" + mes2;




            //g.Dispose();//グラフィックスの解放
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.testflag = 0;
            Dispose();
            
        }
    }
}
