using System.Reflection;
using System.Text;

namespace IceCodeTest;

public class IceTextMatch
{
    // Note: Don't use : String::split(), String::indexOf(), String::lastIndexOf(), String::substring(), Regex.Match(), etc...

    public int FirstIndexOf(string str, string subStr, int startPos = 0)
    {
        subStr = subStr.ToLower();
        string lStr = str.ToLower();
        int subStrLen = subStr.Length;
        int strLen = lStr.Length;
        if(subStrLen == 0 || subStrLen > strLen)
        {
            return -1;
        }
        
        // seek first character in str that matches first character in subStr
        // if found , position (position stoed in i) , then compare remainer of subStr characters to determine
        //  - if all corresponding characters in str match, if so return stored position (reutn i)
        //  - if corresponding characters do not match - go back to step 1 at positoin (i+1)
        // if no match founrd - return -1

        int lastPosToSearch = strLen - subStrLen;
   
        for(int i = startPos ; i < lastPosToSearch ; i++) 
        {
            // check if first character of subStr and lStr for match
            if(lStr[i] == subStr[0])
            {
                // first character matches, check the remained of the subStr
                int j = 1;

                while( j < subStrLen && lStr[i + j] == subStr[j] )
                {
                    j++;
                } 
                
                if(j >= subStrLen)
                {
                    return i;
                }
            }
        }

        // no match found
        return -1;
    }

    // SubString: Currently only used to manage command line arguments when supplying a file name with "-f <filename>"
    public string SubString(string str, int startPos, int subStrLen = -1)
    {
        int sLen = str.Length;
        if(startPos < 0 || startPos >= sLen)
        {
            return "";
        }

        // adding subStrLen for completion, bt this is not used in the Code Test (always defaults to -1)
        int endPos = (subStrLen != -1) ? Math.Min(startPos + subStrLen, sLen) : sLen; 
       
        StringBuilder sb = new StringBuilder(endPos - startPos); // supply init capacity to void calls to reallocaton
        for(int n = startPos ; n < endPos; n++)
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
        int thisPos = 0;
        
        if((thisPos = FirstIndexOf(str, subStr, thisPos)) != -1)
        {
            sb.Append($"{thisPos+1}");       // using +1 as the Code Test is 1-based and not 0-based

            thisPos += subStrLen; 
            while((pos = FirstIndexOf(str, subStr, thisPos)) != -1)
            {
                sb.Append($", {pos+1}");    // using +1 as the Code Test is 1-based and not 0-based
                thisPos = (pos+subStrLen);
            }
            return sb.ToString();
        }

        return "<no matches>";
    }

}