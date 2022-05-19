/* 
 * Copyright 2012-2014 Jeremy Feinstein
 * Copyright 2013-2014 Tomasz Cielecki
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using Android.App;
using Android.OS;
using Android.Views;

namespace SlidingMenuSharp.App
{
    public class SlidingActivity : Activity, ISlidingActivity
    {
        private SlidingActivityHelper _helper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _helper = new SlidingActivityHelper(this);
            _helper.OnCreate(savedInstanceState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _helper.OnPostCreate(savedInstanceState);
        }

        public override View FindViewById(int id)
        {
            var v = base.FindViewById(id);
            return v ?? _helper.FindViewById(id);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            _helper.OnSaveInstanceState(outState);
        }

        public override void SetContentView(int layoutResId)
        {
            SetContentView(LayoutInflater.Inflate(layoutResId, null));
        }

        public override void SetContentView(View view)
        {
            SetContentView(view, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent));
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            base.SetContentView(view, @params);
            _helper.RegisterAboveContentView(view, @params);
        }

        public void SetBehindContentView(View view, ViewGroup.LayoutParams layoutParams)
        {
            _helper.SetBehindContentView(view, layoutParams);
        }

        public void SetBehindContentView(View view)
        {
            SetBehindContentView(view, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 
                ViewGroup.LayoutParams.MatchParent));
        }

        public void SetBehindContentView(int layoutResId)
        {
            SetBehindContentView(LayoutInflater.Inflate(layoutResId, null));
        }

        public SlidingMenu SlidingMenu
        {
            get { return _helper.SlidingMenu; }
        }

        public void Toggle()
        {
            _helper.Toggle();
        }

        public void ShowContent()
        {
            _helper.ShowContent();
        }

        public void ShowMenu()
        {
            _helper.ShowMenu();
        }

        public void ShowSecondaryMenu()
        {
            _helper.ShowSecondaryMenu();
        }

        public void SetSlidingActionBarEnabled(bool enabled)
        {
            _helper.SlidingActionBarEnabled = enabled;
        }

        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            var b = _helper.OnKeyUp(keyCode, e);
		    return b ? b : base.OnKeyUp(keyCode, e);
        }
    }
}