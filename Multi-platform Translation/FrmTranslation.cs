using System;
using System.Collections.Generic;
using System.Threading;
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
            CheckForIllegalCrossThreadCalls = false;
            LangDic_initialization();
            cobForm.SelectedIndex = 0;
            cobTo.SelectedIndex = 2;
        }

        private void LangDic_initialization()
        {
            langDic.Add("谷歌", new Dictionary<string, string>());
            langDic.Add("百度", new Dictionary<string, string>());
            langDic.Add("必应", new Dictionary<string, string>());

            langDic["谷歌"].Add("日语", "ja");
            langDic["谷歌"].Add("英语", "en");
            langDic["谷歌"].Add("中文", "zh-CN");

            langDic["百度"].Add("日语", "jp");
            langDic["百度"].Add("英语", "en");
            langDic["百度"].Add("中文", "zh");

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
            cobForm.SelectedIndex = cobTo.SelectedIndex;
            cobTo.SelectedIndex = c1;
        }

        //========================
        private void SogouTranslation()
        {
            chkSogou.Checked = false;
            chkSogou.Enabled = false;

            textSogou.Text = Sogou.Translation(textOriginal.Text, langDic["必应"][cobForm.Text], langDic["必应"][cobTo.Text]);

            chkSogou.Enabled = true;
            chkSogou.Checked = true;
        }

        private void YoudaoTranslation()
        {
            chkYoudao.Checked = false;
            chkYoudao.Enabled = false;

            textYoudao.Text = Youdao.Translation(textOriginal.Text, langDic["必应"][cobForm.Text], langDic["必应"][cobTo.Text]);

            chkYoudao.Enabled = true;
            chkYoudao.Checked = true;
        }

        private void GoogleTranslation()
        {
            chkGoogle.Checked = false;
            chkGoogle.Enabled = false;

            textGoogle.Text = Google.Translate(textOriginal.Text, langDic["谷歌"][cobForm.Text], langDic["谷歌"][cobTo.Text]);

            chkGoogle.Enabled = true;
            chkGoogle.Checked = true;
        }

        private void BaiduTranslation()
        {
            chkBaidu.Checked = false;
            chkBaidu.Enabled = false;
            textBaidu.Text = Baidu.Translation(textOriginal.Text, langDic["百度"][cobForm.Text], langDic["百度"][cobTo.Text]);
            chkBaidu.Enabled = true;
            chkBaidu.Checked = true;
        }

        private void TencentTranslation()
        {
            chkQQ.Checked = false;
            chkQQ.Enabled = false;
            textQQ.Text = Tencent.Translation(textOriginal.Text, langDic["百度"][cobForm.Text], langDic["百度"][cobTo.Text]);
            chkQQ.Enabled = true;
            chkQQ.Checked = true;
        }

        private void BingTranslation()
        {
            chkBing.Checked = false;
            chkBing.Enabled = false;
            textBing.Text = Bing.Translation(textOriginal.Text, langDic["必应"][cobForm.Text], langDic["必应"][cobTo.Text]);
            chkBing.Enabled = true;
            chkBing.Checked = true;
        }

        //========================
        private void BtnTranslation_Click(object sender, EventArgs e)
        {
            if (!(textOriginal.Text.Length > 0)) return;
            textOriginal.Enabled = false;
            btnTranslation.Enabled = false;

            if (chkSogou.Checked) new Thread(new ThreadStart(SogouTranslation)).Start();
            if (chkYoudao.Checked) new Thread(new ThreadStart(YoudaoTranslation)).Start();
            if (chkGoogle.Checked) new Thread(new ThreadStart(GoogleTranslation)).Start();
            if (chkBaidu.Checked) new Thread(new ThreadStart(BaiduTranslation)).Start();
            if (chkQQ.Checked) new Thread(new ThreadStart(TencentTranslation)).Start();
            if (chkBing.Checked) new Thread(new ThreadStart(BingTranslation)).Start();

            btnTranslation.Enabled = true;
            textOriginal.Enabled = true;
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

        private void textOriginal_TextChanged(object sender, EventArgs e)
        {
            btnTranslation.Enabled = (textOriginal.Text.Length > 0);
        }
    }
}