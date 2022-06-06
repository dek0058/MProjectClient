using System;
using System.Collections.Generic;
using UnityEngine;
//using MProject.Packet;
using MProject.Player;
using MProject.Manager;
using MProject.Unit;
using MProject.Camera;
using MProject.Network;
using MProject.Protocol;

namespace MProject.GameMode {
    
    public class TestGameMode : BaseGameMode {

        public GenericPC PC;

        public UnitActor character;

        public ThirdPersonCamera third_person_camera;

        public GameObject test_prefab;
        public Transform test_start_pos;


        


        public override void Initialize() {
            
            //NetworkManager.Instance.Handler_Manager.RegisterHandler((UInt32)Tag.UserLogin, new UserLoginProtocolHandler());
            //NetworkManager.Instance.Handler_Manager.RegisterHandler((UInt32)Tag.IssueUserKey, new IssuseUserKeyProtocolHandler());
            

        }


        
        public void EndPlay() {

        }


        private void OnConnect() {

            
        }

        private void OnDisconnect() {
            
        }

        private void OnInitialize() {
            //NetworkManager.Instance.SendPacket(UserLoginProtocol.CreatePacket());

        }


        public void CreateActor() {
            //var actor_object = Instantiate(test_prefab, test_start_pos.position, Quaternion.identity);
            //var unit_actor = actor_object.GetComponent<UnitActor>();
            //character = unit_actor;
            //third_person_camera.character = actor_object.transform;
            //
            //PC = PlayerManager.Instance.Local_Player as GenericPC;
            //PC.Character = character;
        }

    }
}
