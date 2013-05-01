using Android.App;
using Android.OS;
using SlidingMenuSharp;

namespace Sample
{
    [Activity(Label = "Left and Right", Theme = "@style/ExampleTheme")]
    public class LeftAndRightActivity : BaseActivity
    {
        public LeftAndRightActivity() 
            : base(Resource.String.left_and_right)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SlidingMenu.Mode = MenuMode.LeftRight;
            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
            
            SetContentView(Resource.Layout.content_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, new SampleListFragment())
                .Commit();

            SlidingMenu.SetSecondaryMenu(Resource.Layout.menu_frame_two);
            SlidingMenu.SecondaryShadowDrawableRes = Resource.Drawable.shadowright;
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.menu_frame_two, new SampleListFragment())
                .Commit();
        }
    }
}