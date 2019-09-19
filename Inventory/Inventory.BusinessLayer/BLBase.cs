using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.BusinessLayer
{
    public abstract class BLBase<T>
    {
        /// <summary>
        /// Validations on Supplier before adding or updating.
        /// </summary>
        /// <param name="entityObject">Represents supplier to be validated.</param>
        /// <returns>Returns a boolean value, that indicates whether the supplier is valid or not.</returns>
        protected bool Validate(T entityObject)
        {
            //Create string builder
            StringBuilder sb = new StringBuilder();
            bool valid = true;

            //Check the mandatory properties using reflection and attributes
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<RequiredAttribute>();
                if (attr != null)
                {
                    object currentValue = prop.GetValue(entityObject);
                    if (string.IsNullOrEmpty(Convert.ToString(currentValue)))
                    {
                        valid = false;
                        sb.Append(Environment.NewLine + attr.ErrorMessage);
                    }
                }
            }

            //Check the regular expression of properties using reflection and attributes
            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<RegExpAttribute>();
                if (attr != null)
                {
                    string currentValue = Convert.ToString(prop.GetValue(entityObject));
                    Regex regex = new Regex(attr.RegularExpressionToCheck);
                    if (!regex.IsMatch(currentValue))
                    {
                        valid = false;
                        sb.Append(Environment.NewLine + attr.ErrorMessage);
                    }
                }
            }

            if (valid == false)
                throw new InventoryException(sb.ToString());
            return valid;
        }
    }
}



