using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Enums
{
    public enum ActionStatusEnum
    {
        /// <summary>
        /// NO Error
        /// </summary>

        NoError = 0,

        /// <summary>
        /// Error thrown by an Exceptin
        /// </summary>

        Exception = -1,

        /// <summary>
        /// Error if Record is already created 
        /// </summary>

        DuplicateID = -2,

        /// <summary>
        /// Cannot delete this Item
        /// </summary>

        CannotDelete = -3,

        /// <summary>
        /// Item not found
        /// </summary>

        NotFound = -4,

        /// <summary>
        ///  Cannot insert this Item
        /// </summary>

        CannotInsert = -5,

        /// <summary>
        ///  Cannot update this Item

        CannotUpdate = -6,

        /// <summary>
        /// The value cannot be empty or null
        /// </summary>

        CannotBeEmptyOrNull = -7,

        /// <summary>
        /// Cannot check the DataBase value
        /// </summary>

        CannotCheck = -8,

        FaildLogin = -9,
        IsExist = -10
    }
}
