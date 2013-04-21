using Android.App;
using Android.OS;

namespace Sample
{
    [Activity(Label = "Sliding Content")]
    public class SlidingContent : BaseActivity
    {
        public SlidingContent() 
            : base(Resource.String.title_bar_content)
        { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.content_frame);
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, new SampleListFragment())
                .Commit();
            
            SetSlidingActionBarEnabled(false);
        }
    }
}