using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Utils
{
    public class TypeValueDictionary
    {
        private Dictionary<Type, int> _typeValue = new Dictionary<Type, int>();

        public void SetValueForType(Type type, int value)
        {
            _typeValue.Add(type, value);
        }

        public int GetValueForType(Type type)
        {
            if (_typeValue.All(x => x.Key != type))
            {
                throw new ArgumentOutOfRangeException(type.Name, string.Format("No value was specified for {0}.", type.Name));
            }

            var keyValuePair = _typeValue.First(x => x.Key == type);

            return keyValuePair.Value;
        }
    }
}
