using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.DAL;
using WebApi.DataSet;
using WebApi.DataSet.SoapDataSetTableAdapters;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReportController : Controller
    {
        public int _patientVisitId;
        private SoapDataSet _soapDs = new SoapDataSet();
        private PatientVisitsTableAdapter _patientVisitTable = new PatientVisitsTableAdapter();
        private AncillaryProceduresTableAdapter _ancillaryTable = new AncillaryProceduresTableAdapter();
        private DrugHistoriesTableAdapter _drugTable = new DrugHistoriesTableAdapter();

        // GET: Report
        public ActionResult Soap(int id)
        {
            try
            {
                _patientVisitId = id;
                _patientVisitTable.Fill(_soapDs.PatientVisits, id);
                _ancillaryTable.Fill(_soapDs.AncillaryProcedures, id);
                _drugTable.Fill(_soapDs.DrugHistories, id);

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "SoapDS";
                rds.Value = _soapDs.PatientVisits;

                ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();
                rv.ProcessingMode = ProcessingMode.Local;
                rv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingHandler);
                rv.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/SoapReport.rdlc");

                // Add the new report datasource to the report.
                rv.LocalReport.DataSources.Add(rds);
                rv.LocalReport.Refresh();

                byte[] streamBytes = null;
                string mimeType = "";
                string encoding = "";
                string filenameExtension = "";
                string[] streamids = null;
                Warning[] warnings = null;

                streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                return File(streamBytes, mimeType, "SoapReport.pdf");
            }
            catch(Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
        }

        private void SubreportProcessingHandler(object sender, SubreportProcessingEventArgs e)
        {
            var rds = new ReportDataSource();
            rds.Name = "DataSet1";

            switch (e.ReportPath)
            {
                case "AncillaryProcedureReport":
                    if (_soapDs.AncillaryProcedures.Count > 0)
                        rds.Value = _soapDs.AncillaryProcedures;
                    else
                        rds.Value = new List<object>() { new { ProcedureName = "No record.", ProcedureDate = new DateTime(1,1,1) } };
                    e.DataSources.Add(rds);
                    break;
                case "DrugReport":
                    if (_soapDs.DrugHistories.Count > 0)
                        rds.Value = _soapDs.DrugHistories;
                    else
                        rds.Value = new List<object>() { new { DrugName = "No record.", DrugDate = new DateTime(1,1,1) } };
                    e.DataSources.Add(rds);
                    break;
            }
        }
    }
}