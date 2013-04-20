using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.BaseClasses;

namespace FSP.Common.Entites.Financial.CashFlow
{
    public class ReferenceItem : BaseClass
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        int cashFlowStatementID;

        public int CashFlowStatementID
        {
            get { return cashFlowStatementID; }
            set { cashFlowStatementID = value; }
        }
        float eBITDA;

        public float EBITDA
        {
            get { return eBITDA; }
            set { eBITDA = value; }
        }
        float netCashPaidForAcquisitions;

        public float NetCashPaidForAcquisitions
        {
            get { return netCashPaidForAcquisitions; }
            set { netCashPaidForAcquisitions = value; }
        }
        float freeCashFlow;

        public float FreeCashFlow
        {
            get { return freeCashFlow; }
            set { freeCashFlow = value; }
        }
        float freeCashFlowToFirm;

        public float FreeCashFlowToFirm
        {
            get { return freeCashFlowToFirm; }
            set { freeCashFlowToFirm = value; }
        }
        float freeCashFlowEquity;

        public float FreeCashFlowEquity
        {
            get { return freeCashFlowEquity; }
            set { freeCashFlowEquity = value; }
        }
        float freeCashFlowBasicShare;

        public float FreeCashFlowBasicShare
        {
            get { return freeCashFlowBasicShare; }
            set { freeCashFlowBasicShare = value; }
        }
        float priceFreeCashFlow;

        public float PriceFreeCashFlow
        {
            get { return priceFreeCashFlow; }
            set { priceFreeCashFlow = value; }
        }
        float cashFlowNetIncome;

        public float CashFlowNetIncome
        {
            get { return cashFlowNetIncome; }
            set { cashFlowNetIncome = value; }
        }
        CashFlowStatement cashFlowStatement;

        public CashFlowStatement CashFlowStatement
        {
            get { return cashFlowStatement; }
            set { cashFlowStatement = value; }
        }
    }
}
