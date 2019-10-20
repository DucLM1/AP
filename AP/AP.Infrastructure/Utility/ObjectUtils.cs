using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;

namespace AP.Infrastructure.Utility
{
    public static class ObjectUtils
    {
        //public static List<string> GetPropertyNames(Type type)
        //{
        //    var properties = type.GetProperties();
        //    var propertyNames = properties.Select(s => s.Name).ToList();
        //    return propertyNames;
        //}

        //public static List<object> GetPropertyValues(object obj)
        //{
        //    var result = new List<object>();
        //    var type = obj.GetType();
        //    var properties = type.GetProperties();

        //    foreach (var property in properties)
        //    {
        //        var propertyValue = property.GetValue(obj);
        //        result.Add(propertyValue);
        //    }

        //    return result;
        //}

        //public static Dictionary<string, Type> GetPropertyTypeMap(Type type)
        //{
        //    var result = new Dictionary<string, Type>();
        //    var properties = type.GetProperties();
        //    foreach (var property in properties)
        //    {
        //        var propertyName = property.Name;
        //        if (property.DeclaringType.Equals(type))
        //            result.Add(property.Name, property.PropertyType);
        //        else if (!result.ContainsKey(propertyName))
        //            result.Add(property.Name, property.PropertyType);
        //    }

        //    return result;
        //}

        //public static Dictionary<string, string> ValidateObject(object obj)
        //{
        //    var validationContext = new ValidationContext(obj);
        //    var validationResults = new List<ValidationResult>();
        //    Validator.TryValidateObject(obj, validationContext, validationResults, true);

        //    var result = new Dictionary<string, string>();
        //    foreach (var validationResult in validationResults)
        //        result.Add(string.Join(",", validationResult.MemberNames), validationResult.ErrorMessage);
        //    return result;
        //}

        //public static bool Equal(object obj1, object obj2)
        //{
        //    if (obj1 == null && obj2 == null)
        //        return true;
        //    if (obj1 == null && obj2 != null)
        //        return false;
        //    if (obj1 != null && obj2 == null)
        //        return false;
        //    return obj1.Equals(obj2);
        //}

        //public static Type GetElementType<T>(this IEnumerable<T> input)
        //{
        //    var interfaces = input.GetType().GetInterfaces();
        //    Type elementType = null;
        //    foreach (var i in interfaces)
        //        if (i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
        //            elementType = i.GetGenericArguments()[0];
        //    return elementType;
        //}

        //public static bool IsBlank<T>(this List<T> list)
        //{
        //    if (list == null)
        //        return true;
        //    if (list.Count == 0)
        //        return true;
        //    return false;
        //}

        //public static bool Equals<T>(List<T> list1, List<T> list2)
        //{
        //    if (list1.IsBlank() && list2.IsBlank()) return true;

        //    if (!list1.IsBlank() && !list2.IsBlank())
        //    {
        //        var exclude1 = list1.Where(w => !list2.Contains(w));
        //        var exclude2 = list2.Where(w => !list1.Contains(w));
        //        if (exclude1.Count() > 0 || exclude2.Count() > 0)
        //            return false;
        //        return true;
        //    }

        //    return false;
        //}

        //public static Type GetType(string typeName)
        //{
        //    var type = Type.GetType(typeName);
        //    if (type != null) return type;
        //    foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        //    {
        //        type = a.GetType(typeName);
        //        if (type != null)
        //            return type;
        //    }

        //    return null;
        //}

        public static List<PropertyDetail> GetPropertyDetails(object obj)
        {
            var result = new List<PropertyDetail>();

            if (obj == null)
                return result;

            var properties = obj.GetType().GetProperties();
            if (properties == null || properties.Count() == 0)
                return result;

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                result.Add(new PropertyDetail
                {
                    Name = property.Name,
                    Type = propertyType,
                    Value = property.GetValue(obj)
                });
            }

            return result;
        }

        //public static List<object> GetPropertyValues(object obj, List<string> propertyNames)
        //{
        //    var result = new List<object>();
        //    if (obj != null)
        //    {
        //        var type = obj.GetType();
        //        var properties = type.GetProperties();

        //        foreach (var propertyName in propertyNames)
        //        {
        //            var property = properties.FirstOrDefault(w => w.Name.Equals(propertyName));
        //            if (property == null)
        //                result.Add(null);

        //            var propertyValue = property.GetValue(obj);
        //            result.Add(propertyValue);
        //        }
        //    }

        //    return result;
        //}

        //public static Dictionary<string, string> ToDictionary(this object obj)
        //{
        //    var type = obj.GetType();

        //    if (type.Equals(typeof(ExpandoObject)))
        //        return (obj as ExpandoObject).ToDictionary();

        //    var dict = new Dictionary<string, string>();

        //    var props = type.GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var value = prop.GetValue(obj);
        //        dict.Add(prop.Name, ConvertPropValueToString(value));
        //    }

        //    return dict;
        //}

        //public static string ConvertPropValueToString(object value)
        //{
        //    if (value == null)
        //        return null;

        //    var valueType = value.GetType();

        //    if (valueType.Equals(typeof(string)))
        //        return (string)value;
        //    if (valueType.IsPrimitive)
        //        return value.ToString();
        //    if (valueType.Equals(typeof(CustomDateTime)))
        //        return ((CustomDateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ");
        //    if (valueType.Equals(typeof(DateTime)))
        //        return ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ");
        //    if (valueType == typeof(List<>))
        //        return string.Join(",", (IList<object>)valueType);
        //    return "";
        //}

        //public static Dictionary<string, string> ToDictionary(this ExpandoObject obj)
        //{
        //    var dict = new Dictionary<string, string>();
        //    var immutableDictionary = obj.ToImmutableDictionary();
        //    foreach (var (key, value) in immutableDictionary) dict.Add(key, ConvertPropValueToString(value));

        //    return dict;
        //}

        //public static object GetDefaultValueOfType(Type type)
        //{
        //    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        return null;
        //    if (type == typeof(DateTime))
        //        return new DateTime();
        //    if (type == typeof(bool))
        //        return false;
        //    if (type == typeof(decimal))
        //        return default(decimal);
        //    if (type == typeof(double))
        //        return default(double);
        //    if (type == typeof(float))
        //        return default(float);
        //    if (type == typeof(short))
        //        return default(short);
        //    if (type == typeof(int))
        //        return default(int);
        //    return null;
        //}

        public static bool IsList(this Type type)
        {
            var result = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
            return result;
        }
    }
    public class PropertyDetail
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}