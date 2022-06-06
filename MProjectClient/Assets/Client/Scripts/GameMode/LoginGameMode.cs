using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MProject.Manager;
using MProject.Player;
using MProject.Protocol;

namespace MProject.GameMode {
    public class LoginGameMode : BaseGameMode {

        public GPC LocalPlayer {
            get; private set;
        }

        bool is_login = false;

        public override void Initialize() {
            base.Initialize();

            if(false == is_login) {
                RequestLogin();
            }
        }

        public void RequestLogin() {
            StartCoroutine(OnRequestLogin());
        }
        private IEnumerator OnRequestLogin() {
            while(false == NetworkManager.Instance.IsConnect()) {
                yield return new WaitForEndOfFrame();
            }

            NetworkManager.Instance.SendPacket(NC2S_UserLoginProtocol.CreatePacket());
        }
        
        public void Login(UInt32 _user_key) {
            PlayerManager.Instance.Join<GPC>(_user_key, true);
            LocalPlayer = PlayerManager.Instance.LocalPlayer;

            // 지금은 바로 월드로 조인 시키자
            is_login = true; // 우선 true로 변경해주자.
            NetworkManager.Instance.SendPacket(NC2S_JoinWorldProtocol.CreatePacket());
        }

        

    }
}
