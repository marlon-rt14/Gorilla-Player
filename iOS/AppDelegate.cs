using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

using Foundation;
using UIKit;

[assembly: ExportRenderer(typeof(Page), typeof(UXDivers.Gorilla.ShakeDetectionRenderer))]
namespace UXDivers.Gorilla.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			FFImageLoading.Forms.Touch.CachedImageRenderer.Init();

			var config = new Config("Gorilla on DESKTOP-MARLON");

			config.RegisterAssemblyFromType<Prism.IActiveAware>(); // Prism
			config.RegisterAssemblyFromType<Prism.PrismApplicationBase<object>>(); // Prism.Forms
			config.RegisterAssemblyFromType<Prism.Unity.PrismApplication>(); // Prism.Unity
			config.RegisterAssemblyFromType<FFImageLoading.Transformations.GrayscaleTransformation>(); // FFImageLoading.Transformations assembly
			config.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>(); // FFImageLoading.Forms assembly

			config.IsImagePropertyDiscriminator = IsImageDiscriminator;

			LoadApplication (Player.CreateApplication(config));

			return base.FinishedLaunching (app, options);
		}

		public override void DidEnterBackground (UIApplication uiApplication)
		{
			base.DidEnterBackground (uiApplication);
		}

		private static bool IsImageDiscriminator(PropertyInfo prop)
		{
			return prop.DeclaringType == typeof(FFImageLoading.Forms.CachedImage) &&
				prop.Name == "Source";
		}
	}
}

