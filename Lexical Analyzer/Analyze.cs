using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compiler_of_c.Helpers;
using compiler_of_c.Utility;
namespace compiler_of_c.Lexical_Analyzer
{
    class Analyze
    {
        public List<State> expectedStates { get; set; }
        Symbol_Table.Symbol_Table table { get; set; }
        List<State> realState { get; set; }
        bool IsGenerated = false;
        public async void Start(string txt, Label label1)
        {
            //**************************
            // important " should be \"
            //**************************

            // initialize mikone stataye tarif shodaro
            States.InitialazeStates();
            // aval state miad ru start
            State firststate = States.S.First(e => e.Name == "Start");
            this.realState = new List<State>();
            realState.Add(firststate);

            this.expectedStates = new List<State>();

            Buffer buffer = new Buffer();

            this.table = new Symbol_Table.Symbol_Table();
            foreach (char c in txt)
            {
                label1.Text += c.ToString();
                if (table.IsEmpty())
                {
                    if (!this.IsGenerated)
                        GenerateExpected();
                    buffer.Add(c);

                    State newstate = null;
                    try
                    {
                        newstate = MatchToExpected(buffer);
                        if (newstate != null)
                        {
                            this.IsGenerated = false;
                            this.realState.Add(newstate);
                        }
                    }
                    catch (WrongStateError)
                    {
                        buffer.ClearBuffer();
                        this.IsGenerated = false;
                    }
                }

            }
        }

        public void GenerateExpected()
        {
            this.IsGenerated = true;
            this.expectedStates.Clear();


            if (this.table.IsEmpty())
            {
                // age khali bashe khob mitune ba keyword ya if shoru she
                if (this.realState.Where(e => e.Name == "KeyWord").FirstOrDefault() == null)
                {
                    this.expectedStates.Add(States.S.Where(e => e.Name == "KeyWord").FirstOrDefault());
                    this.expectedStates.Add(States.S.Where(e => e.Name == "Condition").FirstOrDefault());
                }

                // age keyword umade bashe khob badesh identifier miad
                else if (this.realState.Where(e => e.Name == "KeyWord").FirstOrDefault() != null)
                {
                    this.expectedStates.Add(States.S.Where(e => e.Name == "Identifier").FirstOrDefault());
                }

                //
                else if (this.realState.Where(e => e.Name == "Condition").FirstOrDefault() != null)
                {
                    this.expectedStates.Add(States.S.Where(e => e.Name == "punctuation").FirstOrDefault());
                }

                else if (this.realState.Where(e => e.Name == "Condition").FirstOrDefault() != null &&
                    this.realState.Where(e => e == States.S.First(n => n.Name == "punctuation")).FirstOrDefault() != null)
                {
                    this.expectedStates.Add(States.S.Where(e => e.Name == "Identifier").FirstOrDefault());
                    this.expectedStates.Add(States.S.Where(e => e.Name == "TrueFalse").FirstOrDefault());
                }

                else if (this.realState.Where(e => e.Name == "TrueFalse").FirstOrDefault() != null &&
                    this.realState.Where(e => e == States.S.First(n => n.Name == "punctuation")).FirstOrDefault() != null)
                {
                    this.expectedStates.Add(States.S.Where(e => e.Name == "Identifier").FirstOrDefault());
                    this.expectedStates.Add(States.S.Where(e => e.Name == "Not Yet Identified").FirstOrDefault());
                }
            }
            else if (!this.table.IsEmpty())
            {
                if(realState.Last().Name == "Done")
                {
                    if (this.realState.Where(e => e.Name == "KeyWord").FirstOrDefault() == null)
                    {
                        this.expectedStates.Add(States.S.Where(e => e.Name == "KeyWord").FirstOrDefault());
                        this.expectedStates.Add(States.S.Where(e => e.Name == "Condition").FirstOrDefault());
                    }
                }
            }
        }

        public State MatchToExpected(Buffer buffer)
        {
            if (this.expectedStates.Count == 0)
            {
                return null;
            }
            else
            {
                string bufferstring = buffer.GetString().Trim();

                if (string.IsNullOrEmpty(bufferstring))
                {
                    throw new Exception("method: match to expected \n else \n bufferstring is null or empty");
                }
                foreach (State state in this.expectedStates)
                {
                    if (state.Name == WhatIsIt(bufferstring))
                    {
                        state.Value = bufferstring;
                        if(WhatToDo(state, bufferstring))
                            return state;
                        else
                        {
                            throw new WrongStateError("at match to expected => else => foreach => if => else");
                        }
                    }
                }

                return null;
            }
        }

        public string WhatIsIt(string bufferstring)
        {
            var keyword = StaticData.KeyWords.Contains(bufferstring);
            if (keyword)
            {
                if (bufferstring == "if" || bufferstring == "else")
                {
                    return "Condition";
                }
                return "KeyWord";
            }
            var identifier = IsIdentifier(bufferstring);
            if(identifier)
            {
                return "Identifier";
            }
            return "";
        }

        public static bool IsIdentifier(string bufferstring)
        {
            int result;
            char[] chararr = bufferstring.ToCharArray();

            // age ba ye adad shoru shode khob identifier nis
            if (int.TryParse(chararr.First().ToString(), out result))
            {
                return false;
            }
            var newcharrarr = chararr.Where(e => StaticData.Letters.Contains(e) && StaticData.Numbers.Contains(e) || e == '_' ? true : false).ToList();

            // yani inke ye chizi qeire adad va horufe alephba tushe
            if (newcharrarr.Count != chararr.Length)
            {
                return false;
            }

            return true;
        }

        public bool WhatToDo(State state, string bufferstring)
        {
            if(state.Name == "Identifier")
            {
                table.Add(bufferstring, Type.GetType(realState.Last().Value), bufferstring);
                return true;
            }
        }
    }
}
