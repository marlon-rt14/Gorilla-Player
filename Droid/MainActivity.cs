using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace UXDivers.Gorilla.Droid
{
	[Activity (Label = "Gorilla Player", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public partial/*GORILLA*/class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			FFImageLoading.Forms.Droid.CachedImageRenderer.Init(false);

			LoadApplication (Player.CreateApplication(this, 
                  new Config("Gorilla on DESKTOP-MARLON")
					.RegisterAssemblyFromType<Prism.IActiveAware>() // Prism
					.RegisterAssemblyFromType<Prism.PrismApplicationBase<object>>() // Prism.Forms
					.RegisterAssemblyFromType<Prism.Unity.PrismApplication>() // Prism.Unity
					.RegisterAssemblyFromType<FFImageLoading.Transformations.GrayscaleTransformation>() // FFImageLoading.Transformations assembly
					.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>() // FFImageLoading.Forms assembly
			));
		}

		public override bool OnKeyUp (Keycode keyCode, KeyEvent e)
		{
			if ((keyCode == Keycode.Menu || keyCode == Keycode.F1) && Coordinator.Instance != null) {
				Coordinator.Instance.RequestStatusUpdate ();
				return true; 
			}

			return base.OnKeyUp (keyCode, e); 
		} 
	}
}

