using CRM2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM2
{
    public class Singleton
    {
        private static volatile Singleton _instance;
        private static readonly object _synclock = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_synclock)
                {
                    if(_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }

                return _instance;
            }
        }

        public WebServices webServices = new WebServices();

    }
}
