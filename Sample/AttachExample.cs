using Android.App;
using Android.OS;
using Android.Support.V4.App;
using SlidingMenuSharp;

namespace Sample
{
    [Activity(Label = "Attach Example", Theme = "@style/ExampleTheme")]
    public class AttachExample : FragmentActivity
    {
        private SlidingMenu _menu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetTitle(Resource.String.attach);

            SetContentView(Resource.Layout.content_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, new SampleListFragment())
                .Commit();

            _menu = new SlidingMenu(this)
                {
                    TouchModeAbove = TouchMode.Fullscreen,
                    ShadowWidthRes = Resource.Dimension.shadow_width,
                    ShadowDrawableRes = Resource.Drawable.shadow,
                    BehindWidthRes = Resource.Dimension.slidingmenu_offset,
                    FadeDegree = 0.35f
                };
            _menu.AttachToActivity(this, SlideStyle.Content);
            _menu.SetMenu(Resource.Layout.menu_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.menu_frame, new SampleListFragment())
                .Commit();
        }

        public override void OnBackPressed()
        {
            if (_menu.IsMenuShowing)
                _menu.ShowContent();
            else
                base.OnBackPressed();
        }
    }
}