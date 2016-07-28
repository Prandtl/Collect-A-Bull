using System;
using System.Globalization;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Platform.Converters;

namespace Collect_A_Bull.Core.Converters
{
	public class CollectableHasAPictureValueConverter:MvxValueConverter<Collectable,bool>
	{
		protected override bool Convert(Collectable collectable, Type targetType, object parameter, CultureInfo culture)
		{
			var result = collectable?.ImagePath != null;
			return result;
		}
	}
}