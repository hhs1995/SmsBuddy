﻿using NullVoidCreations.WpfHelpers;
using System.IO;
using System.Windows;

namespace SmsBuddy
{
    class Shared
    {
        static object _syncLock;
        static Shared _instance;

        #region constructor/destructor

        static Shared()
        {
            _syncLock = new object();
        }

        private Shared()
        {
            DbPath = Path.Combine(Application.Current.GetStartupDirectory(), "Assets", "Data", "Data.sqlite");
        }

        #endregion

        #region properties

        public static Shared Instance
        {
            get
            {
                lock(_syncLock)
                {
                    if (_instance == null)
                        _instance = new Shared();
                }

                return _instance;
            }
        }

        public string DbPath { get; }

        #endregion
    }
}
