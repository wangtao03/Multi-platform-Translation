using System.Collections.Generic;

namespace Multi_platform_Translation
{
    public class UndoManager
    {
        //撤销表
        private List<string> undoList = new List<string>();

        //重做表
        private List<string> redoList = new List<string>();

        //最大撤销/重做次数
        private int undoCount = -1;

        //记录是否为撤销的记录，因为在execute函数里会造成重复
        private bool und = false;

        //记录当前需要撤销或回复的字符串
        private string temp;

        public string Record { get => temp; }

        public UndoManager(int _undoCount = 10)
        {
            //校正最大撤销/重做次数
            undoCount = _undoCount + 1;
            //上一句的原因
            undoList.Add("");
        }

        public void Execute(string text)
        {
            temp = text;
            if (!und)
            {
                undoList.Add(text);
                if (undoCount != -1 && undoList.Count > undoCount)
                {
                    undoList.RemoveAt(0);
                }
            }
            else
            {
                und = false;
            }
        }

        public void Undo()
        {
            if (undoList.Count <= 1) return;
            und = true;
            redoList.Add(undoList[undoList.Count - 1]);
            undoList.RemoveAt(undoList.Count - 1);
            temp = undoList[undoList.Count - 1];
        }

        public void Redo()
        {
            if (redoList.Count <= 0) return;
            temp = redoList[redoList.Count - 1];
            redoList.RemoveAt(redoList.Count - 1);
        }
    }
}