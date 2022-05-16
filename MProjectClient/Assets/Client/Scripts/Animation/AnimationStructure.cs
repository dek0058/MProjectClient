using System;
using System.Collections.Generic;
using MProject.Utility;
using UnityEngine;

namespace MProject.Animation {

    public enum AnimationPrority : int {
        High = 1,
        Middle = 2,
        Low = 3,
    }
    
    public enum AnimationType : int {
        None = -1,
        Stand,
        Movement,
        
    }

    [Serializable]
    public class AnimationDictionary : SerializableDictionary<AnimationType, int> {}

}
