using Android.App;
using Android.OS;
using SlidingMenuSharp;

namespace Sample.Fragments
{
    [Activity(Label = "Fragment Change", Theme = "@style/ExampleTheme")]
    public class FragmentChangeActivity : BaseActivity
    {
        private Android.Support.V4.App.Fragment _content;

        public FragmentChangeActivity() 
            : base(Resource.String.changing_fragments)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (null != savedInstanceState)
                _content = SupportFragmentManager.GetFragment(savedInstanceState, "_content");
            if (null == _content)
                _content = new ColorFragment(Resource.Color.red);

            SetContentView(Resource.Layout.content_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, _content)
                .Commit();

            SetBehindContentView(Resource.Layout.menu_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.menu_frame, new ColorMenuFragment())
                .Commit();

            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            SupportFragmentManager.PutFragment(outState, "_content", _content);
        }

        public void SwitchContent(Android.Support.V4.App.Fragment fragment)
        {
            _content = fragment;
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
            SlidingMenu.ShowContent();
        }
    }
}