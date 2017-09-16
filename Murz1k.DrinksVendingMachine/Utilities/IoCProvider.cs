using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Murz1k.DrinksVendingMachine.Utilities
{
    public class IoCProvider
    {
        private static Dictionary<Type, object> _objectsDictionary = new Dictionary<Type, object>();

        public static void AddComponent<TType>() where TType : class
        {
            TType newObject = Activator.CreateInstance<TType>();
            _objectsDictionary.Add(typeof(TType), newObject);
        }

        public static TType GetComponent<TType>() where TType : class
        {
            return (TType)_objectsDictionary[typeof(TType)];
        }

        private static object locker = new object();

        private static DateTime timeSession = DateTime.MaxValue;

        public static DateTime TimeSession
        {
            get
            {
                lock (locker)
                {
                    return timeSession;
                }
            }
            set
            {
                lock (locker)
                {
                    timeSession = value;
                }
            }
        }
    }
}