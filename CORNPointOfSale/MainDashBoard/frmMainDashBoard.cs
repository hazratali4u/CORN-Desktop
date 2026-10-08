using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraBars.Ribbon;

using DevExpress.DashboardWin;
using CornPointHelper;

namespace CORNPointOfSale
{
    public partial class frmMainDashBoard : RibbonForm
    {
        DataSet objDsMenu = null, objDsDashboard = null;
        DataSource objDataSource = null;
        Int32 intMenuCode = 150;

        String strdashboardFilePath = Application.StartupPath + "Dashboard.xml";
        bool bolIsDesignerAllowed=true, bolIsAdminUser=true;
        String strXMLFile;
        byte[] xmlByteArray;

        public frmMainDashBoard()
        {
            InitializeComponent();
        }

        public frmMainDashBoard(Int32 intMenuCode, Boolean bolIsAdminUser)
        {
            InitializeComponent();
            this.intMenuCode = intMenuCode;
            this.bolIsAdminUser = bolIsAdminUser;
        }

        private void frmMainDashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                objDsMenu = CornPointHelper.DashboardClass.GetDashboardMenuInfo(intMenuCode);

                String[] strDashboardProcName = objDsMenu.Tables[0].Rows[0]["strDashboardProcName"].ToString().Split(',');
                String[] strDashboardNameInfo = objDsMenu.Tables[0].Rows[0]["strDashboardNameInfo"].ToString().Split(',');

                objDsDashboard = CornPointHelper.DashboardClass.GetDashboardDataSet(strDashboardProcName[0]);

                for (Int32 intCount = 0; intCount < objDsDashboard.Tables.Count; intCount++)
                {
                    objDsDashboard.Tables[intCount].TableName = strDashboardNameInfo[intCount];
                    objDataSource = new DataSource(strDashboardNameInfo[intCount], objDsDashboard.Tables[intCount]);
                    dshDesigner.Dashboard.DataSources.Add(objDataSource);
                }                              

                Dashboard dshboard = new Dashboard();
                if (objDsMenu.Tables[0].Rows[0]["vbrFile"] != null && !String.IsNullOrEmpty(Convert.ToString(objDsMenu.Tables[0].Rows[0]["vbrFile"])))
                {
                    using (Stream ms = new MemoryStream((byte[])objDsMenu.Tables[0].Rows[0]["vbrFile"]))
                    {
                        ms.Seek(0L, SeekOrigin.Begin);
                        dshboard.LoadFromXml(ms);
                        dshViewer.Dashboard = dshboard;
                        dshDesigner.Dashboard = dshboard;                        
                    }
                }

                if (bolIsDesignerAllowed == true || bolIsAdminUser == true)
                {
                    if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbViewer")
                    {                       
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                                               
                        fnDashboardControlRights(false);
                    }
                }
                else
                {
                    if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbViewer")
                    {                        
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveBarItem1.Enabled = false;                        
                        fnDashboardControlRights(false);
                    }
                }
                dshViewer.AllowPrintDashboard = true;
                dshViewer.AllowPrintDashboardItems = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }       

        private void dshDesigner_DataLoading(object sender, DataLoadingEventArgs e)
        {          
            try
            {
                e.Data = objDsDashboard.Tables[e.DataSourceName];
 //              e.Data = objDsDashboard.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        private void dshViewer_DataLoading(object sender, DataLoadingEventArgs e)
        {            
            try
            {
               e.Data = objDsDashboard.Tables[e.DataSourceName];
  //             e.Data = objDsDashboard.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dshDesigner_DashboardSaving(object sender, DevExpress.DashboardWin.DashboardSavingEventArgs e)
        {
            try
            {
                if (e.Command == DevExpress.DashboardWin.DashboardSaveCommand.Save)
                {
                    if (MessageBox.Show("Do to save changes in dashboard?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        e.Handled = true;
                        return;
                    }

                    dshDesigner.Dashboard.SaveToXml(strdashboardFilePath);

                    strXMLFile = File.ReadAllText(strdashboardFilePath);
                    xmlByteArray = System.Text.Encoding.UTF8.GetBytes(strXMLFile);

                    Int32 intCount = CornPointHelper.DashboardClass.SaveDashboardinMenu(intMenuCode, xmlByteArray);

                    e.Handled = true;
                    
                    if (intCount > 0)
                        MessageBox.Show("Dashboard saved successfully.");
                    else
                        MessageBox.Show("Dashboard not saved. ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }     

        private void xtraTabMainDashboard_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                bool isDesignAllowed = true;

                if (isDesignAllowed == true || bolIsAdminUser == true)
                {
                    if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbDesigner")
                    {
                        fileSaveBarItem1.Enabled = true;
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                                                
                        fnDashboardControlRights(true);
                    }
                    else if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbViewer")
                    {
                        if (dshViewer.Dashboard == null)
                        {
                            String dshFileName;
                            dshFileName = dshBarController.Control.DashboardFileName.ToString();
                            dshViewer.Dashboard = new Dashboard();
                            dshViewer.Dashboard.LoadFromXml(dshFileName);                            
                            dshViewer.ReloadData();
                            dshViewer.Update();
                        }
                        
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                                              
                        fnDashboardControlRights(false);
                    }
                }
                else
                {
                    if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbDesigner")
                    {                                                //fileNewBarItem1.Enabled = true;
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                                               
                        fnDashboardControlRights(true);
                    }
                    else if (xtraTabMainDashboard.SelectedTabPage.Name == "xtraTbViewer")
                    {
                        if (dshViewer.Dashboard == null)
                        {
                            String dshFileName;
                            dshFileName = dshBarController.Control.DashboardFileName.ToString();
                            dshViewer.Dashboard = new Dashboard();
                            dshViewer.Dashboard.LoadFromXml(dshFileName);                            
                            dshViewer.ReloadData();
                            dshViewer.Update();
                        }
                        
                        fileSaveBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveAsBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        fileSaveBarItem1.Enabled = false;                                                  
                        fnDashboardControlRights(false);                      
                    }

                }                              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fnDashboardControlRights(bool bolIsAllowed)
        {
            try
            {
                fileNewBarItem1.Enabled = bolIsAllowed;
                historyRibbonPageGroup1.Visible = bolIsAllowed;
                insertRibbonPageGroup1.Visible = bolIsAllowed;
                itemOperationRibbonPageGroup1.Visible = bolIsAllowed;
                dashboardDesignRibbonPageGroup1.Visible = bolIsAllowed;

                rbnPivotData.Visible = bolIsAllowed;
                rbnPivotDesign.Visible = bolIsAllowed;

                rbnGridData.Visible = bolIsAllowed;
                rbnGridDesign.Visible = bolIsAllowed;

                rbnChartData.Visible = bolIsAllowed;
                rbnChartDesign.Visible = bolIsAllowed;

                rbnPieData.Visible = bolIsAllowed;
                rbnPieDesign.Visible = bolIsAllowed;

                rbnGaugeData.Visible = bolIsAllowed;
                rbnGaugeDesign.Visible = bolIsAllowed;

                rbnCardData.Visible = bolIsAllowed;
                rbnCardDesign.Visible = bolIsAllowed;

                rbnRangeFilterData.Visible = bolIsAllowed;
                rbnRangeFilterDesign.Visible = bolIsAllowed;

                rbnChoropleMapData.Visible = bolIsAllowed;
                rbnChoropleMapDesign.Visible = bolIsAllowed;

                rbnGeoPointMapData.Visible = bolIsAllowed;
                rbnGeoPointMapDesign.Visible = bolIsAllowed;

                rbnImageData.Visible = bolIsAllowed;
                rbnImageDesign.Visible = bolIsAllowed; 
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
   }
}
