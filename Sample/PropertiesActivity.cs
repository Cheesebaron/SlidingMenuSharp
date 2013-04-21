using Android.App;
using Android.OS;
using Android.Widget;
using SlidingMenuSharp;

namespace Sample
{
    [Activity(Label = "Properties")]
    public class PropertiesActivity : BaseActivity
    {
        public PropertiesActivity() 
            : base(Resource.String.properties)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetSlidingActionBarEnabled(true);

            SetContentView(Resource.Layout.properties);

            var mode = FindViewById<RadioGroup>(Resource.Id.mode);
            mode.Check(Resource.Id.left);
            mode.CheckedChange += (sender, args) =>
                {
                    switch (args.CheckedId)
                    {
                        case Resource.Id.left:
                            SlidingMenu.Mode = MenuMode.Left;
                            SlidingMenu.ShadowDrawableRes = Resource.Drawable.shadow;
                            break;
                        case Resource.Id.right:
                            SlidingMenu.Mode = MenuMode.Right;
                            SlidingMenu.ShadowDrawableRes = Resource.Drawable.shadowright;
                            break;
                        case Resource.Id.left_right:
                            SlidingMenu.Mode = MenuMode.LeftRight;
                            SlidingMenu.SetSecondaryMenu(Resource.Layout.menu_frame_two);
                            SupportFragmentManager
                                .BeginTransaction()
                                .Replace(Resource.Id.menu_frame_two, new SampleListFragment())
                                .Commit();
                            SlidingMenu.SecondaryShadowDrawableRes = Resource.Drawable.shadowright;
                            SlidingMenu.ShadowDrawableRes = Resource.Drawable.shadow;
                            break;
                    }
                };

            var touchAbove = FindViewById<RadioGroup>(Resource.Id.touch_above);
            touchAbove.Check(Resource.Id.touch_above_full);
            touchAbove.CheckedChange += (sender, args) =>
                {
                    switch (args.CheckedId)
                    {
                        case Resource.Id.touch_above_full:
                            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
                            break;
                        case Resource.Id.touch_above_margin:
                            SlidingMenu.TouchModeAbove = TouchMode.Margin;
                            break;
                        case Resource.Id.touch_above_none:
                            SlidingMenu.TouchModeAbove = TouchMode.None;
                            break;
                    }
                };

            var scrollScale = FindViewById<SeekBar>(Resource.Id.scroll_scale);
            scrollScale.Max = 1000;
            scrollScale.Progress = 333;
            scrollScale.StopTrackingTouch += (sender, args) =>
                {
                    SlidingMenu.BehindScrollScale = (float) args.SeekBar.Progress / args.SeekBar.Max;
                };

            var behindWidth = FindViewById<SeekBar>(Resource.Id.behind_width);
            behindWidth.Max = 1000;
            behindWidth.Progress = 750;
            behindWidth.StopTrackingTouch += (sender, args) =>
                {
                    var percent = (float) args.SeekBar.Progress / args.SeekBar.Max;
                    SlidingMenu.BehindWidth = (int) (percent * SlidingMenu.Width);
                    SlidingMenu.RequestLayout();
                };

            var shadowEnabled = FindViewById<CheckBox>(Resource.Id.shadow_enabled);
            shadowEnabled.Checked = true;
            shadowEnabled.CheckedChange += (sender, args) =>
                {
                    if (args.IsChecked)
                        SlidingMenu.ShadowDrawableRes = SlidingMenu.Mode == MenuMode.Left
                                                            ? Resource.Drawable.shadow
                                                            : Resource.Drawable.shadowright;
                    else
                        SlidingMenu.ShadowDrawable = null;
                };

            var shadowWidth = FindViewById<SeekBar>(Resource.Id.shadow_width);
            shadowWidth.Max = 1000;
            shadowWidth.Progress = 75;
            shadowWidth.StopTrackingTouch += (sender, args) =>
                {
                    var percent = (float)args.SeekBar.Progress / args.SeekBar.Max;
                    var width = (int) (percent * SlidingMenu.Width);
                    SlidingMenu.ShadowWidth = width;
                    SlidingMenu.Invalidate();
                };

            var fadeEnabled = FindViewById<CheckBox>(Resource.Id.fade_enabled);
            fadeEnabled.Checked = true;
            fadeEnabled.CheckedChange += (sender, args) =>
                {
                    SlidingMenu.FadeEnabled = args.IsChecked;
                };

            var fadeDeg = FindViewById<SeekBar>(Resource.Id.fade_degree);
            fadeDeg.Max = 1000;
            fadeDeg.Progress = 666; //NUMBER OF THE BEAST!
            fadeDeg.StopTrackingTouch += (sender, args) =>
                {
                    SlidingMenu.FadeDegree = (float) args.SeekBar.Progress / args.SeekBar.Max;
                };
        }
    }
}