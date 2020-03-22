using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCompiler
{

    public enum InstructionType
    {
        lit = 0, opr, lod,
        sto, cal, ini,
        jmp, jpc,
    };

    public class Instruction
    {
        public InstructionType f; /* 虚拟机代码指令 */
        public int l;      /* 引用层与声明层的层次差 */
        public int a;      /* 根据f的不同而不同 */
    };



    public enum DefineType
    {
        Constant = 0,
        Variable,
        Procedure,
        Empty
    };

    public class DefineUnit
    {
        public string name;    /* 名字 */
        public DefineType type; /* 类型：const，var或procedure */
        public int value;            /* 数值，仅const使用 */
        public int level;          /* 所处层，仅const不使用 */
        public int address;            /* 地址，仅const不使用 */
        public int size;           /* 需要分配的数据区空间, 仅procedure使用 */
        public string funcName;
    };

    public class CompileController
    {
        static CompileController instance = null;

        public static CompileController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompileController();
                }
                return instance;
            }
        }


        public enum Symbol
        {
            Nul = 0, Ident, Number, Add, Sub,
            Mul, Div, OddSym, Eql, Neq,
            Lss, Leq, Gtr, Geq, Mod, Lparen,
            Rparen, Comma, Semicolon, Range, Becomes,
            BeginSym, EndSym, IfSym, ThenSym, WhileSym,
            WriteSym, ReadSym, DoSym, CallSym, ConstSym,
            VarSym, ProcSym, ElseSym, ForSym, InSym, LineNote, StartMulNote, EndMulNote,ReturnSym
        };

        Dictionary<string, Symbol> symbolDict = new Dictionary<string, Symbol>();
        public List<DefineUnit> defineList = new List<DefineUnit>();
        public List<Instruction> codeList = new List<Instruction>();

        public Dictionary<int, int> lineIndexDict = new Dictionary<int, int>();

        int currentNumber;
        int curCharIndex;
        int curCodeIndex;

        char currentChar;
        Symbol currentSymbol;
        string currentIdent;

        public string[] lineArray;
        int currentLineIndex,lineBufferLength;
        string lineBuffer;

        public int GetInstuctionLineIndex(int codeIndex)
        {
            //if (lineIndexDict.ContainsKey(ins))
            {
                return lineIndexDict[codeIndex];
            }

        }

        public void StartCompile()
        {
            InitCompiler();
            currentLineIndex = curCharIndex = lineBufferLength = curCodeIndex = 0;
            currentChar = ' ';

            GetSymbol();
            Block(0, 0,"Global");


            //Console.WriteLine("------Parseing End------");
            //MackSure canPrint is true ,If is true can print on console
            PrintCodeList(0);

            // Just For Ytq_Compiler  delete these code can use for other program
            if (Ytq_Compiler.instance != null)
            {
                Ytq_Compiler.instance.ShowCodePanel();
                Ytq_Compiler.instance.ShowDefeinePanel();
            }

            if (InterpretController.Instance != null)
            {
                InterpretController.Instance.codeList = codeList;
                InterpretController.Instance.InitController();
                Ytq_Compiler.instance.canDebug = true;
            }
            //can delete end
        }


        void GetChar()
        {
            if (curCharIndex == lineBufferLength)
            {
                curCharIndex = 0;
                currentChar = ' ';

                if (currentLineIndex < lineArray.Length)
                {
                    while (lineArray[currentLineIndex] == "")
                    {
                        if (currentLineIndex + 1 == lineArray.Length)
                        {
                            currentChar = '~';
                            return;
                        }
                        currentLineIndex++;
                    }
                    lineBuffer = lineArray[currentLineIndex];
                    lineBufferLength = lineBuffer.Length;
                    currentLineIndex++;
                }
                else
                {

                    currentChar = '~';
                    return;
                }

                Console.WriteLine(lineBuffer);
            }

            currentChar = lineBuffer[curCharIndex];
            //Console.WriteLine(currentChar+ " "+curCharIndex);
            curCharIndex++;
        }


        public void InitCompiler()
        {
            symbolDict.Clear();
            codeList.Clear();
            defineList.Clear();
            lineIndexDict.Clear();
            isError = false;
            symbolDict.Add("==", Symbol.Eql);
            symbolDict.Add("!=", Symbol.Neq);
            symbolDict.Add("<", Symbol.Lss);
            symbolDict.Add("<=", Symbol.Leq);
            symbolDict.Add(">", Symbol.Gtr);
            symbolDict.Add(">=", Symbol.Geq);
            symbolDict.Add("...", Symbol.Range);
            symbolDict.Add("//", Symbol.LineNote);
            symbolDict.Add("/*", Symbol.StartMulNote);
            symbolDict.Add("*/", Symbol.EndMulNote);

            symbolDict.Add("=", Symbol.Becomes);
            symbolDict.Add("+", Symbol.Add);
            symbolDict.Add("-", Symbol.Sub);
            symbolDict.Add("*", Symbol.Mul);
            symbolDict.Add("/", Symbol.Div);
            symbolDict.Add("(", Symbol.Lparen);
            symbolDict.Add(")", Symbol.Rparen);
            symbolDict.Add(",", Symbol.Comma);
            symbolDict.Add(";", Symbol.Semicolon);
            symbolDict.Add("{", Symbol.BeginSym);
            symbolDict.Add("}", Symbol.EndSym);
            symbolDict.Add("%", Symbol.Mod);

            symbolDict.Add("const", Symbol.ConstSym);
            symbolDict.Add("var", Symbol.VarSym);
            symbolDict.Add("func", Symbol.ProcSym);
            symbolDict.Add("read", Symbol.ReadSym);
            symbolDict.Add("print", Symbol.WriteSym);
            symbolDict.Add("while", Symbol.WhileSym);
            symbolDict.Add("if", Symbol.IfSym);
            symbolDict.Add("call", Symbol.CallSym);
            symbolDict.Add("for", Symbol.ForSym);
            symbolDict.Add("in", Symbol.InSym);
            symbolDict.Add("else", Symbol.ElseSym);
            symbolDict.Add("return", Symbol.ReturnSym);

        }

        const int maxNumberLength = 14;
        bool isError = false;
        enum ErrorCase 
        { TooMuchDigit,NeedSemicolon,NeedBeginSym,NeedIdent,NeedRparen,NeedLparen,
            NeedBecomes,NeedVariable,NeedInSym,NeedRangeSym,NeedCompare,NeedFactor,Undefine
        }
        void PrintError(ErrorCase errorCase)
        {
            //Ytq_Compiler.instance.LightLineText(currentLineIndex - 1);
            string errorStr = "错误的行数是" + (currentLineIndex - 1)+"\r\n";
            //Ytq_Compiler.instance.

            switch (errorCase)
            {
                case ErrorCase.TooMuchDigit:
                    errorStr += "当前数字位数太多";
                    break;
                case ErrorCase.NeedSemicolon:
                    errorStr += "缺少';'";
                    break;
                case ErrorCase.NeedBeginSym:
                    errorStr += "缺少'{'";
                    break;
                case ErrorCase.NeedIdent:
                    errorStr += "当前行需要变量";
                    break;
                case ErrorCase.NeedLparen:
                    errorStr += "缺少'('";
                    break;
                case ErrorCase.NeedRparen:
                    errorStr += "缺少')'";
                    break;
                case ErrorCase.NeedBecomes:
                    errorStr += "缺少'='";
                    break;
                case ErrorCase.NeedVariable:
                    errorStr += "只有变量能被赋值'";
                    break;
                case ErrorCase.NeedInSym:
                    errorStr += "缺少 in ";
                    break;
                case ErrorCase.NeedRangeSym:
                    errorStr += "缺少 ... ";
                    break;
                case ErrorCase.NeedCompare:
                    errorStr += "缺少关系运算符";
                    break;
                case ErrorCase.NeedFactor:
                    errorStr += "因子只能为数字、变量和表达式";
                    break;
                case ErrorCase.Undefine:
                    errorStr += (currentIdent + " 该变量不存在");
                    break;
            }

            Ytq_Compiler.instance.AnswerAppendStr(errorStr, Color.Red);
        }

        public void GetSymbol()
        {
            if (currentChar == '~')
            {
                currentSymbol = Symbol.EndSym;
                return;
            }

            while (currentChar == ' ')
            {
                GetChar();
            }

            if ((currentChar >= 'a' && currentChar <= 'z') || (currentChar >= 'A' && currentChar <= 'Z'))
            {
                string charBuffer = "" + currentChar;
                GetChar();
                while ((currentChar >= 'a' && currentChar <= 'z') || (currentChar >= 'A' && currentChar <= 'Z') || (currentChar >= '0' && currentChar <= '9'))
                {
                    charBuffer += currentChar;
                    GetChar();
                }

                Symbol symbolValue = Symbol.Nul;

                bool isReservedWord = symbolDict.TryGetValue(charBuffer, out symbolValue);

                if (isReservedWord == true)
                {
                    currentSymbol = symbolValue;
                }
                else
                {
                    currentSymbol = Symbol.Ident;
                    currentIdent = charBuffer;

                }
            }
            else if (currentChar >= '0' && currentChar <= '9')
            {
                currentNumber = currentChar - '0';
                GetChar();
                int digit = 1;
                while (currentChar >= '0' && currentChar <= '9')
                {
                    currentNumber = 10 * currentNumber + currentChar - '0';
                    digit++;

                    if (digit > maxNumberLength)
                    {
                        PrintError(ErrorCase.TooMuchDigit);
                        isError = true;
                        return;
                    }


                    GetChar();
                }


                while (currentChar == ' ')
                {
                    GetChar();
                }

                if (currentChar == ';')
                {
                    GetChar();
                }
               
                

                currentSymbol = Symbol.Number;


            }
            else
            {

                string charBuffer = "" + currentChar;
                Symbol symbolValue = Symbol.Nul;

                if (currentChar == '/')
                {
                    GetChar();
                    if (currentChar == '/' || currentChar == '*')
                    {
                        charBuffer += currentChar;
                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;

                        GetChar();
                    }
                    else
                    {
                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;
                    }

                }
                else if (currentChar == '*')
                {
                    GetChar();
                    if (currentChar == '/')
                    {
                        charBuffer += currentChar;
                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;

                        GetChar();
                    }
                    else
                    {
                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;
                    }
                }
                else if (currentChar == '=' || currentChar == '<' || currentChar == '>')
                {
                    GetChar();
                    if (currentChar == '=')
                    {
                        charBuffer += '=';

                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;

                        GetChar();
                    }
                    else
                    {
                        symbolDict.TryGetValue(charBuffer, out symbolValue);
                        currentSymbol = symbolValue;

                        //GetChar();
                    }
                }
                else
                {
                    while (symbolDict.TryGetValue(charBuffer, out symbolValue) == false)
                    {
                        GetChar();
                        charBuffer += currentChar;

                    }

                    currentSymbol = symbolValue;
                    GetChar();
                }
            }
        }



        void GenerateCode(InstructionType x, int y, int z)
        {
            Instruction instruction = new Instruction();
            instruction.f = x;
            instruction.l = y;
            instruction.a = z;

            codeList.Add(instruction);

            lineIndexDict.Add(curCodeIndex, currentLineIndex-1);

            curCodeIndex++;
        }

        void DifineListAdd(DefineType type, string name, int value, int level, int address, int size,string parent)
        {
            DefineUnit unit = new DefineUnit();
            unit.type = type;
            unit.name = name;
            unit.level = level;
            unit.value = currentNumber;
            unit.address = address;
            unit.size = size;
            unit.funcName = parent;
            defineList.Add(unit);
        }


        void LineNoteCheck()
        {
            if (currentSymbol == Symbol.LineNote)
            {
                LineNoteState(0);
            }
            else if (currentSymbol == Symbol.StartMulNote)
            {
                MulNoteState(0);
            }

        }

        public void Block(int level, int procIndex,string blockName)
        {
            int defineNum = 3;
            int orignProcIndex = procIndex;
            
            if (level == 0)
            {
                DifineListAdd(DefineType.Empty, "", 0, 0, curCodeIndex, 0, blockName);
            }

            defineList[procIndex].address = curCodeIndex;
            GenerateCode(InstructionType.jmp, 0, 0);

            while (currentSymbol == Symbol.ConstSym)
            {
                GetSymbol();

                while (currentSymbol == Symbol.Ident)
                {
                    GetSymbol();

                    if (currentSymbol == Symbol.Becomes)
                    {
                        GetSymbol();
                        if (currentSymbol == Symbol.Number)
                        {
                            /*
                            procIndex++;
                            DefineUnit unit = new DefineUnit();
                            unit.type = DefineType.Constant;
                            unit.name = currentIdent;
                            unit.value = currentNumber;
                            defineList.Add(unit);
                            */

                            DifineListAdd(DefineType.Constant, currentIdent, currentNumber, 0, 0, 0, blockName);
                        }
                    }

                    GetSymbol();

                    if (currentSymbol == Symbol.Comma)
                    {
                        GetSymbol();
                    }
                    else if (currentSymbol == Symbol.Semicolon)
                    {
                        GetSymbol();
                    }
                    
                }

                if (isError)
                {
                    return;
                }

            }



            while (currentSymbol == Symbol.VarSym)
            {
                GetSymbol();

                while (currentSymbol == Symbol.Ident)
                {
                    GetSymbol();

                    /*
                    DefineUnit unit = new DefineUnit();
                    unit.type = DefineType.Variable;
                    unit.name = currentIdent;
                    unit.level = level;
                    unit.address = defineNum;
                    defineNum++;
                    defineList.Add(unit);
                    */
                    DifineListAdd(DefineType.Variable, currentIdent, 0, level, defineNum, 0, blockName);
                    defineNum++;
                    
                    if (currentSymbol == Symbol.Comma)
                    {
                        GetSymbol();
                    }

                }
                if (currentSymbol == Symbol.Semicolon)
                {
                    GetSymbol();
                }
                else
                {
                    PrintError(ErrorCase.NeedSemicolon);
                    isError = true;
                    return;
                }

                LineNoteCheck();

                if (isError)
                {
                    return;
                }
            }

            while (currentSymbol == Symbol.ProcSym)
            {
                GetSymbol();

                if (currentSymbol == Symbol.Ident)
                {
                    string newBlockName = currentIdent;
                    /*
                    DefineUnit unit = new DefineUnit();
                    unit.type = DefineType.Procedure;
                    unit.name = currentIdent;
                    unit.level = level;
                    defineList.Add(unit);
                    */
                    DifineListAdd(DefineType.Procedure, currentIdent, 0, level, 0, 0, blockName);

                    GetSymbol();
                    if (currentSymbol == Symbol.Lparen)
                    {
                        GetSymbol();
                        if (currentSymbol == Symbol.Rparen)
                        {
                            GetSymbol();
                            if (currentSymbol == Symbol.BeginSym)
                            {
                                GetSymbol();
                                Block(level + 1, defineList.Count - 1, newBlockName);
                            }
                            else
                            {
                                PrintError(ErrorCase.NeedBeginSym);
                                isError = true;
                                return;
                            }
                        }
                        else
                        {
                            PrintError(ErrorCase.NeedRparen);
                            isError = true;
                            return;
                        }
                    }
                    else
                    {
                        PrintError(ErrorCase.NeedLparen);
                        isError = true;
                        return;
                    }
                   
                }
                LineNoteCheck();

                if (isError)
                {
                    return;
                }
            }


            codeList[defineList[orignProcIndex].address].a = curCodeIndex;
            defineList[orignProcIndex].address = curCodeIndex;
            defineList[orignProcIndex].size = defineNum;
            int listCodeIndex = curCodeIndex;
            GenerateCode(InstructionType.ini, 0, defineNum);

            PrintDefineList();

            Statement(true, level, blockName);


            if (isError)
            {
                return;
            }

            GenerateCode(InstructionType.opr, 0, 0);

            PrintCodeList(listCodeIndex);
        }

        bool canPrintDefine = false;

        void PrintDefineList()
        {
            if (canPrintDefine)
            {
                for (int i = 1; i < defineList.Count; i++)
                {
                    Console.WriteLine(i + " " + defineList[i].name + " " + defineList[i].type.ToString() + " " + defineList[i].level);
                    Console.WriteLine(defineList[i].value + " " + defineList[i].address + " " + defineList[i].size);
                }
            }
        }

        bool canPrintCode = false;
        void PrintCodeList(int startIndex)
        {
            if (canPrintCode)
            {
                for (int i = startIndex; i < curCodeIndex; i++)
                {
                    Console.WriteLine(i + " " + codeList[i].f.ToString() + " " + codeList[i].l + " " + codeList[i].a);
                }
            }
        }

        public void Statement(bool isFirstEnter, int level,string blockName)
        {
            if (isFirstEnter) //|| currentSymbol == Symbol.BeginSym
            {
                while (currentSymbol != Symbol.EndSym)
                {
                    Statement(false, level, blockName);

                    if (currentSymbol == Symbol.Semicolon)
                    {
                        GetSymbol();
                    }
                   

                    if (isError)
                    {
                        return;
                    }

                }
                GetSymbol();
            }
            else
            {
                switch (currentSymbol)
                {
                    case Symbol.IfSym:

                        IfState(level, blockName);
                        break;
                    case Symbol.WhileSym:
                        WhileState(level, blockName);
                        break;
                    case Symbol.ReadSym:
                        ReadState(level, blockName);
                        break;
                    case Symbol.WriteSym:
                        PrintState(level, blockName);
                        break;
                    case Symbol.Ident:
                        AssignState(level,blockName);
                        break;
                    case Symbol.ForSym:
                        ForState(level, blockName);
                        break;
                    case Symbol.CallSym:
                        CallState(level, blockName);
                        break;
                    case Symbol.StartMulNote:
                        MulNoteState(level);
                        break;
                    case Symbol.LineNote:
                        LineNoteState(level);
                        break;
                    case Symbol.ReturnSym:
                        ReturnState(level, blockName);
                        break;
                }
            }

            if (isError)
            {
                return;
            }
        }

        void ReturnState(int level,string blockName)
        {
            GetSymbol();
            Exprission(level, blockName);
            GenerateCode(InstructionType.opr, 0, 18);
        }

        void MulNoteState(int level)
        {
            GetSymbol();

            while (currentSymbol != Symbol.EndMulNote)
            {
                GetSymbol();

                if (isError)
                {
                    return;
                }
            }

            GetSymbol();
        }

        void LineNoteState(int level)
        {
            if (currentLineIndex == lineArray.Length)
            {
                currentChar = '~';
            }
            else
            {
                lineBuffer = lineArray[currentLineIndex];
                currentLineIndex++;
                currentChar = ' ';
                curCharIndex = 0;
                lineBufferLength = lineBuffer.Length;
            }
            GetSymbol();
        }

        void IfState(int level,string blockName)
        {
            GetSymbol();
            Condition(level, blockName);
            if (currentSymbol == Symbol.BeginSym)
            {
                GetSymbol();
            }
            else
            {
                PrintError(ErrorCase.NeedBeginSym);
                isError = true;
                return;
            }
            int jpcCodeIndex = curCodeIndex;
            GenerateCode(InstructionType.jpc, 0, 0);
            Statement(true, level, blockName);
            codeList[jpcCodeIndex].a = curCodeIndex;
            if (currentSymbol == Symbol.ElseSym)
            {
                GetSymbol();
                if (currentSymbol == Symbol.BeginSym)
                {
                    GetSymbol();
                }
                else
                {
                    PrintError(ErrorCase.NeedBeginSym);
                    isError = true;
                    return;

                }

                int jmpCodeIndex = curCodeIndex;
                GenerateCode(InstructionType.jmp, 0, 0);
                codeList[jpcCodeIndex].a = curCodeIndex;
                Statement(true, level,blockName);
                codeList[jmpCodeIndex].a = curCodeIndex;

            }
        }

        void WhileState(int level, string blockName)
        {
            int jmpCodeAddress = curCodeIndex;
            GetSymbol();

            Condition(level, blockName);


            int jpcCodeIndex = curCodeIndex;
            GenerateCode(InstructionType.jpc, 0, 0);

            if (currentSymbol == Symbol.BeginSym)
            {
                GetSymbol();
            }
            else
            {
                PrintError(ErrorCase.NeedBeginSym);
                isError = true;
                return;
            }

            Statement(true, level, blockName);
            GenerateCode(InstructionType.jmp, 0, jmpCodeAddress);
            codeList[jpcCodeIndex].a = curCodeIndex;

        }

        void ReadState(int level,string blockName)
        {
            GetSymbol();
            if (currentSymbol == Symbol.Lparen)
            {
                GetSymbol();
                if (currentSymbol == Symbol.Ident)
                {
                    DefineUnit unit = GetDefineUnit(currentIdent, blockName);

                    if (isError)
                    {
                        return;
                    }
                    GenerateCode(InstructionType.opr, 0, 16);
                    GenerateCode(InstructionType.sto, level - unit.level, unit.address);
                }
                else
                {
                    PrintError(ErrorCase.NeedIdent);
                    isError = true;
                    return;
                }
                GetSymbol();

                if (currentSymbol == Symbol.Rparen)
                {
                    GetSymbol();
                }
                else
                {
                    PrintError(ErrorCase.NeedRparen);
                    isError = true;
                    return;
                }
            }
            else
            {
                PrintError(ErrorCase.NeedLparen);
                isError = true;
                return;
            }
        }

        void PrintState(int level,string blockName)
        {
            GetSymbol();
            if (currentSymbol == Symbol.Lparen)
            {
                GetSymbol();
                if (currentSymbol == Symbol.Ident)
                {
                    Exprission(level, blockName);
                    GenerateCode(InstructionType.opr, 0, 14);
                    GenerateCode(InstructionType.opr, 0, 15);
                }
               
                GetSymbol();

                if (currentSymbol == Symbol.Rparen)
                {
                    GetSymbol();
                }
                
            }
            else
            {
                PrintError(ErrorCase.NeedLparen);
                isError = true;
                return;
            }
        }

        void AssignState(int level, string blockName)
        {
            DefineUnit unit = GetDefineUnit(currentIdent, blockName);

            if (isError)
            {
                return;
            }

            if (unit.type == DefineType.Variable)
            {
                GetSymbol();
                if (currentSymbol == Symbol.Becomes)
                {
                    GetSymbol();

                    if (currentSymbol == Symbol.CallSym)
                    {
                        CallState(level, blockName);
                    }
                    else
                    {
                        Exprission(level, blockName);
                    }
                    GenerateCode(InstructionType.sto, level - unit.level, unit.address);
                }
                else
                {
                    PrintError(ErrorCase.NeedBecomes);
                    isError = true;
                    return;
                }
            }
            else
            {
                PrintError(ErrorCase.NeedVariable);
                isError = true;
                return;
            }
        }

        void CallState(int level, string blockName)
        {
            GetSymbol();

            if (currentSymbol == Symbol.Ident)
            {
                DefineUnit unit = GetDefineUnit(currentIdent, blockName);

                if (isError)
                {
                    return;
                }

                GenerateCode(InstructionType.cal, level - unit.level, unit.address);
                GetSymbol();
                GetSymbol();
                GetSymbol();
            }
            else
            {
                PrintError(ErrorCase.NeedIdent);
                isError = true;
                return;
            }

        }

        void ForState(int level,string blockName)
        {
            GetSymbol();
            if (currentSymbol == Symbol.Ident)
            {
                DefineUnit unit = GetDefineUnit(currentIdent,blockName);

                if (isError)
                {
                    return;
                }

                //GenerateCode(InstructionType.cal, level - unit.level, unit.address);
                GetSymbol();

                if (currentSymbol == Symbol.InSym)
                {
                    GetSymbol();
                }
                else
                {
                    PrintError(ErrorCase.NeedInSym);
                    isError = true;
                    return;
                }


                if (currentSymbol == Symbol.Ident)
                {
                    DefineUnit startCircleUnit = GetDefineUnit(currentIdent, blockName);

                    if (isError)
                    {
                        return;
                    }

                    GenerateCode(InstructionType.lod, level - startCircleUnit.level, startCircleUnit.address);
                    GetSymbol();
                }
                else
                {
                    GenerateCode(InstructionType.lit, 0, currentNumber);
                    GetSymbol();
                }

                GenerateCode(InstructionType.sto, level - unit.level, unit.address);

                int jmpCodeAddress = curCodeIndex;

                if (currentSymbol == Symbol.Range)
                {
                    GenerateCode(InstructionType.lod, level - unit.level, unit.address);
                    GetSymbol();
                }
                else
                {
                    PrintError(ErrorCase.NeedRangeSym);
                    isError = true;
                    return;
                }

                if (currentSymbol == Symbol.Ident)
                {
                    DefineUnit endCircleUnit = GetDefineUnit(currentIdent, blockName);

                    if (isError)
                    {
                        return;
                    }

                    GenerateCode(InstructionType.lod, level - endCircleUnit.level, endCircleUnit.address);
                    GetSymbol();
                }
                else
                {
                    GenerateCode(InstructionType.lit, 0, currentNumber);
                    GetSymbol();
                }
                GenerateCode(InstructionType.opr, 0, 13);
                int jpcCodeIndex = curCodeIndex;
                GenerateCode(InstructionType.jpc, 0, 0);

                if (currentSymbol == Symbol.BeginSym)
                {
                    GetSymbol();
                    Statement(true, level, blockName);
                    GenerateCode(InstructionType.lod, level - unit.level, unit.address);
                    GenerateCode(InstructionType.lit, 0, 1);
                    GenerateCode(InstructionType.opr, 0, 2);
                    GenerateCode(InstructionType.sto, level - unit.level, unit.address);
                    GenerateCode(InstructionType.jmp, 0, jmpCodeAddress);
                    codeList[jpcCodeIndex].a = curCodeIndex;

                }
                else
                {
                    PrintError(ErrorCase.NeedBeginSym);
                    isError = true;
                    return;
                }

            }
            else
            {
                PrintError(ErrorCase.NeedIdent);
                isError = true;
                return;
            }
        }

        void Condition(int level,string blockName)
        {
            Exprission(level, blockName);

            //to do error
            Symbol sign = currentSymbol;
            GetSymbol();
            Exprission(level, blockName);
            switch (sign)
            {
                case Symbol.Eql:
                    GenerateCode(InstructionType.opr, 0, 8);
                    break;
                case Symbol.Neq:
                    GenerateCode(InstructionType.opr, 0, 9);
                    break;
                case Symbol.Lss:
                    GenerateCode(InstructionType.opr, 0, 10);
                    break;
                case Symbol.Geq:
                    GenerateCode(InstructionType.opr, 0, 11);
                    break;
                case Symbol.Gtr:
                    GenerateCode(InstructionType.opr, 0, 12);
                    break;
                case Symbol.Leq:
                    GenerateCode(InstructionType.opr, 0, 13);
                    break;
                default:
                    PrintError(ErrorCase.NeedCompare);
                    isError = true;
                    //return;
                    break;
            }
        }

        void Exprission(int level,string blockName)
        {
            Symbol sign = Symbol.Add;

            if (currentSymbol == Symbol.Add || currentSymbol == Symbol.Sub)
            {
                sign = currentSymbol;
                GetSymbol();
            }

            Term(level, blockName);

            if (sign == Symbol.Sub)
            {
                GenerateCode(InstructionType.opr, 0, 1);
            }

            while (currentSymbol == Symbol.Add || currentSymbol == Symbol.Sub)
            {
                sign = currentSymbol;

                GetSymbol();
                Term(level, blockName);
                if (sign == Symbol.Add)
                {
                    GenerateCode(InstructionType.opr, 0, 2);

                }
                else
                {
                    GenerateCode(InstructionType.opr, 0, 3);
                }

                if (isError)
                {
                    return;
                }

            }

        }

        void Term(int level,string blockName)
        {
            Symbol sign = Symbol.Add;

            Factor(level, blockName);
            while (currentSymbol == Symbol.Mul || currentSymbol == Symbol.Div || currentSymbol == Symbol.Mod)
            {
                sign = currentSymbol;
                GetSymbol();
                Factor(level, blockName);

                if (sign == Symbol.Mul)
                {
                    GenerateCode(InstructionType.opr, 0, 4);
                }
                else if (sign == Symbol.Div)
                {
                    GenerateCode(InstructionType.opr, 0, 5);
                }
                else
                {
                    GenerateCode(InstructionType.opr, 0, 17);
                }

                if (isError)
                {
                    return;
                }
            }
        }

        void Factor(int level, string blockName)
        {
            switch (currentSymbol)
            {
                case Symbol.Ident:
                    DefineUnit unit = GetDefineUnit(currentIdent, blockName);

                    if (isError)
                    {
                        return;
                    }

                    switch (unit.type)
                    {
                        case DefineType.Constant:
                            GenerateCode(InstructionType.lit, 0, unit.value);
                            break;
                        case DefineType.Variable:
                            GenerateCode(InstructionType.lod, level - unit.level, unit.address);
                            break;
                        case DefineType.Procedure:
                            //It's Wrong
                            break;
                    }
                    GetSymbol();
                    break;
                case Symbol.Number:

                    GenerateCode(InstructionType.lit, 0, currentNumber);
                    GetSymbol();
                    break;
                case Symbol.Lparen:
                    GetSymbol();
                    Exprission(level, blockName);

                    if (currentSymbol == Symbol.Rparen)
                    {
                        GetSymbol();
                    }

                    break;
                default :
                    PrintError(ErrorCase.NeedFactor);
                    isError = true;
                    
                    break;
            }
        }

        DefineUnit GetDefineUnit(string identName,string blockName)
        {
            DefineUnit unit = null;
            for (int i = defineList.Count-1; i >= 0; i--)
            {
                if (defineList[i].name == identName)
                {
                    if (defineList[i].funcName == blockName)
                    {
                        unit = defineList[i];
                        break;
                    }
                    
                    if (defineList[i].funcName == "Global")
                    {
                        unit =defineList[i];
                        break;
                    }
                    
                }
            }

                // = defineList.Find(x => x.name == identName);
            if (unit == null)
            {
                PrintError(ErrorCase.Undefine);
                isError = true;

            }
            return unit;

        }


    }
}
