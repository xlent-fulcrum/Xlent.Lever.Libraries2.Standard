﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xlent.Lever.Libraries2.Standard.Storage
{
    /// <summary>
    /// Properties for a data "row" that has timestamps for creation and updates.
    /// </summary>
    public interface ITimeStamped
    {
        /// <summary>
        /// The time when a "row" was created.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The time when a "row" was last updated.
        /// </summary>
        DateTimeOffset UpdatedAt { get; set; }
    }
}
