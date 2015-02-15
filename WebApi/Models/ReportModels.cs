using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL;

namespace WebApi.Models
{
    public class ReportDataSet
    {
        public List<PatientVisit> getPatientVisit(int id)
        {
            List<PatientVisit> _retval = new List<PatientVisit>();

            using (WebApiDbContext ctx = new WebApiDbContext())
            {
                _retval = ctx.PatientVisits.Where(x => x.PatientVisitId == id).ToList();
            }

            return _retval;
        }

        public List<AncillaryProcedure> getAncillaryProcedures()
        {
            List<AncillaryProcedure> _retval = new List<AncillaryProcedure>();

            using (WebApiDbContext ctx = new WebApiDbContext())
            {
                //_retval = ctx.AncillaryProcedures.Where(x=>x.PatientVisitId==id).ToList();
                _retval = ctx.AncillaryProcedures.ToList();
            }

            return _retval;
        }

        public List<AncillaryProcedure> getAncillaryProcedures(int id)
        {
            List<AncillaryProcedure> _retval = new List<AncillaryProcedure>();

            using (WebApiDbContext ctx = new WebApiDbContext())
            {
                //_retval = ctx.AncillaryProcedures.Where(x=>x.PatientVisitId==id).ToList();
                _retval = ctx.AncillaryProcedures.Where(x => x.PatientVisitId == id).ToList();
            }

            return _retval;
        }

        public List<DummyString> getDummydata()
        {
            return new List<DummyString> { new DummyString { Data = " " } };
        }
    }

    public class SoapReportGenerator
    {
        private ReportDataSet _ds;
        public int _patientVisitId;

        public SoapReportGenerator(int patientVisitId)
        {
            this._ds = new ReportDataSet();
            this._patientVisitId = patientVisitId;
        }

        public byte[] GenerateReportStream(string ReportPath, out string mimeType){
            ReportDataSet ds = new ReportDataSet();
            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";
            rds.Value = ds.getPatientVisit(_patientVisitId);

            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingHandler);
            rv.LocalReport.ReportPath = ReportPath;

            // Add the new report datasource to the report.
            rv.LocalReport.DataSources.Add(rds);

            rv.LocalReport.Refresh();

            byte[] streamBytes = null;
            //string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;

            streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            
            return streamBytes;
        }

        private void SubreportProcessingHandler(object sender, SubreportProcessingEventArgs e)
        {
            var ds = new ReportDataSet();
            var rds = new ReportDataSource();
            var rds2 = new ReportDataSource();
            ReportParameter p = new ReportParameter();
            List<ReportParameter> parameters = new List<ReportParameter>();

            rds.Name = "DataSet1";
            rds.Name = "DataSet2";

            switch (e.ReportPath)
            {
                case "AncillaryProcedureReport":
                    rds.Value = _ds.getAncillaryProcedures();
                    //p.Name = "PatientVisitId";
                    //p.Values.Add(_patientVisitId.ToString());
                    //parameters.Add(p);
                    //rds2.Value = ds.getDummydata();
                    var param = e.Parameters.Where(x=>x.Name=="PatientVisitId").FirstOrDefault();
                    param.Values.Add(_patientVisitId.ToString());
                    //e.DataSources.Add(rds2);
                    e.DataSources.Add(rds);
                    break;
            }
        }
    }

    public class DummyString
    {
        public string Data { get; set; }
    }
}
