using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.CompanyAdministration
{
   public class Behaviour: BaseClass
    {
        int iD;
        string name;
        string description;
        BehaviorJudgment judgment;
        string nameEnglish;
        string descriptionEnglish;

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

        public BehaviorJudgment Judgment
        {
            get { return judgment; }
            set { judgment = value; }
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
