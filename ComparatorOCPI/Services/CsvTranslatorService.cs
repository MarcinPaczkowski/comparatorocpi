using ComparatorOCPI.Models;

namespace ComparatorOCPI.Services
{
    internal class CsvTranslatorService
    {
        internal SerializedCsv TranslationOperation(string line)
        {
            var splittedCsvLine = line.Split(';');
            var serializedCsv = new SerializedCsv
            {
                TracerPdm = splittedCsvLine[0].Replace("\"", ""),
                RecordType = splittedCsvLine[1].Replace("\"", ""),
                TypeOfPayment = splittedCsvLine[2].Replace("\"", ""),
                Location = splittedCsvLine[4].Replace("\"", ""),
                SenderPdm = splittedCsvLine[7].Replace("\"", ""),
                Amount = splittedCsvLine[13].Replace("\"", ""),
                TicketNumber = splittedCsvLine[17].Replace("\"", ""),
                DateTime = splittedCsvLine[19].Replace("\"", "")
            };

            return serializedCsv;
        }
    }
}