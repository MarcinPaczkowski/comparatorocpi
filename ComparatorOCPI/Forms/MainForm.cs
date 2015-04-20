using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComparatorOCPI.Models;
using ComparatorOCPI.Services;

namespace ComparatorOCPI.Forms
{
    public partial class MainForm : Form
    {
        private readonly XmlTranslatorService _xmlTranslatorService;
        private readonly CsvTranslatorService _csvTranslatorService;
        private readonly FileComparatorService _fileComparatorService;
        private readonly List<SerializedXml> _serializedXmls;
        private readonly List<SerializedCsv> _serializedCsvs; 

        public MainForm()
        {
            InitializeComponent();
            _xmlTranslatorService = new XmlTranslatorService();
            _csvTranslatorService = new CsvTranslatorService();
            _fileComparatorService = new FileComparatorService();
            _serializedXmls = new List<SerializedXml>();
            _serializedCsvs = new List<SerializedCsv>();
        }

        private void uxGetCsvFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxCsvOpenFile.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = uxCsvOpenFile.FileName;
                using (var sr = new StreamReader(filePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("Tracer PDM"))
                            continue;
                        var serializedCsv = _csvTranslatorService.TranslationOperation(line);
                        _serializedCsvs.Add(serializedCsv);
                    }
                }
                MessageBox.Show(@"Zakończono operację wczytywania danych", @"Operacja zakończona", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd w trakcie odczytu pliku csv.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxGetWiresharkFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxWiresharkOpenFile.ShowDialog() != DialogResult.OK)
                    return;

                Cursor = Cursors.WaitCursor;
                Enabled = false;
                var filePath = uxWiresharkOpenFile.FileName;

                using (var sr = new StreamReader(filePath))
                {
                    string line;
                    var isContent = false;
                    SerializedXml serializedXml = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            if (line.Contains("<ns6:ds>"))
                            {
                                isContent = true;
                                serializedXml = new SerializedXml();
                            }

                            if (isContent)
                                serializedXml = _xmlTranslatorService.TranslationOperation(line, serializedXml);

                            if (line.Contains("</ns6:ds>"))
                            {
                                isContent = false;
                                if (serializedXml != null && serializedXml.IsTransactionType)
                                    _serializedXmls.Add(serializedXml);
                                serializedXml = null;
                            }
                        }
                        catch
                        {
                            if (serializedXml != null)
                                serializedXml.IsError = true;
                        }
                    }
                }

                Cursor = Cursors.Default;
                Enabled = true;
                MessageBox.Show(@"Zakończono operację wczytywania danych.", @"Operacja zakończona", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd w trakcie odczytu pliku wireshark", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxCompareFiles_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Enabled = false;
            try
            {
                if (!_serializedCsvs.Any())
                    throw new Exception("Nie wybrano pliku csv.");
                if (!_serializedXmls.Any())
                    throw new Exception("Nie wybrano pliku wireshark.");
                _fileComparatorService.CompareFiles(_serializedXmls, _serializedCsvs);

                Enabled = true;
                Cursor = Cursors.Default;

                MessageBox.Show(@"Zakończono operację porównywania i generowania plików wynikowych.", @"Operacja zakończona", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Błąd w trakcie porównywania plików", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uxClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
