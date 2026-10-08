using System;
using Microsoft.Win32;

namespace CORNCommon.Classes
{
    public class LiveConfiguration
    {
        #region Constructors
        public LiveConfiguration()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        private static string mConnectionString;
        private static string mstrAppPath;
        private static string mstrDatabaseServer;
        private static string mstrDatabaseName;
        private static string mstrServerUserName;
        private static string mstrServerUserPswd;

        #endregion

        #region public Property
        public static string ConnectionString
        {
            get
            {
                if (mConnectionString == null || mConnectionString == "")
                {
                    GetAppConfiguration();

                    mConnectionString = " Persist Security Info=False; ";
                    mConnectionString += " User ID=" + mstrServerUserName + ";Password=" + Cryptography.Decrypt(mstrServerUserPswd, Constants.CryptographyKey) + ";";

                    //if (mQueryTimeOut != "")
                    //{
                    //    mConnectionString += " Connection Timeout = " + QueryTimeOut + "; ";
                    //    mConnectionString += " Connection Lifetime = " + QueryTimeOut + "; ";
                    //}
                    //common settings

                    mConnectionString += " Initial Catalog = " + mstrDatabaseName + "; ";
                    mConnectionString += " Data Source= " + mstrDatabaseServer + " ";
                }
                return mConnectionString;
            }
        }

        #endregion
        #region public static Methods


        static public void GetAppConfiguration()
        {
            string mstrAppPath = Configuration.GetAppInstallationPath();
            Encryption obEncDecrypt = new Encryption();
            XmlUtil NewSetting = new XmlUtil(mstrAppPath + @"Settings\AppSettings.xml");

            mstrDatabaseServer = NewSetting.GetNode("svr");
            mstrDatabaseName = NewSetting.GetNode("svrdb");

            mstrServerUserName = NewSetting.GetNode("usr");
            mstrServerUserPswd = NewSetting.GetNode("pwd");

            NewSetting.CloseDocument();

            NewSetting = null;

        }

        #endregion

    }
}
