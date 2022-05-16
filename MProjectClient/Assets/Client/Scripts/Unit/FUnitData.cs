using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MProject.Unit {

    [Serializable]
    public struct FUnitData {

        public float mspeed;    //! movement speed


        FUnitData(float _mspeed)
            => (mspeed) 
            = (_mspeed);

        public void Copy(FUnitData _data) {
            mspeed = _data.mspeed;
        }

    }
}
