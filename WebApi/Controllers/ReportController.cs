using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReportController : Controller
    {
        private ReportDataSet _ds;
        public int _patientVisitId;

        // GET: Report
        public ActionResult Soap(int id)
        {
            _patientVisitId = id;
            _ds = new ReportDataSet();
            ReportDataSet ds = new ReportDataSet();
            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";
            rds.Value = ds.getPatientVisit(id);

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

            //var report = new SoapReportGenerator(id);
            //streamBytes = report.GenerateReportStream(Server.MapPath("~/Reports/RDLC/SoapReport.rdlc"), out mimeType);
            return File(streamBytes, mimeType, "SoapReport.pdf");
        }

        private void SubreportProcessingHandler(object sender, SubreportProcessingEventArgs e)
        {
            var ds = new ReportDataSet();
            var rds = new ReportDataSource();
            var rds2 = new ReportDataSource();

            rds.Name = "DataSet1";
            rds2.Name = "DateSet2";

            switch (e.ReportPath)
            {
                case "AncillaryProcedureReport":
                    rds.Value = _ds.getAncillaryProcedures(_patientVisitId);
                    rds2.Value = _ds.getDummydata();

                    e.DataSources.Add(rds);
                    e.DataSources.Add(rds2);
                    break;
            }
        }

        //void SubreportProcessingHandler(object sender, SubreportProcessingEventArgs e)
        //{
        //    var ds = new ReportDataSet();
        //    var rds = new ReportDataSource();
        //    var rds2 = new ReportDataSource();

        //    rds.Name = "DataSet1";
        //    rds.Name = "DataSet2";
            
        //    switch (e.ReportPath)
        //    {
        //        case "AncillaryProcedureReport":
        //            rds.Value = ds.getAncillaryProcedures();
        //            rds2.Value = ds.getDummydata();
        //            e.DataSources.Add(rds2);
        //            e.DataSources.Add(rds);
        //            break;
        //    }
        //}
    }
}