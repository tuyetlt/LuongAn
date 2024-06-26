using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;


/// <summary>
/// Summary description for TextChanger
/// </summary>
public class TextChanger
{
    public TextChanger()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected static string GetRootUrl()
    {
        return C.ROOT_URL;
    }


    public static string Rewrite(string control, string friendlyUrl)
    {
        return Rewrite(control, friendlyUrl, string.Empty);
    }

    public static string FullUrl(object FriendlyUrl)
    {
        string url = ConvertUtility.ToString(FriendlyUrl).ToLower();
        string retUrl = string.Format("{0}/{1}/", GetRootUrl(), url);
        return retUrl;
    }

    public static string Rewrite(string control, string friendlyUrl, string categoryUrl)
    {
        string retUrl = string.Empty;
        if (control == "article")
            GetLinkRewrite_Article(categoryUrl, friendlyUrl);
        if (control == "product")
            GetLinkRewrite_Products(categoryUrl, friendlyUrl);

        return retUrl;
    }


    public static string GetLinkRewrite_Article(string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }

    public static string GetLinkRewrite_Article(string catrul, string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }

    public static string GetLinkRewrite_CategoryArticle(string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }

    public static string GetLinkRewrite_TagCloud(string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }

    public static string GetLinkRewrite_CategoriesAttribute(string Cat, string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }

    public static string GetLinkRewrite_Products(object category, object FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }



    public static string GetLinkRewrite_Category(string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }



    public static string GetLinkRewrite_Menu(string FriendlyUrl)
    {
            return FullUrl(FriendlyUrl);
    }




    static string[] aUniks = new string[] {"aáàảãạâấầẩẫậăắằẳẵặ","dđ","eéèẻẽẹêếềểễệ","iíìỉĩị","oóòỏõọôốồổỗộơớờởỡợ","yýỳỷỹỵ","uúùủũụưứừửữự",
				   "AÁẢÃẠÂẤẨẪẬĂẮẰẲẴẶ","DĐ","EÉÈẺẼẸÊẾỀỂỄỆ","IÍÌỈĨỊ","OÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ","YÝỲỶỸỴ","UÚÙỦŨỤƯỨỪỬỮỰ",
				   @"_ -&?~!@#$%^*():'""/\+=.,;<>[]{}"};

    public static string Translate(string str, string hyphen = " ") //Kỷ niệm câu hỏi đầu tiên ChatGPT 3/2023
    {
        str = str.Replace("Đ", "D");
        str = str.Replace("đ", "d");

        // Remove Vietnamese signs
        string unsignedStr = string.Concat(str.Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
            .Trim();

        // Replace non-letter, non-digit characters with hyphen
        unsignedStr = Regex.Replace(unsignedStr, @"[^a-zA-Z0-9\s]", hyphen, RegexOptions.Compiled);

        // Remove any leading, trailing, or repeated hyphens
        string urlFriendlyStr = Regex.Replace(unsignedStr, @"[\s" + hyphen + "]+", hyphen).Trim(hyphen.ToCharArray());

        return urlFriendlyStr;
    }


    public static string NiceCut(string input, int length)
    {
        const string endS = " .,;!";
        if (string.IsNullOrEmpty(input) || input.Length <= length)
            return input;
        else
        {
            string s = input.Substring(0, length);
            if (endS.Contains(input[length].ToString()))
                return s.Trim();
            else
            {
                int i = length - 1;
                while (!endS.Contains(s[i].ToString()))
                {
                    i--;
                }
                return s.Remove(i);

            }
        }
    }

}

