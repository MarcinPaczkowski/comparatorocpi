using System;
using ComparatorOCPI.Models;

namespace ComparatorOCPI.Services
{
    internal class XmlTranslatorService
    {
        internal SerializedXml TranslationOperation(string line, SerializedXml serializedXml)
        {
            if (line.Contains("<ns6:tstore>"))
                serializedXml.DateTime = GetDateTime(line);
            else if (line.Contains("TransactionType"))
                serializedXml.IsTransactionType = true;
            else if (line.Contains(":Name>"))
                serializedXml.Name = GetName(line);
            else if (line.Contains(":RecordType>"))
                serializedXml.RecordType = GetRecordType(line);
            else if (line.Contains(":SenderPdm>"))
                serializedXml.SenderPdm = GetSenderPdm(line);
            else if (line.Contains(":TracerPdm>"))
                serializedXml.TracerPdm = GetTracerPdm(line);
            else if (line.Contains(":PaymentType>"))
                serializedXml.PaymentType = GetPaymentType(line);
            else if (line.Contains(":Amount>"))
                serializedXml.Amount = GetAmount(line);
            else if (line.Contains(":Number>"))
                serializedXml.Number = GetNumber(line);
            return serializedXml;
        }

        private static string GetNumber(string numberLine)
        {
            try
            {
                numberLine = Between(numberLine, ":Number>", "</ns").Trim();
            }
            catch
            {
                numberLine = "ERROR";
            }
            return numberLine;
        }

        private static string GetAmount(string amountLine)
        {
            try
            {
                amountLine = Between(amountLine, ":Amount>", "</ns").Trim();
            }
            catch
            {
                amountLine = "ERROR";
            }
            return amountLine;
        }

        private static string GetDateTime(string fullDateLine)
        {
            try
            {
                fullDateLine = Between(fullDateLine, ":tstore>", "</ns").Trim();
            }
            catch
            {
                fullDateLine = "ERROR";
            }
            return fullDateLine;
        }

        private static string GetName(string nameLine)
        {
            try
            {
                nameLine = Between(nameLine, ":Name>", "</ns").Trim();
            }
            catch
            {
                nameLine = "ERROR";
            }
            return nameLine;
        }

        private static string GetRecordType(string recordTypeLine)
        {
            try
            {
                recordTypeLine = Between(recordTypeLine, ":RecordType>", "</ns").Trim();
            }
            catch
            {
                recordTypeLine = "ERROR";
            }
            return recordTypeLine;
        }

        private static string GetSenderPdm(string senderPdmLine)
        {
            try
            {
                senderPdmLine = Between(senderPdmLine, ":SenderPdm>", "</ns").Trim();
            }
            catch
            {
                senderPdmLine = "ERROR";
            }
            return senderPdmLine;
        }

        private static string GetTracerPdm(string tracerPdmLine)
        {
            try
            {
                tracerPdmLine = Between(tracerPdmLine, ":TracerPdm>", "</ns").Trim();
            }
            catch
            {
                tracerPdmLine = "ERROR";
            }
            return tracerPdmLine;
        }

        private static string GetPaymentType(string paymentTypeLine)
        {
            try
            {
                paymentTypeLine = Between(paymentTypeLine, ":PaymentType>", "</ns").Trim();
            }
            catch
            {
                paymentTypeLine = "ERROR";
            }
            return paymentTypeLine;
        }

        public static string Between(string value, string a, string b)
        {
            var posA = value.IndexOf(a, StringComparison.Ordinal);
            var posB = value.LastIndexOf(b, StringComparison.Ordinal);
            if (posA == -1)
                return "";
            if (posB == -1)
                return "";
            var adjustedPosA = posA + a.Length;
            return adjustedPosA >= posB ? "" : value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}