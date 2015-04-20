using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ComparatorOCPI.Models;

namespace ComparatorOCPI.Services
{
    internal class FileComparatorService
    {
        internal void CompareFiles(List<SerializedXml> serializedXmls, List<SerializedCsv> serializedCsvs)
        {
            var foundDatas = new List<FullData>();
            var notFoundDatas = new List<FullData>();
            foreach (var serializedCsv in serializedCsvs)
            {
                var foundSerializedXml = serializedXmls.Find(s =>
                    (s.SenderPdm == serializedCsv.SenderPdm) && (s.TracerPdm == serializedCsv.TracerPdm));
                if (foundSerializedXml == null)
                    notFoundDatas.Add(new FullData { SerializedCsv = serializedCsv });
                else
                    foundDatas.Add(new FullData { SerializedCsv = serializedCsv, SerializedXml = foundSerializedXml });
            }

            CreateCsvFileWithFoundData(foundDatas);
            CreateCsvFileWithNotFoundData(notFoundDatas);
        }

        private static void CreateCsvFileWithFoundData(IEnumerable<FullData> foundDatas)
        {
            var filePath = GetFilePath("Found");
            CreateDirectory("OutputFiles");
            CreateFile(filePath);

            using (var streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                CreateHeaderForFound(streamWriter);
                CreateContentForFound(streamWriter, foundDatas);
            }
        }

        private static void CreateCsvFileWithNotFoundData(IEnumerable<FullData> notFoundDatas)
        {
            var filePath = GetFilePath("NotFound");
            CreateDirectory("OutputFiles");
            CreateFile(filePath);

            using (var streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                CreateHeaderForNotFound(streamWriter);
                CreateContentForNotFound(streamWriter, notFoundDatas);
            }
        }

        private static string GetFilePath(string directoryName)
        {
            return String.Format(@"OutputFiles\{0}-{1}.{2}", directoryName, DateTime.Now.ToString("yyyy-MMM-dd HH-mm-ss"), "csv");
        }

        private static void CreateDirectory(string directoryName)
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
        }

        private static void CreateFile(string filePath)
        {
            using (var newFile = File.Create(filePath))
            {
                newFile.Close();
            }
        }

        private static void CreateHeaderForFound(TextWriter textWriter)
        {
            textWriter.Write("Lp.");
            textWriter.Write(";");
            textWriter.Write("Location");
            textWriter.Write(";");
            textWriter.Write("TracerPDM");
            textWriter.Write(";");
            textWriter.Write("RecordType");
            textWriter.Write(";");
            textWriter.Write("TypeOfPayment");
            textWriter.Write(";");
            textWriter.Write("PDMSender");
            textWriter.Write(";");
            textWriter.Write("Amount");
            textWriter.Write(";");
            textWriter.Write("TicketNumber");
            textWriter.Write(";");
            textWriter.Write("Date/TimePC");
            textWriter.Write(";");
            textWriter.Write(";");
            textWriter.Write("TracerPdm");
            textWriter.Write(";");
            textWriter.Write("RecordType");
            textWriter.Write(";");
            textWriter.Write("PaymentType");
            textWriter.Write(";");
            textWriter.Write("SenderPdm");
            textWriter.Write(";");
            textWriter.Write("Amount");
            textWriter.Write(";");
            textWriter.Write("Number");
            textWriter.Write(";");
            textWriter.Write("tstore");
            textWriter.Write("\n");
        }

        private static void CreateHeaderForNotFound(TextWriter textWriter)
        {
            textWriter.Write("Lp.");
            textWriter.Write(";");
            textWriter.Write("Location");
            textWriter.Write(";");
            textWriter.Write("TracerPDM");
            textWriter.Write(";");
            textWriter.Write("RecordType");
            textWriter.Write(";");
            textWriter.Write("TypeOfPayment");
            textWriter.Write(";");
            textWriter.Write("PDMSender");
            textWriter.Write(";");
            textWriter.Write("Amount");
            textWriter.Write(";");
            textWriter.Write("TicketNumber");
            textWriter.Write(";");
            textWriter.Write("Date/TimePC");
            textWriter.Write("\n");
        }

        private static void CreateContentForFound(TextWriter textWriter, IEnumerable<FullData> foundDatas)
        {
            var counter = 1;
            foreach (var foundData in foundDatas)
            {
                textWriter.Write(counter);
                CreateRowForCsvData(textWriter, foundData.SerializedCsv);
                CreateRowForXmlData(textWriter, foundData.SerializedXml);
                textWriter.Write("\n");

                counter++;
            }
        }

        private static void CreateContentForNotFound(TextWriter textWriter, IEnumerable<FullData> foundDatas)
        {
            var counter = 1;
            foreach (var foundData in foundDatas)
            {
                textWriter.Write(counter);
                CreateRowForCsvData(textWriter, foundData.SerializedCsv);
                textWriter.Write("\n");

                counter++;
            }
        }

        private static void CreateRowForCsvData(TextWriter textWriter, SerializedCsv serializedCsv)
        {
            textWriter.Write(";");
            textWriter.Write(serializedCsv.Location);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.TracerPdm);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.RecordType);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.TypeOfPayment);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.SenderPdm);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.Amount);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.TicketNumber);
            textWriter.Write(";");
            textWriter.Write(serializedCsv.DateTime);
            textWriter.Write(";");
        }

        private static void CreateRowForXmlData(TextWriter textWriter, SerializedXml serializedXml)
        {
            textWriter.Write(";");
            textWriter.Write(serializedXml.TracerPdm);
            textWriter.Write(";");
            textWriter.Write(serializedXml.RecordType);
            textWriter.Write(";");
            textWriter.Write(serializedXml.PaymentType);
            textWriter.Write(";");
            textWriter.Write(serializedXml.SenderPdm);
            textWriter.Write(";");
            textWriter.Write(serializedXml.Amount);
            textWriter.Write(";");
            textWriter.Write(serializedXml.Number);
            textWriter.Write(";");
            textWriter.Write(serializedXml.DateTime);
        }
    }
}
