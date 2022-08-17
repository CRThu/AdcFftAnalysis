using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureApp.Model.FftAnalysis
{
    public class FftAnalysisPropertyConfigs
    {
        [Category("样本设置"), Description("数据进制"), DisplayName("数据进制")]
        public int FromBase { get; set; }

        [Category("样本设置"), Description("字长(Bits)"), DisplayName("字长(Bits)")]
        public int Bits { get; set; }

        [Category("样本设置"), Description("偏置电压"), DisplayName("偏置电压")]
        public double VBias { get; set; }

        [Category("样本设置"), Description("偏移零为中间码字"), DisplayName("偏移零为中间码字")]
        public bool HasCodeOffset { get; set; }

        [Category("切片设置"), Description("使用平均FFT(Alpha)"), DisplayName("使用平均FFT(Alpha)")]
        public bool IsAveragedFft { get; set; }

        [Category("切片设置"), Description("平均FFT点数"), DisplayName("平均FFT点数")]
        public int AveragedFftLength { get; set; }

        [Category("切片设置"), Description("平均FFT重叠率"), DisplayName("平均FFT重叠率")]
        public double AveragedFftOverlap { get; set; }

        [Category("基础设置"), Description("分析模式"), DisplayName("分析模式")]
        public string Mode { get; set; }

        [Category("基础设置"), Description("采样率"), DisplayName("采样率")]
        public double Fs { get; set; }

        [Category("基础设置"), Description("采样点数(需为2^N)"), DisplayName("采样点数")]
        public int FftN { get; set; }

        [Category("基础设置"), Description("窗函数"), DisplayName("窗函数")]
        public string Window { get; set; }

        [Category("基础设置"), Description("谐波最大测量阶数"), DisplayName("谐波最大测量阶数")]
        public int NHarmonic { get; set; }

        [Category("基础设置"), Description("满幅电平(正负轨电压差)"), DisplayName("满幅电平(正负轨电压差)")]
        public double FullScale { get; set; }

        [Category("渲染设置"), Description("抽样渲染(提高渲染速度)"), DisplayName("抽样渲染")]
        public bool IsSampling { get; set; }

        [Category("渲染设置"), Description("自动抽样渲染点数(提高渲染速度)"), DisplayName("自动抽样渲染点数")]
        public int AutoSamplingOnDataLength { get; set; }

        [Category("信号设置"), Description("单边信号能量测量跨度"), DisplayName("单边信号能量测量跨度")]
        public int SpanSignalEnergy { get; set; }

        [Category("信号设置"), Description("单边谐波峰值测量跨度"), DisplayName("单边谐波峰值测量跨度")]
        public int SpanHarmonicPeak { get; set; }

        [Category("信号设置"), Description("单边谐波能量测量跨度"), DisplayName("单边谐波能量测量跨度")]
        public int SpanHarmonicEnergy { get; set; }

        [Category("噪声设置"), Description("噪声补偿"), DisplayName("噪声补偿")]
        public bool IsNoiseCorrection { get; set; }

        [Category("基准测试"), Description("基准波形自测试"), DisplayName("基准波形自测试")]
        public bool IsTestCosineWave { get; set; }

        [Category("基准测试"), Description("基准波形频率"), DisplayName("基准波形频率")]
        public double TestCosineWaveFreq { get; set; }

        [Category("基准测试"), Description("基准波形信噪比"), DisplayName("基准波形信噪比")]
        public double? TestCosineWaveSnr { get; set; }

        public FftAnalysisPropertyConfigs(
            int fromBase = 16,
            int bits = 16,
            double vBias = 0,
            bool hasCodeOffset = true,
            bool isAveragedFft = false,
            int averagedFftLength = 16384,
            double averagedFftOverlap = 0.9,
            string mode = "EnergyCorrection",
            double fs = 200000,
            int fftN = 32768,
            string window = "HFT144D",
            int nHarmonic = 5,
            bool isSampling = false,
            int autoSamplingOnDataLength = 65536,
            int spanSignalEnergy = 6,
            int spanHarmonicPeak = 3,
            int spanHarmonicEnergy = 6,
            double fullScale = 10,
            bool isNoiseCorrection = false,
            bool isTestCosineWave = false,
            double testCosineWaveFreq = 1000,
            double? testCosineWaveSnr = null)
        {
            FromBase = fromBase;
            Bits = bits;
            VBias = vBias;
            HasCodeOffset = hasCodeOffset;
            IsAveragedFft = isAveragedFft;
            AveragedFftLength = averagedFftLength;
            AveragedFftOverlap = averagedFftOverlap;
            Mode = mode;
            Fs = fs;
            FftN = fftN;
            Window = window;
            NHarmonic = nHarmonic;
            IsSampling = isSampling;
            AutoSamplingOnDataLength = autoSamplingOnDataLength;
            SpanSignalEnergy = spanSignalEnergy;
            SpanHarmonicPeak = spanHarmonicPeak;
            SpanHarmonicEnergy = spanHarmonicEnergy;
            FullScale = fullScale;
            IsNoiseCorrection = isNoiseCorrection;
            IsTestCosineWave = isTestCosineWave;
            TestCosineWaveFreq = testCosineWaveFreq;
            TestCosineWaveSnr = testCosineWaveSnr;
        }
    }
}