using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCompiler
{
    public class InterpretController
    {
        static InterpretController instance = null;

        public static InterpretController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InterpretController();
                }
                return instance;
            }
        }

        public List<Instruction> codeList;

        public int curCodeIndex = 0; /* 指令指针 */
        int baseAddress = 1; /* 指令基址 */
        public int stackTop = 0; /* 栈顶指针 */

        Instruction currentInstruction;
        public int[] dataStack = new int[500];	/* 栈 */
       
        bool isFinished = false;

        public void InitController()
        {
            curCodeIndex = 0;
            baseAddress = 1;
            stackTop = 0;
            dataStack[0] = 0; /* dataStack[0]不用 */
            dataStack[1] = 0; /* 主程序的三个联系单元均置为0 */
            dataStack[2] = 0;
            dataStack[3] = 0;
            isFinished = false;
            //ShowAnswerPanel();
        }
        
        public void StepIntoNTimes(int times)
        {
            if (times == 0)
            { 
                while(!isFinished)
                {
                    StepInto(times);
                    if (Ytq_Compiler.instance.canDebug == false)
                    {
                        return;
                    }
                }
                Ytq_Compiler.instance.UpdateStackPanel();

                return;
            }

            if (!isFinished)
            {
                for (int i = 0; i < times; i++)
                {
                    if (Ytq_Compiler.instance.canDebug == false)
                    {
                        return;
                    }

                    if (!isFinished)
                    {
                        StepInto(times);
                    }
                    else
                    {
                        break;
                    }
                }
                Ytq_Compiler.instance.UpdateStackPanel();
                
            }
        }

        void StepInto(int times)
        {
            currentInstruction = codeList[curCodeIndex];	/* 读当前指令 */
            curCodeIndex++;
            switch (currentInstruction.f)
            {
                case InstructionType.lit:	/* 将常量symbolBuffer的值取到栈顶 */
                    stackTop = stackTop + 1;
                    dataStack[stackTop] = currentInstruction.a;
                    break;
                case InstructionType.opr:	/* 数学、逻辑运算 */
                    switch (currentInstruction.a)
                    {
                        case 0:  /* 函数调用结束后返回 */
                            stackTop = baseAddress - 1;
                            curCodeIndex = dataStack[stackTop + 3];
                            baseAddress = dataStack[stackTop + 2];
                            //to do return
                            stackTop++;
                            dataStack[stackTop] = dataStack[0];
                            break;
                        case 1: /* 栈顶元素取反 */
                            dataStack[stackTop] = -dataStack[stackTop];
                            break;
                        case 2: /* 次栈顶项加上栈顶项，退两个栈元素，相加值进栈 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = dataStack[stackTop] + dataStack[stackTop + 1];
                            break;
                        case 3:/* 次栈顶项减去栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = dataStack[stackTop] - dataStack[stackTop + 1];
                            break;
                        case 4:/* 次栈顶项乘以栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = dataStack[stackTop] * dataStack[stackTop + 1];
                            break;
                        case 5:/* 次栈顶项除以栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = dataStack[stackTop] / dataStack[stackTop + 1];
                            break;
                        case 6:/* 栈顶元素的奇偶判断 */
                            dataStack[stackTop] = dataStack[stackTop] % 2;
                            break;
                        case 8:/* 次栈顶项与栈顶项是否相等 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] == dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 9:/* 次栈顶项与栈顶项是否不等 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] != dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 10:/* 次栈顶项是否小于栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] < dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 11:/* 次栈顶项是否大于等于栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] >= dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 12:/* 次栈顶项是否大于栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] > dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 13: /* 次栈顶项是否小于等于栈顶项 */
                            stackTop = stackTop - 1;
                            dataStack[stackTop] = (dataStack[stackTop] <= dataStack[stackTop + 1]) ? 1 : 0;
                            break;
                        case 14:/* 栈顶值输出 */
                          
                            Ytq_Compiler.instance.answerBuffer += dataStack[stackTop];
                            //Console.WriteLine(dataStack[stackTop]);
                            stackTop = stackTop - 1;
                            break;
                        case 15:/* 输出换行符 */
                   
                            //Console.WriteLine("\r\n");
                            Ytq_Compiler.instance.answerBuffer += "\r\n";
                            break;
                        case 16:/* 读入一个输入置于栈顶 */
                            stackTop = stackTop + 1;
                           
                            Console.WriteLine("?");
                            Ytq_Compiler.instance.AnswerAppendStr(Ytq_Compiler.instance.answerBuffer, Color.Black);
                            Ytq_Compiler.instance.answerBuffer = "";
                            Ytq_Compiler.instance.AnswerAppendStr("?", Color.Red);
                             //dataStack[stackTop] = Console.Read();	
                            Ytq_Compiler.instance.NeedInputText();

                            break;
                        case 17:
                             stackTop = stackTop - 1;
                            dataStack[stackTop] = dataStack[stackTop] % dataStack[stackTop + 1];
                            break;
                        case 18:
                            dataStack[0] = dataStack[stackTop];
                            stackTop--;
                            break;
                    }
                    break;
                case InstructionType.lod:	/* 取相对当前过程的数据基地址为symbolBuffer的内存的值到栈顶 */
                    stackTop = stackTop + 1;
                    dataStack[stackTop] = dataStack[GetBaseAddress(currentInstruction.l, dataStack, baseAddress) + currentInstruction.a];
                    break;
                case InstructionType.sto:	/* 栈顶的值存到相对当前过程的数据基地址为symbolBuffer的内存 */
                    dataStack[GetBaseAddress(currentInstruction.l, dataStack, baseAddress) + currentInstruction.a] = dataStack[stackTop];
                    stackTop = stackTop - 1;
                    break;
                case InstructionType.cal:	/* 调用子过程 */
                    dataStack[stackTop + 1] = GetBaseAddress(currentInstruction.l, dataStack, baseAddress);	/* 将父过程基地址入栈，即建立静态链 */
                    dataStack[stackTop + 2] = baseAddress;	/* 将本过程基地址入栈，即建立动态链 */
                    dataStack[stackTop + 3] = curCodeIndex;	/* 将当前指令指针入栈，即保存返回地址 */
                    baseAddress = stackTop + 1;	/* 改变基地址指针值为新过程的基地址 */
                    curCodeIndex = currentInstruction.a;	/* 跳转 */
                    break;
                case InstructionType.ini:	/* 在数据栈中为被调用的过程开辟symbolBuffer个单元的数据区 */
                    stackTop = stackTop + currentInstruction.a;
                    break;
                case InstructionType.jmp:	/* 直接跳转 */
                    curCodeIndex = currentInstruction.a;
                    break;
                case InstructionType.jpc:	/* 条件跳转 */
                    if (dataStack[stackTop] == 0)
                        curCodeIndex = currentInstruction.a;
                    stackTop = stackTop - 1;
                    break;
            }

            if (times != 0)
            {
                Ytq_Compiler.instance.LightCurrentLine();
            }

            if (curCodeIndex == 0)
            {
                isFinished = true;
            }
        }

      
        /* 通过过程基址求上l层过程的基址 */
        int GetBaseAddress(int l, int[] dataStack, int b)
        {
            int b1;
            b1 = b;
            while (l > 0)
            {
                b1 = dataStack[b1];
                l--;
            }
            return b1;
        }
    }
}
