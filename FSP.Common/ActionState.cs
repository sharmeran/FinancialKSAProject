﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Enums;
using FSP.Common.Utilities;

namespace FSP.Common
{
    public class ActionState
    {
        #region Private Data
        private ActionStatusEnum status;
        private string result;
        private int ownerID;
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>

        public ActionStatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }


        /// <summary>
        /// In case of errors the ActionResult is filled with the error message
        /// </summary>

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        /// <summary>
        /// User of this action
        /// </summary>

        public int OwnerID
        {
            get
            {
                return ownerID;
            }
            set
            {
                ownerID = value;
            }
        }
        #endregion

        public void SetSuccess()
        {
            status = ActionStatusEnum.NoError;
            result = string.Empty;
        }

        public void SetFail(ActionStatusEnum errCode, string errorMessage)
        {
            this.status = errCode;
            result = errorMessage;
            this.logErrorMessage(errorMessage);
        }

        public override string ToString()
        {
            return string.Format("Action Owner ID = '{0}' Status = '{1}' ErrMsg = '{2}'", ownerID, status.ToString(), string.Empty);// result);
        }

        private void logErrorMessage(string errorMessage)
        {
            // Declaration 
            LoggingUtil logger;

            // Initialization
            logger = new LoggingUtil();

            // Implementation 
            result = errorMessage;
            logger.LogMessage(errorMessage, LogLevelEnum.Error);
            logger = null;
        }
    }
}
