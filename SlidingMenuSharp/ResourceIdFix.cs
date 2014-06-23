/* 
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

using System;
using System.Linq;
using System.Reflection;
using Android.Runtime;

namespace SlidingMenuSharp
{
    public static class ResourceIdManager
    {
        static bool _idInitialized;
        public static void UpdateIdValues()
        {
            if (_idInitialized)
                return;
            var eass = Assembly.GetExecutingAssembly();
            Func<Assembly, Type> f = ass =>
                ass.GetCustomAttributes(typeof(ResourceDesignerAttribute), true)
                    .Select(ca => ca as ResourceDesignerAttribute)
                    .Where(ca => ca != null && ca.IsApplication)
                    .Select(ca => ass.GetType(ca.FullName))
                    .Where(ty => ty != null)
                    .FirstOrDefault();
            var t = f(eass);
            if (t == null)
                t = AppDomain.CurrentDomain.GetAssemblies().Select(ass => f(ass)).Where(ty => ty != null).FirstOrDefault();
            if (t != null)
                t.GetMethod("UpdateIdValues").Invoke(null, new object[0]);
            _idInitialized = true;
        }
    }
}