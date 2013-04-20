using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.Assets
{
    public class OtherLongTermAssets : BaseClass
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
        float dueAmountfromRelatedParties;

        public float DueAmountfromRelatedParties
        {
            get { return dueAmountfromRelatedParties; }
            set { dueAmountfromRelatedParties = value; }
        }
        float dueFromOtherTelecomOperatorsLT;

        public float DueFromOtherTelecomOperatorsLT
        {
            get { return dueFromOtherTelecomOperatorsLT; }
            set { dueFromOtherTelecomOperatorsLT = value; }
        }
        float notesReceivables;

        public float NotesReceivables
        {
            get { return notesReceivables; }
            set { notesReceivables = value; }
        }
        float notesReceivablesNonIslamic;

        public float NotesReceivablesNonIslamic
        {
            get { return notesReceivablesNonIslamic; }
            set { notesReceivablesNonIslamic = value; }
        }
        float prepaidExpensesLT;

        public float PrepaidExpensesLT
        {
            get { return prepaidExpensesLT; }
            set { prepaidExpensesLT = value; }
        }
        float employeesUnionLoan;

        public float EmployeesUnionLoan
        {
            get { return employeesUnionLoan; }
            set { employeesUnionLoan = value; }
        }
        float employeesUnionLoanNonIslamic;

        public float EmployeesUnionLoanNonIslamic
        {
            get { return employeesUnionLoanNonIslamic; }
            set { employeesUnionLoanNonIslamic = value; }
        }
        float incomeReceivables;

        public float IncomeReceivables
        {
            get { return incomeReceivables; }
            set { incomeReceivables = value; }
        }
        float dueFromTaxAuthority;

        public float DueFromTaxAuthority
        {
            get { return dueFromTaxAuthority; }
            set { dueFromTaxAuthority = value; }
        }
        float dueFromSisterCompaniesLT;

        public float DueFromSisterCompaniesLT
        {
            get { return dueFromSisterCompaniesLT; }
            set { dueFromSisterCompaniesLT = value; }
        }
        float dueFromSisterCompaniesLTNonIslamic;

        public float DueFromSisterCompaniesLTNonIslamic
        {
            get { return dueFromSisterCompaniesLTNonIslamic; }
            set { dueFromSisterCompaniesLTNonIslamic = value; }
        }
        Asset asset;

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }
    }
}
