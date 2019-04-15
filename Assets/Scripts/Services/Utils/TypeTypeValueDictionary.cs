using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Utils
{
    public class TypeTypeValueDictionary
    {
        private Dictionary<KeyValuePair<Type, Type>, int> _typeTypeValue = new Dictionary<KeyValuePair<Type, Type>, int>();

        public void SetValueForType<T1, T2>(int value)
        {
            SetValueForType(typeof(T1), typeof(T2), value);
        }

        public void SetValueForType(Type type1, Type type2, int value)
        {
            _typeTypeValue.Add(new KeyValuePair<Type, Type>(type1, type2), value);
        }

        public int GetValueForType<T1, T2>()
        {
            return GetValueForType(typeof(T1), typeof(T2));
        }

        public int GetValueForType(Type type1, Type type2)
        {
            if (_typeTypeValue.All(x => x.Key.Key != type1 || x.Key.Value != type2))
            {
                throw new ArgumentOutOfRangeException(type1.Name, string.Format("No value was specified for {0} and {1}.", type1.Name, type2.Name));
            }

            var keyValuePair = _typeTypeValue.First(x => x.Key.Key == type1 && x.Key.Value == type2);

            return keyValuePair.Value;
        }
    }
}
