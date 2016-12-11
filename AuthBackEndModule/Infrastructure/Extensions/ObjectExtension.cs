using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infrastructure.Encryption;

namespace Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object obj)
        {
            if (obj == null || DBNull.Value == obj)
                return true;
            return false;
        }
        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }
        public static TDestination TransformTo<TDestination>(this object sourceObject, string ExcludeProperties = "") where TDestination : class
        {
            if (!sourceObject.IsNull())
            {
                if (!ExcludeProperties.StringIsNullEmptyWhiteSpace())
                {
                    ExcludeProperties = ExcludeProperties.Trim().ToLower();
                    ExcludeProperties = "[" + ExcludeProperties + "]";
                }
                var destinationObject = Activator.CreateInstance(typeof(TDestination));
                typeof(TDestination).GetProperties().AsParallel().ForAll(destProperty =>
                {
                    PropertyInfo sourceProperty = sourceObject.GetType().GetProperty(destProperty.Name);
                    try
                    {
                        if (sourceProperty != null && !ExcludeProperties.Contains("[" + sourceProperty.Name.ToLower() + "]") && destProperty.CanWrite)
                        {
                            object sourceValue = sourceProperty.GetValue(sourceObject);
                            object desValue = destProperty.GetValue(destinationObject);
                            if (!object.Equals(sourceValue, desValue))
                                destProperty.SetValue(destinationObject, sourceValue);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Transform<TDestination>", ex);
                    }
                });
                return (destinationObject as TDestination);
            }
            return null;
        }

        public static List<TDestination> TransformBetweenCollection<TDestination, TSource>(this List<TSource> sourceCollection, string ExcludeProperties = "")
            where TDestination : class
            where TSource : class
        {
            var desCollection = new List<TDestination>();
            if (!sourceCollection.IsNull() && sourceCollection.Any())
                sourceCollection.ForEach(source =>
                {
                    var obj = source.TransformTo<TDestination>(ExcludeProperties);
                    desCollection.Add(obj);
                });
            return desCollection;
        }

        public static string ConvertToString(this object value)
        {
            if (value == null)
                return string.Empty;
            return value.ToString();
        }

        public static string HashAPIPassword(this string value)
        {
            return SHA1.Hash(value);
        }
    }
}
