using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Manager;

namespace MProject.World {
    public class TestWorld : MWorld {



        public override void Load() {
            base.Load();
        }


        public override void Join() {
            
            //NetworkManager.Instance.SendPacket()
        }

    }
}