﻿using Assets.Scripts.Models.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Models.Abstract
{
    public abstract class SaveableMonoBehaviour<T> : MonoBehaviour, ISaveable<T> where T : class
    {
        [SerializeField, HideInInspector]
        private string _guid;
        public string UniqueId => _guid;

        protected virtual void OnValidate()
        {
            // Only generate a GUID if one doesn't already exist
            if (string.IsNullOrEmpty(_guid))
            {
                _guid = Guid.NewGuid().ToString();
            }
        }

        public abstract T Save();
        public abstract void Load(T data);
    }
}
