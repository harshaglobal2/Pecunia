using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Inventory.Helpers
{
    /// <summary>
    /// Contains static methods for cloning data from one object to another object.
    /// </summary>
    public static class ReflectionHelpers
    {
        /// <summary>
        /// Copies specified property values from source object to destination object.
        /// </summary>
        /// <param name="sourceObject">Represents source object.</param>
        /// <param name="destinationObject">Represents destination object.</param>
        /// <param name="propertiesList">Represents list of properties to copy.</param>
        public static void CopyProperties(object sourceObject, object destinationObject, List<string> propertiesList)
        {
            //Get source type and destination type
            Type sourceType = sourceObject.GetType();
            Type destinationType = destinationObject.GetType();

            //Copy property values from sourceObject to destinationObject
            foreach (var prop in propertiesList)
            {
                object sourceValue = sourceType.GetProperty(prop).GetValue(sourceObject);
                destinationType.GetProperty(prop).SetValue(destinationObject, sourceValue);
            }
        }
    }
}


