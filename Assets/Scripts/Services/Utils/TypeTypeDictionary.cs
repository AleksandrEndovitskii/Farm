using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Utils
{
    public class TypeTypeDictionary<T1, T2>
    {
        private Dictionary<Type, Type> _typeType = new Dictionary<Type, Type>();

        public void Set<T1, T2>()
        {
            _typeType.Add(typeof(T1), typeof(T2));
        }

        public T2 Get<T1, T2>()
        {
            if (_typeType.All(x => x.Key != typeof(T1)))
            {
                throw new ArgumentOutOfRangeException(typeof(T1).Name, string.Format("No type was specified for {0}.", typeof(T1).Name));
            }

            var keyValuePair = _typeType.First(x => x.Key == typeof(T1));

            var type = (T2)Convert.ChangeType(keyValuePair.Value, typeof(T2));

            if (type == null)
            {
                throw new TypeAccessException(string.Format("Can not convert result type {0} to return type {1}.", keyValuePair.Value.Name, typeof(T2).Name));
            }

            return type;
        }
    }
}
