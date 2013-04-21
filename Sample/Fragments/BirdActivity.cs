using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Sample.Fragments
{
    [Activity(Label = "Birds")]
    public class BirdActivity : Activity
    {
        private Handler _handler;

        public static Intent NewInstance(Activity activity, int pos) {
            var intent = new Intent(activity, typeof(BirdActivity));
            intent.PutExtra("pos", pos);
            return intent;
        }

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            
            var pos = 0;
            if (Intent.Extras != null)
                pos = Intent.Extras.GetInt("pos");

            var birds = Resources.GetStringArray(Resource.Array.birds);
            var imgs = Resources.ObtainTypedArray(Resource.Array.birds_img);
            var resId = imgs.GetResourceId(pos, -1);

            Title = birds[pos];
            Window.RequestFeature(WindowFeatures.ActionBarOverlay);
            var color = new ColorDrawable(Color.Black);
            color.SetAlpha(128);
            ActionBar.SetBackgroundDrawable(color);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            _handler = new Handler();

            var imageView = new ImageView(this);
            imageView.SetScaleType(ImageView.ScaleType.CenterInside);
            imageView.SetImageResource(resId);
            imageView.Click += (sender, args) =>
                {
                    ActionBar.Show();
                    HideActionBarDelayed(_handler);
                };
            SetContentView(imageView);
            Window.SetBackgroundDrawableResource(Android.Resource.Color.BackgroundDark);
        }

        protected override void OnResume()
        {
            base.OnResume();
            ActionBar.Show();
            HideActionBarDelayed(_handler);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void HideActionBarDelayed(Handler handler) {
            handler.PostDelayed(() => ActionBar.Hide(), 2000);
        }
    }
}