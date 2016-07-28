using System;
using System.Globalization;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Platform.Converters;

namespace Collect_A_Bull.Core.Converters
{
	public class IsCollectablePresentValueConverter:MvxValueConverter<Collectable,bool>
	{
		protected override bool Convert(Collectable collectable, Type targetType, object parameter, CultureInfo culture)
		{
			var result = collectable == null;
			return result;
		}
	}
}