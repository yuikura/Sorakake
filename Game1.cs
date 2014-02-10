using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace SORAKAKE.Ver1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //White white = new White();

        // 全画面用キー保管
        bool pushed = false;

        const int OB_MAX = 147;

        OBJECT[] objects = new OBJECT[OB_MAX];
        OBJECT player = new OBJECT();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // キーボード状態の宣言
        KeyboardState keyboardState;
        // フォントの宣言
        SpriteFont font;
        //Wiiクラスの宣言
        Wii_ctrl wii = new Wii_ctrl();

        //文字
        Character character = new Character();

        SORA sora = new SORA();
        //ランダム関数
        private Random random = new Random();


        SORAKAKE sorakake = new SORAKAKE();
        SORAKAKE_wii sorakake_wii = new SORAKAKE_wii();

        Texture2D WAKUimg2;
        Texture2D Circle;

        double TotalKM;  //走行距離

        // レンダリングターゲット
        public RenderTarget2D texRender;
        public RenderTarget2D texRender2;
        private DepthStencilBuffer depthRender;

        //状態モード
        Texture2D mode1;
        Texture2D mode2;
        Texture2D mode12;
        Texture2D mode22;
        Texture2D mode3;
        Texture2D mode32;

        Texture2D Compas;
        Texture2D Compas_arrow;

        //地図
        Texture2D MAP;
        Texture2D Hight;
        Texture2D ANGLE;
        Texture2D FRAM;
        Texture2D Arrow2;

        //歩き
        GroundRun groundrun = new GroundRun();
        GroundRun_wii groundrun_wii = new GroundRun_wii();

        //境界線
        Boader board = new Boader();

        //  SORAKAKE fm = new SORAKAKE();

        //ゲームの進行フラグ
        static int flag;

        //地上・空のフラグ
        int SkygroundFlag;

        //メニューの宣言
        Menu menu = new Menu();

        //アピールポイント
        Appeal appeal = new Appeal();

        //リング
        RING ring = new RING();


        // 空間の宣言
        SKY sky = new SKY();

        // 世界のルールの宣言
        Action action = new Action();

        // 行動の宣言
        Flying flying = new Flying();

        //マップ
        MAP map = new MAP();

        int disflag2, disflag;   //速さのフラグ

        
        //デバッグ情報表示用変数
        public int num = 0;
        //モード切替緩衝用変数
        public int mode = 0;
        public int num2 = 0;
        //メニュー切り替え緩衝用変数
        public int num3 = 0;
        //テストフォーム
        public Test test;
        public float arrowXZ;
        DrawRectangle Rectangle;


        //オブジェクトの宣言
        // WORLD ground = new WORLD("ground", "Ground81", new Vector3(10000, 0, 0));

        // 鳥の目線（カメラ）座標、軸方向の宣言
        Vector3 cameraPos = new Vector3(0.0f, 80.0f, 0.0f);
        Vector3 cameraFront = new Vector3(1, 0, 0);
        Vector3 cameraRight = new Vector3(0, 0, 1);
        Vector3 cameraUp = new Vector3(0, 1, 0);


        //サウンドクラス
        Sound sound = new Sound();
        //サウンドデータの宣言
        public AudioEngine engine;
        public AudioEngine engine2;
        public AudioEngine engine3;
        public SoundBank soundBank;
        public SoundBank soundBank2;
        public SoundBank soundBank3;
        public WaveBank waveBank;
        public WaveBank waveBank2;
        public WaveBank waveBank3;

        Wing wing = new Wing(0, 0, 0);
        Wing wing2 = new Wing(0, 0, 0);
        Wing wing3 = new Wing(0, 0, 0);

        //BGMキューの宣言
        public Cue bgm;
        public Cue bgm3;
        public Cue bgm4;

        int grideflag;

        private int wordflag;

        int ALLtime;

        private int x;
        private int y;
        int[] ringyob = new int[7];
        int Appelpoint, RINGPOINT, RINGFLAG;
        int[] Appelflag = new int[32];
        int ringtime;

        //雲
        int[] cloudx = new int[40];
        int[] cloudy = new int[40];
        int[] cloudz = new int[40];

        // スピード
        public float speed;
        int N;
        public Game1()
        {

            //風
            if(random.Next(2)%2==0)
                wing.wingset((float)random.Next(10) / 10f, random.Next(5) / 10, (float)random.Next(10) / 10f);
            else
                wing.wingset(-(float)random.Next(10) / 10f, random.Next(5) / 10, -(float)random.Next(10)/10f);
            wing2.wingset((float)random.Next(10) / 10f, random.Next(5) / 10, (float)random.Next(10) / 10f);
            if (random.Next(3) % 2 == 0)
                wing3.wingset((float)random.Next(10) / 10f, random.Next(5) / 10, (float)random.Next(10) / 10f);
            else
                wing3.wingset((float)random.Next(10) / 10f, random.Next(5) / 10, -(float)random.Next(10) / 10f);



            //フラグの設定
            flag = 0;
            N = 0;   //ためし
            RINGPOINT = 0;
            RINGFLAG = 0;
            Appelpoint = 0;
            arrowXZ = -90;
            for (int i = 0; i < 32; i++)
                Appelflag[i] = 0;
            for (int i = 0; i < 7; i++)
                ringyob[i] = 0;
            //空
            SkygroundFlag = 0;
            //スピード
            speed = 5;

            //雲乱数
            for (int i = 0; i < 40; i++) {
                cloudx[i] = random.Next(40000) * (int)Math.Pow((double)-1, (double)i);
                cloudy[i] = random.Next(5000,7000) ;
                cloudz[i] = random.Next(40000) * (int)Math.Pow((double)-1, (double)i);
            }

                disflag = 0;
            disflag2 = 0;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            wordflag = 0;

            try
            {
                //ファイルのパス
                String path = Path.Combine(StorageContainer.TitleLocation, "test2.txt");
                Console.WriteLine(path);

                //バイトデータを読み込む               
                byte[] w = new byte[1024];
                FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
                int size = fs.Read(w, 0, w.Length);
                fs.Close();

                //バイトデータ⇒XY座標
                String str = Encoding.Unicode.GetString(w, 0, size);
                int idx = str.IndexOf(',');
                x = int.Parse(str.Substring(0, idx));
                //   y = int.Parse(str.Substring(idx + 1));


            }
            catch (Exception exc)
            {
                x = 100;
                //  y = 100;
                Console.WriteLine(">>>>" + exc.ToString());
            }
            ALLtime = x;
            try
            {
                //ファイルのパス
                String path = Path.Combine(StorageContainer.TitleLocation, "test.txt");
                Console.WriteLine(path);

                //バイトデータを読み込む               
                byte[] w = new byte[1024];
                FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
                int size = fs.Read(w, 0, w.Length);
                fs.Close();

                //バイトデータ⇒XY座標
                String str = Encoding.Unicode.GetString(w, 0, size);
                int idx = str.IndexOf(',');
                x = int.Parse(str.Substring(0, idx));
                //   y = int.Parse(str.Substring(idx + 1));


            }
            catch (Exception exc)
            {
                x = 100;
                //  y = 100;
                Console.WriteLine(">>>>" + exc.ToString());
            }
            TotalKM = x;            //TotalKM = (double)x;  //走行距離
            
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0);

        }


        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Rectangle.UpDate(graphics, Content);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // render.Initialize(ref graphics,ref texRender,ref depthRender);
            // sorakake.Initialize(ref graphics);
            Rectangle = new DrawRectangle();
            // TODO: Add your initialization logic here
            // レンダリングターゲット
            texRender = new RenderTarget2D(graphics.GraphicsDevice,
                800, 600, 1, SurfaceFormat.Color);
            texRender2 = new RenderTarget2D(graphics.GraphicsDevice,
                800, 600, 1, SurfaceFormat.Color);
            depthRender = new DepthStencilBuffer(graphics.GraphicsDevice,
                800, 600, DepthFormat.Depth24Stencil8, MultiSampleType.None, 0);

            //sky.SetWORLD(ground);
           // wii.Connect();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // 太陽
            white.Load(Content);

            // オブジェクトの設定+Load
            for (int i = 0; i < OB_MAX; i++)
            {
                objects[i] = new OBJECT();
            }

            // オブジェクトの設置
            // オブジェクトの設置
            objects[0].Set_object(2, new Vector3(0, 80, 0), 0, 0);
            objects[1].Set_object(3, new Vector3(-7000, 80, 300), 0, 0);  //島
            objects[2].Set_object(7, new Vector3(-7000, 150, 360), 0, 0);  //木
            objects[3].Set_object(7, new Vector3(-7000, 150, 500), 0, 0);  //木
            objects[4].Set_object(7, new Vector3(-6800, 150, 900), 0, 0);  //木
            objects[5].Set_object(9, new Vector3(-6200, 200, 1900), 0, 0);  //家
            objects[6].Set_object(4, new Vector3(-13000, 30, 8000), 0, 0);  //島
            objects[7].Set_object(7, new Vector3(-13000, 180, 8000), 0, 0);  //木
            objects[8].Set_object(7, new Vector3(-13600, 180, 7000), 0, 0);  //木
            objects[9].Set_object(7, new Vector3(-12800, 180, 7500), 0, 0);  //木
            objects[10].Set_object(7, new Vector3(-12600, 200, 7200), 0, 0);  //木
            objects[11].Set_object(7, new Vector3(-13400, 180, 8200), 0, 0);  //木
            objects[12].Set_object(7, new Vector3(-14100, 100, 8500), 0, 0);  //木
            objects[13].Set_object(7, new Vector3(-13900, 180, 7900), 0, 0);  //木
            objects[14].Set_object(7, new Vector3(-12500, 180, 8200), 0, 0);  //木
            objects[15].Set_object(7, new Vector3(-12100, 180, 8500), 0, 0);  //木
            objects[16].Set_object(7, new Vector3(-12700, 180, 7900), 0, 0);  //木
            objects[17].Set_object(7, new Vector3(-12900, 180, 8200), 0, 0);  //木
            objects[18].Set_object(7, new Vector3(-12700, 180, 8500), 0, 0);  //木
            objects[19].Set_object(7, new Vector3(-12800, 180, 8900), 0, 0);  //木
            objects[20].Set_object(5, new Vector3(-4000, 80, 20000), 0, 0);  //島
            objects[21].Set_object(9, new Vector3(-4000, 250, 20000), 0, 0);  //家
            objects[22].Set_object(9, new Vector3(-4500, 250, 19500), 0, 0);  //家
            objects[23].Set_object(9, new Vector3(-3500, 250, 20900), 0, 0);  //家
            objects[24].Set_object(9, new Vector3(-3100, 250, 20000), 0, 0);  //家
            objects[25].Set_object(9, new Vector3(-4200, 250, 19200), 0, 0);  //家
            objects[26].Set_object(9, new Vector3(-4200, 250, 20500), 0, 0);  //家
            objects[27].Set_object(3, new Vector3(-20000, 80, 20000), 0, 0);  //島
            objects[28].Set_object(7, new Vector3(-20000, 150, 20000), 0, 0);  //木
            objects[29].Set_object(7, new Vector3(-20000, 150, 20500), 0, 0);  //木
            objects[30].Set_object(7, new Vector3(-22000, 150, 20000), 0, 0);  //木
            objects[31].Set_object(9, new Vector3(-21500, 180, 20000), 0, 0);  //家

            objects[32].Set_object(1, new Vector3(-10000, 40, -10000), 0, 0);  //島
            objects[33].Set_object(7, new Vector3(-10800, 240, -10500), 0, 0);  //木
            objects[34].Set_object(7, new Vector3(-11000, 150, -11300), 0, 0);  //木
            objects[35].Set_object(9, new Vector3(-10000, 260, -10000), 0, 0);  //家

            objects[36].Set_object(2, new Vector3(-22000, 40, -1000), 0, 0);  //リング島
            objects[37].Set_object(7, new Vector3(-22000, 240, -500), 0, 0);  //木
            objects[38].Set_object(7, new Vector3(-21000, 250, -1300), 0, 0);  //木
            objects[39].Set_object(7, new Vector3(-21000, 230, -1000), 0, 0);  //木
            objects[40].Set_object(7, new Vector3(-22500, 240, -800), 0, 0);  //木
            objects[41].Set_object(7, new Vector3(-22300, 230, -1000), 0, 0);  //木

            objects[42].Set_object(10, new Vector3(2000, 200, 0), 0, 0);  //船

            objects[43].Set_object(2, new Vector3(20000, 80, -30000), 0, 0); //島
            objects[44].Set_object(7, new Vector3(19000, 200, -30000), 0, 0); //木
            objects[45].Set_object(7, new Vector3(20500, 230, -29000), 0, 0); //木

            objects[46].Set_object(3, new Vector3(12000, 80, -5300), 0, 0);  //島
            objects[47].Set_object(7, new Vector3(11500, 150, -5900), 0, 0);  //木1
            objects[48].Set_object(7, new Vector3(12000, 150, -5000), 0, 0);  //木2
            objects[49].Set_object(7, new Vector3(11800, 150, -5800), 0, 0);  //木3
            objects[50].Set_object(7, new Vector3(12000, 150, -5300), 0, 0);  //木4
            objects[51].Set_object(7, new Vector3(12500, 150, -5900), 0, 0);  //木5
            objects[52].Set_object(7, new Vector3(13000, 150, -5000), 0, 0);  //木6
            objects[53].Set_object(7, new Vector3(12800, 150, -5800), 0, 0);  //木7
            objects[54].Set_object(7, new Vector3(13000, 150, -5300), 0, 0);  //木8
            objects[55].Set_object(7, new Vector3(11800, 150, -3900), 0, 0);  //木9
            objects[56].Set_object(7, new Vector3(12300, 150, -3000), 0, 0);  //木10
            objects[57].Set_object(7, new Vector3(12100, 150, -3800), 0, 0);  //木11
            objects[58].Set_object(7, new Vector3(12300, 150, -3300), 0, 0);  //木12
            objects[59].Set_object(7, new Vector3(12800, 150, -3900), 0, 0);  //木13
            objects[60].Set_object(7, new Vector3(13300, 150, -3000), 0, 0);  //木14
            objects[61].Set_object(7, new Vector3(13100, 150, -3800), 0, 0);  //木15
            objects[62].Set_object(7, new Vector3(13300, 150, -3300), 0, 0);  //木16
            objects[63].Set_object(4, new Vector3(33000, 30, -18000), 0, 0);  //島

            objects[64].Set_object(12, new Vector3(-21500, 400, -1500), 0, 2);  //リング
            //船
            objects[65].Set_object(13, new Vector3(45500, 200, 3000), 0, 0);  //船
            objects[66].Set_object(13, new Vector3(45000, 200, 2500), 0, 0);  //船
            objects[67].Set_object(13, new Vector3(45000, 200, 3500), 0, 0);  //船
            objects[68].Set_object(13, new Vector3(-45500, 200, -23000), 0, 0);  //船
            objects[69].Set_object(13, new Vector3(-40000, 200, -42500), 0, 0);  //船
            objects[70].Set_object(13, new Vector3(-35000, 200, -33500), 0, 0);  //船
            objects[71].Set_object(13, new Vector3(42500, 200, -13000), 0, 0);  //船
            objects[72].Set_object(13, new Vector3(51000, 200, 40000), 0, 0);  //船
            objects[73].Set_object(13, new Vector3(38000, 200, 15500), 0, 0);  //船
            objects[74].Set_object(13, new Vector3(-35500, 200, 23000), 0, 0);  //船
            objects[75].Set_object(13, new Vector3(40000, 200, 32500), 0, 0);  //船
            objects[76].Set_object(13, new Vector3(-45000, 200, 3500), 0, 0);  //船


            objects[77].Set_object(15, new Vector3(40000, 12000, 30000), 0, 1);  //ラピュタ
            objects[78].Set_object(14, new Vector3(40000, 12000, 30000), 0, 1);  //城

            //リング（予定）
            objects[79].Set_object(12, new Vector3(19000, 2000, 8000), 90, 2);  //リング
            objects[80].Set_object(12, new Vector3(24000, 4000, -5000), 90, 2);  //リング
            objects[81].Set_object(12, new Vector3(23000, 6000, 5000), 90, 2);  //リング
            objects[82].Set_object(12, new Vector3(20000, 1000, 00), 90, 2);  //リング
            objects[83].Set_object(12, new Vector3(26000, 1000, 00), 90, 2);  //リング
            objects[84].Set_object(12, new Vector3(32000, 1000, 00), 90, 2);  //リング
            objects[85].Set_object(12, new Vector3(28000, 1000, -8000), 90, 2);  //リング
            //終了

            // オブジェクトの設置 青山
            //島ID=1,2,3,4,5木7雲8

            //列島
            objects[86].Set_object(3, new Vector3(4000, 80, 4500), 0, 0);      //島
            objects[87].Set_object(7, new Vector3(4500, 200, 5500), 0, 0);
            objects[88].Set_object(7, new Vector3(5000, 200, 6500), 0, 0);
            objects[89].Set_object(7, new Vector3(5000, 200, 7000), 0, 0);

            objects[90].Set_object(2, new Vector3(7000, 80, 10000), 0, 0);     //島
            objects[91].Set_object(7, new Vector3(6700, 300, 11000), 0, 0);
            objects[92].Set_object(7, new Vector3(7000, 300, 10500), 0, 0);
            objects[93].Set_object(7, new Vector3(7200, 300, 10500), 0, 0);
            objects[94].Set_object(7, new Vector3(7000, 300, 11000), 0, 0);

            objects[95].Set_object(5, new Vector3(-12700, 80, -35000), 0, 0);    //島
            objects[96].Set_object(7, new Vector3(-12700, 300, -35000), 0, 0);
            objects[97].Set_object(7, new Vector3(-12900, 300, -35500), 0, 0);
            objects[98].Set_object(7, new Vector3(-11700, 300, -35500), 0, 0);
            objects[99].Set_object(7, new Vector3(-13000, 300, -35300), 0, 0);

            objects[100].Set_object(4, new Vector3(12500, 80, 15000), 0, 0);    //島
            objects[101].Set_object(7, new Vector3(12500, 250, 15000), 0, 0);
            objects[102].Set_object(7, new Vector3(12700, 250, 15500), 0, 0);
            objects[103].Set_object(7, new Vector3(13000, 250, 15500), 0, 0);
            objects[104].Set_object(7, new Vector3(12800, 250, 15000), 0, 0);

            objects[105].Set_object(4, new Vector3(40000, 80, 35000), 0, 0);    //島
            objects[106].Set_object(7, new Vector3(40200, 250, 34500), 0, 0);
            objects[107].Set_object(7, new Vector3(39500, 250, 34800), 0, 0);
            objects[108].Set_object(7, new Vector3(39800, 250, 340000), 0, 0);
            objects[109].Set_object(7, new Vector3(40000, 250, 34500), 0, 0);
            objects[110].Set_object(7, new Vector3(40500, 250, 35000), 0, 0);

            objects[111].Set_object(5, new Vector3(0, 80, 40000), 0, 0);       //島
            objects[112].Set_object(7, new Vector3(500, 250, 40000), 0, 0);
            objects[113].Set_object(7, new Vector3(700, 250, 40500), 0, 0);
            objects[114].Set_object(7, new Vector3(900, 250, 395000), 0, 0);
            objects[115].Set_object(7, new Vector3(1100, 250, 39700), 0, 0);
            objects[116].Set_object(7, new Vector3(300, 250, 40200), 0, 0);
            objects[117].Set_object(7, new Vector3(100, 250, 40700), 0, 0);
            objects[118].Set_object(7, new Vector3(-100, 250, 40100), 0, 0);

            objects[119].Set_object(1, new Vector3(25000, 80, 10000), 0, 0);    //島
            objects[120].Set_object(7, new Vector3(25000, 300, 10000), 0, 0);
            objects[121].Set_object(7, new Vector3(25500, 300, 10500), 0, 0);
            objects[122].Set_object(7, new Vector3(24000, 300, 11000), 0, 0);
            objects[123].Set_object(7, new Vector3(25000, 300, 9700), 0, 0);
            objects[124].Set_object(7, new Vector3(25300, 300, 10300), 0, 0);
            objects[125].Set_object(7, new Vector3(24700, 300, 9500), 0, 0);
            objects[126].Set_object(7, new Vector3(24300, 300, 9300), 0, 0);

            objects[127].Set_object(3, new Vector3(20000, 80, 30000), 0, 0);   //島
            objects[128].Set_object(7, new Vector3(20000, 200, 30000), 0, 0);
            objects[129].Set_object(7, new Vector3(21000, 200, 30500), 0, 0);
            objects[130].Set_object(7, new Vector3(19000, 200, 31000), 0, 0);
            objects[131].Set_object(7, new Vector3(19300, 200, 29000), 0, 0);
            objects[132].Set_object(7, new Vector3(19400, 200, 29500), 0, 0);
            objects[133].Set_object(7, new Vector3(19500, 200, 30700), 0, 0);
            objects[134].Set_object(7, new Vector3(20000, 200, 30100), 0, 0);

            //青山はここまで
            objects[135].Set_object(16, new Vector3(41000, 12000, 31000), 0, 1); //ラピュタのモアイ
            objects[136].Set_object(16, new Vector3(41000, 12000, 29000), 0, 1);
            objects[137].Set_object(16, new Vector3(39000, 12000, 31000), 0, 1);
            objects[138].Set_object(16, new Vector3(39000, 12000, 29000), 0, 1);
            objects[139].Set_object(17, new Vector3(-33000, 200, -40000), 0, 0);//くじら

            objects[140].Set_object(18, new Vector3(1000, 200, 450), 225, 0);//看板

           /* for (int i = 141; i < 181; i++) {
                objects[i].Set_object(8, new Vector3(cloudx[i-141], cloudy[i-141], cloudz[i-141]), 0, 0);//
            }*/

            objects[141].Set_object(1, new Vector3(-55000, 200, 54000), 0, 0);//島
            objects[142].Set_object(1, new Vector3(-50000, 200, 1000), 0, 0);//島
            objects[143].Set_object(1, new Vector3(-47000, 200, 38000), 0, 0);//島
            objects[144].Set_object(1, new Vector3(48000, 200, -1000), 0, 0);//島
            objects[145].Set_object(1, new Vector3(-25000, 200, 49000), 0, 0);//島
            objects[146].Set_object(1, new Vector3(-30000, 200, 35000), 0, 0);//島
                // ここまで
                for (int i = 0; i < OB_MAX; i++)
                {
                    objects[i].Load(Content);
                }


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // フォントの呼出
            font = Content.Load<SpriteFont>("font");

            //メニューの呼び出し
            menu.Load(Content);

            //文字の読み込み
            character.Load(Content);

            // 空間の呼出
            sky.Load(Content);

            map.Load(Content);

            //サウンドの読み込み
            //     sound.Load();

            sora.Load(Content);

            FRAM = Content.Load<Texture2D>("status_back_clear_frame4");
            ANGLE = Content.Load<Texture2D>("bird_vector");
            WAKUimg2 = Content.Load<Texture2D>("WAKU2");
            Circle = Content.Load<Texture2D>("Circle");
            Hight = Content.Load<Texture2D>("Hight");

            mode1 = Content.Load<Texture2D>("habataki");
            mode2 = Content.Load<Texture2D>("kakkuu");
            mode12 = Content.Load<Texture2D>("habataki_shi");
            mode22 = Content.Load<Texture2D>("kakkuu_shi");
            mode3 = Content.Load<Texture2D>("chijo");
            mode32 = Content.Load<Texture2D>("chijo_shi");

            Compas = Content.Load<Texture2D>("Compas-");
            Compas_arrow = Content.Load<Texture2D>("Compas-arrow-");


            engine = new AudioEngine("Content\\XNAaudio.xgs");
            engine2 = new AudioEngine("Content\\XNAaudio.xgs");
            soundBank = new SoundBank(engine, "Content\\Sound Bank.xsb");
            soundBank2 = new SoundBank(engine2, "Content\\Sound Bank.xsb");
            waveBank = new WaveBank(engine, "Content\\Wave Bank.xwb");
            waveBank2 = new WaveBank(engine2, "Content\\Wave Bank.xwb");
            engine3 = new AudioEngine("Content\\XNAaudio.xgs");
            soundBank3 = new SoundBank(engine3, "Content\\Sound Bank.xsb");
            waveBank3 = new WaveBank(engine3, "Content\\Wave Bank.xwb");


            //BGMキューの取得
            //bgm = soundBank.Ge
            //波の音
            bgm3 = soundBank2.GetCue("WAVE");
            bgm3.Play();
            bgm4 = soundBank3.GetCue("KAZE");
            bgm4.Play();


            Rectangle.Load(graphics, Content);
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
            // キーボード状態の取得
            num2++;
            num3++;

            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                //ファイルのパス
                String path = Path.Combine(StorageContainer.TitleLocation, "test.txt");
                Console.WriteLine(path);
                x = 0;
                y = 0;
                //XY座標⇒バイトデータ
                String str = x + "," + y;
                byte[] w = Encoding.Unicode.GetBytes(str);

                //バイトデータを書き込む
                FileStream fs = null;
                if (!File.Exists(path))
                {
                    fs = File.Create(path);
                }
                else
                {
                    fs = File.Open(path, FileMode.Open, FileAccess.Write);
                }
                fs.Write(w, 0, w.Length);
                fs.Close();
                //ファイルのパス
                path = Path.Combine(StorageContainer.TitleLocation, "test2.txt");
                Console.WriteLine(path);
                x = 0;
                y = 0;
                //XY座標⇒バイトデータ
                str = x + "," + y;
                w = Encoding.Unicode.GetBytes(str);

                //バイトデータを書き込む
                fs = null;
                if (!File.Exists(path))
                {
                    fs = File.Create(path);
                }
                else
                {
                    fs = File.Open(path, FileMode.Open, FileAccess.Write);
                }
                fs.Write(w, 0, w.Length);
                fs.Close();

                this.Exit();
            }
            //リングゲーム
            if (keyboardState.IsKeyDown(Keys.R)) {
                sorakake.Ringgame = 1;
                sorakake_wii.Ringgame = 1;
            }

            // 全画面表示
            if (!this.pushed && keyboardState.IsKeyDown(Keys.O))
            {
                // ウインドウモードとフルスクリーンモードを切り替える
                this.graphics.ToggleFullScreen();
            }

            // 押下状態記憶
            this.pushed = keyboardState.IsKeyDown(Keys.O);

            num++;
            if (num > 20 && keyboardState.IsKeyDown(Keys.B))
            {
                num = 0;
                if (wordflag == 0)
                    wordflag = 1;
                else
                    wordflag = 0;
            }

            if (flag == 0)
            {
                //メニュー画面での動作
                    menu.Action(ref keyboardState, ref flag, soundBank, engine, bgm, wii, ref test);
            }
            if (flag == 1)
            {

                //そらかけの運動(キーボード)
                if (menu.Operation == 0)
                {
                    if (SkygroundFlag == 0)      //空判定
                    {

                        /*飛び立ちの速度の判定*/
                        if (grideflag == 1 && speed > 4.9)
                        {
                            //getuptime=appeal.GRIDEUP(gameTime);
                            grideflag = 2;
                        }
                        else if (grideflag == 1)
                        {
                            // getuptime = appeal.GRIDEUP(gameTime);
                            grideflag = 0;
                        }
                        /*ここまで*/

                        sorakake.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag, soundBank, engine, bgm, objects, OB_MAX, player);
                       // cameraPos += wing.WingEffect(60);
                        if (cameraPos.Z > 0 && cameraPos.X > 0)
                        {
                            cameraPos += wing.WingEffect(60);  //体重チェック
                        }
                        else if (cameraPos.Z > 0 && cameraPos.X < 0)
                        {
                            cameraPos += wing2.WingEffect(60);  //体重チェック
                        }
                        else if (cameraPos.Z < 0)
                        {
                            cameraPos += wing3.WingEffect(60);  //体重チェック
                        }
                    }
                    if (SkygroundFlag == 1)  //地上判定
                    {
                        if (speed < 2 && grideflag == 0)  //グライド
                        {
                            grideflag = 1;
                        }

                        groundrun.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag, objects, OB_MAX, player);

                    }
                }
                else if (menu.Operation == 1)   //Wiiリモコン
                {
                    //                    if(wii.Connec_check() == false)
                    //                        wii.Connect();

                    if (SkygroundFlag == 0)     //空判定
                    {

                        /*飛び立ちの速度の判定*/
                        if (grideflag == 1 && speed > 4.5)
                        {
                            //appeal.GRIDEUP(gameTime);
                            grideflag = 2;
                        }
                        else if (grideflag == 1)
                        {
                            //appeal.GRIDEUP(gameTime);
                            grideflag = 0;
                        }
                        /*ここまで*/


                        sorakake_wii.Action(ref cameraPos, ref cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag, soundBank, engine, bgm, objects, OB_MAX, player, ref wii);
                        if (cameraPos.Z > 0 && cameraPos.X > 0)
                        {
                            cameraPos += wing.WingEffect(wii.getWeight());  //体重チェック
                        }
                        else if (cameraPos.Z > 0 && cameraPos.X < 0)
                        {
                            cameraPos += wing2.WingEffect(wii.getWeight());  //体重チェック
                        }
                        else if (cameraPos.Z < 0)
                        {
                            cameraPos += wing3.WingEffect(wii.getWeight());  //体重チェック
                        }
                        
                    }
                    if (SkygroundFlag == 1)   //地上判定
                    {
                        if (speed < 2 && grideflag == 0)  //ｸﾞﾗｲﾄﾞ
                        {
                            grideflag = 1;
                        }

                        groundrun_wii.Action(ref  cameraPos, ref  cameraFront, ref cameraRight, ref  cameraUp, ref  speed, ref keyboardState, ref SkygroundFlag, objects, OB_MAX, player, ref wii);
                    }
                }

            }

            TotalKM += Math.Sqrt(cameraFront.X * speed * cameraFront.X * speed + cameraFront.Y * speed * cameraFront.Y * speed + cameraFront.Z * speed * cameraFront.Z * speed);

            engine.Update();
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

            // 深度バッファを有効
            graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
            spriteBatch.Begin();
            if (flag == 0)
            {
                //メニュー画面の描画
                menu.Graphic(ref  graphics, ref  spriteBatch, ref  font, ref gameTime);
            }
            //ゲーム画面の描画
            if (flag == 1)
            {

                if (N == 0)
                    N = 1;

                if (menu.Operation == 0)
                {
                    /*レクタリング
                    Rectangle.DrawFrame(ref graphics, sorakake.view, sorakake.projection, null,cameraPos,cameraFront);
                    Rectangle.Draw(ref graphics, sorakake.view, sorakake.projection,  texRender,cameraPos);*/

                    sorakake.Graphic(cameraPos, cameraFront, cameraRight, cameraUp,
                           graphics, spriteBatch, font, gameTime, texRender, texRender2, speed, objects, OB_MAX, wordflag, this.GraphicsDevice, white);
                    //LEDの位置
                    spriteBatch.Draw(WAKUimg2, new Vector2(620, 300), Color.White);
                    spriteBatch.Draw(Circle, new Vector2(620 + (int)(0.5 * 100), 300 + (int)(0.5 * 100)), Color.White);
                    spriteBatch.Draw(Circle, new Vector2(620 + (int)(0.5 * 100), 300 + (int)(0.5 * 100)), Color.White);

                }
                else
                {
                    sorakake_wii.Graphic(cameraPos, cameraFront, cameraRight, cameraUp,
                     graphics, spriteBatch, font, gameTime, ref wii, speed, texRender, texRender2, objects, OB_MAX, wordflag, this.GraphicsDevice, white);
                    //LEDの位置
                    spriteBatch.Draw(WAKUimg2, new Vector2(620, 300), Color.White);
                    spriteBatch.Draw(Circle, new Vector2(690 - (int)(wii.carryRx() * 140), 400 - (int)(wii.carryLy() * 100)), Color.White);
                    spriteBatch.Draw(Circle, new Vector2(690 + (int)((wii.carryLx()-0.5) * 140), 400 - (int)(wii.carryRy() * 100)), Color.White);
                }

                int RINGGAME;
                if (menu.Operation == 0)
                    RINGGAME = sorakake.Ringgame;
                else
                    RINGGAME = sorakake_wii.Ringgame;
                //MAPの描画
                map.MapDraw(graphics, spriteBatch, font, gameTime, cameraPos, RINGGAME, ringyob,cameraFront);
                spriteBatch.Draw(Hight, new Vector2(775, 80), Color.White); //フレーム
                spriteBatch.Draw(Compas, new Vector2(0, 210), Color.White); //フレーム
                if (cameraPos.Z > 0 && cameraPos.X >= 0)
                {
                    if (wing.Wingz >= 0)
                    {
                        
                        //spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(-wing.Wingx * 90 - 90), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        if (arrowXZ > -wing.Wingx * 90 - 90)
                            arrowXZ -= 1f;
                        if (arrowXZ < -wing.Wingx * 90 - 90)
                            arrowXZ += 1f;
                    }
                    else if (wing.Wingz < 0)
                    {
                        if (arrowXZ > wing.Wingx * 90 - 90)
                            arrowXZ -= 1f;
                        if (arrowXZ < wing.Wingx * 90 - 90)
                            arrowXZ += 1f;
                    }
                }
                else if (cameraPos.Z > 0 && cameraPos.X < 0)
                {
                    if (wing2.Wingz >= 0)
                    {
                        //spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(-wing2.Wingx * 90 - 90), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        if (arrowXZ > -wing2.Wingx * 90 - 90)
                            arrowXZ -= 1f;
                        if (arrowXZ < -wing2.Wingx * 90 - 90)
                            arrowXZ += 1f;
                    }
                    else if (wing2.Wingz < 0)
                    {
                        if (arrowXZ > wing2.Wingx * 90 - 90)
                            arrowXZ -= 1f;
                        if (arrowXZ < wing2.Wingx * 90 - 90)
                            arrowXZ += 1f;
                        //spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(wing2.Wingx * 90 - 90), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }
                }
                else if (cameraPos.Z <= 0)
                {
                    if (wing3.Wingz >= 0)
                    {
                        if (arrowXZ > -wing3.Wingx * 90 - 90)
                            arrowXZ -= 0.1f;
                        if (arrowXZ < -wing3.Wingx * 90 - 90)
                            arrowXZ += 0.1f;
                        // spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(-wing3.Wingx * 90 - 90), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }
                    else if (wing3.Wingz < 0)
                    {
                        if (arrowXZ > wing3.Wingx * 90 - 90)
                            arrowXZ -= 0.1f;
                        if (arrowXZ < wing3.Wingx * 90 - 90)
                            arrowXZ += 0.1f;
                        //spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(wing3.Wingx * 90 - 90), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }
                }
                spriteBatch.Draw(Compas_arrow, new Vector2(25, 235), null, Color.White, MathHelper.ToRadians(arrowXZ), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                //spriteBatch.Draw(Compas_arrow, new Vector2(0, 210), null, Color.White, MathHelper.ToRadians(0), new Vector2(Compas_arrow.Width / 2, Compas_arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                //鳥の角度
                spriteBatch.Draw(ANGLE, new Vector2(765, 400 - cameraPos.Y / 46), null, Color.White, MathHelper.ToRadians(cameraFront.Y * 90), new Vector2(ANGLE.Width / 2, ANGLE.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                //リングゲーム
                ring.RingGame(gameTime);

                if (sorakake.Ringgame == 1 || sorakake_wii.Ringgame == 1)
                {
                    if (RINGFLAG == 0)
                    {
                        sound.BGM(soundBank, engine, bgm, "Chaim");
                        ringtime = (int)ring.middletime;
                        RINGFLAG = 1;
                        N = 92;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    }
                    ring.RingGame2(gameTime);

                    for (int i = 0; i < 7; i++)
                    {
                        if ((sorakake.Ringpoint[i] == 1 || sorakake_wii.Ringpoint[i] == 1) && ringyob[i] == 0)
                        {
                            ringyob[i] = 1;
                            RINGPOINT++;
                            character.GetRing(RINGPOINT);
                            if (RINGPOINT == 7)
                            {
                                character.GetMiddle((int)ring.middletime - ringtime);
                                N = 93;
                                //  character.GetMiddle((int)ring.middletime2);
                                character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                                //character.Grahpics2(graphics, spriteBatch, font, gameTime, (int)ring.middletime2);
                                //  spriteBatch.DrawString(font, "                  " + (int)(TotalKM - x) / 100 + "m", new Vector2(600, 420), Color.YellowGreen);
                                sound.BGM(soundBank, engine, bgm, "pati");
                                sound.BGM(soundBank, engine, bgm, "pati");
                                sound.BGM(soundBank, engine, bgm, "pati");

                                for (int j = 0; j < 7; j++)
                                {
                                    sorakake.Ringgame = 0;
                                    sorakake_wii.Ringgame = 0;
                                    sorakake.Ringpoint[j] = 0;
                                    sorakake_wii.Ringpoint[j] = 0;
                                    ringyob[j] = 0;
                                    RINGPOINT = 0;
                                    RINGFLAG = 0;
                                }

                            }
                            else
                            {
                                N = 94;
                                character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                                sound.BGM(soundBank, engine, bgm, "pati");

                            }
                            speed += 20;

                        }
                    }

                }
                //wiiの位置
                /*   spriteBatch.Draw(WAKUimg2, new Vector2(655, 500), Color.White);
                   spriteBatch.Draw(Circle, new Vector2(700, 520), Color.White);
                   spriteBatch.Draw(Circle, new Vector2(755, 600), Color.White);*/
                spriteBatch.Draw(FRAM, new Vector2(500, 400), Color.White); //フレーム
                spriteBatch.DrawString(font, "                  " + (int)(TotalKM - x) / 100 + "m", new Vector2(600, 420), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + (float)ring.middletime + "sec", new Vector2(600, 440), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + (int)speed + "km/h", new Vector2(600, 460), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + Appelpoint + " AP", new Vector2(600, 480), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + (int)TotalKM / 100 + "m", new Vector2(600, 520), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + (int)(ALLtime + ring.middletime) + "sec", new Vector2(600, 540), Color.YellowGreen);
                spriteBatch.DrawString(font, "                  " + wing.Wingx+"  "+wing.Wingz + "sec", new Vector2(600, 560), Color.YellowGreen);
                //spriteBatch.DrawString(font, "Gride:   " + grideflag, new Vector2(620, 200), Color.YellowGreen);
                //spriteBatch.DrawString(font, "TIME:   " + getuptime, new Vector2(620, 250), Color.YellowGreen);
                //モードの判断
                if (num2 > 30)
                {
                    num2 = 0;
                    if (SkygroundFlag == 1)
                        mode = 3;
                    else
                    {
                        if (sorakake.checkmode() || sorakake_wii.checkmode())
                            mode = 2;
                        else
                            mode = 1;
                    }
                }


                //モードの判断
                if (mode == 3)
                {
                    spriteBatch.Draw(mode12, new Vector2(620, 0), Color.White);
                    spriteBatch.Draw(mode22, new Vector2(680, 0), Color.White);
                    spriteBatch.Draw(mode3, new Vector2(740, 0), Color.White);
                }
                else if (mode == 2)
                {
                    spriteBatch.Draw(mode12, new Vector2(620, 0), Color.White);
                    spriteBatch.Draw(mode2, new Vector2(680, 0), Color.White);
                    spriteBatch.Draw(mode32, new Vector2(740, 0), Color.White);
                }
                else
                {
                    spriteBatch.Draw(mode1, new Vector2(620, 0), Color.White);
                    spriteBatch.Draw(mode22, new Vector2(680, 0), Color.White);
                    spriteBatch.Draw(mode32, new Vector2(740, 0), Color.White);
                }


                //波の音
                sound.BGM2(ref soundBank2, ref engine2, ref bgm3, "WAVE", cameraPos.Y);
                //風の音
                sound.BGM3(ref soundBank3, ref engine3, ref bgm4, "KAZE", speed);

                //文字の呼び出し

                //メッセージ
                character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);

                //高度が高すぎるときの警告
                if (cameraPos.Y > 14500)
                {
                    N = 2;
                    
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    if (cameraPos.Y > 15000)
                    {
                        sorakake.ikarosu();
                        sorakake_wii.ikarosu();
                        //board.Return(ref cameraPos, ref cameraFront, ref cameraUp, ref cameraRight);
                    }
                }
                //遠くに行き過ぎたとき
                if (cameraPos.X * cameraPos.X + cameraPos.Z * cameraPos.Z > 4000000000)
                {
                    speed = 0.25f;
                    board.Return(ref cameraPos, ref cameraFront, ref cameraUp, ref cameraRight);

                    N = 3;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                }
                //水面に落ちたとき
                if (cameraPos.Y < 150)
                {
                    sound.BGM(soundBank, engine, bgm, "water");
                    cameraPos = new Vector3(0, 200, 0);
                    speed = 0;
                    N = 98;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    cameraFront = new Vector3(1, 0, 0);
                    cameraRight = new Vector3(0, 0, 1);
                    cameraUp = new Vector3(0, 1, 0);

                    //ファイルのパス
                    String path = Path.Combine(StorageContainer.TitleLocation, "test.txt");
                    Console.WriteLine(path);
                    x = (int)TotalKM;
                    y = 0;//(int)ring.middletime+ALLtime;
                    //XY座標⇒バイトデータ
                    String str = x + "," + y;
                    byte[] w = Encoding.Unicode.GetBytes(str);

                    //バイトデータを書き込む
                    FileStream fs = null;
                    if (!File.Exists(path))
                    {
                        fs = File.Create(path);
                    }
                    else
                    {
                        fs = File.Open(path, FileMode.Open, FileAccess.Write);
                    }
                    fs.Write(w, 0, w.Length);
                    fs.Close();

                    //ファイルのパス
                    path = Path.Combine(StorageContainer.TitleLocation, "test2.txt");
                    Console.WriteLine(path);

                    x = (int)ring.middletime + ALLtime;
                    y = 0;
                    //XY座標⇒バイトデータ
                    str = x + "," + y;
                    w = Encoding.Unicode.GetBytes(str);

                    //バイトデータを書き込む
                    fs = null;
                    if (!File.Exists(path))
                    {
                        fs = File.Create(path);
                    }
                    else
                    {
                        fs = File.Open(path, FileMode.Open, FileAccess.Write);
                    }
                    fs.Write(w, 0, w.Length);
                    fs.Close();


                }

                /*アピールポイント*/
                int APEL = appeal.AppealStart(gameTime, cameraUp, speed, TotalKM);
                if (APEL == 1)
                {
                    N = 4;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    sound.BGM(soundBank, engine, bgm, "pati");
                    if (Appelflag[0] == 0)
                    {
                        Appelpoint++;
                        Appelflag[0] = 1;
                    }
                }
                else if (APEL == 2 && grideflag == 2)
                {
                    grideflag = 0;
                    N = 5;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    sound.BGM(soundBank, engine, bgm, "pati");
                    sound.BGM(soundBank, engine, bgm, "pati");

                    if (Appelflag[1] == 0)
                    {
                        Appelpoint++;
                        Appelflag[1] = 1;
                    }
                }
                else if ((TotalKM - x) / 100 > 8800 && disflag == 0)
                {
                    if (disflag == 0)
                    {
                        disflag = 1;
                        N = 6;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");

                        if (Appelflag[2] == 0)
                        {
                            Appelpoint++;
                            Appelflag[2] = 1;
                        }
                    }
                }
                else if ((TotalKM - x) / 100 > 47195 && disflag == 1)
                {
                    if (disflag == 1)
                    {
                        disflag = 2;
                        N = 7;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");

                        if (Appelflag[3] == 0)
                        {
                            Appelpoint++;
                            Appelflag[3] = 1;
                        }
                    }
                }
                else if (speed > 149)   //最高速度
                {

                    N = 8;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    sound.BGM(soundBank, engine, bgm, "pati");
                    sound.BGM(soundBank, engine, bgm, "pati");

                    if (Appelflag[4] == 0)
                    {
                        Appelpoint++;
                        Appelflag[4] = 1;
                    }
                }
                else if (sorakake.raputa == 1 || sorakake_wii.raputa == 1)   //ラピュタに降りた
                {
                    sorakake.raputa = 0;
                    sorakake_wii.raputa = 0;
                    N = 9;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    sound.BGM(soundBank, engine, bgm, "pati");
                    sound.BGM(soundBank, engine, bgm, "pati");

                    if (Appelflag[5] == 0)
                    {
                        Appelpoint++;
                        Appelflag[5] = 1;
                    }
                }
                else if (sorakake.ship == 1 || sorakake_wii.ship == 1)  //船に乗った
                {
                    sorakake.ship = 0;
                    sorakake_wii.ship = 0;
                    N = 10;
                    character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                    sound.BGM(soundBank, engine, bgm, "pati");
                    sound.BGM(soundBank, engine, bgm, "pati");
                    sound.BGM(soundBank, engine, bgm, "pati");
                    if (Appelflag[6] == 0)
                    {
                        Appelpoint++;
                        Appelflag[6] = 1;
                    }
                }

                /*アピールポイント終了*/

                //最高距離
                if (disflag2 == 0 && (TotalKM - x) > 1000)
                {
                    if (x > 360000000 && x < 360001000)
                    {
                        disflag2 = 2;
                        N = 97;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");

                    }
                    else if (x > 7500000 && x < 7501000)
                    {
                        disflag2 = 2;
                        N = 96;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");

                    }
                    else if (x > 100000 && x < 100500)
                    {
                        disflag2 = 2;
                        N = 95;
                        character.Grahpics(graphics, spriteBatch, font, gameTime, ref N);
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");
                        sound.BGM(soundBank, engine, bgm, "pati");

                    }
                }


            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
