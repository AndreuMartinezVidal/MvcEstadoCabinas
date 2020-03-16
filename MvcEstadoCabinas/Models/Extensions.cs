using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MvcPlanificacionCabinas.Models
{

    public static class Extensions
    {
        public static string GetEnumDescription<TEnum>(this TEnum item)
            where TEnum : Enum
            => item.GetType()?
                   .GetField(item.ToString())?
                   .GetCustomAttributes(typeof(DisplayNameAttribute), false)?
                   .Cast<DisplayNameAttribute>()?
                   .FirstOrDefault()?.DisplayName ?? string.Empty;

        public static void SeedEnumValues<T, TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class
            where TEnum : Enum
            => Enum.GetValues(typeof(TEnum))
                  .Cast<object>()
                  .Select(value => converter((TEnum)value))
                  .ToList()
                  .ForEach(instance => dbSet.AddOrUpdate(instance));
    }
}