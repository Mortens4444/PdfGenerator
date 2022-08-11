using System;
using System.Collections.Generic;
using System.Linq;

namespace PdfGenerator
{
	public static class TypeExtensions
	{
		public static IEnumerable<Type> GetDerivedTypesOf<TBaseType>()
		{
			return GetTypes(type => type.IsSubclassOf(typeof(TBaseType)) && !type.IsAbstract);
		}

		private static IEnumerable<Type> GetTypes(Func<Type, bool> predicate)
		{
			var result = new List<Type>();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes().Where(predicate);
				result.AddRange(types);
			}
			return result;
		}
	}
}
