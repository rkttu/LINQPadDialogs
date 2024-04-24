using LINQPad.Controls;
using System.Collections.Generic;
using System.Linq;

namespace LINQPad.Controls
{
    internal static class DialogExtensions
    {
        public static IEnumerable<Control> JoinControls(this IEnumerable<Control> items, Control separator)
        {
            if (items == null || items.Count() < 1)
                return Enumerable.Empty<Control>();

            return items
                .Take(items.Count() - 1)
                .SelectMany(item => new[] { item, separator })
                .Concat(new[] { items.Last() });
        }
    }
}
