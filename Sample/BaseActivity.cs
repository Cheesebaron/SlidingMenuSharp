using Android.OS;
using Android.Views;
using SlidingMenuSharp;
using SlidingMenuSharp.App;
using ListFragment = Android.Support.V4.App.ListFragment;

namespace Sample
{
    public class BaseActivity : SlidingFragmentActivity
    {
        private readonly int _titleRes;
        protected ListFragment Frag;

        public BaseActivity(int titleRes)
        {
            _titleRes = titleRes;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetTitle(_titleRes);

            SetBehindContentView(Resource.Layout.menu_frame);
            if (null == savedInstanceState)
            {
                var t = SupportFragmentManager.BeginTransaction();
                Frag = new SampleListFragment();
                t.Replace(Resource.Id.menu_frame, Frag);
                t.Commit();
            }
            else
                Frag =
                    (ListFragment)
                    SupportFragmentManager.FindFragmentById(Resource.Id.menu_frame);

            SlidingMenu.ShadowWidthRes = Resource.Dimension.shadow_width;
            SlidingMenu.BehindOffsetRes = Resource.Dimension.slidingmenu_offset;
            SlidingMenu.ShadowDrawableRes = Resource.Drawable.shadow;
            SlidingMenu.FadeDegree = 0.25f;
            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;

            ActionBar.SetDisplayHomeAsUpEnabled(true);
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
    }
}