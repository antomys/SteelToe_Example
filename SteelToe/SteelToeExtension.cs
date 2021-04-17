using System;
using Microsoft.Extensions.DependencyInjection;

namespace SteelToe
{
    public static class SteelToeExtension
    {
        public static IServiceCollection AddSteelToe(this IServiceCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.AddSteelToe();

            return collection;
        }
    }
}