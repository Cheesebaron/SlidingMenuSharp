using Android.App;
using SlidingMenuSharp;

namespace Sample.Anim
{
    [Activity(Label = "Scale Animation", Theme = "@style/ExampleTheme")]
    public class ScaleAnimation : CustomAnimation
    {
        public ScaleAnimation() 
            : base(Resource.String.anim_scale)
        {
            Transformer = new ScaleTransformer();
        }
    }
}