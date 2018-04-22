using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TranslationUtil;

namespace Multi_platform_Translation
{
    public partial class FrmTranslation : Form
    {
        private readonly Dictionary<string, Dictionary<string, string>> langDic = new Dictionary<string, Dictionary<string, string>>();

        public FrmTranslation()
        {
            InitializeComponent();
            LangDic_initialization();
            cobForm.SelectedIndex = 0;
            cobTo.SelectedIndex = 2;
        }

        private void LangDic_initialization()
        {
            langDic.Add("谷歌", new Dictionary<string, string>());
            langDic.Add("百度", new Dictionary<string, string>());
            langDic.Add("必应", new Dictionary<string, string>());

            langDic["谷歌"].Add("自动检测", "auto");
            langDic["谷歌"].Add("日语", "ja");
            langDic["谷歌"].Add("英语", "en");
            langDic["谷歌"].Add("中文", "zh-CN");

            langDic["百度"].Add("自动检测", "auto");
            langDic["百度"].Add("日语", "jp");
            langDic["百度"].Add("英语", "en");
            langDic["百度"].Add("中文", "zh");

            langDic["必应"].Add("自动检测", "auto");
            langDic["必应"].Add("日语", "ja");
            langDic["必应"].Add("英语", "en");
            langDic["必应"].Add("中文", "zh-CHS");
        }

        private void ChkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkTopMost.Checked;
        }

        private void BtnCrossing_Click(object sender, EventArgs e)
        {
            var c1 = cobForm.SelectedIndex;
            if (!(c1 > 0)) return;
            cobForm.SelectedIndex = cobTo.SelectedIndex + 1;
            cobTo.SelectedIndex = c1 - 1;
        }

        private void BtnTranslation_Click(object sender, EventArgs e)
        {
            btnTranslation.Enabled = false;
            if (!(textOriginal.Text.Length > 0)) return;
            if (chkSogou.Checked)
            {
                textSogou.Text = Sogou.Translation(textOriginal.Text, langDic["必应"][cobForm.Text], langDic["必应"][cobTo.Text]);
            }
            if (chkYoudao.Checked) { }
            if (chkGoogle.Checked) { }
            if (chkBaidu.Checked)
            {
                textBaidu.Text = Baidu.Translation(textOriginal.Text, langDic["百度"][cobForm.Text], langDic["百度"][cobTo.Text]);
            }
            if (chkQQ.Checked)
            {
                textQQ.Text = Tencent.Translation(textOriginal.Text, langDic["百度"][cobForm.Text], langDic["百度"][cobTo.Text]);
            }
            if (chkBing.Checked && cobForm.SelectedIndex != 0)
            {
                textBing.Text = Bing.Translation(textOriginal.Text, langDic["必应"][cobForm.Text], langDic["必应"][cobTo.Text]);
            }
            btnTranslation.Enabled = true;
        }

        private void ChkGoogle_CheckedChanged(object sender, EventArgs e)
        {
            textGoogle.Enabled = chkGoogle.Checked;
        }

        private void ChkBing_CheckedChanged(object sender, EventArgs e)
        {
            textBing.Enabled = chkBing.Checked;
        }

        private void ChkYoudao_CheckedChanged(object sender, EventArgs e)
        {
            textYoudao.Enabled = chkYoudao.Checked;
        }

        private void ChkBaidu_CheckedChanged(object sender, EventArgs e)
        {
            textBaidu.Enabled = chkBaidu.Checked;
        }

        private void ChkSougo_CheckedChanged(object sender, EventArgs e)
        {
            textSogou.Enabled = chkSogou.Checked;
        }

        private void ChkQQ_CheckedChanged(object sender, EventArgs e)
        {
            textQQ.Enabled = chkQQ.Checked;
        }
    }
}