using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MProject.Utility {
    public class USingleton<T> : MonoBehaviour where T : USingleton<T> {

        [SerializeField]
        bool dont_destroy_on_load = false;
        protected static bool Qutting { get; private set; } = false;
        private static readonly Object mutex = new Object();
        private static SortedDictionary<System.Type, USingleton<T>> instance;

        public static T Instance {
            get {
                if (true == Qutting) {
                    return null;
                }
                lock (mutex) {
                    if (instance == null) {
                        instance = new SortedDictionary<System.Type, USingleton<T>>();
                    }
                    if (instance.ContainsKey(typeof(T))) {
                        return instance[typeof(T)] as T;
                    } else {
                        return null;
                    }
                }
            }
        }


        private void OnEnable() {
            if (false == Qutting) {
                bool is_self = false;

                lock (mutex) {
                    if (instance == null) {
                        instance = new SortedDictionary<System.Type, USingleton<T>>();
                    }
                    if (instance.ContainsKey(GetType())) {
                        Destroy(gameObject);
                    } else {
                        is_self = true;
                        instance.Add(GetType(), this);
                        if (dont_destroy_on_load) {
                            Destroy(gameObject);
                        }
                    }
                }
                if (is_self) {
                    Enable();
                }
            }
        }

        private void OnApplicationQuit() {
            Qutting = true;
            Quit();
        }

        protected virtual void Enable() {}
        protected virtual void Quit() {}
    }
}