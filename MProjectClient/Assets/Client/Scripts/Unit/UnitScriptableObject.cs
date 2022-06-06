using System;
using System.Collections.Generic;
using UnityEngine;
using MProject.Animation;
using MProject.Utility;

using UnityEditor;

namespace MProject.Unit {

    [CreateAssetMenu(fileName = "Data", menuName = "MProject/Unit", order = 1)]
    public class UnitScriptableObject : ScriptableObject {

        public FUnitData unit_data;

        [SerializeField]
        private AnimationDictionary animation_map = new AnimationDictionary();

        public IDictionary<AnimationType, int> Animation_Map {
            get => animation_map;
        }

    }
}
