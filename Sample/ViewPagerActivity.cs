using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Sample.Fragments;
using SlidingMenuSharp;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Sample
{
    [Activity(Label = "ViewPager")]
    public class ViewPagerActivity : BaseActivity
    {
        public ViewPagerActivity() 
            : base(Resource.String.viewpager)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var vp = new ViewPager(this)
                {
                    Id = "VP".GetHashCode()
                };
            SetContentView(vp);

            vp.PageSelected += (sender, args) =>
                {
                    switch (args.P0)
                    {
                        case 0:
                            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
                            break;
                        default:
                            SlidingMenu.TouchModeAbove = TouchMode.Margin;
                            break;
                    }
                };

            vp.Adapter = new ColorPagerAdapter(SupportFragmentManager);
            vp.SetCurrentItem(0, true);
            SlidingMenu.TouchModeAbove = TouchMode.Fullscreen;
        }

        public class ColorPagerAdapter : FragmentPagerAdapter
        {
            private readonly IList<Fragment> _fragments;

            private readonly int[] _colors = new[]
                {
                    Resource.Color.red,
                    Resource.Color.green,
                    Resource.Color.blue,
                    Resource.Color.white,
                    Resource.Color.black
                };

            public ColorPagerAdapter(FragmentManager fm) 
                : base(fm)
            {
                _fragments = new List<Fragment>();
                foreach (var c in _colors)
                    _fragments.Add(new ColorFragment(c));
            }

            public override int Count
            {
                get { return _fragments.Count; }
            }

            public override Fragment GetItem(int p0)
            {
                return _fragments[p0];
            }
        }
    }
}