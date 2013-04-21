using Android.App;
using SlidingMenuSharp;

namespace Sample.Anim
{
    [Activity(Label = "Zoom Animation")]
    public class ZoomAnimation : CustomAnimation
    {
        public ZoomAnimation()
            : base(Resource.String.anim_zoom)
        {
            Transformer = new ZoomTransformer();
        }
    }
}