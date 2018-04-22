using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TranslationUtil;

namespace Multi_platform_Translation
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, Dictionary<string, string>> langDic = new Dictionary<string, Dictionary<string, string>>();

        public Form1()
        {
            InitializeComponent();
            LangDic_initialization();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var c1 = comboBox1.SelectedIndex;
            if (!(c1 > 0)) return;
            comboBox1.SelectedIndex = comboBox2.SelectedIndex + 1;
            comboBox2.SelectedIndex = c1 - 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (chkSogou.Checked) {
                textSogou.Text = Sogou.Translation(textBox1.Text, langDic["必应"][comboBox1.Text], langDic["必应"][comboBox2.Text]);
            }
            if (chkYoudao.Checked) { }
            if (chkGoogle.Checked) { }
            if (chkBaidu.Checked)
            {
                textBaidu.Text = Baidu.Translation(textBox1.Text, langDic["百度"][comboBox1.Text], langDic["百度"][comboBox2.Text]);
            }
            if (chkQQ.Checked)
            {
                textQQ.Text = Tencent.Translation(textBox1.Text, langDic["百度"][comboBox1.Text], langDic["百度"][comboBox2.Text]);
            }
            if (chkBing.Checked)
            {
                textBing.Text = Bing.Translation(textBox1.Text, langDic["必应"][comboBox1.Text], langDic["必应"][comboBox2.Text]);
            }
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