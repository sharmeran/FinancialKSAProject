using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Enums
{
    public enum LoginEnum
    {
        SuccessfulLogin = 1,
        WrongUsernameAndPassword,
        AccountLocked,
        AccounExpired
    }
}
