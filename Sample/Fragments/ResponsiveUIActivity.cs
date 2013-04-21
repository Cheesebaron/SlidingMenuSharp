using Android.App;
using Android.OS;
using Android.Views;
using SlidingMenuSharp;
using SlidingMenuSharp.App;

namespace Sample.Fragments
{
    [Activity(Label = "Responsive UI")]
    public class ResponsiveUIActivity : SlidingFragmentActivity
    {
        private Android.Support.V4.App.Fragment _content;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetTitle(Resource.String.responsive_ui);

            SetContentView(Resource.Layout.responsive_content_frame);

            if (FindViewById(Resource.Id.menu_frame) == null)
            {
                SetBehindContentView(Resource.Layout.menu_frame);
                SlidingMenu.IsSlidingEnabled = true;
                SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
                ActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            else
            {
                var v = new View(this);
                SetBehindContentView(v);
                SlidingMenu.IsSlidingEnabled = false;
                SlidingMenu.TouchModeAbove = TouchMode.None;
            }

            if (savedInstanceState != null)
                _content = SupportFragmentManager.GetFragment(savedInstanceState, "_content");
            else
                _content = new BirdGridFragment(0);

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, _content)
                .Commit();

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.menu_frame, new BirdMenuFragment())
                .Commit();

            SlidingMenu.BehindOffsetRes = Resource.Dimension.slidingmenu_offset;
            SlidingMenu.ShadowWidthRes = Resource.Dimension.shadow_width;
            SlidingMenu.ShadowDrawableRes = Resource.Drawable.shadow;
            SlidingMenu.BehindScrollScale = 0.25f;
            SlidingMenu.FadeDegree = 0.25f;

            if (null == savedInstanceState)
                new AlertDialog.Builder(this)
                    .SetTitle(Resource.String.what_is_this)
                    .SetMessage(Resource.String.responsive_explanation)
                    .Show();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Toggle();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
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
            var h = new Handler();
            h.PostDelayed(() => SlidingMenu.ShowContent(), 50);
        }

        public void OnBirdPressed(int pos)
        {
            var intent = BirdActivity.NewInstance(this, pos);
            StartActivity(intent);
        }
    }
}