// See https://aka.ms/new-console-template for more information
using AdcFftAnalysis;
using CommandLine;
using MeasureApp.Model.FftAnalysis;
using System.Text;

// Console.WriteLine("Hello, World!");
Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(options =>
{
    List<decimal> ChartData = new();
    string FftAnalysisSampleFileName = options.DataFileName;
    //string FftAnalysisSampleFileName = "../../../Data/AD7606_TestData_88d69.txt";
    string OutputReportFileName = options.ReportFileName ?? (FftAnalysisSampleFileName + ".Report.txt");
    string OutputDataFileName = options.ResultFileName ?? (FftAnalysisSampleFileName + ".Result.txt");
    FftAnalysisPropertyConfigs FftAnalysisPropertyConfig = options.ToFftAnalysisPropertyConfigs();
    List<FftAnalysisReport> FftAnalysisReports = new();

    double[] samples;
    if (!FftAnalysisPropertyConfig.IsTestCosineWave)
    {
        // 打开采样文件
        string[] samplesStr = File.ReadAllLines(FftAnalysisSampleFileName);
        samples = DataDecode.Decode(samplesStr, FftAnalysisPropertyConfig);
    }
    else
    {
        // 自测试
        samples = CosineWaveGen.GenWave(FftAnalysisPropertyConfig.FftN,
            FftAnalysisPropertyConfig.TestCosineWaveFreq,
            FftAnalysisPropertyConfig.Fs,
            snr: FftAnalysisPropertyConfig.TestCosineWaveSnr);
    }


    (double[] t, double[] v, double[] f, double[] p,
        Dictionary<string, (double v1, string s1)> perfInfo,
        Dictionary<string, (double v1, string s1, double v2, string s2)> sgnInfo) fftAnaylsisResult;

    // 性能计算
    if (FftAnalysisPropertyConfig.Mode == "EnergyCorrection")
        fftAnaylsisResult = DynamicPerfAnalysis.FftAnalysisEnergyCorrection(samples, FftAnalysisPropertyConfig);
    else if (FftAnalysisPropertyConfig.Mode == "AmplitudeCorrection")
        fftAnaylsisResult = DynamicPerfAnalysis.FftAnalysisAmplitudeCorrection(samples, FftAnalysisPropertyConfig);
    else
        throw new NotImplementedException(FftAnalysisPropertyConfig.Mode);

    // 生成报告
    FftAnalysisReports.Clear();
    foreach (var info in fftAnaylsisResult.perfInfo)
        FftAnalysisReports.Add(new FftAnalysisReport("性能", info.Key, $"{info.Value.v1:F3} {info.Value.s1}"));
    foreach (var info in fftAnaylsisResult.sgnInfo)
        FftAnalysisReports.Add(new FftAnalysisReport("信号", info.Key, $"{info.Value.v1:F3} {info.Value.s1}", $"{info.Value.v2:F3} {info.Value.s2}"));

    StringBuilder dataStringBuilder = new();
    dataStringBuilder.AppendLine("<FREQ/>");
    dataStringBuilder.AppendLine(string.Join('\n', fftAnaylsisResult.f));
    dataStringBuilder.AppendLine("<POWER/>");
    dataStringBuilder.AppendLine(string.Join('\n', fftAnaylsisResult.p));
    File.WriteAllText(OutputDataFileName, dataStringBuilder.ToString());

    StringBuilder reportStringBuilder = new();
    reportStringBuilder.AppendLine("<PERF/>");
    reportStringBuilder.AppendLine(string.Join('\n', FftAnalysisReports));
    File.WriteAllText(OutputReportFileName, reportStringBuilder.ToString());
});
