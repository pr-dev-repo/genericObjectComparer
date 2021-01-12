using System.Collections.Generic;
using System.Reflection;

namespace CGI.DRS.Foundation.Common
{
    /// <summary>
    /// Author: Gabriel Rodriguez
    /// Allows the implementation of customized equality comparison for collections. 
    /// That is, you can create your own definition of equality for type T, and specify that this definition be used with a collection type that accepts the IEqualityComparer<T> generic interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectComparer<T> : IEqualityComparer<T> where T : class
    {
        private readonly string field;
        private readonly PropertyInfo prop;

        public ObjectComparer(string field)
        {
            this.field = field;
            prop = typeof(T).GetProperty(field);
        }

        public bool Equals(T x, T y)
        {
            var valueX = prop.GetValue(x, null);
            var valueY = prop.GetValue(y, null);
            if (valueX == null)
            {
                return valueY == null;
            }
            return valueX.Equals(valueY);
        }

        public int GetHashCode(T obj)
        {
            var value = prop.GetValue(obj, null);
            if (value == null)
            {
                return 0;
            }
            return value.GetHashCode();
        }
    }
}
