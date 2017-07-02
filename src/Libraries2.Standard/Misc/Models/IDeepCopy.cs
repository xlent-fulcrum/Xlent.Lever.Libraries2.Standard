﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xlent.Lever.Libraries2.Standard.Misc.Models
{
    /// <summary>
    /// Copy an object with deep copying
    /// </summary>
    public interface IDeepCopy<out T>
    {
        /// <summary>
        /// Return a new copy.
        /// </summary>
        /// <returns></returns>
        T DeepCopy();
    }
}
