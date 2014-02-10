using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SORAKAKE.Ver1
{
    class Action
    {
        public float accel = -1.0f;
        public float min = 10f;
        public float max = 25f;
        public float accel_ps = 0.1f;
        public int gliding_mode = 0;

        public Action() {        }

        //世界のルール
        public void Rule() {        }

        //重力
        public float Gravity(float y)
        {
            accel = accel - accel_ps;
            if (accel < -min)
                accel = -min;

            return ( y + accel );
        }
        public void accelminer() {
            this.accel = -min;
            this.accel_ps=0.1f;
        }

        public void accel_plus(float plus) {
            this.accel = this.accel + plus;
            if (accel > max)
                accel -= 0.1f;
        }
        
        public void set_accel(float set) {
            this.accel = set;
        }

        public void set_accel_ps(float set) {
            this.accel_ps = set;
        }

        public void set_glide() {
            if (accel > -5)
                return;
            this.gliding_mode = 1;
            this.set_accel_ps(0.001f);
            max = 5f;
        }

        public float get_accel() { return this.accel; }

        public void reset_glide() {
            this.gliding_mode = 0;
            this.set_accel_ps(0.1f);
            max = 25f;
        }

        public bool check_glide_mode() {
            if (gliding_mode == 1) return true;
            else return false;
        }

        //首にかかる重力
        public float GravityNeck(float y)
        {
            return (float)(y - (float)0.01);
        }

        //羽にかかる重力
        public float GravityWing(float y,int N)
        {
            return (float)(y + N*(float)0.001);
        }

    }
}
