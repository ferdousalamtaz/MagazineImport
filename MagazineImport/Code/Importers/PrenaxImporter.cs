using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using MagazineImport.Code.Helpers;
using MagazineImport.Code.Mapping;
using Serilog;
using SmartXLS;
using System.Configuration;

namespace MagazineImport.Code.Importers
{
    public class PrenaxImporter : BaseMultiImporter
    {
        private static string strPathUpload = ConfigurationManager.AppSettings["PrenaxUploadPath"];
        private static string strPathArchive = ConfigurationManager.AppSettings["PrenaxArchivePath"];
        public static string strFilePrefix = ConfigurationManager.AppSettings["PrenaxFilePrefix"];

        protected override bool DoImport()
        {
            var filePaths = GetFilePaths();

            if (filePaths.Count == 0)
            {
                Log.Logger?.Information("No Magazine files with prefix '{MagazineImportFilePrefix}' to import!", strFilePrefix);
                return true;
            }

            List<IMagazineMapper> offers;
            var bitReturn = true;

            //Import all files
            foreach (var strFullFileName in filePaths)
            {
                Log.Logger?.Information("File: {PrenaxImportFileName}", strFullFileName);

                //Init work book
                using (var wb = new WorkBook())
                {
                    if (strFullFileName.EndsWith(".xlsx"))
                        wb.readXLSX(strFullFileName);
                    else
                        wb.read(strFullFileName);

                    var dt = wb.ExportDataTableFullFixed(true);
                    offers = dt.AsEnumerable().Select(dr => (IMagazineMapper) new PrenaxMapper(dr, Path.GetFileName(strFullFileName), strFilePrefix)).ToList();
                }

                //Import to DB
                bitReturn = base.ImportToDatabase(offers);

                ArchiveAndLog(strFullFileName, strPathArchive);
            }

            return bitReturn;
        }

        private static List<string> GetFilePaths()
        {
            //Make sure paths exists
            if (!Directory.Exists(strPathUpload))
                Directory.CreateDirectory(strPathUpload);
            if (!Directory.Exists(strPathArchive))
                Directory.CreateDirectory(strPathArchive);

            //Get all excel files in path
            var filePaths = Directory.GetFiles(strPathUpload)
                .Where(s => (s.EndsWith(".xls") || s.EndsWith(".xlsx")) && Path.GetFileName(s).StartsWith(strFilePrefix))
                .ToList();
            return filePaths;
        }
    }


    }
