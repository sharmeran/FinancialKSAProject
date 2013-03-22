using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.CompanyAdministration
{
   public class BehaviorJudgment:BaseClass
    {
        int iD;
        string name;
        string description;
        string nameEnglish;
        string descriptionEnglish;
        int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string DescriptionEnglish
        {
            get { return descriptionEnglish; }
            set { descriptionEnglish = value; }
        }

        public string NameEnglish
        {
            get { return nameEnglish; }
            set { nameEnglish = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
