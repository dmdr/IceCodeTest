using System.Text;

namespace IceCodeTest;

/// <summary>
/// Class <c>IceTextMatch</c> for the functionally for the code test problem
///  This functionallity could also be added as extension methods into an existing pre-build class
/// </summary>
public class IceTextMatch
{
    /// <summary>
    /// prevent IceTextMatch from being instantiated
    /// </summary>
    private IceTextMatch() { }

    /// <summary>
    /// Method <c>FirstIndexOf</c> return zero-based position of subStr in str starting from startPos.
    /// Returns -1 is not match found
    /// </summary>

    public static int FirstIndexOf(string str, string subStr, int startPos = 0)
    {
        subStr = subStr.ToLower();
        string lStr = str.ToLower();
        int subStrLen = subStr.Length;
        int strLen = lStr.Length;
        if (subStrLen == 0 || subStrLen > strLen)
        {
            return -1;
        }

        // Seek first character in str that matches first character in subStr
        // if found, (position stored in i), then compare remainer of subStr characters to determine ...
        //  - if all corresponding characters in str match, then return stored position (return i)
        //  - if corresponding characters do not match - then continue inital caracter search.
        // if no match founrd - return -1

        int lastPosToSearch = strLen - subStrLen;

        for (int i = startPos; i <= lastPosToSearch; i++)
        {
            // check if first character of subStr and lStr for match
            if (lStr[i] == subStr[0])
            {
                // first character matches, check the remained of the subStr
                int j = 1;

                while (j < subStrLen && lStr[i + j] == subStr[j])
                {
                    j++;
                }

                if (j >= subStrLen)
                {
                    return i;
                }
            }
        }

        // no match found
        return -1;
    }

    /// <summary>
    /// Method <c>SubString</c> return substring of str starting at startPos and optioanlly ending at subStrLen
    ///  subStrLen will defaults to -1 indicating it will return to the end of Str
    ///  Note: Currently only used to manage command line arguments when supplying a file name with "-f <filename>"
    /// </summary>

    public static string SubString(string str, int startPos, int subStrLen = -1)
    {
        int sLen = str.Length;
        if (startPos < 0 || startPos >= sLen)
        {
            return "";
        }

        // adding (optional) subStrLen for completion (defaults to -1)
        int endPos = (subStrLen != -1) ? Math.Min(startPos + subStrLen, sLen) : sLen;

        StringBuilder sb = new StringBuilder(endPos - startPos); // supply init capacity to void calls to reallocaton
        for (int n = startPos; n < endPos; n++)
        {
            sb.Append(str[n]);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Method <c>IndexOfAll</c> return a string that contains all the (1-based) positions of subStr in str 
    /// </summary>
    public static string IndexOfAll(string str, string subStr)
    {
        StringBuilder sb = new StringBuilder();
        int subStrLen = subStr.Length;
        int pos;
        int thisPos = 0;

        if ((thisPos = FirstIndexOf(str, subStr, thisPos)) != -1)
        {
            sb.Append($"{thisPos + 1}");       // using +1 as the Code Test is 1-based and not 0-based

            thisPos += subStrLen;
            while ((pos = FirstIndexOf(str, subStr, thisPos)) != -1)
            {
                sb.Append($", {pos + 1}");    // using +1 as the Code Test is 1-based and not 0-based
                thisPos = (pos + subStrLen);
            }
            return sb.ToString();
        }

        return "<no matches>";
    }

    /// <summary>
    /// Method <c>Split</c> return a string array after splitting str by splitChar 
    /// </summary>
    public static string[] Split(string str, char splitChar = ' ')
    {
        var res = new List<string>();
        int startPos = 0;
        bool bInSplit = true;   // true to handle leading split characters
        int idx = 0;
        for (; idx < str.Length; idx++)
        {
            if (str[idx] == splitChar)
            {
                if (!bInSplit) // skip multiple splitChar's
                {
                    res.Add(IceTextMatch.SubString(str, startPos, idx - startPos));
                    bInSplit = true;
                }
            }
            else if (bInSplit)
            {
                bInSplit = false;
                startPos = idx;
            }
        }
        if (!bInSplit && (idx > startPos))
        {
            res.Add(IceTextMatch.SubString(str, startPos, idx));
        }

        return res.ToArray();
    }
}