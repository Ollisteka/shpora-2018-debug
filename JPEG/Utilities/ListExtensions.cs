using System;
using System.Collections.Generic;
using System.Linq;

namespace JPEG.Utilities
{
	static class ListExtensions
	{
		public static T MinOrDefault<T>(this List<T> enumerable, Func<T, int> selector)
        {
            var min = int.MaxValue;
            var minElement = default(T);
            foreach (var element in enumerable)
            {
                var selected = selector(element);
                if (selected >= min) continue;
                min = selected;
                minElement = element;
            }
            return minElement;
			//return enumerable.OrderBy(selector).FirstOrDefault();
		}

		public static List<T> Without<T>(this List<T> enumerable, T element)
		{
            var result = new List<T>();
            foreach (var el in enumerable)
            {
                if (!(el.Equals(element)))
                    result.Add(el);
            }

            return result;
            //return enumerable.Where(x => !x.Equals(element)).ToList();
        }
	}
}