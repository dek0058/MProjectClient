using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MProject.Animation;

namespace MProject.Unit {
    public class UnitActor : Actor {

        public UnitScriptableObject origin;
        
        private FUnitData unit_data;
        public FUnitData Unit_Data {
            get => unit_data;
        }

        


        //[SerializeReference]
        //public UnitController unit_controller = new UnitController();

        protected override void Awake() {
            base.Awake();
            Register();

            

        }

        protected override void OnEnable() {
            base.OnEnable();
            SceneLinkedSMB<UnitActor>.Initialize(animation_controller.animator, this);
        }

        protected override void Update() {
            base.Update();
            OnMove();
            OnRotate();
        }

        private void FixedUpdate() {
            //unit_controller.Update();
        }



        private void Register() {
            unit_data.Copy(origin.unit_data);
        }




        private Vector3 move_dir = Vector3.zero;
        private Vector3 rotate_dir = Vector3.zero;

        public override Vector3 MDirection { 
            get => move_dir;
            protected set => move_dir = value;
        }

        public override Vector3 RDirection { 
            get => rotate_dir;
            protected set => rotate_dir = value; 
        }


        public void SetDirection(Vector2 _axis) {
            MDirection = new Vector3(_axis.x, 0, _axis.y);
            //if (MDirection.magnitude > 0) {
            //    if (animation_controller.Current_State != AnimationType.Movement) {
            //        animation_controller.Current_State = AnimationType.Movement;
            //        int id = origin.Animation_Map.ContainsKey(AnimationType.Movement) ? origin.Animation_Map[AnimationType.Movement] : 0;
            //        animation_controller.Set(Animation.AnimationPrority.Middle, id);
            //    }
            //}
        }

        public void SetRotation(Vector2 _axis) {
            RDirection = new Vector3(_axis.x, 0, _axis.y);
        }

        
        private void OnMove() {
            
        }

        private void OnRotate() {
            
        }
    }
}
