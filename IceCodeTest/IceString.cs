using System.Reflection;
using System.Text;

namespace IceCodeTest;

public class IceString
{
    // DOn't use : String::split(), String::indexOf(), String::lastIndexOf(), String::substring(), Regex.Match(), etc...


    public int FirstIndexOf(string str, string subStr)
    {
        subStr = subStr.ToLower();
        string lStr = str.ToLower();
        int subStrLen = subStr.Length;
        if(subStrLen == 0 || subStrLen > lStr.Length)
        {
            //throw String.Exception($"IndexOf: SubString must be in the length range of 1-{Str.Length}");
            return -1;
        }
        
        // seek first character in Str that matches first character in subStr
        // if found , store position and compare remainer of subStr characters to determine
        //  - if all corresponding characters in Str match, if so return stored position
        //  - if all corresponding characters do not match - got step 1 at positoin (stored-pos+1)
        // if no match founrd - return -1

        int lastStartPos = 0;
        int posOfLastOccurOfFirstChar = lStr.Length-subStr.Length+1;
   
        int i = 0;
        for( ; i < posOfLastOccurOfFirstChar ; i++) 
        {
            if(lStr[i] == subStr[0]) // check first character of subStr
            {
                lastStartPos = i;
                int j = 1;

                while( j < subStrLen && lStr[lastStartPos+j] == subStr[j] ) j++;
                
                if(j < subStrLen)
                {
                    i = lastStartPos+1;
                }
                else
                {
                    return lastStartPos;
                }
            }
        }

        return -1;
    }

    public string SubString(string str, int startPos, int endPos = -1)
    {
        int sLen = str.Length;
        if(startPos < 0 || startPos >= sLen)
        {
            return "";
        }

        if(endPos != -1)
        {
            sLen = (endPos < sLen) ? endPos+1 : sLen;
        }
       StringBuilder sb = new StringBuilder();
       for(int n = startPos ; n < sLen; n++)
       {
            sb.Append(str[n]);
       }

       return sb.ToString();
    }


    public string IndexOfAll(string str, string subStr)
    {
        StringBuilder sb = new StringBuilder();
        int subStrLen = subStr.Length;

        int pos;
        int thisPos;
        if((thisPos = FirstIndexOf(str, subStr)) != -1)
        {
            sb.Append($"{thisPos+1}");              // using +1 as the Code Test appears to be 1 based and not 0 (zero) based

            thisPos += subStrLen; 
            while((pos = FirstIndexOf(SubString(str, thisPos), subStr)) != -1)
            {
                sb.Append($", {thisPos+pos+1}");    // using +1 as the Code Test appears to be 1 based and not 0 (zero) based
                thisPos += (pos+subStrLen);
            }
            return sb.ToString();
        }

        return "<no matches>";
    }
}