using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class OtherLongTermLiabilities : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int assetsID;

        public int AssetsID
        {
            get { return assetsID; }
            set { assetsID = value; }
        }
        float otherLongTermLiabilitiesIslamic;

        public float OtherLongTermLiabilitiesIslamic
        {
            get { return otherLongTermLiabilitiesIslamic; }
            set { otherLongTermLiabilitiesIslamic = value; }
        }
        float otherLongTermLiabilitiesNonIslamic;

        public float OtherLongTermLiabilitiesNonIslamic
        {
            get { return otherLongTermLiabilitiesNonIslamic; }
            set { otherLongTermLiabilitiesNonIslamic = value; }
        }
        float totalLongTermLiabilities;

        public float TotalLongTermLiabilities
        {
            get { return totalLongTermLiabilities; }
            set { totalLongTermLiabilities = value; }
        }
        float totalLiabilities;

        public float TotalLiabilities
        {
            get { return totalLiabilities; }
            set { totalLiabilities = value; }
        }
        float totalProvisions;

        public float TotalProvisions
        {
            get { return totalProvisions; }
            set { totalProvisions = value; }
        }
        float taxProvisions;

        public float TaxProvisions
        {
            get { return taxProvisions; }
            set { taxProvisions = value; }
        }
        float deferredTaxIncome;

        public float DeferredTaxIncome
        {
            get { return deferredTaxIncome; }
            set { deferredTaxIncome = value; }
        }
        float deferredIncome;

        public float DeferredIncome
        {
            get { return deferredIncome; }
            set { deferredIncome = value; }
        }
        float provisionForEmployeesTermInationbenefits;

        public float ProvisionForEmployeesTermInationbenefits
        {
            get { return provisionForEmployeesTermInationbenefits; }
            set { provisionForEmployeesTermInationbenefits = value; }
        }
        float warrantiesAndOptions;

        public float WarrantiesAndOptions
        {
            get { return warrantiesAndOptions; }
            set { warrantiesAndOptions = value; }
        }
        float warrantiesAndOptionsNonIslamic;

        public float WarrantiesAndOptionsNonIslamic
        {
            get { return warrantiesAndOptionsNonIslamic; }
            set { warrantiesAndOptionsNonIslamic = value; }
        }
        float otherProvisions;

        public float OtherProvisions
        {
            get { return otherProvisions; }
            set { otherProvisions = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
