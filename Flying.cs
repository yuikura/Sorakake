using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SORAKAKE.Ver1
{
    class Flying
    {
        Action action = new Action();

        public Flying() { 
        
        }

        public void Flaps(float up) {
            action.accel_plus( up );
        }

    }
}
