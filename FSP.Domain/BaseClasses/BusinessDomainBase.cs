using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;

namespace FSP.Domain.BaseClasses
{
    public abstract class BusinessDomainBase<T> : NoneDBDomainBase where T : BaseClass
    {
        public BusinessDomainBase(int userID, LanguagesEnum language)
            : base(userID, language)
        {
        }

        #region Member Variables

        private RepositoryBaseClass<T> dbRepository;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the dbRepository.
        /// </summary>
        /// <value>The dbRepository.</value>
        public RepositoryBaseClass<T> DBRepository
        {
            set { dbRepository = value; }
            get { return dbRepository; }
        }

        #endregion

        #region Data Accesss Methods

        public abstract void Add(T entity);

        public abstract void Delete(T entity);

        public abstract void Update(T entity);

        public abstract T FindByID(int entityID);

        public abstract List<T> FindAll();

        public abstract bool IsExist(T entity);

        #endregion
    } // End of the class
}
