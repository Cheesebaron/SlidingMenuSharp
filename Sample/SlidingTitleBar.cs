using Android.App;
using Android.OS;

namespace Sample
{
    [Activity(Label = "Sliding TitleBar")]
    public class SlidingTitleBar : BaseActivity
    {
        public SlidingTitleBar() 
            : base(Resource.String.title_bar_slide)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.content_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, new SampleListFragment())
                .Commit();
            
            SetSlidingActionBarEnabled(true);
        }
    }
}