using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CORNDataAccessLayer.Classes;
using CORNCommon.Classes;
using CORNDatabaseLayer.Classes;

namespace CORNBusinessLayer.Classes
{
    public class SupplierController
    {
        public bool InsertVendorOpening(int p_DISTRIBUTOR_ID, int p_TYPE_ID, int p_AMOUNT, DateTime p_OPENING_DATE, int p_SupplierID, int p_UserId)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
               

                #region Account Posting

                LedgerController LController = new LedgerController();
                Configuration.GetAccountHead();


                string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, 1);

                Configuration.GetAccountHead();

                if (p_TYPE_ID == 0)
                {
                    LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), 97, p_DISTRIBUTOR_ID, 0, p_AMOUNT, p_OPENING_DATE, null,System.DateTime.Now , p_SupplierID, 0,0, "opng", 15, p_UserId, mTransaction, mConnection, Constants.CreditSale, "Credit");
                    LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.PayableAccount), p_DISTRIBUTOR_ID, p_AMOUNT, 0, p_OPENING_DATE, null, System.DateTime.Now, p_SupplierID, 0, 0, "opng", 15, p_UserId, mTransaction, mConnection, Constants.CreditSale, "Credit");
                }
                else
                {
                    LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), 97, p_DISTRIBUTOR_ID, p_AMOUNT, 0, p_OPENING_DATE, null, System.DateTime.Now, p_SupplierID, 0, 0, "opng", 15, p_UserId, mTransaction, mConnection, Constants.CreditSale, "Debit");
                    LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.PayableAccount), p_DISTRIBUTOR_ID, 0, p_AMOUNT, p_OPENING_DATE, null, System.DateTime.Now, p_SupplierID, 0, 0, "opng", 15, p_UserId, mTransaction, mConnection, Constants.CreditSale, "Debit");
                }
                #endregion

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }


        public void InsertVendorLedger(long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, int p_PRINCIPAL_ID, long p_DOCUMENT_NO, int p_DOCUMENT_TYPE_ID, int p_UserId, IDbTransaction mTransaction, IDbConnection mConnection, int p_Paymode)
        {

            try
            {
                uspInsertVendorLedger mspInsertLedger = new uspInsertVendorLedger();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.Transaction = mTransaction;
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.VENDOR_LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID;
                mspInsertLedger.DOCUMENT_NO = p_DOCUMENT_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.PAYMENT_MODE = p_Paymode;
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public void DeleteVendorLedger(int p_principaID)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspDeleteVendorLedger mspDeleteLedger = new uspDeleteVendorLedger();
                mspDeleteLedger.Connection = mConnection;
                mspDeleteLedger.Transaction = mTransaction;


                mspDeleteLedger.PRINCIPAL_ID = p_principaID;
                mspDeleteLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }
        }
    }
}
