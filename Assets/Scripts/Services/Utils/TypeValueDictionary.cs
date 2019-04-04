using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Utils
{
    public class TypeValueDictionary
    {
        private Dictionary<Type, int> _typeValue = new Dictionary<Type, int>();

        public void SetValueForType<T>(int value)
        {
            _typeValue.Add(typeof(T),value);
        }

        public int GetValueForType<T>()
        {
            if (_typeValue.All(x => x.Key != typeof(T)))
            {
                throw new ArgumentOutOfRangeException(string.Format("No value was specified for {0}", typeof(T).Name));
            }

            var keyValuePair = _typeValue.First(x => x.Key == typeof(T));

            return keyValuePair.Value;
        }
    }
}
