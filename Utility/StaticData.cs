using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_of_c.Utility
{
    public static class StaticData
    {
        public static char[] Numbers = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public static char[] Letters = new[] { 'A' ,'a','B','b','C','c','D','d','E','e','F','f','G','g','H','h','I','i','J','j','K','k','L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s','T','t','U','u','V','v','W','w','X','x','Y','y','Z','z' };
        public static char[] Punctuations = new[] { '}', '{', ')', '(', ']', '[', ';', ',', '.' };
        public static Dictionary<string, string> Operators = new Dictionary<string, string>()
        {
            {"=","ASSIGN" },
            {"+=","ADD_ASSIGN" },
            {"-=","SUB_ASSIGN" },
            {"*=","MUL_ASSIGN" },
            {"/=","DIV_ASSIGN" },
            {"++","INC" },
            {"--","DEC" },
            {"+","ADD" },
            {"-","SUB" },
            {"*","MUL" },
            {"/","DIV" },
            {"==","EQ" },
            {"!=","NE" },
            {"<","LT" },
            {">","GT" },
            {"<=","LE" },
            {">=","GE" },
            {"!","NOT" },
            {"&&","AND" },
            {"||","OR" },
        };
        public static string[] KeyWords = new[]
        {
            "auto",
            "break",
            "case",
            "char",
            "const",
            "continue",
            "default",
            "do",
            "double",
            "else",
            "enum",
            "extern",
            "float",
            "for",
            "goto",
            "if",
            "int",
            "long",
            "register",
            "return",
            "short",
            "signed",
            "sizeof",
            "static",
            "struct",
            "switch",
            "typedef",
            "union",
            "unsigned",
            "void",
            "volatile",
            "while"
        };
    }
}
