using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common;
using FSP.Common.BaseClasses;
using FSP.Common.Enums;
using FSP.Common.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FSP.DataAccess.BaseClasses
{
    public abstract class RepositoryBaseClass<T> where T : BaseClass
    {
        protected Database database;
        protected LanguagesEnum language;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase&lt;T&gt;"/> class.
        /// </summary>
        protected RepositoryBaseClass()
        {
            database = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        protected void LogException(Exception exception)
        {
            LoggingUtil logger = new LoggingUtil();
            logger.LogException(exception);
            logger = null;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userID">Id of the who will delete this entity</param>
        /// <param name="actionState">Return result which contains the error massage</param>
        public abstract void Delete(T entity, ActionState actionState);

        /// <summary>
        /// Finds the by ID.
        /// </summary>
        /// <param name="resourceMessageEntityID">The entity ID.</param>
        /// <param name="actionState">Return result which contains the error massage</param>
        /// <returns>The founded entity</returns>
        public abstract T FindByID(int entityID, ActionState actionState);

        /// <summary>
        /// Inserts the specified activeSession entity.
        /// </summary>
        /// <param name="userEntity">The activeSession entity.</param>
        /// <param name="userID">Id of the who will create this record</param>
        /// <param name="actionState">Return result which contains the error massage</param>
        public abstract void Insert(T entity, ActionState actionState);

        /// <summary>
        /// Updates the specified activeSession entity.
        /// </summary>
        /// <param name="entity">The activeSession entity.</param>
        /// <param name="userID">Id os the user who update this entity</param>
        /// <param name="actionState">Return result which contains the error massage</param>
        public abstract void Update(T entity, ActionState actionState);

        /// <summary>
        /// Determines whether the specified entity is exist.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// 	<c>true</c> if the specified entity is exist; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsExist(T entity, ActionState actionState);

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns>list of entities of type T</returns>
        public abstract List<T> FindAll(ActionState actionState);
    }
}
