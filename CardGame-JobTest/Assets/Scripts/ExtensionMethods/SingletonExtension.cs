﻿using UnityEngine;

namespace ExtensionMethods
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                _instance = Resources.Load<T>(typeof(T).Name.ToString());

                if (_instance == null)
                {
                    _instance = Resources.Load<T>(typeof(T).Name.ToString());

                    (_instance as ScriptableSingleton<T>).OnInitialize();
                }

                return _instance;
            }
        }

        protected virtual void OnInitialize() { }
    }
}