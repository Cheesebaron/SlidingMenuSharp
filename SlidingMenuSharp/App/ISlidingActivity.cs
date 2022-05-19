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

using Android.Views;

namespace SlidingMenuSharp.App
{
    public interface ISlidingActivity
    {
        void SetBehindContentView(View view, ViewGroup.LayoutParams layoutParams);
        void SetBehindContentView(View view);
        void SetBehindContentView(int layoutResId);
        SlidingMenu SlidingMenu { get; }
        void Toggle();
        void ShowContent();
        void ShowMenu();
        void ShowSecondaryMenu();
        void SetSlidingActionBarEnabled(bool enabled);
    }
}