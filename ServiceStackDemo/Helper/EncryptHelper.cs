using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public static class EncryptHelper
{
    public static string Md5(this string str)
    {
        var bytes = Encoding.Default.GetBytes(str);
        var data = MD5.Create().ComputeHash(bytes);
        var sb = new StringBuilder();
        foreach (var t in data)
        {
            sb.Append(t.ToString("X2"));
        }
        return sb.ToString();
    }

    public static string Sha1(this string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        var data = SHA1.Create().ComputeHash(bytes);
        var sb = new StringBuilder();
        foreach (var t in data)
        {
            sb.Append(t.ToString("X2"));
        }
        return sb.ToString();
    }

}
