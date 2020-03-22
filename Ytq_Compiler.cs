using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YCompiler
{
    public partial class Ytq_Compiler : BaseForm
    {

        public static Ytq_Compiler instance;
        public Ytq_Compiler()
        {
            
            InitializeComponent();
            instance = this;
            FormBorderStyle = FormBorderStyle.None;

            ButtonTip.InitialDelay = 100;
            RotateGraphics();
            LinePanel.Visible = false;
            LineText.Visible = false;

            CodePanel.Visible = false;
            CodeText.Visible = false;

            DefinePanel.Visible = false;
            DefineText.Visible = false;

            StackPanel.Visible = false;
            StackText.Visible = false;
            StackText.Text = "";
            AnswerPanel.Visible = false;
            AnswerText.Visible = false;
            InputText.Text = "0";
        }

        public int stepNum = 1;
        public int deltaStepNum =1;

        public Color nameColor = Color.FromArgb(0, 0, 0);
        public Color typeColor = Color.FromArgb(80, 166, 37);
        public Color valueColor = Color.FromArgb(0, 178, 191);
        public Color levelColor = Color.FromArgb(93, 12, 123);
        public Color addressColor = Color.FromArgb(255, 0, 109);
        public Color sizeColor = Color.FromArgb(32, 90, 167);


        public void ShowLinePanel()
        {
            LinePanel.Visible = true;
            LineText.Visible = true;
            LinePanel.AutoScroll = true;
            LineText.Lines = CompileController.Instance.lineArray;
            double size = 27.5 * LineText.Lines.Length;
            LineText.Height = (int)Math.Ceiling(size);

            if (!LinePanel.Controls.Contains(LineText))
            {
                LinePanel.Controls.Add(LineText);
            }
        }

        public void ShowCodePanel()
        {
            CodePanel.Visible = true;
            CodeText.Visible = true;
            CodePanel.AutoScroll = true;

            List<Instruction> codeList = CompileController.Instance.codeList;
            string[] codeArray = new string[codeList.Count];
            
            for (int i = 0; i < codeList.Count; i++)
            {
                string value = (i + " " + codeList[i].f.ToString() + " " + codeList[i].l + " " + codeList[i].a);
                codeArray[i] = value;
            }
            CodeText.Lines = codeArray;
            
            double size = 27.5 * CodeText.Lines.Length;
            CodeText.Height = (int)Math.Ceiling(size);
            if (!CodePanel.Controls.Contains(CodeText))
            {
                CodePanel.Controls.Add(CodeText);
            }
        }


        void RichTextAppeedStr(RichTextBox richText,string appendStr,Color textColor)
        {
            int startIndex = richText.Text.Length;
            richText.AppendText(appendStr);
            richText.Select(startIndex, appendStr.Length);
            richText.SelectionColor = textColor;
        }

        public void ShowDefeinePanel()
        {
            DefinePanel.Visible = true;
            DefineText.Visible = true;
            DefinePanel.AutoScroll = true;

            List<DefineUnit> defineList = CompileController.Instance.defineList;
            
            for (int i = 1; i < defineList.Count; i++)
            {
                DefineText.AppendText(i + ". ");
                RichTextAppeedStr(DefineText, defineList[i].name, nameColor);
                DefineText.AppendText(" ");
                RichTextAppeedStr(DefineText, defineList[i].type.ToString(), typeColor);
                DefineText.AppendText(" ");
                RichTextAppeedStr(DefineText, defineList[i].value.ToString(), valueColor);
                DefineText.AppendText(" ");
                RichTextAppeedStr(DefineText, defineList[i].funcName, levelColor);
                DefineText.AppendText(" ");
                RichTextAppeedStr(DefineText, defineList[i].address.ToString(), addressColor);
                DefineText.AppendText(" ");
                RichTextAppeedStr(DefineText, defineList[i].size.ToString(), sizeColor);
                DefineText.AppendText("\r\n");
                
            }

            double size = 27.5 * DefineText.Lines.Length;
            DefineText.Height = (int)Math.Ceiling(size);

            if (!DefinePanel.Controls.Contains(DefineText))
            {
                DefinePanel.Controls.Add(DefineText);
            }
        }

        private void LoadedPictureBox_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Background_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void StepNumSlider_Scroll(object sender, EventArgs e)
        {
            stepNum=StepNumSlider.Value*deltaStepNum;
            StepNumText.Text = Convert.ToString(stepNum);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        List<PictureBox> rotateBoxes=new List<PictureBox>();
        Bitmap[] bitmaps;
        Bitmap[] backgrounds;
        Graphics[] graphicses;
        public void RotateGraphics()
        {
            rotateBoxes.Add(SetPathBox);
            rotateBoxes.Add(LoadLineBox);
            rotateBoxes.Add(StepIntoBox);
            rotateBoxes.Add(Star1Box);
            rotateBoxes.Add(Star2Box);
            rotateBoxes.Add(InputConfirmBox);

            bitmaps = new Bitmap[rotateBoxes.Count];
            backgrounds = new Bitmap[rotateBoxes.Count];
            graphicses = new Graphics[rotateBoxes.Count];
            
            for (int i = 0; i < rotateBoxes.Count; i++)
            {
                bitmaps[i]=(Bitmap)rotateBoxes[i].Image.Clone();
                backgrounds[i] = new Bitmap(rotateBoxes[i].Width, rotateBoxes[i].Height, PixelFormat.Format24bppRgb);
                graphicses[i] = Graphics.FromImage(backgrounds[i]);
                graphicses[i].TranslateTransform(backgrounds[i].Width / 2, backgrounds[i].Height / 2);
            }
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(RotateEvent);
            timer.Enabled = true;
        }

        void RotateEvent(object sender,EventArgs e)
        {
            for (int i = 0; i < rotateBoxes.Count; i++)
            {
                graphicses[i].Clear(Color.Transparent);
                graphicses[i].RotateTransform(10.0f);
                graphicses[i].DrawImage(bitmaps[i], -bitmaps[i].Width / 2, -bitmaps[i].Height / 2);
                Graphics newGraphics = rotateBoxes[i].CreateGraphics();
                newGraphics.DrawImage(backgrounds[i], 0, 0);
            }
        }

        private void LoadFileBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";//设置打开文件类型
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                    DefineText.Text = "";
                    StackText.Text = "";
                    AnswerText.Text = "";
                    answerBuffer = "";
                    CompileController.Instance.lineArray = File.ReadAllLines(openFileDialog.FileName); 
                    CompileController.Instance.StartCompile();
                    ShowLinePanel();
                    ShowAnswerPanel();
                    StackPanel.Visible = true;
                    StackText.Visible = true;
                    StackPanel.AutoScroll = true;
                   
                   
                }
            }
        }


        public void UpdateStackPanel()
        {
            int stackTop = InterpretController.Instance.stackTop;
            int[] dataStack = InterpretController.Instance.dataStack;
            StackText.Text = "";
            for (int i = 0; i <= stackTop; i++)
            {
                StackText.AppendText( i + ".  ");
                StackText.AppendText(dataStack[i].ToString());

                StackText.AppendText("\r\n");
            }

            double size = 27.5 * StackText.Lines.Length;
            StackText.Height = (int)Math.Ceiling(size);

            if (!StackPanel.Controls.Contains(StackText))
            {
                StackPanel.Controls.Add(StackText);
            }
        }

        int GetStartIndex(RichTextBox richText, int lineNum)
        {
            int sum = 0;
            for (int i = 0; i < lineNum; i++)
            {
                sum += richText.Lines[i].Length;
            }
            return sum + lineNum;
        }

        public bool needRecord = false;
        public void LightCurrentLine()
        {
            int curCodeIndex = InterpretController.Instance.curCodeIndex;
            if (curCodeIndex != 0)
            {
                if (!needRecord)
                {
                    CodeText.Select(0, CodeText.Text.Length);
                    CodeText.SelectionColor = Color.Black;

                    LineText.Select(0, LineText.Text.Length);
                    LineText.SelectionColor = Color.Black;

                }
                List<Instruction> codeList = InterpretController.Instance.codeList;
                int startIndex = GetStartIndex(CodeText, curCodeIndex);
                CodeText.Select(startIndex, CodeText.Lines[curCodeIndex].Length);
                CodeText.SelectionColor = Color.Red;

                int lineIndex = CompileController.Instance.GetInstuctionLineIndex(curCodeIndex);
                startIndex = GetStartIndex(LineText, lineIndex);
                LineText.Select(startIndex, LineText.Lines[lineIndex].Length);
                LineText.SelectionColor = Color.Red;
            }
        }

        public void LightLineText(int lineNum)
        {
            RichTextLightLine(LineText, lineNum);
        }
        
        void RichTextLightLine(RichTextBox richText, int lineNum)
        {
            int startIndex = GetStartIndex(richText, lineNum);
            LineText.Select(startIndex, richText.Lines[lineNum].Length);
            LineText.SelectionColor = valueColor;
        }

        private void NeedRecordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            needRecord = NeedRecordCheckBox.CheckState == CheckState.Checked ? true : false ;
        }

        public bool canDebug = false;
        public string answerBuffer = "";
        private void StepIntoBox_Click(object sender, EventArgs e)
        {
            if (canDebug)
            {
                answerBuffer = "";
                InterpretController.Instance.StepIntoNTimes(stepNum);
                AnswerAppendStr(answerBuffer, Color.Black);

            }
        }
    

        void ShowAnswerPanel()
        {
            AnswerPanel.Visible = true;
            AnswerText.Visible = true;
            AnswerPanel.AutoScroll = true;

            if (!AnswerPanel.Controls.Contains(AnswerText))
            {
                AnswerPanel.Controls.Add(AnswerText);
            }
        }

        public void AnswerAppendStr(string str,Color color)
        {
            RichTextAppeedStr(AnswerText, str, color);

            double size = 27.5 * AnswerText.Lines.Length;
            AnswerText.Height = (int)Math.Ceiling(size);
          
        }

        public bool canInput = false;
        public void NeedInputText()
        {
            InputText.ReadOnly = false;
            canDebug = false;
            canInput = true;
        }


        private void InputConfirmBox_Click(object sender, EventArgs e)
        {
            if (canInput)
            {
                if (InputText.Text != "")
                {
                    InterpretController.Instance.dataStack[InterpretController.Instance.stackTop] = int.Parse(InputText.Text);
                    canInput = false;
                    canDebug = true;
                    InputText.ReadOnly = true;
                    AnswerAppendStr(InputText.Text,valueColor);
                    AnswerAppendStr("\r\n", addressColor);
                }
            }
        }
    }
}
