using FSP.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Common.Entites.Adoptions
{
   public class AdoptionMeta : BaseClass
    {
        int iD;
        int zakatMainID;
        int iSAdoptionNumber;
        int notAdoptionNumber;
        int lateOfAdoptionNumber;
        int violationAdoptionNumber;
        int testNumber;
        List<ISAdoption> isAdoptionList;
        List<NotAdoption> notAdoptionList;
        List<LateOfAdoption> lateOfAdoption;
        List<ViolationAdoption> violationAdoptionList;
        List<Test> testList;

        public List<Test> TestList
        {
            get { return testList; }
            set { testList = value; }
        }

        public List<ViolationAdoption> ViolationAdoptionList
        {
            get { return violationAdoptionList; }
            set { violationAdoptionList = value; }
        }

        public List<LateOfAdoption> LateOfAdoption
        {
            get { return lateOfAdoption; }
            set { lateOfAdoption = value; }
        }

        public List<NotAdoption> NotAdoptionList
        {
            get { return notAdoptionList; }
            set { notAdoptionList = value; }
        }

        public List<ISAdoption> IsAdoptionList
        {
            get { return isAdoptionList; }
            set { isAdoptionList = value; }
        }

        public int TestNumber
        {
            get { return testNumber; }
            set { testNumber = value; }
        }

        public int ViolationAdoptionNumber
        {
            get { return violationAdoptionNumber; }
            set { violationAdoptionNumber = value; }
        }

        public int LateOfAdoptionNumber
        {
            get { return lateOfAdoptionNumber; }
            set { lateOfAdoptionNumber = value; }
        }

        public int NotAdoptionNumber
        {
            get { return notAdoptionNumber; }
            set { notAdoptionNumber = value; }
        }

        public int ISAdoptionNumber
        {
            get { return iSAdoptionNumber; }
            set { iSAdoptionNumber = value; }
        }

        public int ZakatMainID
        {
            get { return zakatMainID; }
            set { zakatMainID = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
