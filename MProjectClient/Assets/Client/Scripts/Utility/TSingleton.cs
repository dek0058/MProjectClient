using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.Utility {
    public class TSingleton<T> where T : new() {
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());
        public static T Instance => instance.Value;
    }
}
