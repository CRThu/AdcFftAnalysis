using CommandLine;
using MeasureApp.Model.FftAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdcFftAnalysis
{
    public class CommandLineOptions
    {
        // ------------------------- LoadFileConfigs -------------------------
        [Option('f', "DataFileName", Group = "文件设置", Required = true, HelpText = "数据文件路径")]
        public string DataFileName { get; set; }

        [Option("ReportFileName", Group = "文件设置", Default = null, HelpText = "报告文件路径,未指定则默认文件后加入.Report.txt")]
        public string? ReportFileName { get; set; }

        [Option("ResultFileName", Group = "文件设置", Default = null, HelpText = "分析数据文件路径,未指定则默认文件后加入.Result.txt")]
        public string? ResultFileName { get; set; }

        // ------------------------- FftAnalysisPropertyConfigs -------------------------

        [Option("FromBase", Group = "样本设置", Default = 16, HelpText = "数据进制")]
        public int FromBase { get; set; }

        [Option("Bits", Group = "样本设置", Default = 16, HelpText = "字长(Bits)")]
        public int Bits { get; set; }

        [Option("VBias", Group = "样本设置", Default = 0, HelpText = "偏置电压")]
        public double VBias { get; set; }

        [Option("HasCodeOffset", Group = "样本设置", Default = true, HelpText = "是否偏移中间码字")]
        public bool HasCodeOffset { get; set; }

        [Option("IsAveragedFft", Group = "切片设置", Default = false, HelpText = "使用平均FFT(Alpha)")]
        public bool IsAveragedFft { get; set; }

        [Option("AveragedFftLength", Group = "切片设置", Default = 16384, HelpText = "平均FFT点数")]
        public int AveragedFftLength { get; set; }

        [Option("AveragedFftOverlap", Group = "切片设置", Default = 0.9, HelpText = "平均FFT重叠率")]
        public double AveragedFftOverlap { get; set; }

        [Option("Mode", Group = "基础设置", Default = "EnergyCorrection", HelpText = "分析模式")]
        public string Mode { get; set; }

        [Option("Fs", Group = "基础设置", Default = 200000, HelpText = "采样率")]
        public double Fs { get; set; }

        [Option("FftN", Group = "基础设置", Default = 32768, HelpText = "采样点数(需为2^N)")]
        public int FftN { get; set; }

        [Option("Window", Group = "基础设置", Default = "HFT144D", HelpText = "窗函数")]
        public string Window { get; set; }

        [Option("NHarmonic", Group = "基础设置", Default = 5, HelpText = "谐波最大测量阶数")]
        public int NHarmonic { get; set; }

        [Option("FullScale", Group = "基础设置", Default = 10, HelpText = "满幅电平(正负轨电压差)")]
        public double FullScale { get; set; }

        [Option("SpanSignalEnergy", Group = "信号设置", Default = 6, HelpText = "单边信号能量测量跨度")]
        public int SpanSignalEnergy { get; set; }

        [Option("SpanHarmonicPeak", Group = "信号设置", Default = 3, HelpText = "单边谐波峰值测量跨度")]
        public int SpanHarmonicPeak { get; set; }

        [Option("SpanHarmonicEnergy", Group = "信号设置", Default = 6, HelpText = "单边谐波能量测量跨度")]
        public int SpanHarmonicEnergy { get; set; }

        [Option("IsNoiseCorrection", Group = "噪声设置", Default = false, HelpText = "噪声补偿")]
        public bool IsNoiseCorrection { get; set; }

        [Option("IsTestCosineWave", Group = "基准测试", Default = false, HelpText = "基准波形自测试")]
        public bool IsTestCosineWave { get; set; }

        [Option("TestCosineWaveFreq", Group = "基准测试", Default = 1000, HelpText = "基准波形频率")]
        public double TestCosineWaveFreq { get; set; }

        [Option("TestCosineWaveSnr", Group = "基准测试", Default = null, HelpText = "基准波形信噪比")]
        public double? TestCosineWaveSnr { get; set; }

        public FftAnalysisPropertyConfigs ToFftAnalysisPropertyConfigs()
        {
            return new()
            {
                FromBase = FromBase,
                Bits = Bits,
                VBias = VBias,
                HasCodeOffset = HasCodeOffset,
                IsAveragedFft = IsAveragedFft,
                AveragedFftLength = AveragedFftLength,
                AveragedFftOverlap = AveragedFftOverlap,
                Mode = Mode,
                Fs = Fs,
                FftN = FftN,
                Window = Window,
                NHarmonic = NHarmonic,
                IsSampling = false,
                AutoSamplingOnDataLength = 65536,
                SpanSignalEnergy = SpanSignalEnergy,
                SpanHarmonicPeak = SpanHarmonicPeak,
                SpanHarmonicEnergy = SpanHarmonicEnergy,
                FullScale = FullScale,
                IsNoiseCorrection = IsNoiseCorrection,
                IsTestCosineWave = IsTestCosineWave,
                TestCosineWaveFreq = TestCosineWaveFreq,
                TestCosineWaveSnr = TestCosineWaveSnr
            };
        }
    }
}
